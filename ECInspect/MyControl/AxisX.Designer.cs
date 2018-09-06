namespace ECInspect
{
    partial class AxisX
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
            this.label15 = new System.Windows.Forms.Label();
            this.textBox_XAxis_AssemblyPosition = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBoxEx2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxEx2
            // 
            this.groupBoxEx2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBoxEx2.Controls.Add(this.label15);
            this.groupBoxEx2.Controls.Add(this.textBox_XAxis_AssemblyPosition);
            this.groupBoxEx2.Controls.Add(this.label7);
            this.groupBoxEx2.Location = new System.Drawing.Point(559, 144);
            this.groupBoxEx2.Name = "groupBoxEx2";
            this.groupBoxEx2.Radius = 10;
            this.groupBoxEx2.Size = new System.Drawing.Size(433, 460);
            this.groupBoxEx2.TabIndex = 6;
            this.groupBoxEx2.TabStop = false;
            this.groupBoxEx2.Text = "位置";
            this.groupBoxEx2.TitleFont = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(350, 28);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 39);
            this.label15.TabIndex = 3;
            this.label15.Text = "毫米";
            // 
            // textBox_XAxis_AssemblyPosition
            // 
            this.textBox_XAxis_AssemblyPosition.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBox_XAxis_AssemblyPosition.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold);
            this.textBox_XAxis_AssemblyPosition.Location = new System.Drawing.Point(207, 24);
            this.textBox_XAxis_AssemblyPosition.Name = "textBox_XAxis_AssemblyPosition";
            this.textBox_XAxis_AssemblyPosition.ReadOnly = true;
            this.textBox_XAxis_AssemblyPosition.Size = new System.Drawing.Size(138, 46);
            this.textBox_XAxis_AssemblyPosition.TabIndex = 1;
            this.toolTip.SetToolTip(this.textBox_XAxis_AssemblyPosition, "手动输入坐标修改位置");
            this.textBox_XAxis_AssemblyPosition.Click += new System.EventHandler(this.textBox_XAxis_AssemblyPosition_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(32, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 39);
            this.label7.TabIndex = 0;
            this.label7.Text = "合模位置:";
            this.toolTip.SetToolTip(this.label7, "手动输入坐标修改位置");
            // 
            // AxisX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxEx2);
            this.Name = "AxisX";
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
        private System.Windows.Forms.TextBox textBox_XAxis_AssemblyPosition;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label15;
    }
}
