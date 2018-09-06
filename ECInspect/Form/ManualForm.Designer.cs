namespace ECInspect
{
    partial class ManualForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManualForm));
            this.btn_MoveToProduct = new ECInspect.ImageButton();
            this.btn_MoveToNazzie = new ECInspect.ImageButton();
            this.btn_MoveToEdge = new ECInspect.ImageButton();
            this.btn_AdjustNozzle = new ECInspect.ImageButton();
            this.btn_Mark = new ECInspect.ImageButton();
            this.btn_Disassemble = new ECInspect.ImageButton();
            this.either_Press = new ECInspect.Either();
            this.either_DiNianZhe = new ECInspect.Either();
            this.btn_MoveToCCD = new ECInspect.ImageButton();
            this.btn_CCD = new ECInspect.ImageButton();
            this.either_DownJigCylinder = new ECInspect.Either();
            this.btn_MoveToScanPoint = new ECInspect.ImageButton();
            this.btn_ScanPoint = new ECInspect.ImageButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Font = new System.Drawing.Font("SimSun", 9F);
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.btn_MoveToScanPoint);
            this.splitContainer.Panel1.Controls.Add(this.btn_ScanPoint);
            this.splitContainer.Panel1.Controls.Add(this.either_DiNianZhe);
            this.splitContainer.Panel1.Controls.Add(this.either_DownJigCylinder);
            this.splitContainer.Panel1.Controls.Add(this.either_Press);
            this.splitContainer.Panel1.Controls.Add(this.btn_MoveToEdge);
            this.splitContainer.Panel1.Controls.Add(this.btn_MoveToNazzie);
            this.splitContainer.Panel1.Controls.Add(this.btn_Disassemble);
            this.splitContainer.Panel1.Controls.Add(this.btn_Mark);
            this.splitContainer.Panel1.Controls.Add(this.btn_CCD);
            this.splitContainer.Panel1.Controls.Add(this.btn_AdjustNozzle);
            this.splitContainer.Panel1.Controls.Add(this.btn_MoveToCCD);
            this.splitContainer.Panel1.Controls.Add(this.btn_MoveToProduct);
            this.splitContainer.Panel1.Font = new System.Drawing.Font("SimSun", 9F);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Font = new System.Drawing.Font("SimSun", 9F);
            // 
            // btn_MoveToProduct
            // 
            this.btn_MoveToProduct.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_MoveToProduct.Location = new System.Drawing.Point(305, 42);
            this.btn_MoveToProduct.Name = "btn_MoveToProduct";
            this.btn_MoveToProduct.Size = new System.Drawing.Size(380, 120);
            this.btn_MoveToProduct.TabIndex = 0;
            this.btn_MoveToProduct.Text = "治具位置";
            this.btn_MoveToProduct.UseVisualStyleBackColor = true;
            this.btn_MoveToProduct.Click += new System.EventHandler(this.btn_MoveToProduct_Click);
            // 
            // btn_MoveToNazzie
            // 
            this.btn_MoveToNazzie.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_MoveToNazzie.Location = new System.Drawing.Point(305, 340);
            this.btn_MoveToNazzie.Name = "btn_MoveToNazzie";
            this.btn_MoveToNazzie.Size = new System.Drawing.Size(380, 120);
            this.btn_MoveToNazzie.TabIndex = 0;
            this.btn_MoveToNazzie.Text = "逆向放置位置";
            this.btn_MoveToNazzie.UseVisualStyleBackColor = true;
            this.btn_MoveToNazzie.Click += new System.EventHandler(this.btn_MoveToNazzie_Click);
            // 
            // btn_MoveToEdge
            // 
            this.btn_MoveToEdge.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_MoveToEdge.Location = new System.Drawing.Point(305, 489);
            this.btn_MoveToEdge.Name = "btn_MoveToEdge";
            this.btn_MoveToEdge.Size = new System.Drawing.Size(380, 120);
            this.btn_MoveToEdge.TabIndex = 0;
            this.btn_MoveToEdge.Text = "放置位置";
            this.btn_MoveToEdge.UseVisualStyleBackColor = true;
            this.btn_MoveToEdge.Click += new System.EventHandler(this.btn_MoveToEdge_Click);
            // 
            // btn_AdjustNozzle
            // 
            this.btn_AdjustNozzle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_AdjustNozzle.FlatAppearance.BorderSize = 6;
            this.btn_AdjustNozzle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AdjustNozzle.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_AdjustNozzle.Location = new System.Drawing.Point(806, 42);
            this.btn_AdjustNozzle.Name = "btn_AdjustNozzle";
            this.btn_AdjustNozzle.Size = new System.Drawing.Size(380, 120);
            this.btn_AdjustNozzle.TabIndex = 0;
            this.btn_AdjustNozzle.Text = "吸附装置调整";
            this.btn_AdjustNozzle.UseVisualStyleBackColor = false;
            this.btn_AdjustNozzle.Click += new System.EventHandler(this.btn_AdjustNozzle_Click);
            // 
            // btn_Mark
            // 
            this.btn_Mark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_Mark.FlatAppearance.BorderSize = 6;
            this.btn_Mark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Mark.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Mark.Location = new System.Drawing.Point(806, 340);
            this.btn_Mark.Name = "btn_Mark";
            this.btn_Mark.Size = new System.Drawing.Size(380, 120);
            this.btn_Mark.TabIndex = 0;
            this.btn_Mark.Text = "打标菜单";
            this.btn_Mark.UseVisualStyleBackColor = false;
            this.btn_Mark.Click += new System.EventHandler(this.btn_Mark_Click);
            // 
            // btn_Disassemble
            // 
            this.btn_Disassemble.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_Disassemble.FlatAppearance.BorderSize = 6;
            this.btn_Disassemble.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Disassemble.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Disassemble.Location = new System.Drawing.Point(1192, 42);
            this.btn_Disassemble.Name = "btn_Disassemble";
            this.btn_Disassemble.Size = new System.Drawing.Size(380, 120);
            this.btn_Disassemble.TabIndex = 0;
            this.btn_Disassemble.Text = "上治具拆卸";
            this.btn_Disassemble.UseVisualStyleBackColor = false;
            this.btn_Disassemble.Click += new System.EventHandler(this.btn_Disassemble_Click);
            // 
            // either_Press
            // 
            this.either_Press.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.either_Press.BtnLeftText = "上升";
            this.either_Press.BtnRightText = "下降";
            this.either_Press.LeftPress = true;
            this.either_Press.Location = new System.Drawing.Point(1191, 647);
            this.either_Press.Name = "either_Press";
            this.either_Press.Size = new System.Drawing.Size(717, 113);
            this.either_Press.TabIndex = 1;
            this.either_Press.Title = "  压合装置";
            this.either_Press.Event_BtnClick += new ECInspect.Either.dele_LeftRight(this.either_Press_Event_BtnClick);
            // 
            // either_DiNianZhe
            // 
            this.either_DiNianZhe.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.either_DiNianZhe.BtnLeftText = "打开";
            this.either_DiNianZhe.BtnRightText = "关闭";
            this.either_DiNianZhe.LeftPress = true;
            this.either_DiNianZhe.Location = new System.Drawing.Point(1191, 790);
            this.either_DiNianZhe.Name = "either_DiNianZhe";
            this.either_DiNianZhe.Size = new System.Drawing.Size(717, 113);
            this.either_DiNianZhe.TabIndex = 1;
            this.either_DiNianZhe.Title = "低粘着";
            this.either_DiNianZhe.Visible = false;
            this.either_DiNianZhe.Event_BtnClick += new ECInspect.Either.dele_LeftRight(this.either_DiNianZhe_Event_BtnClick);
            // 
            // btn_MoveToCCD
            // 
            this.btn_MoveToCCD.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_MoveToCCD.Location = new System.Drawing.Point(305, 191);
            this.btn_MoveToCCD.Name = "btn_MoveToCCD";
            this.btn_MoveToCCD.Size = new System.Drawing.Size(380, 120);
            this.btn_MoveToCCD.TabIndex = 0;
            this.btn_MoveToCCD.Text = "相机位置";
            this.btn_MoveToCCD.UseVisualStyleBackColor = true;
            this.btn_MoveToCCD.Click += new System.EventHandler(this.btn_MoveToCCD_Click);
            // 
            // btn_CCD
            // 
            this.btn_CCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_CCD.FlatAppearance.BorderSize = 6;
            this.btn_CCD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CCD.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CCD.Location = new System.Drawing.Point(806, 191);
            this.btn_CCD.Name = "btn_CCD";
            this.btn_CCD.Size = new System.Drawing.Size(380, 120);
            this.btn_CCD.TabIndex = 0;
            this.btn_CCD.Text = "相机调整";
            this.btn_CCD.UseVisualStyleBackColor = false;
            this.btn_CCD.Click += new System.EventHandler(this.btn_CCD_Click);
            // 
            // either_DownJigCylinder
            // 
            this.either_DownJigCylinder.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.either_DownJigCylinder.BtnLeftText = "气缸打开";
            this.either_DownJigCylinder.BtnRightText = "气缸关闭";
            this.either_DownJigCylinder.LeftPress = true;
            this.either_DownJigCylinder.Location = new System.Drawing.Point(347, 790);
            this.either_DownJigCylinder.Name = "either_DownJigCylinder";
            this.either_DownJigCylinder.Size = new System.Drawing.Size(717, 113);
            this.either_DownJigCylinder.TabIndex = 1;
            this.either_DownJigCylinder.Title = "下治具电磁阀";
            this.either_DownJigCylinder.Event_BtnClick += new ECInspect.Either.dele_LeftRight(this.either_DownJigCylinder_Event_BtnClick);
            // 
            // btn_MoveToScanPoint
            // 
            this.btn_MoveToScanPoint.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_MoveToScanPoint.Location = new System.Drawing.Point(305, 640);
            this.btn_MoveToScanPoint.Name = "btn_MoveToScanPoint";
            this.btn_MoveToScanPoint.Size = new System.Drawing.Size(380, 120);
            this.btn_MoveToScanPoint.TabIndex = 2;
            this.btn_MoveToScanPoint.Text = "扫描位置";
            this.btn_MoveToScanPoint.UseVisualStyleBackColor = true;
            this.btn_MoveToScanPoint.Click += new System.EventHandler(this.btn_MoveToScanPoint_Click_1);
            // 
            // btn_ScanPoint
            // 
            this.btn_ScanPoint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_ScanPoint.FlatAppearance.BorderSize = 6;
            this.btn_ScanPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ScanPoint.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ScanPoint.Location = new System.Drawing.Point(806, 489);
            this.btn_ScanPoint.Name = "btn_ScanPoint";
            this.btn_ScanPoint.Size = new System.Drawing.Size(380, 120);
            this.btn_ScanPoint.TabIndex = 3;
            this.btn_ScanPoint.Text = "扫码调整";
            this.btn_ScanPoint.UseVisualStyleBackColor = false;
            this.btn_ScanPoint.Click += new System.EventHandler(this.btn_ScanPoint_Click);
            // 
            // ManualForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ManualForm";
            this.Text = "ManualForm";
            this.Load += new System.EventHandler(this.ManualForm_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ImageButton btn_MoveToProduct;
        private ImageButton btn_MoveToEdge;
        private ImageButton btn_MoveToNazzie;
        private ImageButton btn_Disassemble;
        private ImageButton btn_Mark;
        private ImageButton btn_AdjustNozzle;
        private Either either_Press;
        private Either either_DiNianZhe;
        private ImageButton btn_CCD;
        private ImageButton btn_MoveToCCD;
        private Either either_DownJigCylinder;
        private ImageButton btn_MoveToScanPoint;
        private ImageButton btn_ScanPoint;
    }
}