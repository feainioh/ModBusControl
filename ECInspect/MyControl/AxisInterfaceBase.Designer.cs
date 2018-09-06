namespace ECInspect
{
    partial class AxisInterface
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label_RealLocation = new System.Windows.Forms.Label();
            this.WindowRefresh = new System.Windows.Forms.Timer(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btn_Origin = new ECInspect.ImageButton();
            this.btn_ReleaseAxisAlarm = new ECInspect.ImageButton();
            this.btn_JOG_Negative = new ECInspect.ImageButton();
            this.btn_JOG_Positive = new ECInspect.ImageButton();
            this.groupBoxEx_Speed = new ECInspect.GroupBoxEx();
            this.label012 = new System.Windows.Forms.Label();
            this.label011 = new System.Windows.Forms.Label();
            this.label010 = new System.Windows.Forms.Label();
            this.label09 = new System.Windows.Forms.Label();
            this.label08 = new System.Windows.Forms.Label();
            this.label07 = new System.Windows.Forms.Label();
            this.textBox_DeceleratSpeed = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_AcceleratSpeed = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_JOGSpeed = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_MoveOriginCrawlSpeed = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_MoveOriginSpeed = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_MoveSpeed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.axisTrackBar = new ECInspect.AxisTrackBar();
            this.groupBoxEx_Speed.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_RealLocation
            // 
            this.label_RealLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_RealLocation.AutoSize = true;
            this.label_RealLocation.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_RealLocation.Location = new System.Drawing.Point(1509, 6);
            this.label_RealLocation.Name = "label_RealLocation";
            this.label_RealLocation.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_RealLocation.Size = new System.Drawing.Size(203, 39);
            this.label_RealLocation.TabIndex = 5;
            this.label_RealLocation.Text = "实时位置:0.00";
            this.label_RealLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // WindowRefresh
            // 
            this.WindowRefresh.Tag = "更新窗体数据的定时器";
            // 
            // toolTip
            // 
            this.toolTip.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolTip.ForeColor = System.Drawing.SystemColors.Highlight;
            // 
            // btn_Origin
            // 
            this.btn_Origin.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Origin.Location = new System.Drawing.Point(249, 75);
            this.btn_Origin.Name = "btn_Origin";
            this.btn_Origin.Size = new System.Drawing.Size(111, 62);
            this.btn_Origin.TabIndex = 9;
            this.btn_Origin.Text = "回原点";
            this.btn_Origin.UseVisualStyleBackColor = true;
            this.btn_Origin.Click += new System.EventHandler(this.btn_Origin_Click);
            // 
            // btn_ReleaseAxisAlarm
            // 
            this.btn_ReleaseAxisAlarm.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ReleaseAxisAlarm.Location = new System.Drawing.Point(536, 73);
            this.btn_ReleaseAxisAlarm.Name = "btn_ReleaseAxisAlarm";
            this.btn_ReleaseAxisAlarm.Size = new System.Drawing.Size(181, 65);
            this.btn_ReleaseAxisAlarm.TabIndex = 8;
            this.btn_ReleaseAxisAlarm.Text = "轴报警解除";
            this.btn_ReleaseAxisAlarm.UseVisualStyleBackColor = true;
            this.btn_ReleaseAxisAlarm.Click += new System.EventHandler(this.btn_ReleaseAlarm_Click);
            // 
            // btn_JOG_Negative
            // 
            this.btn_JOG_Negative.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btn_JOG_Negative.FlatAppearance.BorderSize = 8;
            this.btn_JOG_Negative.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_JOG_Negative.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_JOG_Negative.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_JOG_Negative.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_JOG_Negative.Location = new System.Drawing.Point(104, 72);
            this.btn_JOG_Negative.Name = "btn_JOG_Negative";
            this.btn_JOG_Negative.Size = new System.Drawing.Size(138, 69);
            this.btn_JOG_Negative.TabIndex = 2;
            this.btn_JOG_Negative.Text = "JOG-";
            this.btn_JOG_Negative.UseVisualStyleBackColor = true;
            this.btn_JOG_Negative.MouseCaptureChanged += new System.EventHandler(this.btn_JOG_MouseCaptureChanged);
            this.btn_JOG_Negative.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_JOG_Negative_MouseDown);
            this.btn_JOG_Negative.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_JOG_MouseUp);
            // 
            // btn_JOG_Positive
            // 
            this.btn_JOG_Positive.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btn_JOG_Positive.FlatAppearance.BorderSize = 8;
            this.btn_JOG_Positive.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_JOG_Positive.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_JOG_Positive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_JOG_Positive.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_JOG_Positive.Location = new System.Drawing.Point(366, 72);
            this.btn_JOG_Positive.Name = "btn_JOG_Positive";
            this.btn_JOG_Positive.Size = new System.Drawing.Size(138, 69);
            this.btn_JOG_Positive.TabIndex = 2;
            this.btn_JOG_Positive.Text = "JOG+";
            this.btn_JOG_Positive.UseVisualStyleBackColor = true;
            this.btn_JOG_Positive.MouseCaptureChanged += new System.EventHandler(this.btn_JOG_MouseCaptureChanged);
            this.btn_JOG_Positive.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_JOG_Positive_MouseDown);
            this.btn_JOG_Positive.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_JOG_MouseUp);
            // 
            // groupBoxEx_Speed
            // 
            this.groupBoxEx_Speed.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBoxEx_Speed.Controls.Add(this.label012);
            this.groupBoxEx_Speed.Controls.Add(this.label011);
            this.groupBoxEx_Speed.Controls.Add(this.label010);
            this.groupBoxEx_Speed.Controls.Add(this.label09);
            this.groupBoxEx_Speed.Controls.Add(this.label08);
            this.groupBoxEx_Speed.Controls.Add(this.label07);
            this.groupBoxEx_Speed.Controls.Add(this.textBox_DeceleratSpeed);
            this.groupBoxEx_Speed.Controls.Add(this.label6);
            this.groupBoxEx_Speed.Controls.Add(this.textBox_AcceleratSpeed);
            this.groupBoxEx_Speed.Controls.Add(this.label5);
            this.groupBoxEx_Speed.Controls.Add(this.textBox_JOGSpeed);
            this.groupBoxEx_Speed.Controls.Add(this.label4);
            this.groupBoxEx_Speed.Controls.Add(this.textBox_MoveOriginCrawlSpeed);
            this.groupBoxEx_Speed.Controls.Add(this.label3);
            this.groupBoxEx_Speed.Controls.Add(this.textBox_MoveOriginSpeed);
            this.groupBoxEx_Speed.Controls.Add(this.label2);
            this.groupBoxEx_Speed.Controls.Add(this.textBox_MoveSpeed);
            this.groupBoxEx_Speed.Controls.Add(this.label1);
            this.groupBoxEx_Speed.Location = new System.Drawing.Point(17, 144);
            this.groupBoxEx_Speed.Name = "groupBoxEx_Speed";
            this.groupBoxEx_Speed.Radius = 10;
            this.groupBoxEx_Speed.Size = new System.Drawing.Size(513, 460);
            this.groupBoxEx_Speed.TabIndex = 3;
            this.groupBoxEx_Speed.TabStop = false;
            this.groupBoxEx_Speed.Text = "速度";
            this.groupBoxEx_Speed.TitleFont = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // label012
            // 
            this.label012.AutoSize = true;
            this.label012.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold);
            this.label012.Location = new System.Drawing.Point(388, 403);
            this.label012.Name = "label012";
            this.label012.Size = new System.Drawing.Size(75, 39);
            this.label012.TabIndex = 2;
            this.label012.Text = "毫秒";
            // 
            // label011
            // 
            this.label011.AutoSize = true;
            this.label011.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold);
            this.label011.Location = new System.Drawing.Point(388, 328);
            this.label011.Name = "label011";
            this.label011.Size = new System.Drawing.Size(75, 39);
            this.label011.TabIndex = 2;
            this.label011.Text = "毫秒";
            // 
            // label010
            // 
            this.label010.AutoSize = true;
            this.label010.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold);
            this.label010.Location = new System.Drawing.Point(388, 253);
            this.label010.Name = "label010";
            this.label010.Size = new System.Drawing.Size(118, 39);
            this.label010.TabIndex = 2;
            this.label010.Text = "毫米/秒";
            // 
            // label09
            // 
            this.label09.AutoSize = true;
            this.label09.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold);
            this.label09.Location = new System.Drawing.Point(388, 178);
            this.label09.Name = "label09";
            this.label09.Size = new System.Drawing.Size(118, 39);
            this.label09.TabIndex = 2;
            this.label09.Text = "毫米/秒";
            // 
            // label08
            // 
            this.label08.AutoSize = true;
            this.label08.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold);
            this.label08.Location = new System.Drawing.Point(388, 103);
            this.label08.Name = "label08";
            this.label08.Size = new System.Drawing.Size(118, 39);
            this.label08.TabIndex = 2;
            this.label08.Text = "毫米/秒";
            // 
            // label07
            // 
            this.label07.AutoSize = true;
            this.label07.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold);
            this.label07.Location = new System.Drawing.Point(388, 28);
            this.label07.Name = "label07";
            this.label07.Size = new System.Drawing.Size(118, 39);
            this.label07.TabIndex = 2;
            this.label07.Text = "毫米/秒";
            // 
            // textBox_DeceleratSpeed
            // 
            this.textBox_DeceleratSpeed.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBox_DeceleratSpeed.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_DeceleratSpeed.Location = new System.Drawing.Point(240, 399);
            this.textBox_DeceleratSpeed.Name = "textBox_DeceleratSpeed";
            this.textBox_DeceleratSpeed.ReadOnly = true;
            this.textBox_DeceleratSpeed.Size = new System.Drawing.Size(144, 46);
            this.textBox_DeceleratSpeed.TabIndex = 1;
            this.textBox_DeceleratSpeed.Click += new System.EventHandler(this.textBox_DeceleratSpeed_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(62, 397);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 39);
            this.label6.TabIndex = 0;
            this.label6.Text = "减速度:";
            // 
            // textBox_AcceleratSpeed
            // 
            this.textBox_AcceleratSpeed.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBox_AcceleratSpeed.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_AcceleratSpeed.Location = new System.Drawing.Point(240, 324);
            this.textBox_AcceleratSpeed.Name = "textBox_AcceleratSpeed";
            this.textBox_AcceleratSpeed.ReadOnly = true;
            this.textBox_AcceleratSpeed.Size = new System.Drawing.Size(144, 46);
            this.textBox_AcceleratSpeed.TabIndex = 1;
            this.textBox_AcceleratSpeed.Click += new System.EventHandler(this.textBox_AcceleratSpeed_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(62, 322);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 39);
            this.label5.TabIndex = 0;
            this.label5.Text = "加速度:";
            // 
            // textBox_JOGSpeed
            // 
            this.textBox_JOGSpeed.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBox_JOGSpeed.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_JOGSpeed.Location = new System.Drawing.Point(240, 249);
            this.textBox_JOGSpeed.Name = "textBox_JOGSpeed";
            this.textBox_JOGSpeed.ReadOnly = true;
            this.textBox_JOGSpeed.Size = new System.Drawing.Size(144, 46);
            this.textBox_JOGSpeed.TabIndex = 1;
            this.textBox_JOGSpeed.Click += new System.EventHandler(this.textBox_JOGSpeed_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(56, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 39);
            this.label4.TabIndex = 0;
            this.label4.Text = "JOG速度:";
            // 
            // textBox_MoveOriginCrawlSpeed
            // 
            this.textBox_MoveOriginCrawlSpeed.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBox_MoveOriginCrawlSpeed.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_MoveOriginCrawlSpeed.Location = new System.Drawing.Point(240, 174);
            this.textBox_MoveOriginCrawlSpeed.Name = "textBox_MoveOriginCrawlSpeed";
            this.textBox_MoveOriginCrawlSpeed.ReadOnly = true;
            this.textBox_MoveOriginCrawlSpeed.Size = new System.Drawing.Size(144, 46);
            this.textBox_MoveOriginCrawlSpeed.TabIndex = 1;
            this.textBox_MoveOriginCrawlSpeed.Click += new System.EventHandler(this.textBox_MoveOriginCrawlSpeed_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(14, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(228, 39);
            this.label3.TabIndex = 0;
            this.label3.Text = "归原点爬行速度:";
            // 
            // textBox_MoveOriginSpeed
            // 
            this.textBox_MoveOriginSpeed.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBox_MoveOriginSpeed.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_MoveOriginSpeed.Location = new System.Drawing.Point(240, 99);
            this.textBox_MoveOriginSpeed.Name = "textBox_MoveOriginSpeed";
            this.textBox_MoveOriginSpeed.ReadOnly = true;
            this.textBox_MoveOriginSpeed.Size = new System.Drawing.Size(144, 46);
            this.textBox_MoveOriginSpeed.TabIndex = 1;
            this.textBox_MoveOriginSpeed.Click += new System.EventHandler(this.textBox_MoveOriginSpeed_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(38, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 39);
            this.label2.TabIndex = 0;
            this.label2.Text = "归原点速度:";
            // 
            // textBox_MoveSpeed
            // 
            this.textBox_MoveSpeed.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBox_MoveSpeed.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_MoveSpeed.Location = new System.Drawing.Point(240, 24);
            this.textBox_MoveSpeed.Name = "textBox_MoveSpeed";
            this.textBox_MoveSpeed.ReadOnly = true;
            this.textBox_MoveSpeed.Size = new System.Drawing.Size(144, 46);
            this.textBox_MoveSpeed.TabIndex = 1;
            this.textBox_MoveSpeed.Click += new System.EventHandler(this.textBox_MoveSpeed_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(50, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "定位速度:";
            // 
            // axisTrackBar
            // 
            this.axisTrackBar.AxisMaxValue = 100000;
            this.axisTrackBar.AxisMinValue = 0;
            this.axisTrackBar.AxisName = ECInspect.Axis.X;
            this.axisTrackBar.AxisRealValue = 0D;
            this.axisTrackBar.BackColor = System.Drawing.Color.Silver;
            this.axisTrackBar.Location = new System.Drawing.Point(17, 6);
            this.axisTrackBar.MinimumSize = new System.Drawing.Size(538, 59);
            this.axisTrackBar.Name = "axisTrackBar";
            this.axisTrackBar.Size = new System.Drawing.Size(620, 59);
            this.axisTrackBar.TabIndex = 1;
            // 
            // AxisInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Controls.Add(this.btn_Origin);
            this.Controls.Add(this.btn_ReleaseAxisAlarm);
            this.Controls.Add(this.label_RealLocation);
            this.Controls.Add(this.btn_JOG_Negative);
            this.Controls.Add(this.btn_JOG_Positive);
            this.Controls.Add(this.groupBoxEx_Speed);
            this.Controls.Add(this.axisTrackBar);
            this.Name = "AxisInterface";
            this.Size = new System.Drawing.Size(1792, 896);
            this.groupBoxEx_Speed.ResumeLayout(false);
            this.groupBoxEx_Speed.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ImageButton btn_JOG_Positive;
        private ImageButton btn_JOG_Negative;
        private GroupBoxEx groupBoxEx_Speed;
        private System.Windows.Forms.TextBox textBox_DeceleratSpeed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_AcceleratSpeed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_JOGSpeed;
        private System.Windows.Forms.Label label4;
        protected AxisTrackBar axisTrackBar;
        protected System.Windows.Forms.TextBox textBox_MoveOriginCrawlSpeed;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.TextBox textBox_MoveOriginSpeed;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.TextBox textBox_MoveSpeed;
        protected System.Windows.Forms.Label label1;
        protected ImageButton btn_Origin;
        protected ImageButton btn_ReleaseAxisAlarm;
        protected System.Windows.Forms.Label label_RealLocation;
        protected System.Windows.Forms.Timer WindowRefresh;
        protected System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label012;
        private System.Windows.Forms.Label label011;
        private System.Windows.Forms.Label label010;
        private System.Windows.Forms.Label label07;
        protected System.Windows.Forms.Label label09;
        protected System.Windows.Forms.Label label08;
    }
}
