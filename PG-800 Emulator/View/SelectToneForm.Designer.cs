namespace MidiApp.GB800.View
{
    partial class SelectToneForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectToneForm));
            this._toneListView = new System.Windows.Forms.ListView();
            this._imageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // _toneListView
            // 
            this._toneListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._toneListView.LargeImageList = this._imageList;
            this._toneListView.Location = new System.Drawing.Point(12, 12);
            this._toneListView.MultiSelect = false;
            this._toneListView.Name = "_toneListView";
            this._toneListView.Size = new System.Drawing.Size(156, 601);
            this._toneListView.SmallImageList = this._imageList;
            this._toneListView.TabIndex = 0;
            this._toneListView.UseCompatibleStateImageBehavior = false;
            this._toneListView.View = System.Windows.Forms.View.SmallIcon;
            this._toneListView.DoubleClick += new System.EventHandler(this._toneListView_DoubleClick);
            // 
            // _imageList
            // 
            this._imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_imageList.ImageStream")));
            this._imageList.TransparentColor = System.Drawing.Color.Transparent;
            this._imageList.Images.SetKeyName(0, "Banque.ico");
            this._imageList.Images.SetKeyName(1, "Tone.ico");
            // 
            // SelectToneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(180, 625);
            this.Controls.Add(this._toneListView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(182, 229);
            this.Name = "SelectToneForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Tone list";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView _toneListView;
        private System.Windows.Forms.ImageList _imageList;
    }
}
