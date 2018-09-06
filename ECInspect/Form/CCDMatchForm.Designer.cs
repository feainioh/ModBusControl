namespace ECInspect
{
    partial class CCDMatchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CCDMatchForm));
            this.pictureBox_Image = new System.Windows.Forms.PictureBox();
            this.btn_Save = new ECInspect.ImageButton();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_LightBalance = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Optimization = new ECInspect.ImageButton();
            this.groupBoxEx1 = new ECInspect.GroupBoxEx();
            this.radioButton_Exclude = new System.Windows.Forms.RadioButton();
            this.radioButton_ROI = new System.Windows.Forms.RadioButton();
            this.btn_Learn = new ECInspect.ImageButton();
            this.label_LearnResult = new System.Windows.Forms.Label();
            this.panel_Pic = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Image)).BeginInit();
            this.groupBoxEx1.SuspendLayout();
            this.panel_Pic.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.panel_Pic);
            this.splitContainer.Panel1.Controls.Add(this.groupBoxEx1);
            this.splitContainer.Panel1.Controls.Add(this.btn_Learn);
            this.splitContainer.Panel1.Controls.Add(this.btn_Optimization);
            this.splitContainer.Panel1.Controls.Add(this.textBox_LightBalance);
            this.splitContainer.Panel1.Controls.Add(this.label_LearnResult);
            this.splitContainer.Panel1.Controls.Add(this.label6);
            this.splitContainer.Panel1.Controls.Add(this.label5);
            this.splitContainer.Panel1.Controls.Add(this.btn_Save);
            // 
            // pictureBox_Image
            // 
            this.pictureBox_Image.Location = new System.Drawing.Point(0, 3);
            this.pictureBox_Image.Name = "pictureBox_Image";
            this.pictureBox_Image.Size = new System.Drawing.Size(1184, 900);
            this.pictureBox_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_Image.TabIndex = 0;
            this.pictureBox_Image.TabStop = false;
            this.pictureBox_Image.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Image_MouseDown);
            this.pictureBox_Image.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Image_MouseMove);
            this.pictureBox_Image.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Image_MouseUp);
            // 
            // btn_Save
            // 
            this.btn_Save.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Bold);
            this.btn_Save.Location = new System.Drawing.Point(1486, 792);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(280, 120);
            this.btn_Save.TabIndex = 1;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(1358, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(508, 320);
            this.label5.TabIndex = 2;
            this.label5.Text = "操作步骤：\r\n①.拖拽绘制排除区域,\r\n尽可能排除内侧轮廓。\r\n②.拖拽绘制ROI小框,\r\n尽可能选中外侧轮廓。";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_LightBalance
            // 
            this.textBox_LightBalance.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Bold);
            this.textBox_LightBalance.Location = new System.Drawing.Point(1521, 535);
            this.textBox_LightBalance.Name = "textBox_LightBalance";
            this.textBox_LightBalance.Size = new System.Drawing.Size(145, 71);
            this.textBox_LightBalance.TabIndex = 3;
            this.textBox_LightBalance.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(1338, 538);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(186, 64);
            this.label6.TabIndex = 4;
            this.label6.Text = "光平衡:";
            // 
            // btn_Optimization
            // 
            this.btn_Optimization.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Bold);
            this.btn_Optimization.Location = new System.Drawing.Point(1673, 530);
            this.btn_Optimization.Name = "btn_Optimization";
            this.btn_Optimization.Size = new System.Drawing.Size(230, 80);
            this.btn_Optimization.TabIndex = 5;
            this.btn_Optimization.Text = "开始优化";
            this.btn_Optimization.UseVisualStyleBackColor = true;
            this.btn_Optimization.Visible = false;
            this.btn_Optimization.Click += new System.EventHandler(this.btn_Optimization_Click);
            // 
            // groupBoxEx1
            // 
            this.groupBoxEx1.Controls.Add(this.radioButton_Exclude);
            this.groupBoxEx1.Controls.Add(this.radioButton_ROI);
            this.groupBoxEx1.Location = new System.Drawing.Point(1392, 395);
            this.groupBoxEx1.Name = "groupBoxEx1";
            this.groupBoxEx1.Radius = 10;
            this.groupBoxEx1.Size = new System.Drawing.Size(500, 100);
            this.groupBoxEx1.TabIndex = 6;
            this.groupBoxEx1.TabStop = false;
            this.groupBoxEx1.TitleFont = new System.Drawing.Font("SimSun", 10F);
            // 
            // radioButton_Exclude
            // 
            this.radioButton_Exclude.AutoSize = true;
            this.radioButton_Exclude.Checked = true;
            this.radioButton_Exclude.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Bold);
            this.radioButton_Exclude.Location = new System.Drawing.Point(253, 20);
            this.radioButton_Exclude.Name = "radioButton_Exclude";
            this.radioButton_Exclude.Size = new System.Drawing.Size(142, 68);
            this.radioButton_Exclude.TabIndex = 0;
            this.radioButton_Exclude.TabStop = true;
            this.radioButton_Exclude.Text = "排除";
            this.radioButton_Exclude.UseVisualStyleBackColor = true;
            // 
            // radioButton_ROI
            // 
            this.radioButton_ROI.AutoSize = true;
            this.radioButton_ROI.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Bold);
            this.radioButton_ROI.Location = new System.Drawing.Point(58, 20);
            this.radioButton_ROI.Name = "radioButton_ROI";
            this.radioButton_ROI.Size = new System.Drawing.Size(135, 68);
            this.radioButton_ROI.TabIndex = 0;
            this.radioButton_ROI.Text = "ROI";
            this.radioButton_ROI.UseVisualStyleBackColor = true;
            // 
            // btn_Learn
            // 
            this.btn_Learn.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Bold);
            this.btn_Learn.Location = new System.Drawing.Point(1481, 651);
            this.btn_Learn.Name = "btn_Learn";
            this.btn_Learn.Size = new System.Drawing.Size(230, 80);
            this.btn_Learn.TabIndex = 5;
            this.btn_Learn.Text = "学习";
            this.btn_Learn.UseVisualStyleBackColor = true;
            this.btn_Learn.Click += new System.EventHandler(this.btn_Learn_Click);
            // 
            // label_LearnResult
            // 
            this.label_LearnResult.AutoSize = true;
            this.label_LearnResult.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Bold);
            this.label_LearnResult.Location = new System.Drawing.Point(1722, 659);
            this.label_LearnResult.Name = "label_LearnResult";
            this.label_LearnResult.Size = new System.Drawing.Size(112, 64);
            this.label_LearnResult.TabIndex = 4;
            this.label_LearnResult.Text = "----";
            // 
            // panel_Pic
            // 
            this.panel_Pic.AutoScroll = true;
            this.panel_Pic.Controls.Add(this.pictureBox_Image);
            this.panel_Pic.Location = new System.Drawing.Point(100, 8);
            this.panel_Pic.Name = "panel_Pic";
            this.panel_Pic.Size = new System.Drawing.Size(1188, 908);
            this.panel_Pic.TabIndex = 7;
            // 
            // CCDMatchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "CCDMatchForm";
            this.Text = "CCDMatchForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CCDMatchForm_FormClosed);
            this.Load += new System.EventHandler(this.CCDMatchForm_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Image)).EndInit();
            this.groupBoxEx1.ResumeLayout(false);
            this.groupBoxEx1.PerformLayout();
            this.panel_Pic.ResumeLayout(false);
            this.panel_Pic.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ImageButton btn_Save;
        private System.Windows.Forms.PictureBox pictureBox_Image;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_LightBalance;
        private System.Windows.Forms.Label label6;
        private ImageButton btn_Optimization;
        private GroupBoxEx groupBoxEx1;
        private System.Windows.Forms.RadioButton radioButton_Exclude;
        private System.Windows.Forms.RadioButton radioButton_ROI;
        private ImageButton btn_Learn;
        private System.Windows.Forms.Label label_LearnResult;
        private System.Windows.Forms.Panel panel_Pic;
    }
}