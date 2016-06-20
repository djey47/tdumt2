namespace TDUMT_2.MiniXmb.Gui
{
    partial class XmbForm
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
            this.loadBtn = new System.Windows.Forms.Button();
            this.fileBrowseBtn = new System.Windows.Forms.Button();
            this.fileTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.xmbFileInfoLbl = new System.Windows.Forms.Label();
            this.aboutBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.soundVolumeTabPage = new System.Windows.Forms.TabPage();
            this.revertBtn = new System.Windows.Forms.Button();
            this.outVolumeTxt = new System.Windows.Forms.TextBox();
            this.inVolumeTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sampleSearchBtn = new System.Windows.Forms.Button();
            this.sampleComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.instructionsLbl = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.soundVolumeTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // loadBtn
            // 
            this.loadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadBtn.Location = new System.Drawing.Point(426, 10);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(43, 23);
            this.loadBtn.TabIndex = 3;
            this.loadBtn.Text = "Load";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // fileBrowseBtn
            // 
            this.fileBrowseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fileBrowseBtn.Location = new System.Drawing.Point(396, 10);
            this.fileBrowseBtn.Name = "fileBrowseBtn";
            this.fileBrowseBtn.Size = new System.Drawing.Size(24, 23);
            this.fileBrowseBtn.TabIndex = 2;
            this.fileBrowseBtn.Text = "...";
            this.fileBrowseBtn.UseVisualStyleBackColor = true;
            this.fileBrowseBtn.Click += new System.EventHandler(this.fileBrowseBtn_Click);
            // 
            // fileTxt
            // 
            this.fileTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileTxt.Location = new System.Drawing.Point(69, 12);
            this.fileTxt.Name = "fileTxt";
            this.fileTxt.Size = new System.Drawing.Size(321, 20);
            this.fileTxt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data file:";
            // 
            // xmbFileInfoLbl
            // 
            this.xmbFileInfoLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xmbFileInfoLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xmbFileInfoLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xmbFileInfoLbl.ForeColor = System.Drawing.Color.Teal;
            this.xmbFileInfoLbl.Location = new System.Drawing.Point(15, 45);
            this.xmbFileInfoLbl.Name = "xmbFileInfoLbl";
            this.xmbFileInfoLbl.Size = new System.Drawing.Size(454, 24);
            this.xmbFileInfoLbl.TabIndex = 4;
            this.xmbFileInfoLbl.Text = "Please load a TDU2 XMetadataBank file...";
            this.xmbFileInfoLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aboutBtn
            // 
            this.aboutBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aboutBtn.Location = new System.Drawing.Point(402, 429);
            this.aboutBtn.Name = "aboutBtn";
            this.aboutBtn.Size = new System.Drawing.Size(70, 23);
            this.aboutBtn.TabIndex = 8;
            this.aboutBtn.Text = "About...";
            this.aboutBtn.UseVisualStyleBackColor = true;
            this.aboutBtn.Click += new System.EventHandler(this.aboutBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveBtn.Location = new System.Drawing.Point(141, 123);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 7;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.soundVolumeTabPage);
            this.tabControl.Location = new System.Drawing.Point(15, 72);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(457, 327);
            this.tabControl.TabIndex = 5;
            // 
            // soundVolumeTabPage
            // 
            this.soundVolumeTabPage.Controls.Add(this.revertBtn);
            this.soundVolumeTabPage.Controls.Add(this.outVolumeTxt);
            this.soundVolumeTabPage.Controls.Add(this.inVolumeTxt);
            this.soundVolumeTabPage.Controls.Add(this.label5);
            this.soundVolumeTabPage.Controls.Add(this.label4);
            this.soundVolumeTabPage.Controls.Add(this.sampleSearchBtn);
            this.soundVolumeTabPage.Controls.Add(this.saveBtn);
            this.soundVolumeTabPage.Controls.Add(this.sampleComboBox);
            this.soundVolumeTabPage.Controls.Add(this.label2);
            this.soundVolumeTabPage.Location = new System.Drawing.Point(4, 22);
            this.soundVolumeTabPage.Name = "soundVolumeTabPage";
            this.soundVolumeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.soundVolumeTabPage.Size = new System.Drawing.Size(449, 301);
            this.soundVolumeTabPage.TabIndex = 0;
            this.soundVolumeTabPage.Text = "Sound volume";
            this.soundVolumeTabPage.UseVisualStyleBackColor = true;
            // 
            // revertBtn
            // 
            this.revertBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.revertBtn.Location = new System.Drawing.Point(58, 123);
            this.revertBtn.Name = "revertBtn";
            this.revertBtn.Size = new System.Drawing.Size(75, 23);
            this.revertBtn.TabIndex = 5;
            this.revertBtn.Text = "Revert";
            this.revertBtn.UseVisualStyleBackColor = true;
            this.revertBtn.Click += new System.EventHandler(this.revertBtn_Click);
            // 
            // outVolumeTxt
            // 
            this.outVolumeTxt.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outVolumeTxt.Location = new System.Drawing.Point(109, 87);
            this.outVolumeTxt.Name = "outVolumeTxt";
            this.outVolumeTxt.Size = new System.Drawing.Size(107, 18);
            this.outVolumeTxt.TabIndex = 7;
            // 
            // inVolumeTxt
            // 
            this.inVolumeTxt.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inVolumeTxt.Location = new System.Drawing.Point(109, 51);
            this.inVolumeTxt.Name = "inVolumeTxt";
            this.inVolumeTxt.Size = new System.Drawing.Size(107, 18);
            this.inVolumeTxt.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(57, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "OUT";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(58, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "IN";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sampleSearchBtn
            // 
            this.sampleSearchBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sampleSearchBtn.Location = new System.Drawing.Point(274, 7);
            this.sampleSearchBtn.Name = "sampleSearchBtn";
            this.sampleSearchBtn.Size = new System.Drawing.Size(70, 23);
            this.sampleSearchBtn.TabIndex = 2;
            this.sampleSearchBtn.Text = "Search!";
            this.sampleSearchBtn.UseVisualStyleBackColor = true;
            this.sampleSearchBtn.Click += new System.EventHandler(this.sampleSearchBtn_Click);
            // 
            // sampleComboBox
            // 
            this.sampleComboBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sampleComboBox.FormattingEnabled = true;
            this.sampleComboBox.Location = new System.Drawing.Point(57, 11);
            this.sampleComboBox.MaxDropDownItems = 10;
            this.sampleComboBox.MaxLength = 32;
            this.sampleComboBox.Name = "sampleComboBox";
            this.sampleComboBox.Size = new System.Drawing.Size(211, 19);
            this.sampleComboBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Sample:";
            // 
            // instructionsLbl
            // 
            this.instructionsLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.instructionsLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.instructionsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionsLbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.instructionsLbl.Location = new System.Drawing.Point(15, 402);
            this.instructionsLbl.Name = "instructionsLbl";
            this.instructionsLbl.Size = new System.Drawing.Size(454, 24);
            this.instructionsLbl.TabIndex = 6;
            this.instructionsLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // XmbForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 462);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fileTxt);
            this.Controls.Add(this.fileBrowseBtn);
            this.Controls.Add(this.loadBtn);
            this.Controls.Add(this.xmbFileInfoLbl);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.instructionsLbl);
            this.Controls.Add(this.aboutBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "XmbForm";
            this.Text = "TDUMT II - Mini Xmb Editor";
            this.tabControl.ResumeLayout(false);
            this.soundVolumeTabPage.ResumeLayout(false);
            this.soundVolumeTabPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.Button fileBrowseBtn;
        private System.Windows.Forms.TextBox fileTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDlg;
        private System.Windows.Forms.Label xmbFileInfoLbl;
        private System.Windows.Forms.Button aboutBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage soundVolumeTabPage;
        private System.Windows.Forms.Label instructionsLbl;
        private System.Windows.Forms.Button sampleSearchBtn;
        private System.Windows.Forms.ComboBox sampleComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button revertBtn;
        private System.Windows.Forms.TextBox outVolumeTxt;
        private System.Windows.Forms.TextBox inVolumeTxt;
        private System.Windows.Forms.Label label5;
    }
}