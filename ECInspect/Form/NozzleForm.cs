using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ECInspect
{
    public partial class NozzleForm : Frame
    {
        public NozzleForm()
        {
            InitializeComponent();
            this.WindowRefresh.Tick += new EventHandler(WindowRefresh_Tick);
            WindowRefresh_Tick(null,EventArgs.Empty);//立刻刷新一次
        }

        private void WindowRefresh_Tick(object sender, EventArgs e)
        {
            this.either_NozzleUpDown.LeftPress = !GlobalVar.c_Modbus.Coils.Cylinder_Absorb.Value;  //吸附装置 上升
            this.either_Vacuum.LeftPress  = GlobalVar.c_Modbus.Coils.Vacuum_Absorb.Value;          //真空
            this.either_Rotate.LeftPress =GlobalVar.c_Modbus.Coils.Cylinder_Rotate.Value;   //吸附装置 左
            this.either_SetBoard.LeftPress = GlobalVar.c_Modbus.Coils.Cylinder_HoldMater.Value;       //制品设定板
            this.either_Carry.LeftPress = GlobalVar.c_Modbus.Coils.CarryFeedPosition.Value;         //搬运轴
        }

        private void either_NozzleUpDown_Event_BtnClick(object sender, LeftRightSide lr)
        {
            switch(lr)
            {
                case LeftRightSide.Left:
                    GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.Cylinder_Absorb, false);
                    break;
                case LeftRightSide.Right:
                    GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.Cylinder_Absorb, true);
                    break;
            }
            ReStartRefresh();
        }

        private void either_Vacuum_Event_BtnClick(object sender, LeftRightSide lr)
        {
            switch (lr)
            {
                case LeftRightSide.Left:
                    GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.Vacuum_Absorb, true);
                    break;
                case LeftRightSide.Right:
                    GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.Vacuum_Absorb, false);
                    break;
            }
            ReStartRefresh();
        }

        private void either_Rotate_Event_BtnClick(object sender, LeftRightSide lr)
        {
            switch (lr)
            {
                case LeftRightSide.Left:
                    GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.Cylinder_Rotate, true);
                    break;
                case LeftRightSide.Right:
                    GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.Cylinder_Rotate, false);
                    break;
            }
            ReStartRefresh();
        }

        private void either_SetBoard_Event_BtnClick(object sender, LeftRightSide lr)
        {
            switch (lr)
            {
                case LeftRightSide.Left:
                    GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.Cylinder_HoldMater, true);
                    break;
                case LeftRightSide.Right:
                    GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.Cylinder_HoldMater, false);
                    break;
            }
            ReStartRefresh();
        }

        private void either_Carry_Event_BtnClick(object sender, LeftRightSide lr)
        {
            switch (lr)
            {
                case LeftRightSide.Left:
                    GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.CarryFeedPosition, true);
                    GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.CarryBlankPositon, false);
                    break;
                case LeftRightSide.Right:
                    GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.CarryFeedPosition, false);
                    GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.CarryBlankPositon, true);
                    break;
            }
            ReStartRefresh();
        }
    }
}
