namespace ECInspect
{
    partial class Loading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loading));
            this.label_Show = new System.Windows.Forms.Label();
            this.label_Wifi = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_Show
            // 
            this.label_Show.Font = new System.Drawing.Font("Microsoft YaHei", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Show.Location = new System.Drawing.Point(53, 348);
            this.label_Show.Name = "label_Show";
            this.label_Show.Size = new System.Drawing.Size(681, 216);
            this.label_Show.TabIndex = 0;
            this.label_Show.Text = "----";
            this.label_Show.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_Wifi
            // 
            this.label_Wifi.Image = ((System.Drawing.Image)(resources.GetObject("label_Wifi.Image")));
            this.label_Wifi.Location = new System.Drawing.Point(292, 22);
            this.label_Wifi.Name = "label_Wifi";
            this.label_Wifi.Size = new System.Drawing.Size(220, 220);
            this.label_Wifi.TabIndex = 1;
            // 
            // Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.label_Wifi);
            this.Controls.Add(this.label_Show);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Loading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading";
            this.Load += new System.EventHandler(this.Loading_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_Show;
        private System.Windows.Forms.Label label_Wifi;
    }
}