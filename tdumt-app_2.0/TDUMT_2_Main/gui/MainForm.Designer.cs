using TDUMT_2.Main;
using TDUMT_2.Main.Gui.Common;

namespace TDUMT_2.Gui
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.controlPanel = new System.Windows.Forms.Panel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.searchToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.dbModuleButton = new System.Windows.Forms.ToolStripButton();
            this.texButton = new System.Windows.Forms.ToolStripButton();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupRestoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.createFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toOtherPaneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toOtherPaneToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toLocationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.unpackBNKToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repackBNKToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unselectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.largeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tDUPEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusPanel = new System.Windows.Forms.Panel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.wsPanel = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.fileBrowsingControl1 = new FileBrowsingControl();
            this.fileBrowsingControl2 = new FileBrowsingControl();
            this.controlPanel.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.statusPanel.SuspendLayout();
            this.wsPanel.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlPanel
            // 
            this.controlPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(170)))), ((int)(((byte)(193)))));
            this.controlPanel.Controls.Add(this.toolStrip);
            this.controlPanel.Controls.Add(this.menuStrip);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlPanel.Location = new System.Drawing.Point(0, 0);
            this.controlPanel.Margin = new System.Windows.Forms.Padding(0);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.controlPanel.Size = new System.Drawing.Size(1008, 49);
            this.controlPanel.TabIndex = 0;
            // 
            // toolStrip
            // 
            this.toolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackgroundImage = GuiResources.toolbarBackground;
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripTextBox,
            this.toolStripLabel1,
            this.toolStripLabel2,
            this.dbModuleButton,
            this.texButton});
            this.toolStrip.Location = new System.Drawing.Point(1, 21);
            this.toolStrip.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip.Size = new System.Drawing.Size(1006, 26);
            this.toolStrip.TabIndex = 1;
            // 
            // searchToolStripTextBox
            // 
            this.searchToolStripTextBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.searchToolStripTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.searchToolStripTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchToolStripTextBox.Enabled = false;
            this.searchToolStripTextBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchToolStripTextBox.Margin = new System.Windows.Forms.Padding(0, 3, 5, 3);
            this.searchToolStripTextBox.Name = "searchToolStripTextBox";
            this.searchToolStripTextBox.Size = new System.Drawing.Size(200, 20);
            this.searchToolStripTextBox.Text = "enter word here...";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(45, 23);
            this.toolStripLabel1.Text = "Search:";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(88, 23);
            this.toolStripLabel2.Text = "Modding tools:";
            // 
            // dbModuleButton
            // 
            this.dbModuleButton.AutoToolTip = false;
            this.dbModuleButton.Enabled = false;
            this.dbModuleButton.Image = ((System.Drawing.Image)(resources.GetObject("dbModuleButton.Image")));
            this.dbModuleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dbModuleButton.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.dbModuleButton.Name = "dbModuleButton";
            this.dbModuleButton.Size = new System.Drawing.Size(75, 23);
            this.dbModuleButton.Text = "Database";
            // 
            // texButton
            // 
            this.texButton.AutoToolTip = false;
            this.texButton.Enabled = false;
            this.texButton.Image = ((System.Drawing.Image)(resources.GetObject("texButton.Image")));
            this.texButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.texButton.Name = "texButton";
            this.texButton.Size = new System.Drawing.Size(71, 23);
            this.texButton.Text = "Textures";
            // 
            // menuStrip
            // 
            this.menuStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip.AutoSize = false;
            this.menuStrip.BackgroundImage = GuiResources.menuBackground;
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.editToolStripMenuItem,
            this.displayToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(0);
            this.menuStrip.Size = new System.Drawing.Size(1008, 20);
            this.menuStrip.TabIndex = 0;
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.backupRestoreToolStripMenuItem,
            this.testToolStripMenuItem,
            this.propertiesToolStripMenuItem,
            this.toolStripSeparator5,
            this.createFolderToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // backupRestoreToolStripMenuItem
            // 
            this.backupRestoreToolStripMenuItem.Enabled = false;
            this.backupRestoreToolStripMenuItem.Name = "backupRestoreToolStripMenuItem";
            this.backupRestoreToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.backupRestoreToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.backupRestoreToolStripMenuItem.Text = "Backup/Restore";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Enabled = false;
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.testToolStripMenuItem.Text = "Test";
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Enabled = false;
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.propertiesToolStripMenuItem.Text = "Properties...";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(195, 6);
            // 
            // createFolderToolStripMenuItem
            // 
            this.createFolderToolStripMenuItem.Enabled = false;
            this.createFolderToolStripMenuItem.Name = "createFolderToolStripMenuItem";
            this.createFolderToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.createFolderToolStripMenuItem.Text = "Create folder...";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(195, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.moveToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator8,
            this.unpackBNKToToolStripMenuItem,
            this.repackBNKToToolStripMenuItem,
            this.replaceToolStripMenuItem,
            this.toolStripSeparator7,
            this.selectAllToolStripMenuItem,
            this.unselectAllToolStripMenuItem,
            this.invertSelectionToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Enabled = false;
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toOtherPaneToolStripMenuItem,
            this.toLocationToolStripMenuItem});
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // toOtherPaneToolStripMenuItem
            // 
            this.toOtherPaneToolStripMenuItem.Enabled = false;
            this.toOtherPaneToolStripMenuItem.Name = "toOtherPaneToolStripMenuItem";
            this.toOtherPaneToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.C)));
            this.toOtherPaneToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.toOtherPaneToolStripMenuItem.Text = "To opposite";
            // 
            // toLocationToolStripMenuItem
            // 
            this.toLocationToolStripMenuItem.Enabled = false;
            this.toLocationToolStripMenuItem.Name = "toLocationToolStripMenuItem";
            this.toLocationToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.toLocationToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.toLocationToolStripMenuItem.Text = "To location...";
            this.toLocationToolStripMenuItem.Click += new System.EventHandler(this.toLocationToolStripMenuItem_Click);
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toOtherPaneToolStripMenuItem1,
            this.toLocationToolStripMenuItem1});
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.moveToolStripMenuItem.Text = "Move";
            // 
            // toOtherPaneToolStripMenuItem1
            // 
            this.toOtherPaneToolStripMenuItem1.Enabled = false;
            this.toOtherPaneToolStripMenuItem1.Name = "toOtherPaneToolStripMenuItem1";
            this.toOtherPaneToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.X)));
            this.toOtherPaneToolStripMenuItem1.Size = new System.Drawing.Size(206, 22);
            this.toOtherPaneToolStripMenuItem1.Text = "To opposite";
            this.toOtherPaneToolStripMenuItem1.Click += new System.EventHandler(this.toOtherPaneToolStripMenuItem1_Click);
            // 
            // toLocationToolStripMenuItem1
            // 
            this.toLocationToolStripMenuItem1.Enabled = false;
            this.toLocationToolStripMenuItem1.Name = "toLocationToolStripMenuItem1";
            this.toLocationToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.toLocationToolStripMenuItem1.Size = new System.Drawing.Size(206, 22);
            this.toLocationToolStripMenuItem1.Text = "To location...";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Enabled = false;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(188, 6);
            // 
            // unpackBNKToToolStripMenuItem
            // 
            this.unpackBNKToToolStripMenuItem.Enabled = false;
            this.unpackBNKToToolStripMenuItem.Name = "unpackBNKToToolStripMenuItem";
            this.unpackBNKToToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.unpackBNKToToolStripMenuItem.Text = "Unpack BNK to...";
            // 
            // repackBNKToToolStripMenuItem
            // 
            this.repackBNKToToolStripMenuItem.Enabled = false;
            this.repackBNKToToolStripMenuItem.Name = "repackBNKToToolStripMenuItem";
            this.repackBNKToToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.repackBNKToToolStripMenuItem.Text = "Repack to BNK...";
            // 
            // replaceToolStripMenuItem
            // 
            this.replaceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataOnlyToolStripMenuItem,
            this.allToolStripMenuItem});
            this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
            this.replaceToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.replaceToolStripMenuItem.Text = "Replace";
            // 
            // dataOnlyToolStripMenuItem
            // 
            this.dataOnlyToolStripMenuItem.Enabled = false;
            this.dataOnlyToolStripMenuItem.Name = "dataOnlyToolStripMenuItem";
            this.dataOnlyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.dataOnlyToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.dataOnlyToolStripMenuItem.Text = "Data only...";
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Enabled = false;
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.R)));
            this.allToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.allToolStripMenuItem.Text = "All...";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(188, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Enabled = false;
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.selectAllToolStripMenuItem.Text = "Select all";
            // 
            // unselectAllToolStripMenuItem
            // 
            this.unselectAllToolStripMenuItem.Enabled = false;
            this.unselectAllToolStripMenuItem.Name = "unselectAllToolStripMenuItem";
            this.unselectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.unselectAllToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.unselectAllToolStripMenuItem.Text = "Unselect all";
            // 
            // invertSelectionToolStripMenuItem
            // 
            this.invertSelectionToolStripMenuItem.Enabled = false;
            this.invertSelectionToolStripMenuItem.Name = "invertSelectionToolStripMenuItem";
            this.invertSelectionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.invertSelectionToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.invertSelectionToolStripMenuItem.Text = "Invert selection";
            // 
            // displayToolStripMenuItem
            // 
            this.displayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.toolStripSeparator3,
            this.largeIconsToolStripMenuItem,
            this.smallIconsToolStripMenuItem,
            this.listToolStripMenuItem,
            this.detailsToolStripMenuItem});
            this.displayToolStripMenuItem.Name = "displayToolStripMenuItem";
            this.displayToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.displayToolStripMenuItem.Text = "Display";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Enabled = false;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(151, 6);
            // 
            // largeIconsToolStripMenuItem
            // 
            this.largeIconsToolStripMenuItem.Enabled = false;
            this.largeIconsToolStripMenuItem.Name = "largeIconsToolStripMenuItem";
            this.largeIconsToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.largeIconsToolStripMenuItem.Text = "Large icons";
            // 
            // smallIconsToolStripMenuItem
            // 
            this.smallIconsToolStripMenuItem.Enabled = false;
            this.smallIconsToolStripMenuItem.Name = "smallIconsToolStripMenuItem";
            this.smallIconsToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.smallIconsToolStripMenuItem.Text = "Small icons";
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.Enabled = false;
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.listToolStripMenuItem.Text = "List";
            // 
            // detailsToolStripMenuItem
            // 
            this.detailsToolStripMenuItem.Enabled = false;
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.detailsToolStripMenuItem.Text = "Details";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customToolStripMenuItem,
            this.toolStripSeparator1,
            this.settingsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // customToolStripMenuItem
            // 
            this.customToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tDUPEToolStripMenuItem});
            this.customToolStripMenuItem.Name = "customToolStripMenuItem";
            this.customToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.customToolStripMenuItem.Text = "Custom";
            // 
            // tDUPEToolStripMenuItem
            // 
            this.tDUPEToolStripMenuItem.Enabled = false;
            this.tDUPEToolStripMenuItem.Name = "tDUPEToolStripMenuItem";
            this.tDUPEToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.NumPad0)));
            this.tDUPEToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.tDUPEToolStripMenuItem.Text = "TDUPE";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(122, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.settingsToolStripMenuItem.Text = "Settings...";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(24, 20);
            this.helpToolStripMenuItem.Text = "?";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Enabled = false;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.aboutToolStripMenuItem.Text = "About TDUMT II...";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // statusPanel
            // 
            this.statusPanel.BackColor = System.Drawing.Color.Transparent;
            this.statusPanel.Controls.Add(this.statusLabel);
            this.statusPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusPanel.ForeColor = System.Drawing.Color.White;
            this.statusPanel.Location = new System.Drawing.Point(0, 538);
            this.statusPanel.Margin = new System.Windows.Forms.Padding(0);
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.Size = new System.Drawing.Size(1008, 24);
            this.statusPanel.TabIndex = 2;
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(7, 4);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(60, 15);
            this.statusLabel.TabIndex = 0;
            this.statusLabel.Text = "Welcome!";
            // 
            // wsPanel
            // 
            this.wsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.wsPanel.BackColor = System.Drawing.SystemColors.Control;
            this.wsPanel.BackgroundImage = GuiResources.wsBackground;
            this.wsPanel.Controls.Add(this.splitContainer);
            this.wsPanel.Location = new System.Drawing.Point(0, 49);
            this.wsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.wsPanel.Name = "wsPanel";
            this.wsPanel.Size = new System.Drawing.Size(1008, 489);
            this.wsPanel.TabIndex = 1;
            this.wsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.wsPanel_Paint);
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.Location = new System.Drawing.Point(10, 10);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer.Panel1.Controls.Add(this.fileBrowsingControl1);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer.Panel2.Controls.Add(this.fileBrowsingControl2);
            this.splitContainer.Size = new System.Drawing.Size(989, 469);
            this.splitContainer.SplitterDistance = 456;
            this.splitContainer.TabIndex = 0;
            // 
            // fileBrowsingControl1
            // 
            this.fileBrowsingControl1.AutoSize = true;
            this.fileBrowsingControl1.CurrentFolder = null;
            this.fileBrowsingControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileBrowsingControl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileBrowsingControl1.Location = new System.Drawing.Point(0, 0);
            this.fileBrowsingControl1.Name = "fileBrowsingControl1";
            this.fileBrowsingControl1.Size = new System.Drawing.Size(454, 467);
            this.fileBrowsingControl1.TabIndex = 0;
            // 
            // fileBrowsingControl2
            // 
            this.fileBrowsingControl2.AutoSize = true;
            this.fileBrowsingControl2.CurrentFolder = null;
            this.fileBrowsingControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileBrowsingControl2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileBrowsingControl2.Location = new System.Drawing.Point(0, 0);
            this.fileBrowsingControl2.Name = "fileBrowsingControl2";
            this.fileBrowsingControl2.Size = new System.Drawing.Size(527, 467);
            this.fileBrowsingControl2.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.ClientSize = new System.Drawing.Size(1008, 562);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.wsPanel);
            this.Controls.Add(this.statusPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm";
            this.Text = "TDUMT II";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.controlPanel.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusPanel.ResumeLayout(false);
            this.statusPanel.PerformLayout();
            this.wsPanel.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Panel wsPanel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.Panel statusPanel;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer;
        private FileBrowsingControl fileBrowsingControl1;
        private FileBrowsingControl fileBrowsingControl2;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem backupRestoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tDUPEToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem createFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toOtherPaneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toOtherPaneToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toLocationToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unselectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertSelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ToolStripTextBox searchToolStripTextBox;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton dbModuleButton;
        private System.Windows.Forms.ToolStripButton texButton;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripMenuItem largeIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smallIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unpackBNKToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem repackBNKToToolStripMenuItem;

    }
}