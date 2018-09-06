namespace ECInspect
{
    partial class AxisTrackBar
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
            this.groupBoxEx1 = new ECInspect.GroupBoxEx();
            this.label_AxisName = new System.Windows.Forms.Label();
            this.trackBar_Axis = new System.Windows.Forms.TrackBar();
            this.textBox_Axis = new System.Windows.Forms.TextBox();
            this.btn_Run = new ECInspect.ImageButton();
            this.groupBoxEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Axis)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxEx1
            // 
            this.groupBoxEx1.BorderColor = System.Drawing.Color.Blue;
            this.groupBoxEx1.Controls.Add(this.label_AxisName);
            this.groupBoxEx1.Controls.Add(this.trackBar_Axis);
            this.groupBoxEx1.Controls.Add(this.textBox_Axis);
            this.groupBoxEx1.Controls.Add(this.btn_Run);
            this.groupBoxEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxEx1.Location = new System.Drawing.Point(0, 0);
            this.groupBoxEx1.Name = "groupBoxEx1";
            this.groupBoxEx1.Radius = 10;
            this.groupBoxEx1.Size = new System.Drawing.Size(800, 59);
            this.groupBoxEx1.TabIndex = 8;
            this.groupBoxEx1.TabStop = false;
            this.groupBoxEx1.TitleFont = new System.Drawing.Font("SimSun", 10F);
            // 
            // label_AxisName
            // 
            this.label_AxisName.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Bold);
            this.label_AxisName.Location = new System.Drawing.Point(4, 14);
            this.label_AxisName.Name = "label_AxisName";
            this.label_AxisName.Size = new System.Drawing.Size(58, 27);
            this.label_AxisName.TabIndex = 4;
            this.label_AxisName.Text = "X:";
            this.label_AxisName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBar_Axis
            // 
            this.trackBar_Axis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar_Axis.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.trackBar_Axis.Location = new System.Drawing.Point(63, 5);
            this.trackBar_Axis.Name = "trackBar_Axis";
            this.trackBar_Axis.Size = new System.Drawing.Size(527, 45);
            this.trackBar_Axis.TabIndex = 5;
            this.trackBar_Axis.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_Axis.Scroll += new System.EventHandler(this.trackBar_Axis_Scroll);
            this.trackBar_Axis.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBar_Axis_MouseDown);
            this.trackBar_Axis.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar_Axis_MouseUp);
            // 
            // textBox_Axis
            // 
            this.textBox_Axis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Axis.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Bold);
            this.textBox_Axis.Location = new System.Drawing.Point(596, 10);
            this.textBox_Axis.Name = "textBox_Axis";
            this.textBox_Axis.Size = new System.Drawing.Size(100, 34);
            this.textBox_Axis.TabIndex = 7;
            this.textBox_Axis.Text = "0";
            this.textBox_Axis.Click += new System.EventHandler(this.textBox_Axis_Click);
            // 
            // btn_Run
            // 
            this.btn_Run.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Run.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Run.Location = new System.Drawing.Point(702, 5);
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.Size = new System.Drawing.Size(92, 48);
            this.btn_Run.TabIndex = 6;
            this.btn_Run.Text = "执行";
            this.btn_Run.UseVisualStyleBackColor = true;
            this.btn_Run.Click += new System.EventHandler(this.btn_Run_Click);
            // 
            // AxisTrackBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxEx1);
            this.MinimumSize = new System.Drawing.Size(538, 59);
            this.Name = "AxisTrackBar";
            this.Size = new System.Drawing.Size(800, 59);
            this.groupBoxEx1.ResumeLayout(false);
            this.groupBoxEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Axis)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Axis;
        private ImageButton btn_Run;
        private System.Windows.Forms.TrackBar trackBar_Axis;
        private System.Windows.Forms.Label label_AxisName;
        private GroupBoxEx groupBoxEx1;
    }
}
