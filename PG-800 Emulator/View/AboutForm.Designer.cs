using MidiApp.UIControls;

namespace MidiApp.GB800.View
{
    partial class AboutForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
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
            this.okButton = new System.Windows.Forms.Button();
            this.linkGB = new System.Windows.Forms.LinkLabel();
            this.labelIntro = new System.Windows.Forms.Label();
            this.lbDescription = new System.Windows.Forms.Label();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(392, 219);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 31;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = false;
            // 
            // linkGB
            // 
            this.linkGB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.linkGB.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(83)))), ((int)(((byte)(82)))));
            this.linkGB.Location = new System.Drawing.Point(3, 181);
            this.linkGB.Name = "linkGB";
            this.linkGB.Size = new System.Drawing.Size(464, 26);
            this.linkGB.TabIndex = 33;
            this.linkGB.TabStop = true;
            this.linkGB.Text = "http://greg-MidiApp.com";
            this.linkGB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkGB.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(83)))), ((int)(((byte)(82)))));
            this.linkGB.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkGB_LinkClicked);
            // 
            // labelIntro
            // 
            this.labelIntro.BackColor = System.Drawing.Color.Transparent;
            this.labelIntro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIntro.ForeColor = System.Drawing.Color.Black;
            this.labelIntro.Location = new System.Drawing.Point(2, 27);
            this.labelIntro.Name = "labelIntro";
            this.labelIntro.Size = new System.Drawing.Size(190, 90);
            this.labelIntro.TabIndex = 34;
            this.labelIntro.Text = "lbIntro";
            // 
            // lbDescription
            // 
            this.lbDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.lbDescription.Location = new System.Drawing.Point(2, 120);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(469, 61);
            this.lbDescription.TabIndex = 35;
            this.lbDescription.Text = "lbDescription";
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.logoPictureBox.Image = global::MidiApp.GB800.Properties.Resources.About;
            this.logoPictureBox.Location = new System.Drawing.Point(0, 0);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(471, 117);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.logoPictureBox.TabIndex = 26;
            this.logoPictureBox.TabStop = false;
            // 
            // AboutForm
            // 
            this.AccessibleDescription = "About form";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(470, 245);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.labelIntro);
            this.Controls.Add(this.linkGB);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.logoPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.Load += new System.EventHandler(this.AboutFor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.LinkLabel linkGB;
        private System.Windows.Forms.Label labelIntro;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.PictureBox logoPictureBox;

    }
}
