using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ECInspect
{
    public partial class ManualForm : Frame
    {
        public ManualForm()
        {
            InitializeComponent();

            this.WindowRefresh.Tick += new EventHandler(WindowRefresh_Tick);
            WindowRefresh_Tick(null, EventArgs.Empty);//立刻刷新一次
        }

        private void WindowRefresh_Tick(object sender, EventArgs e)
        {
            this.either_Press.LeftPress = !GlobalVar.c_Modbus.Coils.Cylinder_DownPressure.Value;//下压汽缸
            this.either_DiNianZhe.LeftPress = GlobalVar.c_Modbus.Coils.DiNianZhe.Value;//低粘着
            this.either_DownJigCylinder.LeftPress = GlobalVar.c_Modbus.Coils.DownJigCylinder.Value;//下治具电磁阀

            this.Invalidate();
        }

        private void ManualForm_Load(object sender, EventArgs e)
        {
            this.btn_CCD.Enabled = GlobalVar.CCDEnable;
            this.btn_ScanPoint.Enabled = INIFileValue.BarcodeScanEnable;
        }

        private void btn_AdjustNozzle_Click(object sender, EventArgs e)
        {
            ShowFrame(ClickBtn.Nozzle);
        }

        private void btn_CCD_Click(object sender, EventArgs e)
        {
            ShowFrame(ClickBtn.CCD);
        }

        private void btn_Mark_Click(object sender, EventArgs e)
        {
            ShowFrame(ClickBtn.Mark);
        }
        private void btn_ScanPoint_Click(object sender, EventArgs e)
        {
            ShowFrame(ClickBtn.Scan);
        }

        private void ShowFrame(ClickBtn cb)
        {
            Frame form = null;
            switch (cb)
            {
                case ClickBtn.Nozzle:
                    form = new NozzleForm();
                    break;
                case ClickBtn.Mark:
                    form = new MarkForm();
                    break;
                case ClickBtn.CCD:
                    if (GlobalVar.CCD == null) return;
                    form = new CCDForm();
                    break;
                case ClickBtn.Scan:
                    form = new ScanMarkForm();
                    break;
                default:
                    //默认窗口，测试用···
                    form = new Frame();
                    break;
            }
            form.TopLevel = false;
            form.Parent = this;
            form.MdiParent = this.MdiParent;
            form.ShowDialog();
        }

        /// <summary>
        /// 运动判断，是否允许Y轴运动
        /// </summary>
        /// <returns></returns>
        private bool MoveJudge()
        {
            if (GlobalVar.c_Modbus == null || !GlobalVar.c_Modbus.Coils.StartLeft.Value) return false;      //未按下左键
            if (GlobalVar.c_Modbus.Coils.Cylinder12.Value)   //相机下压
            {
                GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.Cylinder12, false);
                for (int i = 0; i < 3; i++)
                {
                    Thread.Sleep(350);
                    if (!GlobalVar.c_Modbus.Coils.Cylinder12.Value) return true;
                }
                return false;
            }
            else return true;
        }

        private void btn_MoveToProduct_Click(object sender, EventArgs e)
        {
            if (!MoveJudge()) return;

            GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.YJigLocation, true);
        }

        private void btn_MoveToCCD_Click(object sender, EventArgs e)
        {
            if (!MoveJudge()) return;

            if (btn_MoveToCCD.Text == "相机位置")
            {
                btn_MoveToCCD.Text = "初始位置";
                GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.TakePhotoPosition, true);
                GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.CCD_PhotoPoint, true);
            }
            else
            {
                btn_MoveToCCD.Text = "相机位置";
                GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.TakePhotoPosition, false);
                GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.CCD_PhotoPoint, false);

            }
            
            
        }

        private void btn_MoveToNazzie_Click(object sender, EventArgs e)
        {
            if (!MoveJudge()) return;

            GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.YReverseLocation, true);
        }

        private void btn_MoveToEdge_Click(object sender, EventArgs e)
        {
            if (!MoveJudge()) return;

            GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.YPlaceLocation, true);
        }

        private void btn_MoveToScanPoint_Click(object sender, EventArgs e)
        {

        }
        private void btn_Disassemble_Click(object sender, EventArgs e)
        {
            btn_Disassemble.Visible = false;

            Either cylnder_fixed = new Either();
            cylnder_fixed.Location = btn_Disassemble.Location;
            cylnder_fixed.Title = "上治具固定";
            cylnder_fixed.BtnLeftText = "ON";
            cylnder_fixed.BtnRightText = "OFF";
            cylnder_fixed.Show();
            btn_Disassemble.Parent.Controls.Add(cylnder_fixed);

            Either cylnder_connection = new Either();
            cylnder_connection.Location = new Point(btn_Disassemble.Location.X, btn_Disassemble.Location.Y + cylnder_fixed.Height + 10);
            cylnder_connection.Title = "上治具连接";
            cylnder_connection.BtnLeftText = "ON";
            cylnder_connection.BtnRightText = "OFF";
            cylnder_connection.Show();
            btn_Disassemble.Parent.Controls.Add(cylnder_connection);

            cylnder_fixed.LeftPress = (!GlobalVar.c_Modbus.Coils.Cylinder_LeftRightClamp.Value) && (!GlobalVar.c_Modbus.Coils.Cylinder_UpDown.Value);//左右夹取、上下夹取汽缸
            cylnder_connection.LeftPress = !GlobalVar.c_Modbus.Coils.Cylinder_BeforeBack.Value;//前后夹取汽缸
            
            cylnder_fixed.Event_BtnClick += new Either.dele_LeftRight(cylnder_fixed_Event_BtnClick);
            cylnder_connection.Event_BtnClick += new Either.dele_LeftRight(cylnder_connection_Event_BtnClick);
        }

        private void cylnder_fixed_Event_BtnClick(object sender, LeftRightSide lr)
        {
            switch (lr)
            {
                case LeftRightSide.Left:
                    GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.Cylinder_LeftRightClamp, false);
                    for (int i = 0; i < 10; i++)//等待一秒到位
                    {
                        if (GlobalVar.c_Modbus.Coils.Cylinder_LeftRightClamp.Value) Thread.Sleep(100);
                    }
                    if (GlobalVar.c_Modbus.Coils.Cylinder_LeftRightClamp.Value)
                    {
                        //此时PLC提示左右夹取汽缸超时
                        break;
                    }
                    GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.Cylinder_UpDown, false);
                    break;
                case LeftRightSide.Right:
                    if (!GlobalVar.c_Modbus.Coils.Cylinder_BeforeBack.Value)
                    {
                        ((Either)sender).ChangeBackColor(true);
                        MsgBox("终止连接", Color.Red, MessageBoxButtons.OK);//提示的意思是，先解开上治具连接
                        break;
                    }

                    GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.Cylinder_LeftRightClamp, true);
                    for (int i = 0; i < 10; i++)//等待一秒到位
                    {
                        if (!GlobalVar.c_Modbus.Coils.Cylinder_LeftRightClamp.Value) Thread.Sleep(100);
                    }
                    if (!GlobalVar.c_Modbus.Coils.Cylinder_LeftRightClamp.Value)
                    {
                        //此时PLC提示左右夹取汽缸超时
                        break;
                    }
                    GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.Cylinder_UpDown, true);
                    MsgBox("上治具锁紧装置打开，再次进行段取", Color.LightGoldenrodYellow, MessageBoxButtons.OK);
                    break;
            }
        }

        private void cylnder_connection_Event_BtnClick(object sender, LeftRightSide lr)
        {
            switch (lr)
            {
                case LeftRightSide.Left:
                    if ((GlobalVar.c_Modbus.Coils.Cylinder_LeftRightClamp.Value) || (GlobalVar.c_Modbus.Coils.Cylinder_UpDown.Value))
                    {
                        ((Either)sender).ChangeBackColor(false);
                        MsgBox("请先锁紧上治具", Color.LightGoldenrodYellow, MessageBoxButtons.OK);
                        break;
                    }
                    GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.Cylinder_BeforeBack, false);
                    if ((!GlobalVar.c_Modbus.Coils.Cylinder_LeftRightClamp.Value) && (!GlobalVar.c_Modbus.Coils.Cylinder_UpDown.Value))
                    {
                        MsgBox("上治具锁紧装置打开，再次进行段取", Color.LightGoldenrodYellow, MessageBoxButtons.OK);
                        break;
                    }
                    break;
                case LeftRightSide.Right:
                    GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.Cylinder_BeforeBack, true);
                    break;
            }
        }

        private void either_Press_Event_BtnClick(object sender, LeftRightSide lr)
        {
            switch (lr)
            { 
                case LeftRightSide.Left:
                    GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.Cylinder_DownPressure, false);
                    break;
                case LeftRightSide.Right:
                    if (GlobalVar.c_Modbus.HoldingRegisters.AxisY_RealLocation.Value != GlobalVar.c_Modbus.HoldingRegisters.AxisY_JigPoint.Value)//当前位置非治具位置，禁止下压
                    {
                        ((Either)sender).ChangeBackColor(true);
                        MsgBox("请先移动到治具位置", Color.Red, MessageBoxButtons.OK);
                        break;
                    }
                    else
                        GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.Cylinder_DownPressure, true);
                    break;
            }
        }

        private void either_DiNianZhe_Event_BtnClick(object sender, LeftRightSide lr)
        {
            switch (lr)
            {
                case LeftRightSide.Left:
                    GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.DiNianZhe, true);
                    break;
                case LeftRightSide.Right:
                    GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.DiNianZhe, false);
                    break;
            }           
        }

        private void either_DownJigCylinder_Event_BtnClick(object sender, LeftRightSide lr)
        {
            switch (lr)
            {
                case LeftRightSide.Left:
                    GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.DownJigCylinder, true);
                    break;
                case LeftRightSide.Right:
                    GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.DownJigCylinder, false);
                    break;
            }           
        }

        private void btn_MoveToScanPoint_Click_1(object sender, EventArgs e)
        {
            if (btn_MoveToScanPoint.Text == "扫描位置")
            {
                GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.ScanPosition, true);
                btn_MoveToScanPoint.Text = "等待位置";
            }
            else
            {
                GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.ScanPosition, false);
                btn_MoveToScanPoint.Text = "扫描位置";
            }
        }

    }
}
