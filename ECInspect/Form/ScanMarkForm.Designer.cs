namespace ECInspect
{
    partial class ScanMarkForm
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
            this.textBox_Barcode = new System.Windows.Forms.TextBox();
            this.btn_MoveToScanPoint = new ECInspect.ImageButton();
            this.either_Scan = new ECInspect.Either();
            this.btn_ScanPoint = new ECInspect.ImageButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.textBox_Barcode);
            this.splitContainer.Panel1.Controls.Add(this.btn_ScanPoint);
            // 
            // textBox_Barcode
            // 
            this.textBox_Barcode.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Barcode.Location = new System.Drawing.Point(819, 594);
            this.textBox_Barcode.Name = "textBox_Barcode";
            this.textBox_Barcode.Size = new System.Drawing.Size(500, 54);
            this.textBox_Barcode.TabIndex = 7;
            // 
            // btn_MoveToScanPoint
            // 
            this.btn_MoveToScanPoint.Font = new System.Drawing.Font("微软雅黑", 30F, System.Drawing.FontStyle.Bold);
            this.btn_MoveToScanPoint.Location = new System.Drawing.Point(602, 568);
            this.btn_MoveToScanPoint.Name = "btn_MoveToScanPoint";
            this.btn_MoveToScanPoint.Size = new System.Drawing.Size(200, 100);
            this.btn_MoveToScanPoint.TabIndex = 6;
            this.btn_MoveToScanPoint.Text = "扫描条码";
            this.btn_MoveToScanPoint.UseVisualStyleBackColor = true;
            this.btn_MoveToScanPoint.Click += new System.EventHandler(this.btn_MoveToScanPoint_Click);
            // 
            // either_Scan
            // 
            this.either_Scan.BackColor = System.Drawing.SystemColors.Control;
            this.either_Scan.BtnLeftText = "等待位置";
            this.either_Scan.BtnRightText = "扫码位置";
            this.either_Scan.LeftPress = true;
            this.either_Scan.Location = new System.Drawing.Point(602, 412);
            this.either_Scan.Name = "either_Scan";
            this.either_Scan.Size = new System.Drawing.Size(717, 113);
            this.either_Scan.TabIndex = 5;
            this.either_Scan.TabStop = false;
            this.either_Scan.Title = "扫码枪";
            this.either_Scan.Event_BtnClick += new ECInspect.Either.dele_LeftRight(this.either_Scan_Event_BtnClick);
            // 
            // btn_ScanPoint
            // 
            this.btn_ScanPoint.Font = new System.Drawing.Font("微软雅黑", 30F, System.Drawing.FontStyle.Bold);
            this.btn_ScanPoint.Location = new System.Drawing.Point(602, 702);
            this.btn_ScanPoint.Name = "btn_ScanPoint";
            this.btn_ScanPoint.Size = new System.Drawing.Size(200, 100);
            this.btn_ScanPoint.TabIndex = 8;
            this.btn_ScanPoint.Text = "连续扫码";
            this.btn_ScanPoint.UseVisualStyleBackColor = true;
            this.btn_ScanPoint.Visible = false;
            this.btn_ScanPoint.Click += new System.EventHandler(this.btn_ScanPoint_Click);
            // 
            // ScanMarkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.btn_MoveToScanPoint);
            this.Controls.Add(this.either_Scan);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ScanMarkForm";
            this.Text = "ScanMarkForm";
            this.Controls.SetChildIndex(this.splitContainer, 0);
            this.Controls.SetChildIndex(this.either_Scan, 0);
            this.Controls.SetChildIndex(this.btn_MoveToScanPoint, 0);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Barcode;
        private ImageButton btn_MoveToScanPoint;
        private Either either_Scan;
        private ImageButton btn_ScanPoint;
    }
}