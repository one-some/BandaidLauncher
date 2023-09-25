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
            ((System.ComponentModel.ISupportInitialize)chosenGameIcon).BeginInit();
            SuspendLayout();
            // 
            // gameList
            // 
            gameList.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            gameList.FormattingEnabled = true;
            gameList.ItemHeight = 21;
            gameList.Items.AddRange(new object[] { "Bob", "John", "Markus" });
            gameList.Location = new Point(12, 12);
            gameList.Name = "gameList";
            gameList.Size = new Size(402, 298);
            gameList.Sorted = true;
            gameList.TabIndex = 0;
            gameList.SelectedIndexChanged += gameList_SelectedIndexChanged;
            // 
            // chosenGameIcon
            // 
            chosenGameIcon.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            chosenGameIcon.Location = new Point(12, 334);
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
            chosenGameName.Location = new Point(82, 334);
            chosenGameName.Name = "chosenGameName";
            chosenGameName.Size = new Size(53, 15);
            chosenGameName.TabIndex = 2;
            chosenGameName.Text = "Oblivion";
            // 
            // playButton
            // 
            playButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            playButton.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            playButton.Location = new Point(457, 334);
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
            chosenGamePath.BackColor = SystemColors.Control;
            chosenGamePath.Cursor = Cursors.Hand;
            chosenGamePath.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            chosenGamePath.ForeColor = SystemColors.ButtonShadow;
            chosenGamePath.Location = new Point(82, 380);
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
            dllList.Location = new Point(420, 54);
            dllList.Name = "dllList";
            dllList.Size = new Size(121, 256);
            dllList.Sorted = true;
            dllList.TabIndex = 5;
            dllList.ItemCheck += dllList_ItemCheck;
            // 
            // dllLabel
            // 
            dllLabel.AutoSize = true;
            dllLabel.Location = new Point(440, 18);
            dllLabel.Name = "dllLabel";
            dllLabel.Size = new Size(81, 30);
            dllLabel.TabIndex = 6;
            dllLabel.Text = "Injected\r\nDependencies";
            dllLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chosenGameBitness
            // 
            chosenGameBitness.Anchor = AnchorStyles.Right;
            chosenGameBitness.BackColor = SystemColors.Control;
            chosenGameBitness.Cursor = Cursors.Hand;
            chosenGameBitness.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            chosenGameBitness.ForeColor = SystemColors.ButtonShadow;
            chosenGameBitness.Location = new Point(323, 380);
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
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(553, 410);
            Controls.Add(chosenGameBitness);
            Controls.Add(dllLabel);
            Controls.Add(dllList);
            Controls.Add(chosenGamePath);
            Controls.Add(playButton);
            Controls.Add(chosenGameName);
            Controls.Add(chosenGameIcon);
            Controls.Add(gameList);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Main";
            Text = "Bandaid Launcher";
            Load += Main_Load;
            ((System.ComponentModel.ISupportInitialize)chosenGameIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
    }
}