namespace ChordOrganizer {
  partial class MainForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.tbContent = new System.Windows.Forms.RichTextBox();
      this.lbSongs = new System.Windows.Forms.ListBox();
      this.bSyncRefresh = new System.Windows.Forms.Button();
      this.bUploadAll = new System.Windows.Forms.Button();
      this.lDirectory = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.lNumberSongs = new System.Windows.Forms.Label();
      this.bDelete = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.tbSearch = new System.Windows.Forms.TextBox();
      this.tbTitle = new System.Windows.Forms.TextBox();
      this.bAddModify = new System.Windows.Forms.Button();
      this.bSharp = new System.Windows.Forms.Button();
      this.bFlat = new System.Windows.Forms.Button();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.changeDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.miExit = new System.Windows.Forms.ToolStripMenuItem();
      this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.miOnline = new System.Windows.Forms.ToolStripMenuItem();
      this.miOffline = new System.Windows.Forms.ToolStripMenuItem();
      this.hotkeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.bPreview = new System.Windows.Forms.Button();
      this.bChangeFont = new System.Windows.Forms.Button();
      this.bTest = new System.Windows.Forms.Button();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tbContent
      // 
      this.tbContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbContent.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbContent.ForeColor = System.Drawing.Color.Black;
      this.tbContent.Location = new System.Drawing.Point(222, 148);
      this.tbContent.Name = "tbContent";
      this.tbContent.Size = new System.Drawing.Size(880, 434);
      this.tbContent.TabIndex = 0;
      this.tbContent.Text = "";
      // 
      // lbSongs
      // 
      this.lbSongs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.lbSongs.FormattingEnabled = true;
      this.lbSongs.Location = new System.Drawing.Point(13, 148);
      this.lbSongs.Name = "lbSongs";
      this.lbSongs.Size = new System.Drawing.Size(203, 433);
      this.lbSongs.TabIndex = 1;
      this.lbSongs.SelectedIndexChanged += new System.EventHandler(this.lbSongs_SelectedIndexChanged);
      // 
      // bSyncRefresh
      // 
      this.bSyncRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.bSyncRefresh.Location = new System.Drawing.Point(1015, 74);
      this.bSyncRefresh.Name = "bSyncRefresh";
      this.bSyncRefresh.Size = new System.Drawing.Size(87, 68);
      this.bSyncRefresh.TabIndex = 2;
      this.bSyncRefresh.Text = "Sync";
      this.bSyncRefresh.UseVisualStyleBackColor = true;
      this.bSyncRefresh.Click += new System.EventHandler(this.bSyncRefresh_Click);
      // 
      // bUploadAll
      // 
      this.bUploadAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.bUploadAll.Location = new System.Drawing.Point(938, 35);
      this.bUploadAll.Name = "bUploadAll";
      this.bUploadAll.Size = new System.Drawing.Size(164, 33);
      this.bUploadAll.TabIndex = 3;
      this.bUploadAll.Text = "Up All Songs";
      this.bUploadAll.UseVisualStyleBackColor = true;
      this.bUploadAll.Click += new System.EventHandler(this.bUploadAll_Click);
      // 
      // lDirectory
      // 
      this.lDirectory.AutoSize = true;
      this.lDirectory.Location = new System.Drawing.Point(13, 35);
      this.lDirectory.Name = "lDirectory";
      this.lDirectory.Size = new System.Drawing.Size(49, 13);
      this.lDirectory.TabIndex = 4;
      this.lDirectory.Text = "Directory";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(13, 93);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(41, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "Search";
      // 
      // lNumberSongs
      // 
      this.lNumberSongs.AutoSize = true;
      this.lNumberSongs.Location = new System.Drawing.Point(16, 124);
      this.lNumberSongs.Name = "lNumberSongs";
      this.lNumberSongs.Size = new System.Drawing.Size(46, 13);
      this.lNumberSongs.TabIndex = 6;
      this.lNumberSongs.Text = "0 Songs";
      // 
      // bDelete
      // 
      this.bDelete.Location = new System.Drawing.Point(140, 119);
      this.bDelete.Name = "bDelete";
      this.bDelete.Size = new System.Drawing.Size(75, 23);
      this.bDelete.TabIndex = 7;
      this.bDelete.Text = "Delete";
      this.bDelete.UseVisualStyleBackColor = true;
      this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(221, 119);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(55, 13);
      this.label3.TabIndex = 5;
      this.label3.Text = "Song Title";
      // 
      // tbSearch
      // 
      this.tbSearch.Location = new System.Drawing.Point(74, 90);
      this.tbSearch.Name = "tbSearch";
      this.tbSearch.Size = new System.Drawing.Size(141, 20);
      this.tbSearch.TabIndex = 9;
      this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
      // 
      // tbTitle
      // 
      this.tbTitle.Location = new System.Drawing.Point(291, 117);
      this.tbTitle.Name = "tbTitle";
      this.tbTitle.Size = new System.Drawing.Size(141, 20);
      this.tbTitle.TabIndex = 9;
      // 
      // bAddModify
      // 
      this.bAddModify.Location = new System.Drawing.Point(437, 115);
      this.bAddModify.Name = "bAddModify";
      this.bAddModify.Size = new System.Drawing.Size(95, 23);
      this.bAddModify.TabIndex = 10;
      this.bAddModify.Text = "Add / Modify";
      this.bAddModify.UseVisualStyleBackColor = true;
      this.bAddModify.Click += new System.EventHandler(this.bUpload_Click);
      // 
      // bSharp
      // 
      this.bSharp.Location = new System.Drawing.Point(558, 83);
      this.bSharp.Name = "bSharp";
      this.bSharp.Size = new System.Drawing.Size(76, 27);
      this.bSharp.TabIndex = 10;
      this.bSharp.Text = "#";
      this.bSharp.UseVisualStyleBackColor = true;
      this.bSharp.Click += new System.EventHandler(this.bSharp_Click);
      // 
      // bFlat
      // 
      this.bFlat.Location = new System.Drawing.Point(559, 114);
      this.bFlat.Name = "bFlat";
      this.bFlat.Size = new System.Drawing.Size(75, 27);
      this.bFlat.TabIndex = 10;
      this.bFlat.Text = "b";
      this.bFlat.UseVisualStyleBackColor = true;
      this.bFlat.Click += new System.EventHandler(this.bFlat_Click);
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.modeToolStripMenuItem,
            this.hotkeysToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(1114, 24);
      this.menuStrip1.TabIndex = 11;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeDirectoryToolStripMenuItem,
            this.miExit});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // changeDirectoryToolStripMenuItem
      // 
      this.changeDirectoryToolStripMenuItem.Name = "changeDirectoryToolStripMenuItem";
      this.changeDirectoryToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
      this.changeDirectoryToolStripMenuItem.Text = "Change directory";
      this.changeDirectoryToolStripMenuItem.Click += new System.EventHandler(this.changeDirectoryToolStripMenuItem_Click);
      // 
      // miExit
      // 
      this.miExit.Name = "miExit";
      this.miExit.Size = new System.Drawing.Size(157, 22);
      this.miExit.Text = "Exit";
      this.miExit.Click += new System.EventHandler(this.miExit_Click);
      // 
      // modeToolStripMenuItem
      // 
      this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miOnline,
            this.miOffline});
      this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
      this.modeToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
      this.modeToolStripMenuItem.Text = "Mode";
      // 
      // miOnline
      // 
      this.miOnline.Checked = true;
      this.miOnline.CheckOnClick = true;
      this.miOnline.CheckState = System.Windows.Forms.CheckState.Checked;
      this.miOnline.Name = "miOnline";
      this.miOnline.Size = new System.Drawing.Size(106, 22);
      this.miOnline.Text = "Online";
      this.miOnline.Click += new System.EventHandler(this.miOnline_Click);
      // 
      // miOffline
      // 
      this.miOffline.Name = "miOffline";
      this.miOffline.Size = new System.Drawing.Size(106, 22);
      this.miOffline.Text = "Offline";
      this.miOffline.Click += new System.EventHandler(this.miOffline_Click);
      // 
      // hotkeysToolStripMenuItem
      // 
      this.hotkeysToolStripMenuItem.Name = "hotkeysToolStripMenuItem";
      this.hotkeysToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
      this.hotkeysToolStripMenuItem.Text = "Hotkeys";
      this.hotkeysToolStripMenuItem.Click += new System.EventHandler(this.hotkeysToolStripMenuItem_Click);
      // 
      // bPreview
      // 
      this.bPreview.Location = new System.Drawing.Point(437, 85);
      this.bPreview.Name = "bPreview";
      this.bPreview.Size = new System.Drawing.Size(94, 23);
      this.bPreview.TabIndex = 12;
      this.bPreview.Text = "Preview";
      this.bPreview.UseVisualStyleBackColor = true;
      this.bPreview.Click += new System.EventHandler(this.bPreview_Click);
      // 
      // bChangeFont
      // 
      this.bChangeFont.Location = new System.Drawing.Point(656, 114);
      this.bChangeFont.Name = "bChangeFont";
      this.bChangeFont.Size = new System.Drawing.Size(112, 25);
      this.bChangeFont.TabIndex = 13;
      this.bChangeFont.Text = "Change Lyric Font";
      this.bChangeFont.UseVisualStyleBackColor = true;
      this.bChangeFont.Click += new System.EventHandler(this.bChangeFont_Click);
      // 
      // bTest
      // 
      this.bTest.Location = new System.Drawing.Point(696, 35);
      this.bTest.Name = "bTest";
      this.bTest.Size = new System.Drawing.Size(75, 23);
      this.bTest.TabIndex = 14;
      this.bTest.Text = "button1";
      this.bTest.UseVisualStyleBackColor = true;
      this.bTest.Click += new System.EventHandler(this.bTest_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1114, 594);
      this.Controls.Add(this.bTest);
      this.Controls.Add(this.bChangeFont);
      this.Controls.Add(this.bPreview);
      this.Controls.Add(this.bFlat);
      this.Controls.Add(this.bSharp);
      this.Controls.Add(this.bAddModify);
      this.Controls.Add(this.tbTitle);
      this.Controls.Add(this.tbSearch);
      this.Controls.Add(this.bDelete);
      this.Controls.Add(this.lNumberSongs);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.lDirectory);
      this.Controls.Add(this.bUploadAll);
      this.Controls.Add(this.bSyncRefresh);
      this.Controls.Add(this.lbSongs);
      this.Controls.Add(this.tbContent);
      this.Controls.Add(this.menuStrip1);
      this.KeyPreview = true;
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "MainForm";
      this.Text = "Form1";
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.RichTextBox tbContent;
    private System.Windows.Forms.ListBox lbSongs;
    private System.Windows.Forms.Button bSyncRefresh;
    private System.Windows.Forms.Button bUploadAll;
    private System.Windows.Forms.Label lDirectory;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label lNumberSongs;
    private System.Windows.Forms.Button bDelete;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox tbSearch;
    private System.Windows.Forms.TextBox tbTitle;
    private System.Windows.Forms.Button bAddModify;
    private System.Windows.Forms.Button bSharp;
    private System.Windows.Forms.Button bFlat;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem changeDirectoryToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem miExit;
    private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem miOnline;
    private System.Windows.Forms.ToolStripMenuItem miOffline;
    private System.Windows.Forms.Button bPreview;
    private System.Windows.Forms.Button bChangeFont;
    private System.Windows.Forms.ToolStripMenuItem hotkeysToolStripMenuItem;
    private System.Windows.Forms.Button bTest;
  }
}

