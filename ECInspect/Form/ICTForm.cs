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
    public partial class ICTForm : Frame
    {
        Logs log = Logs.LogsT();

        public ICTForm()
        {
            InitializeComponent();
        }

        private void ICTForm_Load(object sender, EventArgs e)
        {
            this.either_BarcodeGun.LeftPress = (INIFileValue.BarcodeGunEnable||INIFileValue.BarcodeScanEnable);
            this.either_UpToSql.LeftPress = GlobalVar.gl_UpSql;
            if (this.either_BarcodeGun.LeftPress)
            {
                gb_scanMode.Visible = true;
                rb_GunScan.Checked = INIFileValue.BarcodeGunEnable;
                rb_scan.Checked = INIFileValue.BarcodeScanEnable;
            }
            else
            {
                gb_scanMode.Visible = false;
                INIFileValue.BarcodeGunEnable=false;
               INIFileValue.BarcodeScanEnable=false;
            }
            if (GlobalVar.gl_UpSql)
            {
                lb_Product.Visible = true;
                cb_Product.Visible = true;
                foreach(string item in DBQuery.GetAllDataBase())
                {
                    if (item.IndexOf('A') == 0) cb_Product.Items.Add(item);
                }
                foreach(string item in cb_Product.Items)
                {
                    if (item==GlobalVar.gl_str_product)
                    {
                        cb_Product.SelectedText = item;
                        break;
                    }
                }
                if (INIFileValue.FlowID == "33") radioButton_FirstMachine.Checked = true;
                else radioButton_SecondMachine.Checked = true;
            }
            else
            {
                lb_Product.Visible = false;
                cb_Product.Visible = false;
            }
        }

        private void btn_Tester_Click(object sender, EventArgs e)
        {
            GlobalVar.m_ECTest.StartTest();
        }

        private void btn_GroupNum_Click(object sender, EventArgs e)
        {
            MsgBoxShow("个体片数：" + INIFileValue.Product_GROUP.ToString());
        }


        /// <summary>
        /// 弹框
        /// </summary>
        /// <param name="msg">内容</param>
        /// <param name="title">标题</param>
        /// <returns></returns>
        private DialogResult MsgBoxShow(string msg, string title = "ICT")
        {
            log.AddCommLOG(msg);
            MsgBox box = new MsgBox();
            box.BackColor = Color.LimeGreen;
            box.Title = title;
            box.ShowText = msg;
            return box.ShowDialog();
        }

        private void btn_ReadCard_Click(object sender, EventArgs e)
        {
            this.textBox_CardContent.Text = string.Empty;
            string msg = GlobalVar.m_CardReader.ReadOnce();
            this.textBox_CardContent.Text = !string.IsNullOrEmpty(msg) ? msg : "读取失败";
            log.AddCommLOG("手动 读卡器:" + msg);
        }

        private void either_BarcodeGun_Event_BtnClick(object sender, LeftRightSide lr)
        {
            if (lr == LeftRightSide.Left) gb_scanMode.Visible = true;
            else
            {
                gb_scanMode.Visible = false;
                INIFileValue.BarcodeGunEnable = false;
                myFunction.WriteIniString(INIFileValue.gl_inisection_BarcodeGun, INIFileValue.gl_iniKey_BarcodeGunEnable, INIFileValue.BarcodeGunEnable.ToString());//条码枪是否启用s
                INIFileValue.BarcodeScanEnable = false;
                myFunction.WriteIniString(INIFileValue.gl_inisection_BarcodeScan, INIFileValue.gl_iniKey_BarcodeScanEnable, INIFileValue.BarcodeScanEnable.ToString());//康耐视条码枪是否启用
                GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.BarcodeScanUesd, false);
            }
        }

        private void rb_GunScan_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_GunScan.Checked)
            {
                INIFileValue.BarcodeGunEnable = true ;
                myFunction.WriteIniString(INIFileValue.gl_inisection_BarcodeGun, INIFileValue.gl_iniKey_BarcodeGunEnable, INIFileValue.BarcodeGunEnable.ToString());//条码枪是否启用
            }
            else
            {
                INIFileValue.BarcodeGunEnable = false;
                myFunction.WriteIniString(INIFileValue.gl_inisection_BarcodeGun, INIFileValue.gl_iniKey_BarcodeGunEnable, INIFileValue.BarcodeGunEnable.ToString());//条码枪是否启用s
            }
        }

        private void rb_scan_CheckedChanged(object sender, EventArgs e)
        {//设置是否启用条码枪--[2018.3.29 lqz]
            if (rb_scan.Checked)
            {
                INIFileValue.BarcodeScanEnable = true;
                myFunction.WriteIniString(INIFileValue.gl_inisection_BarcodeScan, INIFileValue.gl_iniKey_BarcodeScanEnable, INIFileValue.BarcodeScanEnable.ToString());//康耐视条码枪是否启用
                GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.BarcodeScanUesd,true);
            }
            else
            {
                INIFileValue.BarcodeScanEnable = false;
                myFunction.WriteIniString(INIFileValue.gl_inisection_BarcodeScan, INIFileValue.gl_iniKey_BarcodeScanEnable, INIFileValue.BarcodeScanEnable.ToString());//康耐视条码枪是否启用
                GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.BarcodeScanUesd, false);
            }
            
        }

        private void either_UpToSql_Event_BtnClick(object sender, LeftRightSide lr)
        {
            if (lr==LeftRightSide.Left)
            {
                GlobalVar.gl_UpSql = true;
                myFunction.WriteIniString(INIFileValue.gl_inisection_UpdateSql, INIFileValue.gl_iniKey_UpdateSql, true.ToString());//上传数据库是否启用
                cb_Product.Visible = true;
            }
            else
            {
                GlobalVar.gl_UpSql = false;
                myFunction.WriteIniString(INIFileValue.gl_inisection_UpdateSql, INIFileValue.gl_iniKey_UpdateSql, false.ToString());//上传数据库是否启用               
                cb_Product.Visible = false;
            }
        }

        private void cb_Product_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Product.SelectedText != "")
            {
                GlobalVar.gl_str_product = cb_Product.SelectedText;
                myFunction.WriteIniString(INIFileValue.gl_inisection_UpdateSql, INIFileValue.gl_iniKey_SqlName, GlobalVar.gl_str_product);//上传数据库名称   
                myFunction myf = new myFunction();
                myf.ReadMapping();
            }
        }

        private void radioButton_FirstMachine_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_FirstMachine.Checked)
            {
                INIFileValue.FlowID = "33";
                myFunction.WriteIniString(INIFileValue.gl_inisection_UpdateSql,INIFileValue.gl_iniKey_FlowId,INIFileValue.FlowID);
            }
            else
            {
                INIFileValue.FlowID = "35";
                myFunction.WriteIniString(INIFileValue.gl_inisection_UpdateSql,INIFileValue.gl_iniKey_FlowId,INIFileValue.FlowID);
            }
        }

        private void radioButton_SecondMachine_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_SecondMachine.Checked)
            {
                INIFileValue.FlowID = "35";
                myFunction.WriteIniString(INIFileValue.gl_inisection_UpdateSql, INIFileValue.gl_iniKey_FlowId, INIFileValue.FlowID);
            }
            else
            {
                INIFileValue.FlowID = "33";
                myFunction.WriteIniString(INIFileValue.gl_inisection_UpdateSql, INIFileValue.gl_iniKey_FlowId, INIFileValue.FlowID);
            }
        }
    }
}
