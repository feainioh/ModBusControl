namespace ECInspect
{
    partial class NozzleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NozzleForm));
            this.either_NozzleUpDown = new ECInspect.Either();
            this.either_Vacuum = new ECInspect.Either();
            this.either_Rotate = new ECInspect.Either();
            this.either_SetBoard = new ECInspect.Either();
            this.either_Carry = new ECInspect.Either();
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
            this.splitContainer.Panel1.Controls.Add(this.either_Carry);
            this.splitContainer.Panel1.Controls.Add(this.either_Rotate);
            this.splitContainer.Panel1.Controls.Add(this.either_SetBoard);
            this.splitContainer.Panel1.Controls.Add(this.either_Vacuum);
            this.splitContainer.Panel1.Controls.Add(this.either_NozzleUpDown);
            // 
            // either_NozzleUpDown
            // 
            this.either_NozzleUpDown.BackColor = System.Drawing.SystemColors.Control;
            this.either_NozzleUpDown.BtnLeftText = "上升";
            this.either_NozzleUpDown.BtnRightText = "下降";
            this.either_NozzleUpDown.LeftPress = true;
            this.either_NozzleUpDown.Location = new System.Drawing.Point(160, 162);
            this.either_NozzleUpDown.Name = "either_NozzleUpDown";
            this.either_NozzleUpDown.Size = new System.Drawing.Size(717, 113);
            this.either_NozzleUpDown.TabIndex = 0;
            this.either_NozzleUpDown.Title = "吸附装置";
            this.either_NozzleUpDown.Event_BtnClick += new ECInspect.Either.dele_LeftRight(this.either_NozzleUpDown_Event_BtnClick);
            // 
            // either_Vacuum
            // 
            this.either_Vacuum.BackColor = System.Drawing.SystemColors.Control;
            this.either_Vacuum.BtnLeftText = "ON";
            this.either_Vacuum.BtnRightText = "OFF";
            this.either_Vacuum.LeftPress = true;
            this.either_Vacuum.Location = new System.Drawing.Point(908, 162);
            this.either_Vacuum.Name = "either_Vacuum";
            this.either_Vacuum.Size = new System.Drawing.Size(717, 113);
            this.either_Vacuum.TabIndex = 0;
            this.either_Vacuum.Title = "真空";
            this.either_Vacuum.Event_BtnClick += new ECInspect.Either.dele_LeftRight(this.either_Vacuum_Event_BtnClick);
            // 
            // either_Rotate
            // 
            this.either_Rotate.BackColor = System.Drawing.SystemColors.Control;
            this.either_Rotate.BtnLeftText = "旋转";
            this.either_Rotate.BtnRightText = "回位";
            this.either_Rotate.LeftPress = true;
            this.either_Rotate.Location = new System.Drawing.Point(160, 468);
            this.either_Rotate.Name = "either_Rotate";
            this.either_Rotate.Size = new System.Drawing.Size(717, 113);
            this.either_Rotate.TabIndex = 0;
            this.either_Rotate.Title = "旋转汽缸";
            this.either_Rotate.Event_BtnClick += new ECInspect.Either.dele_LeftRight(this.either_Rotate_Event_BtnClick);
            // 
            // either_SetBoard
            // 
            this.either_SetBoard.BackColor = System.Drawing.SystemColors.Control;
            this.either_SetBoard.BtnLeftText = "上升";
            this.either_SetBoard.BtnRightText = "下降";
            this.either_SetBoard.LeftPress = true;
            this.either_SetBoard.Location = new System.Drawing.Point(908, 468);
            this.either_SetBoard.Name = "either_SetBoard";
            this.either_SetBoard.Size = new System.Drawing.Size(717, 113);
            this.either_SetBoard.TabIndex = 0;
            this.either_SetBoard.Title = "制品设定板";
            this.either_SetBoard.Event_BtnClick += new ECInspect.Either.dele_LeftRight(this.either_SetBoard_Event_BtnClick);
            // 
            // either_Carry
            // 
            this.either_Carry.BackColor = System.Drawing.SystemColors.Control;
            this.either_Carry.BtnLeftText = "左";
            this.either_Carry.BtnRightText = "右";
            this.either_Carry.LeftPress = true;
            this.either_Carry.Location = new System.Drawing.Point(160, 758);
            this.either_Carry.Name = "either_Carry";
            this.either_Carry.Size = new System.Drawing.Size(717, 113);
            this.either_Carry.TabIndex = 1;
            this.either_Carry.Title = "搬运轴";
            this.either_Carry.Event_BtnClick += new ECInspect.Either.dele_LeftRight(this.either_Carry_Event_BtnClick);
            // 
            // NozzleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "NozzleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NozzleForm";
            this.splitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Either either_Vacuum;
        private Either either_NozzleUpDown;
        private Either either_Rotate;
        private Either either_SetBoard;
        private Either either_Carry;
    }
}