using global::System.Windows.Forms;

namespace DjeLibrary_2.Gui.WinForms
{
    partial class AboutBox
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private global::System.ComponentModel.IContainer components = null;

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

        #region Code généré par le Concepteur Windows Form
        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOK = new global::System.Windows.Forms.Button();
            this.txtMessage = new global::System.Windows.Forms.TextBox();
            this.lblApplication = new global::System.Windows.Forms.Label();
            this.lblVersion = new global::System.Windows.Forms.Label();
            this.lblCompany = new global::System.Windows.Forms.Label();
            this.lblCustom = new global::System.Windows.Forms.Label();
            this.panel1 = new global::System.Windows.Forms.Panel();
            this.imgCustom = new global::System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.imgCustom)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((global::System.Windows.Forms.AnchorStyles)((global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = global::System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new global::System.Drawing.Font("Segoe UI", 9F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new global::System.Drawing.Point(245, 177);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new global::System.Drawing.Size(87, 27);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = global::System.Drawing.SystemColors.Window;
            this.txtMessage.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
            this.txtMessage.Cursor = global::System.Windows.Forms.Cursors.Default;
            this.txtMessage.Font = new global::System.Drawing.Font("Segoe UI", 9F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new global::System.Drawing.Point(11, 106);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new global::System.Drawing.Size(320, 54);
            this.txtMessage.TabIndex = 4;
            this.txtMessage.TabStop = false;
            this.txtMessage.Text = "<custom message>";
            this.txtMessage.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMessage.Visible = false;
            // 
            // lblApplication
            // 
            this.lblApplication.Font = new global::System.Drawing.Font("Segoe UI", 12F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplication.ForeColor = global::System.Drawing.SystemColors.HotTrack;
            this.lblApplication.Location = new global::System.Drawing.Point(105, 12);
            this.lblApplication.Name = "lblApplication";
            this.lblApplication.Size = new global::System.Drawing.Size(226, 23);
            this.lblApplication.TabIndex = 0;
            this.lblApplication.Text = "<Application>";
            this.lblApplication.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new global::System.Drawing.Font("Segoe UI", 8.25F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new global::System.Drawing.Point(12, 194);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new global::System.Drawing.Size(58, 13);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "Version ...";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new global::System.Drawing.Font("Segoe UI", 9F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.Location = new global::System.Drawing.Point(105, 44);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new global::System.Drawing.Size(74, 15);
            this.lblCompany.TabIndex = 2;
            this.lblCompany.Text = "<copyright>";
            // 
            // lblCustom
            // 
            this.lblCustom.Font = new global::System.Drawing.Font("Segoe UI", 9F, global::System.Drawing.FontStyle.Italic, global::System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustom.Location = new global::System.Drawing.Point(105, 69);
            this.lblCustom.Name = "lblCustom";
            this.lblCustom.Size = new global::System.Drawing.Size(226, 31);
            this.lblCustom.TabIndex = 3;
            this.lblCustom.Text = "<custom information>";
            this.lblCustom.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = global::System.Drawing.Color.White;
            this.panel1.Controls.Add(this.imgCustom);
            this.panel1.Controls.Add(this.txtMessage);
            this.panel1.Controls.Add(this.lblCustom);
            this.panel1.Controls.Add(this.lblApplication);
            this.panel1.Controls.Add(this.lblCompany);
            this.panel1.Location = new global::System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new global::System.Drawing.Size(344, 163);
            this.panel1.TabIndex = 6;
            // 
            // imgCustom
            // 
            this.imgCustom.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgCustom.Image = global::DjeLibrary_2.Properties.Resources.aboutStars_98px;
            this.imgCustom.Location = new global::System.Drawing.Point(11, 12);
            this.imgCustom.Name = "imgCustom";
            this.imgCustom.Size = new global::System.Drawing.Size(88, 88);
            this.imgCustom.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgCustom.TabIndex = 2;
            this.imgCustom.TabStop = false;
            // 
            // AboutBox
            // 
            this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
            this.ClientSize = new global::System.Drawing.Size(344, 216);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblVersion);
            this.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.ShowInTaskbar = false;
            this.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AboutBox";
            this.Load += new global::System.EventHandler(this.AboutBox_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.imgCustom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private Button btnOK;
        private TextBox txtMessage;
        private PictureBox imgCustom;
        private Label lblApplication;
        private Label lblVersion;
        private Label lblCompany;
        private Label lblCustom;
        private Panel panel1;
    }
}
