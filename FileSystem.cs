using System;
using System.CodeDom;
using System.Diagnostics;

namespace BandaidLauncher
{
    public class FileSystem
    {
        public FileSystem()
        {
        }

        public static string GetDriveBase()
        {
            string driveBase = Path.GetPathRoot(System.Diagnostics.Process.GetCurrentProcess().MainModule?.FileName) ?? throw new Exception("Unable to get drivebase");

            // Assume C is debugging
            if (driveBase == "C:\\") return "V:\\";
            return driveBase;
        }

        public static string GetGameDir()
        {
            return Path.Combine(GetDriveBase(), "Games");
        }

        public static string GetDLLDir()
        {
            return Path.Combine(GetDriveBase(), "DLLs");
        }

        public static string GetMyGamesDir()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "My Games");
        }

        public static string GetLauncherDir()
        {
            return Path.Combine(GetDriveBase(), "Launcher");
        }

        public static string GetSyncDir(string subdir) {
            return Path.Combine(GetLauncherDir(), "Sync", subdir);
        }

        public static string ExpandZanyPath(string path)
        {
            path = path.Replace("%documents%", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            return path;
        }

        public static void OpenMyGamesSymlink()
        {
            return;
            string gamesPath = GetMyGamesDir();

            if (Directory.Exists(gamesPath))
            {
                if (System.Diagnostics.Debugger.IsAttached) return;

                MessageBox.Show(
                    "My Games directory already exists, not making symlink. Some games may write save data to primary disk!",
                    "Trouble is brewing...",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // TODO: https://stackoverflow.com/questions/1400549/in-net-how-do-i-create-a-junction-in-ntfs-as-opposed-to-a-symlink
            File.CreateSymbolicLink(gamesPath, Path.Combine(GetGameDir(), "MyGameData"));
        }
    }
}