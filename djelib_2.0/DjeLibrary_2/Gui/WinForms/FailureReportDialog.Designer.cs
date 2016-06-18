namespace DjeLibrary_2.Gui.WinForms
{
    partial class FailureReportDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private global::System.ComponentModel.IContainer components = null;

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
            this.failureLabel = new global::System.Windows.Forms.Label();
            this.stackTextBox = new global::System.Windows.Forms.TextBox();
            this.copyButton = new global::System.Windows.Forms.Button();
            this.label2 = new global::System.Windows.Forms.Label();
            this.saveButton = new global::System.Windows.Forms.Button();
            this.closeButton = new global::System.Windows.Forms.Button();
            this.panel1 = new global::System.Windows.Forms.Panel();
            this.iconBox = new global::System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.iconBox)).BeginInit();
            this.SuspendLayout();
            // 
            // failureLabel
            // 
            this.failureLabel.Anchor = ((global::System.Windows.Forms.AnchorStyles)(((global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left)
                        | global::System.Windows.Forms.AnchorStyles.Right)));
            this.failureLabel.Font = new global::System.Drawing.Font("Segoe UI", 9F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.failureLabel.Location = new global::System.Drawing.Point(55, 12);
            this.failureLabel.Name = "failureLabel";
            this.failureLabel.Size = new global::System.Drawing.Size(336, 35);
            this.failureLabel.TabIndex = 0;
            this.failureLabel.Text = "Sorry, <application> has failed. Here are the details:";
            // 
            // stackTextBox
            // 
            this.stackTextBox.Anchor = ((global::System.Windows.Forms.AnchorStyles)((((global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom)
                        | global::System.Windows.Forms.AnchorStyles.Left)
                        | global::System.Windows.Forms.AnchorStyles.Right)));
            this.stackTextBox.BackColor = global::System.Drawing.Color.White;
            this.stackTextBox.Font = new global::System.Drawing.Font("Lucida Console", 9F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stackTextBox.Location = new global::System.Drawing.Point(14, 54);
            this.stackTextBox.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
            this.stackTextBox.Multiline = true;
            this.stackTextBox.Name = "stackTextBox";
            this.stackTextBox.ReadOnly = true;
            this.stackTextBox.Size = new global::System.Drawing.Size(377, 287);
            this.stackTextBox.TabIndex = 1;
            // 
            // copyButton
            // 
            this.copyButton.Anchor = ((global::System.Windows.Forms.AnchorStyles)((global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left)));
            this.copyButton.Font = new global::System.Drawing.Font("Segoe UI", 9F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyButton.Location = new global::System.Drawing.Point(12, 385);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new global::System.Drawing.Size(91, 29);
            this.copyButton.TabIndex = 3;
            this.copyButton.Text = "Copy";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new global::System.EventHandler(this.copyButton_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((global::System.Windows.Forms.AnchorStyles)((global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new global::System.Drawing.Font("Segoe UI", 9F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new global::System.Drawing.Point(14, 345);
            this.label2.Name = "label2";
            this.label2.Size = new global::System.Drawing.Size(214, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Please submit those details for analysis.";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((global::System.Windows.Forms.AnchorStyles)((global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left)));
            this.saveButton.Font = new global::System.Drawing.Font("Segoe UI", 9F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new global::System.Drawing.Point(109, 385);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new global::System.Drawing.Size(91, 29);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save...";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new global::System.EventHandler(this.saveButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((global::System.Windows.Forms.AnchorStyles)((global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left)));
            this.closeButton.DialogResult = global::System.Windows.Forms.DialogResult.OK;
            this.closeButton.Font = new global::System.Drawing.Font("Segoe UI", 9F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Location = new global::System.Drawing.Point(298, 385);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new global::System.Drawing.Size(91, 29);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new global::System.EventHandler(this.closeButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = global::System.Drawing.Color.White;
            this.panel1.Controls.Add(this.iconBox);
            this.panel1.Controls.Add(this.failureLabel);
            this.panel1.Controls.Add(this.stackTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new global::System.Drawing.Point(-2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new global::System.Drawing.Size(403, 371);
            this.panel1.TabIndex = 6;
            // 
            // iconBox
            // 
            this.iconBox.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
            this.iconBox.Image = global::DjeLibrary_2.Properties.Resources.Caution_32px;
            this.iconBox.Location = new global::System.Drawing.Point(14, 12);
            this.iconBox.Name = "iconBox";
            this.iconBox.Size = new global::System.Drawing.Size(35, 35);
            this.iconBox.TabIndex = 3;
            this.iconBox.TabStop = false;
            // 
            // FailureReportDialog
            // 
            this.AutoScaleDimensions = new global::System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new global::System.Drawing.Size(401, 426);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.copyButton);
            this.Font = new global::System.Drawing.Font("Segoe UI", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FailureReportDialog";
            this.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Failure report...";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.iconBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private global::System.Windows.Forms.Label failureLabel;
        private global::System.Windows.Forms.TextBox stackTextBox;
        private global::System.Windows.Forms.Button copyButton;
        private global::System.Windows.Forms.Label label2;
        private global::System.Windows.Forms.Button saveButton;
        private global::System.Windows.Forms.Button closeButton;
        private global::System.Windows.Forms.Panel panel1;
        private global::System.Windows.Forms.PictureBox iconBox;
    }
}