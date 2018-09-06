namespace ECInspect.MyControl
{
    partial class AxisCarry
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
            this.groupBoxEx2 = new ECInspect.GroupBoxEx();
            this.textBox_CarryAxisBlankPosition = new System.Windows.Forms.TextBox();
            this.textBox_CarryAxisFeedPosition = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBoxEx2.SuspendLayout();
            this.SuspendLayout();
            // 
            // axisTrackBar
            // 
            this.axisTrackBar.AxisName = ECInspect.Axis.Carry;
            // 
            // groupBoxEx2
            // 
            this.groupBoxEx2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBoxEx2.Controls.Add(this.label7);
            this.groupBoxEx2.Controls.Add(this.label15);
            this.groupBoxEx2.Controls.Add(this.textBox_CarryAxisBlankPosition);
            this.groupBoxEx2.Controls.Add(this.textBox_CarryAxisFeedPosition);
            this.groupBoxEx2.Controls.Add(this.label10);
            this.groupBoxEx2.Controls.Add(this.label9);
            this.groupBoxEx2.Location = new System.Drawing.Point(558, 144);
            this.groupBoxEx2.Name = "groupBoxEx2";
            this.groupBoxEx2.Radius = 10;
            this.groupBoxEx2.Size = new System.Drawing.Size(493, 460);
            this.groupBoxEx2.TabIndex = 10;
            this.groupBoxEx2.TabStop = false;
            this.groupBoxEx2.Text = "位置";
            this.groupBoxEx2.TitleFont = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // textBox_CarryAxisBlankPosition
            // 
            this.textBox_CarryAxisBlankPosition.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBox_CarryAxisBlankPosition.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold);
            this.textBox_CarryAxisBlankPosition.Location = new System.Drawing.Point(232, 96);
            this.textBox_CarryAxisBlankPosition.Name = "textBox_CarryAxisBlankPosition";
            this.textBox_CarryAxisBlankPosition.ReadOnly = true;
            this.textBox_CarryAxisBlankPosition.Size = new System.Drawing.Size(139, 46);
            this.textBox_CarryAxisBlankPosition.TabIndex = 1;
            this.textBox_CarryAxisBlankPosition.Click += new System.EventHandler(this.textBox_CarryAxisBlankPosition_Click);
            // 
            // textBox_CarryAxisFeedPosition
            // 
            this.textBox_CarryAxisFeedPosition.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBox_CarryAxisFeedPosition.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold);
            this.textBox_CarryAxisFeedPosition.Location = new System.Drawing.Point(232, 21);
            this.textBox_CarryAxisFeedPosition.Name = "textBox_CarryAxisFeedPosition";
            this.textBox_CarryAxisFeedPosition.ReadOnly = true;
            this.textBox_CarryAxisFeedPosition.Size = new System.Drawing.Size(139, 46);
            this.textBox_CarryAxisFeedPosition.TabIndex = 1;
            this.textBox_CarryAxisFeedPosition.Click += new System.EventHandler(this.textBox_CarryAxisFeedPosition_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(8, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(199, 39);
            this.label10.TabIndex = 0;
            this.label10.Text = "搬运下料位置:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(8, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(199, 39);
            this.label9.TabIndex = 0;
            this.label9.Text = "搬运上料位置:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(377, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 39);
            this.label15.TabIndex = 4;
            this.label15.Text = "毫米";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(377, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 39);
            this.label7.TabIndex = 4;
            this.label7.Text = "毫米";
            // 
            // AxisCarry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AxisName = ECInspect.Axis.Carry;
            this.Controls.Add(this.groupBoxEx2);
            this.Name = "AxisCarry";
            this.Load += new System.EventHandler(this.AxisCarry_Load);
            this.Controls.SetChildIndex(this.axisTrackBar, 0);
            this.Controls.SetChildIndex(this.label_RealLocation, 0);
            this.Controls.SetChildIndex(this.btn_ReleaseAxisAlarm, 0);
            this.Controls.SetChildIndex(this.btn_Origin, 0);
            this.Controls.SetChildIndex(this.groupBoxEx2, 0);
            this.groupBoxEx2.ResumeLayout(false);
            this.groupBoxEx2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBoxEx groupBoxEx2;
        private System.Windows.Forms.TextBox textBox_CarryAxisBlankPosition;
        private System.Windows.Forms.TextBox textBox_CarryAxisFeedPosition;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label15;
    }
}
