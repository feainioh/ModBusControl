using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace ECInspect
{
    class DBQuery
    {
        myFunction myFunc = new myFunction();
        Logs log = Logs.LogsT();

        int updateErrCount = 0;//上传数据库异常计数
        int updateErrCount_BM = 0;
        private string database_BM = "BARDATA";
        private string database_Acuqaint = "BASEDATA";

        /// <summary>
        /// suzsqlv01数据库插入测试结果[2018/03/03 lqz]
        /// </summary>
        /// <param name="database">数据库名称</param>
        /// <param name="tr">测试结果</param>
        /// <returns></returns>
        public bool InsertTestResult(string database, TestResult tr)
        {
            //suzsqlv01 192.168.208.207
            string strsql = string.Format("Data Source={0};database={1};uid=suzmektec;pwd=suzmek;Connect Timeout=2;Application Name={2}", GlobalVar.DataSource_TestResult, database, GlobalVar.ApplicationName);//数据库链接字符串
            #region 直接插入数据库
            if (tr.ShtBarcode == "" || tr.ShtBarcode == null)
            {
                return false;
            }
            //String sqlS = null;
            //string sql = "select * from " + GlobalVar.gl_Table_TestResultData + " where ShtBarcode='" + tr.ShtBarcode + "' and PcsIndex =" + tr.PcsIndex + " and FlowId=" + tr.FlowId;
            //using (SqlConnection sqlConn = new SqlConnection(strsql))
            //{
            //    try
            //    {
            //        sqlConn.Open();
            //        SqlCommand sqlCmd = new SqlCommand(sql, sqlConn);
            //        SqlDataReader read = sqlCmd.ExecuteReader();
            //        if (!read.HasRows)
            //        {
            //            sqlS = "insert into " + GlobalVar.gl_Table_TestResultData + " (ShtBarcode,PcsIndex,TestResult,FlowId,CreateUser,CreateDate)" +
            //                                "values('" + tr.ShtBarcode + "'," + tr.PcsIndex + "," + tr.Result + "," + tr.FlowId + ",'" + tr.CreateUser + "','" + tr.CreateDate.ToString("yyyyMMdd HH:mm:ss.fff") + "')";
            //        }
            //        else
            //        {
            //            sqlS = "update " + GlobalVar.gl_Table_TestResultData + " set TestResult=" + tr.Result + ", CreateDate='" + tr.CreateDate.ToString("yyyyMMdd HH:mm:ss.fff") + "' where ShtBarcode='" + tr.ShtBarcode + "' and PcsIndex =" + tr.PcsIndex + " and FlowId=" + tr.FlowId;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        log.AddERRORLOG("查询数据库异常:" + ex.Message);
            //    }
            //    finally
            //    {
            //        sqlConn.Close();
            //    }
            //}
            //log.AddCommLOG("数据库操作:" + sqlS);
            String sqlS = "insert into " + GlobalVar.gl_Table_TestResultData + " (ShtBarcode,PcsIndex,TestResult,FlowId,CreateUser,CreateDate)" +
                                            "values('" + tr.ShtBarcode + "'," + tr.PcsIndex + "," + tr.Result + "," + tr.FlowId + ",'" + tr.CreateUser + "','" + tr.CreateDate.ToString("yyyyMMdd HH:mm:ss.fff") + "')";

            using (SqlConnection connValue = new SqlConnection(strsql))
            {
                try
                {
                    connValue.Open();
                    SqlCommand commv = new SqlCommand(sqlS);
                    commv.CommandTimeout = 1;
                    commv.Connection = connValue;
                    if (commv.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else return false;
                }
                catch (Exception ex)
                {
                    updateErrCount++;
                    log.AddERRORLOG("数据库上传异常:" + ex.ToString());
                    if (updateErrCount > INIFileValue.Product_GROUP)
                    {
                        updateErrCount = 0;
                        ErrMsgBox("数据库上传异常连续次数超限！");
                    }
                    return false;
                }
                finally
                {
                    connValue.Close();
                }
            }
            #endregion
        }

        /// <summary>
        /// 关联pcs位置
        /// </summary>
        public bool AcuqaintPcs()
        {
            string strsql = string.Format("Data Source={0};database={1};uid=suzmektec;pwd=suzmek;Connect Timeout=2;Application Name={2}", GlobalVar.DataSource_TestResult, database_Acuqaint, GlobalVar.ApplicationName);
            string sql = "SELECT PhyAddress,LogicAddress FROM Comparison WHERE ProductModel = '" + GlobalVar.gl_str_product + "'  and Mtype='EC' and MachineType='" + INIFileValue.MType + "' and isnull(DeletedFlag,'')=''";
            using (SqlConnection conn = new SqlConnection(strsql))
            {
                try
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    adapter.Fill(dt);
                    GlobalVar.gl_mapping.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int key = (int)dt.Rows[i][0];
                        int value = (int)dt.Rows[i][1];
                        if (GlobalVar.gl_mapping.ContainsKey(key)) GlobalVar.gl_mapping[key] = value;
                        else GlobalVar.gl_mapping.Add(key, value);
                    }
                    if (GlobalVar.gl_mapping.Keys.Count != 0)
                    {
                        myFunc.WriteMapping();
                        return true;
                    }
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    log.AddERRORLOG("获取MAPPING文件异常," + ex.Message);
                    return false;
                }
            }
        }




        /// <summary>
        /// 上传BM数据
        /// </summary>
        /// <param name="tr"></param>
        public bool InsertNGResultInBM(TestResult tr)
        {
            string strsql_BM = string.Format("Data Source={0};database={1};uid=suzmektec;pwd=suzmek;Connect Timeout=2;Application Name={2}", GlobalVar.DataSource_TestResult, database_BM, GlobalVar.ApplicationName);
            if (tr.Result == 1)
            {
                string sql_BM = "INSERT INTO " + GlobalVar.gl_Table_AutoPunchDataDetail + " (SHEETSN,PCSNO,PARTNO,WRITEDATE,UPDATETIME,DeletedFlag) " +
                    "VALUES  ('" + tr.ShtBarcode + "', '" + tr.PcsIndex + "', 'TOEC', '" + tr.CreateDate.ToString("yyyyMMdd HH:mm:ss.fff") + "', NULL, NULL)";
                using (SqlConnection connValue = new SqlConnection(strsql_BM))
                {
                    try
                    {
                        connValue.Open();
                        SqlCommand commv = new SqlCommand(sql_BM);
                        commv.CommandTimeout = 1;
                        commv.Connection = connValue;
                        if (commv.ExecuteNonQuery() > 0)
                        {
                            return true;
                        }
                        else return false;
                    }
                    catch (Exception ex)
                    {
                        updateErrCount_BM++;
                        log.AddERRORLOG("数据库上传异常:" + ex.ToString());
                        if (updateErrCount_BM > INIFileValue.Product_GROUP)//连续异常超过
                        {
                            updateErrCount_BM = 0;
                            ErrMsgBox("上传BM数据库异常连续次数超限！");
                        }
                        return false;
                    }
                    finally
                    {
                        connValue.Close();
                    }
                }
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 取所有数据库名,添加到lvDB
        /// </summary>
        /// <returns></returns>
        public static List<String> GetAllDataBase()
        {
            List<String> DBNameList = new List<String>();
            SqlConnection Connection = new SqlConnection(String.Format("Data Source={0};uid=suzmektec;pwd=suzmek;Connect Timeout=2;Application Name={1}", GlobalVar.DataSource_TestResult, GlobalVar.ApplicationName));
            DataTable DBNameTable = new DataTable();
            SqlDataAdapter Adapter = new SqlDataAdapter("select name from master..sysdatabases", Connection);

            lock (Adapter)
            {
                Adapter.Fill(DBNameTable);
            }

            foreach (DataRow row in DBNameTable.Rows)
            {
                DBNameList.Add(row["name"].ToString());
            }

            return DBNameList;
        }

        /// <summary>
        /// 异常弹框
        /// </summary>
        /// <param name="errmsg">异常内容</param>
        /// <param name="title">异常标题</param>
        /// <returns></returns>
        private DialogResult ErrMsgBox(string errmsg, string title = "异常")
        {
            log.AddERRORLOG(errmsg);
            MsgBox box = new MsgBox();
            box.Title = title;
            box.ShowText = errmsg;
            return box.ShowDialog();
        }
    }
}
