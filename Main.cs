using System.Diagnostics;

// https://github.com/citronneur/detours.net (?)

namespace BandaidLauncher
{
    public partial class Main : Form
    {
        private Game chosenGame;

        public Main()
        {
            InitializeComponent();

            gameList.Items.Clear();
            IndexGames();
            chosenGame = (Game)gameList.Items[0];

            dllList.Items.Clear();
            IndexDLLs();

            LoadSyncTargets();

            FileSystem.OpenMyGamesSymlink();
        }

        private void IndexGames()
        {
            foreach (string file in Directory.EnumerateFiles(
                FileSystem.GetGameDir(),
                "config.ban", SearchOption.AllDirectories
            ))
            {
                gameList.Items.Add(new Game(file, chosenGameIcon.Size.Height));
            }
        }

        private void IndexDLLs()
        {
            Debug.WriteLine(Directory.GetDirectories(FileSystem.GetDLLDir()));
            foreach (string directory in Directory.GetDirectories(FileSystem.GetDLLDir()))
            {
                dllList.Items.Add(Path.GetFileName(directory));
            }
        }

        private void LoadSyncTargets()
        {
            SyncTarget target = new SyncTarget("%documents%\\My Games", FileSystem.GetSyncDir("My Games"));
            int index = syncListBox.Items.Add(target);
            syncListBox.SetItemChecked(index, target.IsEnabled());
        }

        private void Main_Load(object sender, EventArgs e)
        {
            gameList.SelectedIndex = 0;
        }

        private void gameList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gameList.SelectedItem is not Game maybeGame) return;
            chosenGame = maybeGame;
            chosenGameName.Text = chosenGame.name;
            chosenGameIcon.Image = chosenGame.bitmapIcon;
            chosenGamePath.Text = chosenGame.path;
            chosenGameBitness.Text = chosenGame.GetBinaryType().ToString();

            // Load visual checked from game object state
            for (int i = 0; i < dllList.Items.Count; i++)
            {
                dllList.SetItemChecked(i, chosenGame.dependencyPaths.Contains(dllList.Items[i]));
            }
        }

        private void chosenGamePath_Click(object sender, EventArgs e)
        {
            // https://stackoverflow.com/a/9904834
            string args = string.Format("/e, /select, \"{0}\"", chosenGame.path);

            ProcessStartInfo info = new ProcessStartInfo
            {
                FileName = "explorer",
                Arguments = args
            };
            Process.Start(info);
        }
        private void playButton_Click(object sender, EventArgs e)
        {
            chosenGame.Launch();
        }

        private void dllList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string? depName = dllList.Items[e.Index].ToString();
            if (depName == null) return;

            bool didAnything;
            if (e.NewValue == CheckState.Checked)
            {
                didAnything = chosenGame.dependencyPaths.Add(depName);
            }
            else
            {
                didAnything = chosenGame.dependencyPaths.Remove(depName);
            }

            if (didAnything) { chosenGame.TaintConfig(); }
        }

        private void autosaveTimer_Tick(object sender, EventArgs e)
        {
            foreach (Game game in gameList.Items)
            {
                if (!game.ShouldCommit()) continue;
                new Thread(() => game.maybeCommitToConfig()).Start();
            }
        }

        private void syncButton_Click(object sender, EventArgs e)
        {
            foreach (SyncTarget syncTarget in syncListBox.Items)
            {
                syncTarget.Sync();
            }
        }
    }
}