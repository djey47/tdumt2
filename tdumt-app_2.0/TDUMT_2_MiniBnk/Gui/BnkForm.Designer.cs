namespace TDUMT_2.MiniBnkManager.Gui
{
    partial class BnkForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.fileTxt = new System.Windows.Forms.TextBox();
            this.fileBrowseBtn = new System.Windows.Forms.Button();
            this.contentsLst = new System.Windows.Forms.ListBox();
            this.loadBtn = new System.Windows.Forms.Button();
            this.extractBtn = new System.Windows.Forms.Button();
            this.dirBrowseBtn = new System.Windows.Forms.Button();
            this.wDirTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.repackBtn = new System.Windows.Forms.Button();
            this.bnkFileInfoLbl = new System.Windows.Forms.Label();
            this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.openDirBtn = new System.Windows.Forms.Button();
            this.extractAllButton = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.packedFileInfoLbl = new System.Windows.Forms.Label();
            this.dumpButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bank file:";
            // 
            // fileTxt
            // 
            this.fileTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileTxt.Location = new System.Drawing.Point(69, 12);
            this.fileTxt.Name = "fileTxt";
            this.fileTxt.Size = new System.Drawing.Size(321, 20);
            this.fileTxt.TabIndex = 2;
            // 
            // fileBrowseBtn
            // 
            this.fileBrowseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fileBrowseBtn.Location = new System.Drawing.Point(396, 10);
            this.fileBrowseBtn.Name = "fileBrowseBtn";
            this.fileBrowseBtn.Size = new System.Drawing.Size(24, 23);
            this.fileBrowseBtn.TabIndex = 1;
            this.fileBrowseBtn.Text = "...";
            this.fileBrowseBtn.UseVisualStyleBackColor = true;
            this.fileBrowseBtn.Click += new System.EventHandler(this.fileBrowseBtn_Click);
            // 
            // contentsLst
            // 
            this.contentsLst.AllowDrop = true;
            this.contentsLst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentsLst.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contentsLst.FormattingEnabled = true;
            this.contentsLst.ItemHeight = 11;
            this.contentsLst.Location = new System.Drawing.Point(15, 68);
            this.contentsLst.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.contentsLst.Name = "contentsLst";
            this.contentsLst.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.contentsLst.Size = new System.Drawing.Size(454, 290);
            this.contentsLst.TabIndex = 3;
            this.contentsLst.SelectedIndexChanged += new System.EventHandler(this.contentsLst_SelectedIndexChanged);
            this.contentsLst.DragDrop += new System.Windows.Forms.DragEventHandler(this.contentsLst_DragDrop);
            this.contentsLst.DragEnter += new System.Windows.Forms.DragEventHandler(this.contentsLst_DragEnter);
            // 
            // loadBtn
            // 
            this.loadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadBtn.Location = new System.Drawing.Point(426, 10);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(43, 23);
            this.loadBtn.TabIndex = 2;
            this.loadBtn.Text = "Load";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // extractBtn
            // 
            this.extractBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.extractBtn.Location = new System.Drawing.Point(15, 429);
            this.extractBtn.Name = "extractBtn";
            this.extractBtn.Size = new System.Drawing.Size(70, 23);
            this.extractBtn.TabIndex = 10;
            this.extractBtn.Text = "Unpack";
            this.extractBtn.UseVisualStyleBackColor = true;
            this.extractBtn.Click += new System.EventHandler(this.extractBtn_Click);
            // 
            // dirBrowseBtn
            // 
            this.dirBrowseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dirBrowseBtn.Location = new System.Drawing.Point(396, 398);
            this.dirBrowseBtn.Name = "dirBrowseBtn";
            this.dirBrowseBtn.Size = new System.Drawing.Size(24, 23);
            this.dirBrowseBtn.TabIndex = 8;
            this.dirBrowseBtn.Text = "...";
            this.dirBrowseBtn.UseVisualStyleBackColor = true;
            this.dirBrowseBtn.Click += new System.EventHandler(this.dirBrowseBtn_Click);
            // 
            // wDirTxt
            // 
            this.wDirTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wDirTxt.Location = new System.Drawing.Point(97, 400);
            this.wDirTxt.Name = "wDirTxt";
            this.wDirTxt.Size = new System.Drawing.Size(293, 20);
            this.wDirTxt.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 403);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Work directory:";
            // 
            // repackBtn
            // 
            this.repackBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.repackBtn.Location = new System.Drawing.Point(176, 429);
            this.repackBtn.Name = "repackBtn";
            this.repackBtn.Size = new System.Drawing.Size(70, 23);
            this.repackBtn.TabIndex = 12;
            this.repackBtn.Text = "Repack...";
            this.repackBtn.UseVisualStyleBackColor = true;
            this.repackBtn.Click += new System.EventHandler(this.repackBtn_Click);
            // 
            // bnkFileInfoLbl
            // 
            this.bnkFileInfoLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bnkFileInfoLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bnkFileInfoLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnkFileInfoLbl.ForeColor = System.Drawing.Color.Teal;
            this.bnkFileInfoLbl.Location = new System.Drawing.Point(15, 45);
            this.bnkFileInfoLbl.Name = "bnkFileInfoLbl";
            this.bnkFileInfoLbl.Size = new System.Drawing.Size(454, 24);
            this.bnkFileInfoLbl.TabIndex = 4;
            this.bnkFileInfoLbl.Text = "Please load a TDU/TDU2 Bank file...";
            this.bnkFileInfoLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openDirBtn
            // 
            this.openDirBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.openDirBtn.Location = new System.Drawing.Point(426, 398);
            this.openDirBtn.Name = "openDirBtn";
            this.openDirBtn.Size = new System.Drawing.Size(43, 23);
            this.openDirBtn.TabIndex = 9;
            this.openDirBtn.Text = "Open";
            this.openDirBtn.UseVisualStyleBackColor = true;
            this.openDirBtn.Click += new System.EventHandler(this.openDirBtn_Click);
            // 
            // extractAllButton
            // 
            this.extractAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.extractAllButton.Location = new System.Drawing.Point(91, 429);
            this.extractAllButton.Name = "extractAllButton";
            this.extractAllButton.Size = new System.Drawing.Size(70, 23);
            this.extractAllButton.TabIndex = 11;
            this.extractAllButton.Text = "Unpack all";
            this.extractAllButton.UseVisualStyleBackColor = true;
            this.extractAllButton.Click += new System.EventHandler(this.extractAllButton_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aboutButton.Location = new System.Drawing.Point(402, 429);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(70, 23);
            this.aboutButton.TabIndex = 14;
            this.aboutButton.Text = "About...";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // packedFileInfoLbl
            // 
            this.packedFileInfoLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.packedFileInfoLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.packedFileInfoLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.packedFileInfoLbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.packedFileInfoLbl.Location = new System.Drawing.Point(15, 364);
            this.packedFileInfoLbl.Name = "packedFileInfoLbl";
            this.packedFileInfoLbl.Size = new System.Drawing.Size(454, 24);
            this.packedFileInfoLbl.TabIndex = 5;
            this.packedFileInfoLbl.Text = "Please select a packed file...";
            this.packedFileInfoLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dumpButton
            // 
            this.dumpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dumpButton.Location = new System.Drawing.Point(326, 429);
            this.dumpButton.Name = "dumpButton";
            this.dumpButton.Size = new System.Drawing.Size(70, 23);
            this.dumpButton.TabIndex = 13;
            this.dumpButton.Text = "Dump";
            this.dumpButton.UseVisualStyleBackColor = true;
            this.dumpButton.Click += new System.EventHandler(this.dumpButton_Click);
            // 
            // BnkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 462);
            this.Controls.Add(this.dumpButton);
            this.Controls.Add(this.packedFileInfoLbl);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.extractAllButton);
            this.Controls.Add(this.openDirBtn);
            this.Controls.Add(this.bnkFileInfoLbl);
            this.Controls.Add(this.repackBtn);
            this.Controls.Add(this.extractBtn);
            this.Controls.Add(this.dirBrowseBtn);
            this.Controls.Add(this.wDirTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.loadBtn);
            this.Controls.Add(this.contentsLst);
            this.Controls.Add(this.fileBrowseBtn);
            this.Controls.Add(this.fileTxt);
            this.Controls.Add(this.label1);
            this.Name = "BnkForm";
            this.Text = "TDUMT II - Mini Bnk Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fileTxt;
        private System.Windows.Forms.Button fileBrowseBtn;
        private System.Windows.Forms.ListBox contentsLst;
        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.Button extractBtn;
        private System.Windows.Forms.Button dirBrowseBtn;
        private System.Windows.Forms.TextBox wDirTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button repackBtn;
        private System.Windows.Forms.Label bnkFileInfoLbl;
        private System.Windows.Forms.OpenFileDialog openFileDlg;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDlg;
        private System.Windows.Forms.Button openDirBtn;
        private System.Windows.Forms.Button extractAllButton;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label packedFileInfoLbl;
        private System.Windows.Forms.Button dumpButton;

    }
}