namespace ECInspect
{
    partial class SystemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemForm));
            this.btn_Shutdown = new ECInspect.ImageButton();
            this.btn_RestartComputer = new ECInspect.ImageButton();
            this.btn_ShutdownComputer = new ECInspect.ImageButton();
            this.btn_PLC = new ECInspect.ImageButton();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_ICT = new ECInspect.ImageButton();
            this.btn_Update = new ECInspect.ImageButton();
            this.label_Ver = new System.Windows.Forms.Label();
            this.label_PLCVer = new System.Windows.Forms.Label();
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
            this.splitContainer.Panel1.Controls.Add(this.label_PLCVer);
            this.splitContainer.Panel1.Controls.Add(this.label_Ver);
            this.splitContainer.Panel1.Controls.Add(this.btn_ICT);
            this.splitContainer.Panel1.Controls.Add(this.label5);
            this.splitContainer.Panel1.Controls.Add(this.btn_Update);
            this.splitContainer.Panel1.Controls.Add(this.btn_PLC);
            // 
            // btn_Shutdown
            // 
            this.btn_Shutdown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Shutdown.BackColor = System.Drawing.Color.Purple;
            this.btn_Shutdown.Font = new System.Drawing.Font("Microsoft YaHei", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Shutdown.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Shutdown.Location = new System.Drawing.Point(361, 413);
            this.btn_Shutdown.Name = "btn_Shutdown";
            this.btn_Shutdown.Size = new System.Drawing.Size(1208, 120);
            this.btn_Shutdown.TabIndex = 0;
            this.btn_Shutdown.Text = "关闭软件";
            this.btn_Shutdown.UseVisualStyleBackColor = false;
            this.btn_Shutdown.Click += new System.EventHandler(this.btn_Shutdown_Click);
            // 
            // btn_RestartComputer
            // 
            this.btn_RestartComputer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_RestartComputer.BackColor = System.Drawing.Color.Green;
            this.btn_RestartComputer.Font = new System.Drawing.Font("Microsoft YaHei", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_RestartComputer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_RestartComputer.Location = new System.Drawing.Point(361, 261);
            this.btn_RestartComputer.Name = "btn_RestartComputer";
            this.btn_RestartComputer.Size = new System.Drawing.Size(1208, 120);
            this.btn_RestartComputer.TabIndex = 1;
            this.btn_RestartComputer.Text = "重启电脑";
            this.btn_RestartComputer.UseVisualStyleBackColor = false;
            this.btn_RestartComputer.Click += new System.EventHandler(this.btn_RestartComputer_Click);
            // 
            // btn_ShutdownComputer
            // 
            this.btn_ShutdownComputer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ShutdownComputer.BackColor = System.Drawing.Color.Black;
            this.btn_ShutdownComputer.Font = new System.Drawing.Font("Microsoft YaHei", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ShutdownComputer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_ShutdownComputer.Location = new System.Drawing.Point(361, 109);
            this.btn_ShutdownComputer.Name = "btn_ShutdownComputer";
            this.btn_ShutdownComputer.Size = new System.Drawing.Size(1208, 120);
            this.btn_ShutdownComputer.TabIndex = 2;
            this.btn_ShutdownComputer.Text = "关闭电脑";
            this.btn_ShutdownComputer.UseVisualStyleBackColor = false;
            this.btn_ShutdownComputer.Click += new System.EventHandler(this.btn_ShutdownComputer_Click);
            // 
            // btn_PLC
            // 
            this.btn_PLC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_PLC.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_PLC.Location = new System.Drawing.Point(1678, 819);
            this.btn_PLC.Name = "btn_PLC";
            this.btn_PLC.Size = new System.Drawing.Size(230, 110);
            this.btn_PLC.TabIndex = 0;
            this.btn_PLC.Text = "PLC";
            this.btn_PLC.UseVisualStyleBackColor = true;
            this.btn_PLC.Click += new System.EventHandler(this.btn_PLC_Click);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1920, 80);
            this.label5.TabIndex = 1;
            this.label5.Text = "指定系统运行动作";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_ICT
            // 
            this.btn_ICT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ICT.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ICT.Location = new System.Drawing.Point(1678, 693);
            this.btn_ICT.Name = "btn_ICT";
            this.btn_ICT.Size = new System.Drawing.Size(230, 110);
            this.btn_ICT.TabIndex = 0;
            this.btn_ICT.Text = "ICT";
            this.btn_ICT.UseVisualStyleBackColor = true;
            this.btn_ICT.Click += new System.EventHandler(this.btn_ICT_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Update.BackColor = System.Drawing.Color.RoyalBlue;
            this.btn_Update.Font = new System.Drawing.Font("Microsoft YaHei", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Update.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Update.Location = new System.Drawing.Point(361, 793);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(1208, 120);
            this.btn_Update.TabIndex = 0;
            this.btn_Update.Text = "版本升级";
            this.btn_Update.UseVisualStyleBackColor = false;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // label_Ver
            // 
            this.label_Ver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_Ver.AutoSize = true;
            this.label_Ver.Font = new System.Drawing.Font("Microsoft YaHei", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Ver.Location = new System.Drawing.Point(12, 607);
            this.label_Ver.Name = "label_Ver";
            this.label_Ver.Size = new System.Drawing.Size(90, 46);
            this.label_Ver.TabIndex = 2;
            this.label_Ver.Text = "Ver:";
            // 
            // label_PLCVer
            // 
            this.label_PLCVer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_PLCVer.AutoSize = true;
            this.label_PLCVer.Font = new System.Drawing.Font("Microsoft YaHei", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_PLCVer.Location = new System.Drawing.Point(12, 804);
            this.label_PLCVer.Name = "label_PLCVer";
            this.label_PLCVer.Size = new System.Drawing.Size(316, 46);
            this.label_PLCVer.TabIndex = 2;
            this.label_PLCVer.Text = "PLC Ver:读取中···";
            // 
            // SystemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.btn_ShutdownComputer);
            this.Controls.Add(this.btn_RestartComputer);
            this.Controls.Add(this.btn_Shutdown);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "SystemForm";
            this.Text = "SystemForm";
            this.Load += new System.EventHandler(this.SystemForm_Load);
            this.Controls.SetChildIndex(this.splitContainer, 0);
            this.Controls.SetChildIndex(this.btn_Shutdown, 0);
            this.Controls.SetChildIndex(this.btn_RestartComputer, 0);
            this.Controls.SetChildIndex(this.btn_ShutdownComputer, 0);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ImageButton btn_Shutdown;
        private ImageButton btn_RestartComputer;
        private ImageButton btn_ShutdownComputer;
        private ImageButton btn_PLC;
        private System.Windows.Forms.Label label5;
        private ImageButton btn_ICT;
        private ImageButton btn_Update;
        private System.Windows.Forms.Label label_Ver;
        private System.Windows.Forms.Label label_PLCVer;
    }
}