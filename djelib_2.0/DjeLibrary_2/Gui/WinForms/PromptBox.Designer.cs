namespace DjeLibrary_2.Forms.Dialogs
{
    partial class PromptBox
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
            this.customLabel = new global::System.Windows.Forms.Label();
            this.promptTextBox = new global::System.Windows.Forms.TextBox();
            this.okButton = new global::System.Windows.Forms.Button();
            this.panel1 = new global::System.Windows.Forms.Panel();
            this.iconBox = new global::System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.iconBox)).BeginInit();
            this.SuspendLayout();
            // 
            // customLabel
            // 
            this.customLabel.Font = new global::System.Drawing.Font("Segoe UI", 9F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customLabel.Location = new global::System.Drawing.Point(53, 12);
            this.customLabel.Name = "customLabel";
            this.customLabel.Size = new global::System.Drawing.Size(276, 35);
            this.customLabel.TabIndex = 0;
            this.customLabel.Text = "<Custom message>";
            this.customLabel.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // promptTextBox
            // 
            this.promptTextBox.Font = new global::System.Drawing.Font("Segoe UI", 9F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.promptTextBox.Location = new global::System.Drawing.Point(12, 54);
            this.promptTextBox.Name = "promptTextBox";
            this.promptTextBox.Size = new global::System.Drawing.Size(317, 23);
            this.promptTextBox.TabIndex = 1;
            this.promptTextBox.Text = "<Input field>";
            this.promptTextBox.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.promptTextBox_KeyDown);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((global::System.Windows.Forms.AnchorStyles)((global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Font = new global::System.Drawing.Font("Segoe UI", 9F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButton.Location = new global::System.Drawing.Point(242, 103);
            this.okButton.Name = "okButton";
            this.okButton.Size = new global::System.Drawing.Size(87, 27);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new global::System.EventHandler(this.okButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((global::System.Windows.Forms.AnchorStyles)((((global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom)
                        | global::System.Windows.Forms.AnchorStyles.Left)
                        | global::System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = global::System.Drawing.Color.White;
            this.panel1.Controls.Add(this.iconBox);
            this.panel1.Controls.Add(this.customLabel);
            this.panel1.Controls.Add(this.promptTextBox);
            this.panel1.Location = new global::System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new global::System.Drawing.Size(344, 89);
            this.panel1.TabIndex = 0;
            // 
            // iconBox
            // 
            this.iconBox.Image = global::DjeLibrary_2.Properties.Resources.prepare32;
            this.iconBox.Location = new global::System.Drawing.Point(12, 12);
            this.iconBox.Name = "iconBox";
            this.iconBox.Size = new global::System.Drawing.Size(35, 35);
            this.iconBox.TabIndex = 2;
            this.iconBox.TabStop = false;
            // 
            // PromptBox
            // 
            this.AutoScaleDimensions = new global::System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new global::System.Drawing.Size(341, 142);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.okButton);
            this.Font = new global::System.Drawing.Font("Segoe UI", 9F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PromptBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "<Custom title>";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.iconBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected global::System.Windows.Forms.Label customLabel;
        protected global::System.Windows.Forms.TextBox promptTextBox;
        protected global::System.Windows.Forms.Button okButton;
        private global::System.Windows.Forms.Panel panel1;
        private global::System.Windows.Forms.PictureBox iconBox;
    }
}