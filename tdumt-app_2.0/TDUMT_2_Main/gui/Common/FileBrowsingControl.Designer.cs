namespace TDUMT_2.Main.Gui.Common
{
    partial class FileBrowsingControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileBrowsingControl));
            this.parentButton = new System.Windows.Forms.Button();
            this.fileListView = new System.Windows.Forms.ListView();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.largeImageList = new System.Windows.Forms.ImageList(this.components);
            this.smallImageList = new System.Windows.Forms.ImageList(this.components);
            this.controlPanel = new System.Windows.Forms.Panel();
            this.explorerButton = new System.Windows.Forms.Button();
            this.pathComboBox = new System.Windows.Forms.ComboBox();
            this.controlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // parentButton
            // 
            this.parentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.parentButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parentButton.Location = new System.Drawing.Point(3, 6);
            this.parentButton.Name = "parentButton";
            this.parentButton.Size = new System.Drawing.Size(26, 25);
            this.parentButton.TabIndex = 0;
            this.parentButton.Text = "^";
            this.parentButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.parentButton.UseVisualStyleBackColor = true;
            this.parentButton.Click += new System.EventHandler(this.parentButton_Click);
            // 
            // fileListView
            // 
            this.fileListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fileListView.BackgroundImage = GuiResources.WIP;
            this.fileListView.BackgroundImageTiled = true;
            this.fileListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fileListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader});
            this.fileListView.LargeImageList = this.largeImageList;
            this.fileListView.Location = new System.Drawing.Point(0, 36);
            this.fileListView.Name = "fileListView";
            this.fileListView.Size = new System.Drawing.Size(422, 366);
            this.fileListView.SmallImageList = this.smallImageList;
            this.fileListView.TabIndex = 2;
            this.fileListView.UseCompatibleStateImageBehavior = false;
            this.fileListView.View = System.Windows.Forms.View.Details;
            this.fileListView.DoubleClick += new System.EventHandler(this.fileListView_DoubleClick);
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Name";
            this.nameColumnHeader.Width = 250;
            // 
            // largeImageList
            // 
            this.largeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("largeImageList.ImageStream")));
            this.largeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.largeImageList.Images.SetKeyName(0, "folder-closed_32.png");
            this.largeImageList.Images.SetKeyName(1, "folder-open_32.png");
            this.largeImageList.Images.SetKeyName(2, "applications_32.png");
            this.largeImageList.Images.SetKeyName(3, "disc-media_32.png");
            this.largeImageList.Images.SetKeyName(4, "documents_32.png");
            this.largeImageList.Images.SetKeyName(5, "bnk-closed_32.png");
            this.largeImageList.Images.SetKeyName(6, "backup_32.png");
            this.largeImageList.Images.SetKeyName(7, "2db_32.png");
            this.largeImageList.Images.SetKeyName(8, "2dm_32.png");
            this.largeImageList.Images.SetKeyName(9, "3d_32.png");
            this.largeImageList.Images.SetKeyName(10, "wav_32.png");
            this.largeImageList.Images.SetKeyName(11, "database_32.png");
            this.largeImageList.Images.SetKeyName(12, "blank.png");
            this.largeImageList.Images.SetKeyName(13, "blank.png");
            this.largeImageList.Images.SetKeyName(14, "blank.png");
            this.largeImageList.Images.SetKeyName(15, "blank.png");
            this.largeImageList.Images.SetKeyName(16, "cam_32.png");
            // 
            // smallImageList
            // 
            this.smallImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("smallImageList.ImageStream")));
            this.smallImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.smallImageList.Images.SetKeyName(0, "folder-open_16.png");
            this.smallImageList.Images.SetKeyName(1, "folder-closed_16.png");
            this.smallImageList.Images.SetKeyName(2, "applications_16.png");
            this.smallImageList.Images.SetKeyName(3, "disc-media_16.png");
            this.smallImageList.Images.SetKeyName(4, "documents_16.png");
            this.smallImageList.Images.SetKeyName(5, "bnk-closed_16.png");
            this.smallImageList.Images.SetKeyName(6, "backup_16.png");
            this.smallImageList.Images.SetKeyName(7, "2db_16.png");
            this.smallImageList.Images.SetKeyName(8, "2dm_16.png");
            this.smallImageList.Images.SetKeyName(9, "3d_16.png");
            this.smallImageList.Images.SetKeyName(10, "wav_16.png");
            this.smallImageList.Images.SetKeyName(11, "database_16.png");
            this.smallImageList.Images.SetKeyName(12, "folder-packed-open_16.png");
            this.smallImageList.Images.SetKeyName(13, "folder-packed-closed_16.png");
            this.smallImageList.Images.SetKeyName(14, "folder-ext-open_16.png");
            this.smallImageList.Images.SetKeyName(15, "folder-ext-closed_16.png");
            this.smallImageList.Images.SetKeyName(16, "cam_16.png");
            // 
            // controlPanel
            // 
            this.controlPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(170)))), ((int)(((byte)(193)))));
            this.controlPanel.Controls.Add(this.explorerButton);
            this.controlPanel.Controls.Add(this.pathComboBox);
            this.controlPanel.Controls.Add(this.parentButton);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlPanel.Location = new System.Drawing.Point(0, 0);
            this.controlPanel.Margin = new System.Windows.Forms.Padding(0);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.controlPanel.Size = new System.Drawing.Size(422, 36);
            this.controlPanel.TabIndex = 3;
            // 
            // explorerButton
            // 
            this.explorerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.explorerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.explorerButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.explorerButton.Location = new System.Drawing.Point(393, 6);
            this.explorerButton.Name = "explorerButton";
            this.explorerButton.Size = new System.Drawing.Size(26, 25);
            this.explorerButton.TabIndex = 2;
            this.explorerButton.Text = "O";
            this.explorerButton.UseVisualStyleBackColor = true;
            // 
            // pathComboBox
            // 
            this.pathComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pathComboBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathComboBox.FormattingEnabled = true;
            this.pathComboBox.Location = new System.Drawing.Point(35, 7);
            this.pathComboBox.Name = "pathComboBox";
            this.pathComboBox.Size = new System.Drawing.Size(352, 23);
            this.pathComboBox.TabIndex = 1;
            this.pathComboBox.SelectedIndexChanged += new System.EventHandler(this.pathComboBox_SelectedIndexChanged);
            // 
            // FileBrowsingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.fileListView);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FileBrowsingControl";
            this.Size = new System.Drawing.Size(422, 403);
            this.controlPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button parentButton;
        private System.Windows.Forms.ListView fileListView;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.ComboBox pathComboBox;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ImageList smallImageList;
        private System.Windows.Forms.ImageList largeImageList;
        private System.Windows.Forms.Button explorerButton;

    }
}
