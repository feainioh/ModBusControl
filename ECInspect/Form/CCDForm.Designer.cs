namespace ECInspect
{
    partial class CCDForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CCDForm));
            this.pictureBox_CCD = new System.Windows.Forms.PictureBox();
            this.panel_CCD = new System.Windows.Forms.Panel();
            this.either_Press = new ECInspect.Either();
            this.textBox_X = new System.Windows.Forms.TextBox();
            this.panel_X = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel_Y = new System.Windows.Forms.Panel();
            this.textBox_Y = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Set = new ECInspect.ImageButton();
            this.either_Light = new ECInspect.Either();
            this.label_RealLocation = new System.Windows.Forms.Label();
            this.btn_JOG_Negative = new ECInspect.ImageButton();
            this.btn_JOG_Positive = new ECInspect.ImageButton();
            this.axisTrackBar = new ECInspect.AxisTrackBar();
            this.groupBoxEx_Y = new ECInspect.GroupBoxEx();
            this.groupBoxEx_Match = new ECInspect.GroupBoxEx();
            this.checkBox_AutoFind = new System.Windows.Forms.CheckBox();
            this.panel_Score = new System.Windows.Forms.Panel();
            this.textBox_Score = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_Zoom = new ECInspect.ImageButton();
            this.btn_Normal = new ECInspect.ImageButton();
            this.btn_Test = new ECInspect.ImageButton();
            this.groupBoxEx1 = new ECInspect.GroupBoxEx();
            this.axisTrackBar_CCD = new ECInspect.AxisTrackBar();
            this.label_RealLocation_CCD = new System.Windows.Forms.Label();
            this.btn_CCDJOG_Positive = new ECInspect.ImageButton();
            this.btn_CCDJOG_Negative = new ECInspect.ImageButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CCD)).BeginInit();
            this.panel_CCD.SuspendLayout();
            this.panel_X.SuspendLayout();
            this.panel_Y.SuspendLayout();
            this.groupBoxEx_Y.SuspendLayout();
            this.groupBoxEx_Match.SuspendLayout();
            this.panel_Score.SuspendLayout();
            this.groupBoxEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.groupBoxEx1);
            this.splitContainer.Panel1.Controls.Add(this.btn_Test);
            this.splitContainer.Panel1.Controls.Add(this.btn_Normal);
            this.splitContainer.Panel1.Controls.Add(this.btn_Zoom);
            this.splitContainer.Panel1.Controls.Add(this.groupBoxEx_Match);
            this.splitContainer.Panel1.Controls.Add(this.groupBoxEx_Y);
            this.splitContainer.Panel1.Controls.Add(this.either_Light);
            this.splitContainer.Panel1.Controls.Add(this.btn_Set);
            this.splitContainer.Panel1.Controls.Add(this.either_Press);
            this.splitContainer.Panel1.Controls.Add(this.panel_CCD);
            // 
            // pictureBox_CCD
            // 
            this.pictureBox_CCD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_CCD.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_CCD.Name = "pictureBox_CCD";
            this.pictureBox_CCD.Size = new System.Drawing.Size(1066, 800);
            this.pictureBox_CCD.TabIndex = 2;
            this.pictureBox_CCD.TabStop = false;
            // 
            // panel_CCD
            // 
            this.panel_CCD.Controls.Add(this.pictureBox_CCD);
            this.panel_CCD.Location = new System.Drawing.Point(806, 120);
            this.panel_CCD.Name = "panel_CCD";
            this.panel_CCD.Size = new System.Drawing.Size(1066, 800);
            this.panel_CCD.TabIndex = 3;
            // 
            // either_Press
            // 
            this.either_Press.BackColor = System.Drawing.SystemColors.Control;
            this.either_Press.BtnLeftText = "上升";
            this.either_Press.BtnRightText = "下降";
            this.either_Press.LeftPress = true;
            this.either_Press.Location = new System.Drawing.Point(47, 131);
            this.either_Press.Name = "either_Press";
            this.either_Press.Size = new System.Drawing.Size(717, 113);
            this.either_Press.TabIndex = 4;
            this.either_Press.Title = "取像制品压紧装置";
            this.either_Press.Event_BtnClick += new ECInspect.Either.dele_LeftRight(this.either_Press_Event_BtnClick);
            // 
            // textBox_X
            // 
            this.textBox_X.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Bold);
            this.textBox_X.Location = new System.Drawing.Point(81, 15);
            this.textBox_X.Name = "textBox_X";
            this.textBox_X.ReadOnly = true;
            this.textBox_X.Size = new System.Drawing.Size(228, 71);
            this.textBox_X.TabIndex = 5;
            this.textBox_X.Text = "000.000";
            // 
            // panel_X
            // 
            this.panel_X.Controls.Add(this.textBox_X);
            this.panel_X.Controls.Add(this.label5);
            this.panel_X.Location = new System.Drawing.Point(8, 26);
            this.panel_X.Name = "panel_X";
            this.panel_X.Size = new System.Drawing.Size(328, 100);
            this.panel_X.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(16, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 64);
            this.label5.TabIndex = 6;
            this.label5.Text = "X:";
            // 
            // panel_Y
            // 
            this.panel_Y.Controls.Add(this.textBox_Y);
            this.panel_Y.Controls.Add(this.label6);
            this.panel_Y.Location = new System.Drawing.Point(344, 26);
            this.panel_Y.Name = "panel_Y";
            this.panel_Y.Size = new System.Drawing.Size(328, 100);
            this.panel_Y.TabIndex = 7;
            // 
            // textBox_Y
            // 
            this.textBox_Y.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Bold);
            this.textBox_Y.Location = new System.Drawing.Point(81, 15);
            this.textBox_Y.Name = "textBox_Y";
            this.textBox_Y.ReadOnly = true;
            this.textBox_Y.Size = new System.Drawing.Size(228, 71);
            this.textBox_Y.TabIndex = 5;
            this.textBox_Y.Text = "000.000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(16, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 64);
            this.label6.TabIndex = 6;
            this.label6.Text = "Y:";
            // 
            // btn_Set
            // 
            this.btn_Set.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Set.Location = new System.Drawing.Point(235, 852);
            this.btn_Set.Name = "btn_Set";
            this.btn_Set.Size = new System.Drawing.Size(260, 80);
            this.btn_Set.TabIndex = 8;
            this.btn_Set.Text = "设定";
            this.btn_Set.UseVisualStyleBackColor = true;
            this.btn_Set.Click += new System.EventHandler(this.btn_Set_Click);
            // 
            // either_Light
            // 
            this.either_Light.BackColor = System.Drawing.SystemColors.Control;
            this.either_Light.BtnLeftText = "开启";
            this.either_Light.BtnRightText = "关闭";
            this.either_Light.LeftPress = true;
            this.either_Light.Location = new System.Drawing.Point(47, 12);
            this.either_Light.Name = "either_Light";
            this.either_Light.Size = new System.Drawing.Size(717, 113);
            this.either_Light.TabIndex = 9;
            this.either_Light.Title = "光源";
            this.either_Light.Event_BtnClick += new ECInspect.Either.dele_LeftRight(this.either_Light_Event_BtnClick);
            // 
            // label_RealLocation
            // 
            this.label_RealLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_RealLocation.AutoSize = true;
            this.label_RealLocation.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_RealLocation.Location = new System.Drawing.Point(205, 146);
            this.label_RealLocation.Name = "label_RealLocation";
            this.label_RealLocation.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_RealLocation.Size = new System.Drawing.Size(203, 39);
            this.label_RealLocation.TabIndex = 13;
            this.label_RealLocation.Text = "实时位置:0.00";
            this.label_RealLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_JOG_Negative
            // 
            this.btn_JOG_Negative.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_JOG_Negative.Location = new System.Drawing.Point(100, 88);
            this.btn_JOG_Negative.Name = "btn_JOG_Negative";
            this.btn_JOG_Negative.Size = new System.Drawing.Size(130, 55);
            this.btn_JOG_Negative.TabIndex = 12;
            this.btn_JOG_Negative.Text = "JOG-";
            this.btn_JOG_Negative.UseVisualStyleBackColor = true;
            this.btn_JOG_Negative.MouseCaptureChanged += new System.EventHandler(this.btn_JOG_MouseCaptureChanged);
            this.btn_JOG_Negative.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_JOG_Negative_MouseDown);
            this.btn_JOG_Negative.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_JOG_MouseUp);
            // 
            // btn_JOG_Positive
            // 
            this.btn_JOG_Positive.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_JOG_Positive.Location = new System.Drawing.Point(371, 88);
            this.btn_JOG_Positive.Name = "btn_JOG_Positive";
            this.btn_JOG_Positive.Size = new System.Drawing.Size(130, 55);
            this.btn_JOG_Positive.TabIndex = 11;
            this.btn_JOG_Positive.Text = "JOG+";
            this.btn_JOG_Positive.UseVisualStyleBackColor = true;
            this.btn_JOG_Positive.MouseCaptureChanged += new System.EventHandler(this.btn_JOG_MouseCaptureChanged);
            this.btn_JOG_Positive.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_JOG_Positive_MouseDown);
            this.btn_JOG_Positive.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_JOG_MouseUp);
            // 
            // axisTrackBar
            // 
            this.axisTrackBar.AxisMaxValue = 100000;
            this.axisTrackBar.AxisMinValue = 0;
            this.axisTrackBar.AxisName = ECInspect.Axis.Y;
            this.axisTrackBar.AxisRealValue = 0D;
            this.axisTrackBar.BackColor = System.Drawing.Color.Silver;
            this.axisTrackBar.Location = new System.Drawing.Point(33, 23);
            this.axisTrackBar.MinimumSize = new System.Drawing.Size(538, 59);
            this.axisTrackBar.Name = "axisTrackBar";
            this.axisTrackBar.Size = new System.Drawing.Size(620, 59);
            this.axisTrackBar.TabIndex = 10;
            // 
            // groupBoxEx_Y
            // 
            this.groupBoxEx_Y.Controls.Add(this.axisTrackBar);
            this.groupBoxEx_Y.Controls.Add(this.label_RealLocation);
            this.groupBoxEx_Y.Controls.Add(this.btn_JOG_Positive);
            this.groupBoxEx_Y.Controls.Add(this.btn_JOG_Negative);
            this.groupBoxEx_Y.Location = new System.Drawing.Point(57, 248);
            this.groupBoxEx_Y.Name = "groupBoxEx_Y";
            this.groupBoxEx_Y.Radius = 10;
            this.groupBoxEx_Y.Size = new System.Drawing.Size(680, 186);
            this.groupBoxEx_Y.TabIndex = 14;
            this.groupBoxEx_Y.TabStop = false;
            this.groupBoxEx_Y.Text = "Y轴";
            this.groupBoxEx_Y.TitleFont = new System.Drawing.Font("SimSun", 15.75F);
            // 
            // groupBoxEx_Match
            // 
            this.groupBoxEx_Match.Controls.Add(this.checkBox_AutoFind);
            this.groupBoxEx_Match.Controls.Add(this.panel_Score);
            this.groupBoxEx_Match.Controls.Add(this.panel_X);
            this.groupBoxEx_Match.Controls.Add(this.panel_Y);
            this.groupBoxEx_Match.Location = new System.Drawing.Point(57, 620);
            this.groupBoxEx_Match.Name = "groupBoxEx_Match";
            this.groupBoxEx_Match.Radius = 10;
            this.groupBoxEx_Match.Size = new System.Drawing.Size(680, 230);
            this.groupBoxEx_Match.TabIndex = 15;
            this.groupBoxEx_Match.TabStop = false;
            this.groupBoxEx_Match.Text = "匹配";
            this.groupBoxEx_Match.TitleFont = new System.Drawing.Font("SimSun", 15.75F);
            // 
            // checkBox_AutoFind
            // 
            this.checkBox_AutoFind.AutoSize = true;
            this.checkBox_AutoFind.Checked = true;
            this.checkBox_AutoFind.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_AutoFind.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Bold);
            this.checkBox_AutoFind.Location = new System.Drawing.Point(21, 141);
            this.checkBox_AutoFind.Name = "checkBox_AutoFind";
            this.checkBox_AutoFind.Size = new System.Drawing.Size(239, 68);
            this.checkBox_AutoFind.TabIndex = 9;
            this.checkBox_AutoFind.Text = "自动定位";
            this.checkBox_AutoFind.UseVisualStyleBackColor = true;
            this.checkBox_AutoFind.CheckedChanged += new System.EventHandler(this.checkBox_AutoFind_CheckedChanged);
            // 
            // panel_Score
            // 
            this.panel_Score.Controls.Add(this.textBox_Score);
            this.panel_Score.Controls.Add(this.label7);
            this.panel_Score.Location = new System.Drawing.Point(284, 126);
            this.panel_Score.Name = "panel_Score";
            this.panel_Score.Size = new System.Drawing.Size(328, 100);
            this.panel_Score.TabIndex = 8;
            // 
            // textBox_Score
            // 
            this.textBox_Score.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Bold);
            this.textBox_Score.Location = new System.Drawing.Point(150, 15);
            this.textBox_Score.Name = "textBox_Score";
            this.textBox_Score.ReadOnly = true;
            this.textBox_Score.Size = new System.Drawing.Size(150, 71);
            this.textBox_Score.TabIndex = 5;
            this.textBox_Score.Text = "00.00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(16, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 64);
            this.label7.TabIndex = 6;
            this.label7.Text = "得分:";
            // 
            // btn_Zoom
            // 
            this.btn_Zoom.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Zoom.Location = new System.Drawing.Point(1142, 42);
            this.btn_Zoom.Name = "btn_Zoom";
            this.btn_Zoom.Size = new System.Drawing.Size(80, 50);
            this.btn_Zoom.TabIndex = 16;
            this.btn_Zoom.Text = "Zoom";
            this.btn_Zoom.UseVisualStyleBackColor = true;
            this.btn_Zoom.Click += new System.EventHandler(this.btn_Zoom_Click);
            // 
            // btn_Normal
            // 
            this.btn_Normal.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Normal.Location = new System.Drawing.Point(1247, 42);
            this.btn_Normal.Name = "btn_Normal";
            this.btn_Normal.Size = new System.Drawing.Size(80, 50);
            this.btn_Normal.TabIndex = 16;
            this.btn_Normal.Text = "Normal";
            this.btn_Normal.UseVisualStyleBackColor = true;
            this.btn_Normal.Click += new System.EventHandler(this.btn_Normal_Click);
            // 
            // btn_Test
            // 
            this.btn_Test.Location = new System.Drawing.Point(1821, 12);
            this.btn_Test.Name = "btn_Test";
            this.btn_Test.Size = new System.Drawing.Size(75, 50);
            this.btn_Test.TabIndex = 17;
            this.btn_Test.Text = "Test";
            this.btn_Test.UseVisualStyleBackColor = true;
            this.btn_Test.Visible = false;
            this.btn_Test.Click += new System.EventHandler(this.btn_Test_Click);
            // 
            // groupBoxEx1
            // 
            this.groupBoxEx1.Controls.Add(this.axisTrackBar_CCD);
            this.groupBoxEx1.Controls.Add(this.label_RealLocation_CCD);
            this.groupBoxEx1.Controls.Add(this.btn_CCDJOG_Positive);
            this.groupBoxEx1.Controls.Add(this.btn_CCDJOG_Negative);
            this.groupBoxEx1.Location = new System.Drawing.Point(57, 434);
            this.groupBoxEx1.Name = "groupBoxEx1";
            this.groupBoxEx1.Radius = 10;
            this.groupBoxEx1.Size = new System.Drawing.Size(680, 186);
            this.groupBoxEx1.TabIndex = 18;
            this.groupBoxEx1.TabStop = false;
            this.groupBoxEx1.Text = "相机轴";
            this.groupBoxEx1.TitleFont = new System.Drawing.Font("SimSun", 15.75F);
            // 
            // axisTrackBar_CCD
            // 
            this.axisTrackBar_CCD.AxisMaxValue = 100000;
            this.axisTrackBar_CCD.AxisMinValue = 0;
            this.axisTrackBar_CCD.AxisName = ECInspect.Axis.CCD;
            this.axisTrackBar_CCD.AxisRealValue = 0D;
            this.axisTrackBar_CCD.BackColor = System.Drawing.Color.Silver;
            this.axisTrackBar_CCD.Location = new System.Drawing.Point(33, 23);
            this.axisTrackBar_CCD.MinimumSize = new System.Drawing.Size(538, 59);
            this.axisTrackBar_CCD.Name = "axisTrackBar_CCD";
            this.axisTrackBar_CCD.Size = new System.Drawing.Size(620, 59);
            this.axisTrackBar_CCD.TabIndex = 10;
            // 
            // label_RealLocation_CCD
            // 
            this.label_RealLocation_CCD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_RealLocation_CCD.AutoSize = true;
            this.label_RealLocation_CCD.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_RealLocation_CCD.Location = new System.Drawing.Point(205, 146);
            this.label_RealLocation_CCD.Name = "label_RealLocation_CCD";
            this.label_RealLocation_CCD.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_RealLocation_CCD.Size = new System.Drawing.Size(203, 39);
            this.label_RealLocation_CCD.TabIndex = 13;
            this.label_RealLocation_CCD.Text = "实时位置:0.00";
            this.label_RealLocation_CCD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_CCDJOG_Positive
            // 
            this.btn_CCDJOG_Positive.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CCDJOG_Positive.Location = new System.Drawing.Point(371, 88);
            this.btn_CCDJOG_Positive.Name = "btn_CCDJOG_Positive";
            this.btn_CCDJOG_Positive.Size = new System.Drawing.Size(130, 55);
            this.btn_CCDJOG_Positive.TabIndex = 11;
            this.btn_CCDJOG_Positive.Text = "JOG+";
            this.btn_CCDJOG_Positive.UseVisualStyleBackColor = true;
            this.btn_CCDJOG_Positive.MouseCaptureChanged += new System.EventHandler(this.btn_CCDJOG_MouseCaptureChanged);
            this.btn_CCDJOG_Positive.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_CCDJOG_Positive_MouseDown);
            this.btn_CCDJOG_Positive.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_CCDJOG_MouseUp);
            // 
            // btn_CCDJOG_Negative
            // 
            this.btn_CCDJOG_Negative.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CCDJOG_Negative.Location = new System.Drawing.Point(100, 88);
            this.btn_CCDJOG_Negative.Name = "btn_CCDJOG_Negative";
            this.btn_CCDJOG_Negative.Size = new System.Drawing.Size(130, 55);
            this.btn_CCDJOG_Negative.TabIndex = 12;
            this.btn_CCDJOG_Negative.Text = "JOG-";
            this.btn_CCDJOG_Negative.UseVisualStyleBackColor = true;
            this.btn_CCDJOG_Negative.MouseCaptureChanged += new System.EventHandler(this.btn_CCDJOG_MouseCaptureChanged);
            this.btn_CCDJOG_Negative.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_CCDJOG_Negative_MouseDown);
            this.btn_CCDJOG_Negative.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_CCDJOG_MouseUp);
            // 
            // CCDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "CCDForm";
            this.Text = "CCDForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CCDForm_FormClosed);
            this.Load += new System.EventHandler(this.CCDForm_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CCD)).EndInit();
            this.panel_CCD.ResumeLayout(false);
            this.panel_X.ResumeLayout(false);
            this.panel_X.PerformLayout();
            this.panel_Y.ResumeLayout(false);
            this.panel_Y.PerformLayout();
            this.groupBoxEx_Y.ResumeLayout(false);
            this.groupBoxEx_Y.PerformLayout();
            this.groupBoxEx_Match.ResumeLayout(false);
            this.groupBoxEx_Match.PerformLayout();
            this.panel_Score.ResumeLayout(false);
            this.panel_Score.PerformLayout();
            this.groupBoxEx1.ResumeLayout(false);
            this.groupBoxEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_CCD;
        private System.Windows.Forms.PictureBox pictureBox_CCD;
        private Either either_Press;
        private System.Windows.Forms.Panel panel_X;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_X;
        private System.Windows.Forms.Panel panel_Y;
        private System.Windows.Forms.TextBox textBox_Y;
        private System.Windows.Forms.Label label6;
        private ImageButton btn_Set;
        private Either either_Light;
        private GroupBoxEx groupBoxEx_Y;
        protected System.Windows.Forms.Label label_RealLocation;
        private ImageButton btn_JOG_Negative;
        private ImageButton btn_JOG_Positive;
        protected AxisTrackBar axisTrackBar;
        private GroupBoxEx groupBoxEx_Match;
        private System.Windows.Forms.Panel panel_Score;
        private System.Windows.Forms.TextBox textBox_Score;
        private System.Windows.Forms.Label label7;
        private ImageButton btn_Normal;
        private ImageButton btn_Zoom;
        private ImageButton btn_Test;
        private System.Windows.Forms.CheckBox checkBox_AutoFind;
        private GroupBoxEx groupBoxEx1;
        protected AxisTrackBar axisTrackBar_CCD;
        protected System.Windows.Forms.Label label_RealLocation_CCD;
        private ImageButton btn_CCDJOG_Positive;
        private ImageButton btn_CCDJOG_Negative;
    }
}