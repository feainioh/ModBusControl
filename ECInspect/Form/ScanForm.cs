namespace ECInspect
{
    internal class ScanForm : Frame
    {
        private Either either_Scan;
        private System.Windows.Forms.TextBox textBox_Barcode;
        private ImageButton btn_MoveToScanPoint;

        private void InitializeComponent()
        {
            this.either_Scan = new ECInspect.Either();
            this.btn_MoveToScanPoint = new ECInspect.ImageButton();
            this.textBox_Barcode = new System.Windows.Forms.TextBox();
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
            this.splitContainer.Panel1.Controls.Add(this.btn_MoveToScanPoint);
            // 
            // either_Scan
            // 
            this.either_Scan.BackColor = System.Drawing.SystemColors.Control;
            this.either_Scan.BtnLeftText = "等待位置";
            this.either_Scan.BtnRightText = "扫码位置";
            this.either_Scan.LeftPress = true;
            this.either_Scan.Location = new System.Drawing.Point(602, 106);
            this.either_Scan.Name = "either_Scan";
            this.either_Scan.Size = new System.Drawing.Size(717, 113);
            this.either_Scan.TabIndex = 2;
            this.either_Scan.TabStop = false;
            this.either_Scan.Title = "扫码枪";
            this.either_Scan.Event_BtnClick += new ECInspect.Either.dele_LeftRight(this.either_Scan_Event_BtnClick);
            // 
            // btn_MoveToScanPoint
            // 
            this.btn_MoveToScanPoint.Font = new System.Drawing.Font("微软雅黑", 30F, System.Drawing.FontStyle.Bold);
            this.btn_MoveToScanPoint.Location = new System.Drawing.Point(602, 262);
            this.btn_MoveToScanPoint.Name = "btn_MoveToScanPoint";
            this.btn_MoveToScanPoint.Size = new System.Drawing.Size(200, 100);
            this.btn_MoveToScanPoint.TabIndex = 3;
            this.btn_MoveToScanPoint.Text = "扫描条码";
            this.btn_MoveToScanPoint.UseVisualStyleBackColor = true;
            this.btn_MoveToScanPoint.Click += new System.EventHandler(this.btn_MoveToScanPoint_Click);
            // 
            // textBox_Barcode
            // 
            this.textBox_Barcode.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Barcode.Location = new System.Drawing.Point(819, 288);
            this.textBox_Barcode.Name = "textBox_Barcode";
            this.textBox_Barcode.Size = new System.Drawing.Size(500, 54);
            this.textBox_Barcode.TabIndex = 4;
            // 
            // ScanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.either_Scan);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ScanForm";
            this.Controls.SetChildIndex(this.splitContainer, 0);
            this.Controls.SetChildIndex(this.either_Scan, 0);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void btn_MoveToScanPoint_Click(object sender, System.EventArgs e)
        {
            string barcode = "";
            if (GlobalVar.gl_Scan.StartScan(barcode)) textBox_Barcode.Text = barcode;
        }

        private void either_DownJig_Event_BtnClick(LeftRightSide lr)
        {
            switch (lr)
            {
                case LeftRightSide.Left:
                    GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.YSignLocation, false);
                    break;
                case LeftRightSide.Right:
                    GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.YSignLocation, true);
                    break;
            }
        }

        private void either_Scan_Event_BtnClick(LeftRightSide lr)
        {
            switch (lr)
            {
                case LeftRightSide.Left:
                    GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.ScanPosition, false);
                    break;
                case LeftRightSide.Right:
                    GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.ScanPosition, true);
                    break;
            }
        }
    }
}