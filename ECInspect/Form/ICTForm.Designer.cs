namespace ECInspect
{
    partial class ICTForm
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
            this.btn_Tester = new ECInspect.ImageButton();
            this.btn_GroupNum = new ECInspect.ImageButton();
            this.either_Remote = new ECInspect.Either();
            this.btn_ReadCard = new ECInspect.ImageButton();
            this.textBox_CardContent = new System.Windows.Forms.TextBox();
            this.either_BarcodeGun = new ECInspect.Either();
            this.gb_scanMode = new ECInspect.GroupBoxEx();
            this.rb_GunScan = new System.Windows.Forms.RadioButton();
            this.rb_scan = new System.Windows.Forms.RadioButton();
            this.either_UpToSql = new ECInspect.Either();
            this.cb_Product = new System.Windows.Forms.ComboBox();
            this.lb_Product = new System.Windows.Forms.Label();
            this.groupBoxEx1 = new ECInspect.GroupBoxEx();
            this.radioButton_FirstMachine = new System.Windows.Forms.RadioButton();
            this.radioButton_SecondMachine = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.gb_scanMode.SuspendLayout();
            this.groupBoxEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.groupBoxEx1);
            this.splitContainer.Panel1.Controls.Add(this.lb_Product);
            this.splitContainer.Panel1.Controls.Add(this.cb_Product);
            this.splitContainer.Panel1.Controls.Add(this.either_UpToSql);
            this.splitContainer.Panel1.Controls.Add(this.gb_scanMode);
            this.splitContainer.Panel1.Controls.Add(this.textBox_CardContent);
            this.splitContainer.Panel1.Controls.Add(this.either_BarcodeGun);
            this.splitContainer.Panel1.Controls.Add(this.either_Remote);
            this.splitContainer.Panel1.Controls.Add(this.btn_ReadCard);
            this.splitContainer.Panel1.Controls.Add(this.btn_GroupNum);
            this.splitContainer.Panel1.Controls.Add(this.btn_Tester);
            // 
            // btn_Tester
            // 
            this.btn_Tester.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Tester.BackColor = System.Drawing.Color.Lime;
            this.btn_Tester.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Tester.Location = new System.Drawing.Point(738, 56);
            this.btn_Tester.Name = "btn_Tester";
            this.btn_Tester.Size = new System.Drawing.Size(380, 120);
            this.btn_Tester.TabIndex = 3;
            this.btn_Tester.Text = "Tester";
            this.btn_Tester.UseVisualStyleBackColor = false;
            this.btn_Tester.Click += new System.EventHandler(this.btn_Tester_Click);
            // 
            // btn_GroupNum
            // 
            this.btn_GroupNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_GroupNum.BackColor = System.Drawing.Color.Lime;
            this.btn_GroupNum.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_GroupNum.Location = new System.Drawing.Point(738, 473);
            this.btn_GroupNum.Name = "btn_GroupNum";
            this.btn_GroupNum.Size = new System.Drawing.Size(380, 120);
            this.btn_GroupNum.TabIndex = 3;
            this.btn_GroupNum.Text = "Group Num";
            this.btn_GroupNum.UseVisualStyleBackColor = false;
            this.btn_GroupNum.Click += new System.EventHandler(this.btn_GroupNum_Click);
            // 
            // either_Remote
            // 
            this.either_Remote.BackColor = System.Drawing.SystemColors.Control;
            this.either_Remote.BtnLeftText = "ON";
            this.either_Remote.BtnRightText = "OFF";
            this.either_Remote.LeftPress = true;
            this.either_Remote.Location = new System.Drawing.Point(571, 200);
            this.either_Remote.Name = "either_Remote";
            this.either_Remote.Size = new System.Drawing.Size(740, 113);
            this.either_Remote.TabIndex = 4;
            this.either_Remote.Title = "Remote";
            // 
            // btn_ReadCard
            // 
            this.btn_ReadCard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ReadCard.BackColor = System.Drawing.Color.Lime;
            this.btn_ReadCard.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ReadCard.Location = new System.Drawing.Point(738, 644);
            this.btn_ReadCard.Name = "btn_ReadCard";
            this.btn_ReadCard.Size = new System.Drawing.Size(380, 120);
            this.btn_ReadCard.TabIndex = 3;
            this.btn_ReadCard.Text = "Read Card";
            this.btn_ReadCard.UseVisualStyleBackColor = false;
            this.btn_ReadCard.Click += new System.EventHandler(this.btn_ReadCard_Click);
            // 
            // textBox_CardContent
            // 
            this.textBox_CardContent.Font = new System.Drawing.Font("微软雅黑", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_CardContent.Location = new System.Drawing.Point(1169, 660);
            this.textBox_CardContent.Name = "textBox_CardContent";
            this.textBox_CardContent.Size = new System.Drawing.Size(380, 81);
            this.textBox_CardContent.TabIndex = 5;
            // 
            // either_BarcodeGun
            // 
            this.either_BarcodeGun.BackColor = System.Drawing.SystemColors.Control;
            this.either_BarcodeGun.BtnLeftText = "使用";
            this.either_BarcodeGun.BtnRightText = "停用";
            this.either_BarcodeGun.LeftPress = true;
            this.either_BarcodeGun.Location = new System.Drawing.Point(378, 808);
            this.either_BarcodeGun.Name = "either_BarcodeGun";
            this.either_BarcodeGun.Size = new System.Drawing.Size(740, 113);
            this.either_BarcodeGun.TabIndex = 4;
            this.either_BarcodeGun.Title = "条码枪";
            this.either_BarcodeGun.Event_BtnClick += new ECInspect.Either.dele_LeftRight(this.either_BarcodeGun_Event_BtnClick);
            // 
            // gb_scanMode
            // 
            this.gb_scanMode.Controls.Add(this.rb_GunScan);
            this.gb_scanMode.Controls.Add(this.rb_scan);
            this.gb_scanMode.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gb_scanMode.Location = new System.Drawing.Point(1166, 809);
            this.gb_scanMode.Name = "gb_scanMode";
            this.gb_scanMode.Radius = 10;
            this.gb_scanMode.Size = new System.Drawing.Size(380, 110);
            this.gb_scanMode.TabIndex = 6;
            this.gb_scanMode.TabStop = false;
            this.gb_scanMode.Text = "扫码模式";
            this.gb_scanMode.TitleFont = new System.Drawing.Font("宋体", 10F);
            this.gb_scanMode.Visible = false;
            // 
            // rb_GunScan
            // 
            this.rb_GunScan.AutoSize = true;
            this.rb_GunScan.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Bold);
            this.rb_GunScan.Location = new System.Drawing.Point(3, 34);
            this.rb_GunScan.Name = "rb_GunScan";
            this.rb_GunScan.Size = new System.Drawing.Size(168, 40);
            this.rb_GunScan.TabIndex = 0;
            this.rb_GunScan.TabStop = true;
            this.rb_GunScan.Text = "手持条码枪";
            this.rb_GunScan.UseVisualStyleBackColor = true;
            this.rb_GunScan.CheckedChanged += new System.EventHandler(this.rb_GunScan_CheckedChanged);
            // 
            // rb_scan
            // 
            this.rb_scan.AutoSize = true;
            this.rb_scan.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Bold);
            this.rb_scan.Location = new System.Drawing.Point(183, 34);
            this.rb_scan.Name = "rb_scan";
            this.rb_scan.Size = new System.Drawing.Size(195, 40);
            this.rb_scan.TabIndex = 1;
            this.rb_scan.TabStop = true;
            this.rb_scan.Text = "康耐视条码枪";
            this.rb_scan.UseVisualStyleBackColor = true;
            this.rb_scan.CheckedChanged += new System.EventHandler(this.rb_scan_CheckedChanged);
            // 
            // either_UpToSql
            // 
            this.either_UpToSql.BackColor = System.Drawing.SystemColors.Control;
            this.either_UpToSql.BtnLeftText = "启用";
            this.either_UpToSql.BtnRightText = "禁用";
            this.either_UpToSql.LeftPress = true;
            this.either_UpToSql.Location = new System.Drawing.Point(571, 339);
            this.either_UpToSql.Name = "either_UpToSql";
            this.either_UpToSql.Size = new System.Drawing.Size(740, 113);
            this.either_UpToSql.TabIndex = 7;
            this.either_UpToSql.Title = "数据上传";
            this.either_UpToSql.Event_BtnClick += new ECInspect.Either.dele_LeftRight(this.either_UpToSql_Event_BtnClick);
            // 
            // cb_Product
            // 
            this.cb_Product.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_Product.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_Product.FormattingEnabled = true;
            this.cb_Product.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cb_Product.Items.AddRange(new object[] {
            "A82TFLEX",
            "A85TFLEX"});
            this.cb_Product.Location = new System.Drawing.Point(1534, 374);
            this.cb_Product.Name = "cb_Product";
            this.cb_Product.Size = new System.Drawing.Size(240, 54);
            this.cb_Product.TabIndex = 8;
            this.cb_Product.SelectedIndexChanged += new System.EventHandler(this.cb_Product_SelectedIndexChanged);
            // 
            // lb_Product
            // 
            this.lb_Product.AutoSize = true;
            this.lb_Product.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Product.Location = new System.Drawing.Point(1333, 377);
            this.lb_Product.Name = "lb_Product";
            this.lb_Product.Size = new System.Drawing.Size(195, 46);
            this.lb_Product.TabIndex = 9;
            this.lb_Product.Text = "数据库名：";
            // 
            // groupBoxEx1
            // 
            this.groupBoxEx1.Controls.Add(this.radioButton_FirstMachine);
            this.groupBoxEx1.Controls.Add(this.radioButton_SecondMachine);
            this.groupBoxEx1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxEx1.Location = new System.Drawing.Point(1341, 200);
            this.groupBoxEx1.Name = "groupBoxEx1";
            this.groupBoxEx1.Radius = 10;
            this.groupBoxEx1.Size = new System.Drawing.Size(274, 110);
            this.groupBoxEx1.TabIndex = 10;
            this.groupBoxEx1.TabStop = false;
            this.groupBoxEx1.Text = "测试顺序";
            this.groupBoxEx1.TitleFont = new System.Drawing.Font("宋体", 10F);
            // 
            // radioButton_FirstMachine
            // 
            this.radioButton_FirstMachine.AutoSize = true;
            this.radioButton_FirstMachine.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Bold);
            this.radioButton_FirstMachine.Location = new System.Drawing.Point(3, 34);
            this.radioButton_FirstMachine.Name = "radioButton_FirstMachine";
            this.radioButton_FirstMachine.Size = new System.Drawing.Size(114, 40);
            this.radioButton_FirstMachine.TabIndex = 0;
            this.radioButton_FirstMachine.TabStop = true;
            this.radioButton_FirstMachine.Text = "第一台";
            this.radioButton_FirstMachine.UseVisualStyleBackColor = true;
            this.radioButton_FirstMachine.CheckedChanged += new System.EventHandler(this.radioButton_FirstMachine_CheckedChanged);
            // 
            // radioButton_SecondMachine
            // 
            this.radioButton_SecondMachine.AutoSize = true;
            this.radioButton_SecondMachine.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Bold);
            this.radioButton_SecondMachine.Location = new System.Drawing.Point(144, 34);
            this.radioButton_SecondMachine.Name = "radioButton_SecondMachine";
            this.radioButton_SecondMachine.Size = new System.Drawing.Size(114, 40);
            this.radioButton_SecondMachine.TabIndex = 1;
            this.radioButton_SecondMachine.TabStop = true;
            this.radioButton_SecondMachine.Text = "第二台";
            this.radioButton_SecondMachine.UseVisualStyleBackColor = true;
            this.radioButton_SecondMachine.CheckedChanged += new System.EventHandler(this.radioButton_SecondMachine_CheckedChanged);
            // 
            // ICTForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ICTForm";
            this.Text = "ICTForm";
            this.Load += new System.EventHandler(this.ICTForm_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.gb_scanMode.ResumeLayout(false);
            this.gb_scanMode.PerformLayout();
            this.groupBoxEx1.ResumeLayout(false);
            this.groupBoxEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Either either_Remote;
        private ImageButton btn_GroupNum;
        private ImageButton btn_Tester;
        private ImageButton btn_ReadCard;
        private System.Windows.Forms.TextBox textBox_CardContent;
        private Either either_BarcodeGun;
        private GroupBoxEx gb_scanMode;
        private System.Windows.Forms.RadioButton rb_GunScan;
        private System.Windows.Forms.RadioButton rb_scan;
        private Either either_UpToSql;
        private System.Windows.Forms.Label lb_Product;
        private System.Windows.Forms.ComboBox cb_Product;
        private GroupBoxEx groupBoxEx1;
        private System.Windows.Forms.RadioButton radioButton_FirstMachine;
        private System.Windows.Forms.RadioButton radioButton_SecondMachine;
    }
}