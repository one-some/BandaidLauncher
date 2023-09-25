namespace BandaidLauncher
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            gameList = new ListBox();
            chosenGameIcon = new PictureBox();
            chosenGameName = new Label();
            playButton = new Button();
            chosenGamePath = new Label();
            dllList = new CheckedListBox();
            dllLabel = new Label();
            chosenGameBitness = new Label();
            autosaveTimer = new System.Windows.Forms.Timer(components);
            mainTabControl = new TabControl();
            tabPageGames = new TabPage();
            syncTabPage = new TabPage();
            label2 = new Label();
            numericUpDown1 = new NumericUpDown();
            checkBox1 = new CheckBox();
            syncListBox = new CheckedListBox();
            label1 = new Label();
            syncButton = new Button();
            ((System.ComponentModel.ISupportInitialize)chosenGameIcon).BeginInit();
            mainTabControl.SuspendLayout();
            tabPageGames.SuspendLayout();
            syncTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // gameList
            // 
            gameList.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            gameList.FormattingEnabled = true;
            gameList.ItemHeight = 21;
            gameList.Items.AddRange(new object[] { "Bob", "John", "Markus" });
            gameList.Location = new Point(6, 6);
            gameList.Name = "gameList";
            gameList.Size = new Size(402, 298);
            gameList.Sorted = true;
            gameList.TabIndex = 0;
            gameList.SelectedIndexChanged += gameList_SelectedIndexChanged;
            // 
            // chosenGameIcon
            // 
            chosenGameIcon.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            chosenGameIcon.Location = new Point(6, 315);
            chosenGameIcon.Name = "chosenGameIcon";
            chosenGameIcon.Size = new Size(64, 64);
            chosenGameIcon.TabIndex = 1;
            chosenGameIcon.TabStop = false;
            // 
            // chosenGameName
            // 
            chosenGameName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            chosenGameName.AutoSize = true;
            chosenGameName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            chosenGameName.Location = new Point(76, 315);
            chosenGameName.Name = "chosenGameName";
            chosenGameName.Size = new Size(53, 15);
            chosenGameName.TabIndex = 2;
            chosenGameName.Text = "Oblivion";
            // 
            // playButton
            // 
            playButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            playButton.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            playButton.Location = new Point(456, 318);
            playButton.Name = "playButton";
            playButton.Size = new Size(84, 64);
            playButton.TabIndex = 3;
            playButton.Text = "Play";
            playButton.UseVisualStyleBackColor = false;
            playButton.Click += playButton_Click;
            // 
            // chosenGamePath
            // 
            chosenGamePath.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            chosenGamePath.AutoSize = true;
            chosenGamePath.BackColor = Color.Transparent;
            chosenGamePath.Cursor = Cursors.Hand;
            chosenGamePath.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            chosenGamePath.ForeColor = SystemColors.ButtonShadow;
            chosenGamePath.Location = new Point(76, 361);
            chosenGamePath.Name = "chosenGamePath";
            chosenGamePath.Size = new Size(88, 15);
            chosenGamePath.TabIndex = 4;
            chosenGamePath.Text = "path path path";
            chosenGamePath.Click += chosenGamePath_Click;
            // 
            // dllList
            // 
            dllList.Anchor = AnchorStyles.Right;
            dllList.FormattingEnabled = true;
            dllList.Location = new Point(414, 48);
            dllList.Name = "dllList";
            dllList.Size = new Size(121, 256);
            dllList.Sorted = true;
            dllList.TabIndex = 5;
            dllList.ItemCheck += dllList_ItemCheck;
            // 
            // dllLabel
            // 
            dllLabel.AutoSize = true;
            dllLabel.Location = new Point(434, 12);
            dllLabel.Name = "dllLabel";
            dllLabel.Size = new Size(81, 30);
            dllLabel.TabIndex = 6;
            dllLabel.Text = "Injected\r\nDependencies";
            dllLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chosenGameBitness
            // 
            chosenGameBitness.Anchor = AnchorStyles.Right;
            chosenGameBitness.BackColor = Color.Transparent;
            chosenGameBitness.Cursor = Cursors.Hand;
            chosenGameBitness.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            chosenGameBitness.ForeColor = SystemColors.ButtonShadow;
            chosenGameBitness.Location = new Point(322, 361);
            chosenGameBitness.Name = "chosenGameBitness";
            chosenGameBitness.Size = new Size(128, 18);
            chosenGameBitness.TabIndex = 7;
            chosenGameBitness.Text = "x64";
            chosenGameBitness.TextAlign = ContentAlignment.MiddleRight;
            // 
            // autosaveTimer
            // 
            autosaveTimer.Enabled = true;
            autosaveTimer.Interval = 2000;
            autosaveTimer.Tick += autosaveTimer_Tick;
            // 
            // mainTabControl
            // 
            mainTabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainTabControl.Controls.Add(tabPageGames);
            mainTabControl.Controls.Add(syncTabPage);
            mainTabControl.Location = new Point(0, 0);
            mainTabControl.Margin = new Padding(0);
            mainTabControl.Name = "mainTabControl";
            mainTabControl.SelectedIndex = 0;
            mainTabControl.Size = new Size(554, 413);
            mainTabControl.TabIndex = 8;
            // 
            // tabPageGames
            // 
            tabPageGames.Controls.Add(gameList);
            tabPageGames.Controls.Add(chosenGameBitness);
            tabPageGames.Controls.Add(playButton);
            tabPageGames.Controls.Add(chosenGameIcon);
            tabPageGames.Controls.Add(dllLabel);
            tabPageGames.Controls.Add(chosenGameName);
            tabPageGames.Controls.Add(dllList);
            tabPageGames.Controls.Add(chosenGamePath);
            tabPageGames.Location = new Point(4, 24);
            tabPageGames.Name = "tabPageGames";
            tabPageGames.Padding = new Padding(3);
            tabPageGames.Size = new Size(546, 385);
            tabPageGames.TabIndex = 0;
            tabPageGames.Text = "Games";
            tabPageGames.UseVisualStyleBackColor = true;
            // 
            // syncTabPage
            // 
            syncTabPage.Controls.Add(syncButton);
            syncTabPage.Controls.Add(label2);
            syncTabPage.Controls.Add(numericUpDown1);
            syncTabPage.Controls.Add(checkBox1);
            syncTabPage.Controls.Add(syncListBox);
            syncTabPage.Controls.Add(label1);
            syncTabPage.Location = new Point(4, 24);
            syncTabPage.Name = "syncTabPage";
            syncTabPage.Padding = new Padding(3);
            syncTabPage.Size = new Size(546, 385);
            syncTabPage.TabIndex = 1;
            syncTabPage.Text = "Sync";
            syncTabPage.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(385, 28);
            label2.Name = "label2";
            label2.Size = new Size(152, 15);
            label2.TabIndex = 4;
            label2.Text = "Autosave Interval (Minutes)";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(385, 46);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(152, 23);
            numericUpDown1.TabIndex = 3;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(385, 6);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(113, 19);
            checkBox1.TabIndex = 2;
            checkBox1.Text = "Enable Autosave";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // syncListBox
            // 
            syncListBox.FormattingEnabled = true;
            syncListBox.Location = new Point(6, 33);
            syncListBox.Name = "syncListBox";
            syncListBox.Size = new Size(268, 346);
            syncListBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 10);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 0;
            label1.Text = "Sync Targets";
            // 
            // syncButton
            // 
            syncButton.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            syncButton.Location = new Point(280, 330);
            syncButton.Name = "syncButton";
            syncButton.Size = new Size(260, 49);
            syncButton.TabIndex = 5;
            syncButton.Text = "Sync Now!";
            syncButton.UseVisualStyleBackColor = true;
            syncButton.Click += syncButton_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(553, 410);
            Controls.Add(mainTabControl);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Main";
            Text = "Bandaid Launcher";
            Load += Main_Load;
            ((System.ComponentModel.ISupportInitialize)chosenGameIcon).EndInit();
            mainTabControl.ResumeLayout(false);
            tabPageGames.ResumeLayout(false);
            tabPageGames.PerformLayout();
            syncTabPage.ResumeLayout(false);
            syncTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListBox gameList;
        private PictureBox chosenGameIcon;
        private Label chosenGameName;
        private Button playButton;
        private Label chosenGamePath;
        private CheckedListBox dllList;
        private Label dllLabel;
        private Label chosenGameBitness;
        private System.Windows.Forms.Timer autosaveTimer;
        private TabControl mainTabControl;
        private TabPage tabPageGames;
        private TabPage syncTabPage;
        private CheckedListBox syncListBox;
        private Label label1;
        private Label label2;
        private NumericUpDown numericUpDown1;
        private CheckBox checkBox1;
        private Button syncButton;
    }
}