using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ECInspect
{
    class MyFunction
    {

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key,
            string def, StringBuilder retVal, int size, string filePath);

        //配置文件的读取
        private bool GetIniString(string iniPath, string section, string key, ref string value)
        {
            StringBuilder sb = new StringBuilder(1024);
            GetPrivateProfileString(section, key, value, sb, 1024, iniPath);
            value = sb.ToString();
            if (value.Length > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 获取语言配置
        /// </summary>
        internal void ReadLanguageIni()
        {
            string lastfile = string.Empty;//最新的文件
            string dllpath = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            dllpath = dllpath.Substring(8, dllpath.Length - 8);    // 8是 file:// 的长度
            char sep = System.IO.Path.DirectorySeparatorChar;
            string dir = System.IO.Path.GetDirectoryName(dllpath) + sep + GlobalVar.Folder_Config + sep;
            if (!Directory.Exists(dir)) throw new Exception("读取SANTEC.ini的路径不存在");
            lastfile = dir + "SANTEC.ini";
           // GetIniString(lastfile, INIFileValue.gl_inisection_Languange, INIFileValue.gl_iniKey_Language, ref INIFileValue.LanguageCH);
            //GetTransmitString(INIFileValue.LanguageCH);
        }
        public bool GetTransmitString(string language)
        {
            string file_Name = "";
            switch (language)
            {
                case "EN":
                    file_Name = "Language_EN.ini";
                    break;
                case "JP":
                    file_Name = "Language_JP.ini";
                    break;
            }
            string loadfile = string.Empty;
            string dllpath = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            dllpath = dllpath.Substring(8, dllpath.Length - 8);    // 8是 file:// 的长度
            char sep = System.IO.Path.DirectorySeparatorChar;
            string dir = System.IO.Path.GetDirectoryName(dllpath) + sep + GlobalVar.Folder_Config + sep;
            if (!Directory.Exists(dir)) throw new Exception(string.Format("读取{0}的路径不存在", file_Name));
            loadfile = dir + file_Name;
            #region mianform
            //读卡器
            GetIniString(loadfile,"LANGUAGE",Language.main_readcard_key,ref Language.main_readcard);
            //轴移动完成
            GetIniString(loadfile,"LANGUAGE",Language.main_axis_move_complete_key, ref Language.main_axis_move_complete);
            //测试异常不更新数据
            GetIniString(loadfile,"LANGUAGE",Language.main_ex_no_upload_key, ref Language.main_ex_no_upload);
            //请手动复位
            GetIniString(loadfile, "LANGUAGE", Language.main_manual_reset_key, ref Language.main_manual_reset);
            //测试异常
            GetIniString(loadfile, "LANGUAGE", Language.main_test_exception_key, ref Language.main_test_exception);
            //系统复位，不再等待按下左右开始键退出下治具
            GetIniString(loadfile, "LANGUAGE", Language.main_reset_without_wait_key, ref Language.main_reset_without_wait);
            //同时按下左右开始键，退出下治具
            GetIniString(loadfile, "LANGUAGE", Language.main_exit_lower_key, ref Language.main_exit_lower);
            //调整异常
            GetIniString(loadfile, "LANGUAGE", Language.main_adjustment_ex_key, ref Language.main_adjustment_ex);
            //开始调整模式
            GetIniString(loadfile, "LANGUAGE", Language.main_start_adjust_key, ref Language.main_start_adjust);
            //打标器已经到达使用寿命，需要更换
            GetIniString(loadfile, "LANGUAGE", Language.main_mark_count_key, ref Language.main_mark_count);
            //更换打标器
            GetIniString(loadfile, "LANGUAGE", Language.main_change_mark_key, ref Language.main_change_mark);
            //确认不良位置，按复位键
            GetIniString(loadfile, "LANGUAGE", Language.main_ensure_fail_key, ref Language.main_ensure_fail);
            //测试，不启动测试
            GetIniString(loadfile, "LANGUAGE", Language.main_noTest_key, ref Language.main_noTest);
            //开始测试
            GetIniString(loadfile, "LANGUAGE", Language.main_start_test_key, ref Language.main_start_test);
            //停止
            GetIniString(loadfile, "LANGUAGE", Language.main_stop_key, ref Language.main_stop);
            //系统复位完成
            GetIniString(loadfile, "LANGUAGE", Language.main_reset_complete_key, ref Language.main_reset_complete);
            //系统复位超时
            GetIniString(loadfile, "LANGUAGE", Language.main_reset_outtime_key, ref Language.main_reset_outtime);
            //是否系统复位
            GetIniString(loadfile, "LANGUAGE", Language.main_is_reset_key, ref Language.main_is_reset);
            //下压汽缸抬起超时，无法复位
            GetIniString(loadfile, "LANGUAGE", Language.main_cylinder_outtime_key, ref Language.main_cylinder_outtime);
            //程序关闭
            GetIniString(loadfile, "LANGUAGE", Language.main_app_shutdown_key, ref Language.main_app_shutdown);
            //主机测试异常，停止调整
            GetIniString(loadfile, "LANGUAGE", Language.main_adjust_ex_key, ref Language.main_adjust_ex);
            //调整模式-开始测试
            GetIniString(loadfile, "LANGUAGE", Language.main_adjuststart_key, ref Language.main_adjuststart);
            //尽管搜索了，但是测试没通过
            GetIniString(loadfile, "LANGUAGE", Language.main_search_fail_key, ref Language.main_search_fail);
            //间距
            GetIniString(loadfile, "LANGUAGE", Language.main_temp_key, ref Language.main_temp);
            //正方向搜索中
            GetIniString(loadfile, "LANGUAGE", Language.main_search_pos_key, ref Language.main_search_pos);
            //X轴合模位置修改
            GetIniString(loadfile, "LANGUAGE", Language.main_axis_X_change_key, ref Language.main_axis_X_change);
            //Y轴治具位置修改
            GetIniString(loadfile, "LANGUAGE", Language.main_axis_Y_change_key, ref Language.main_axis_Y_change);
            //差距上限
            GetIniString(loadfile, "LANGUAGE", Language.main_limit_key, ref Language.main_limit);
            //进入位置
            GetIniString(loadfile, "LANGUAGE", Language.main_enter_position_key, ref Language.main_enter_position);
            //程序计算错误，请联系开发人员
            GetIniString(loadfile, "LANGUAGE", Language.main_contact_admin_key, ref Language.main_contact_admin);
            //进一步搜索
            GetIniString(loadfile, "LANGUAGE", Language.main_further_search_key, ref Language.main_further_search);
            //中心位置
            GetIniString(loadfile, "LANGUAGE", Language.main_center_locate_key, ref Language.main_center_locate);
            //读取文件异常
            GetIniString(loadfile, "LANGUAGE", Language.main_read_usb_ex_key, ref Language.main_read_usb_ex);
            //移动存储盘读取文件失败,取消读取
            GetIniString(loadfile, "LANGUAGE", Language.main_read_usb_fail_key, ref Language.main_read_usb_fail);
            //等待
            GetIniString(loadfile, "LANGUAGE", Language.main_wait_key, ref Language.main_wait);
            //提示
            GetIniString(loadfile, "LANGUAGE", Language.main_test_tips_key, ref Language.main_test_tips);
            //系统复位
            GetIniString(loadfile, "LANGUAGE", Language.main_test_reset_key, ref Language.main_test_reset);
            //继续测试
            GetIniString(loadfile, "LANGUAGE", Language.main_test_continue_key, ref Language.main_test_continue);
            //打点笔达到使用寿命
            GetIniString(loadfile, "LANGUAGE", Language.main_mark_end_key, ref Language.main_mark_end);
            //打点笔
            GetIniString(loadfile, "LANGUAGE", Language.main_mark_pen_key, ref Language.main_mark_pen);
            //报警已经解除
            GetIniString(loadfile, "LANGUAGE", Language.main_emg_end_key, ref Language.main_emg_end);
            //扫码
            GetIniString(loadfile, "LANGUAGE", Language.main_scan_key, ref Language.main_scan);
            //扫描条码失败
            GetIniString(loadfile, "LANGUAGE", Language.main_scanning_failed_key, ref Language.main_scanning_failed);
            //测试主机
            GetIniString(loadfile, "LANGUAGE", Language.main_Host_key, ref Language.main_Host);
            //急停按下
            GetIniString(loadfile, "LANGUAGE", Language.main_emg_key, ref Language.main_emg);
            //EC电测上位机(含相机)
            GetIniString(loadfile, "LANGUAGE", Language.main_desktop_key, ref Language.main_desktop);
            //测试等待中
            GetIniString(loadfile, "LANGUAGE", Language.main_Test_waiting_key, ref Language.main_Test_waiting);
            //保存统计数据失败
            GetIniString(loadfile, "LANGUAGE", Language.main_save_fail_key, ref Language.main_save_fail);
            //请确认制品Mark点在相机视野内，并且没有脏污
            GetIniString(loadfile, "LANGUAGE", Language.main_CCD_fail_msg_key, ref Language.main_CCD_fail_msg);
            //拍照失败
            GetIniString(loadfile, "LANGUAGE", Language.main_CCD_fail_t_key, ref Language.main_CCD_fail_t);
            //拍照失败，请确认相机拍照结果
            GetIniString(loadfile, "LANGUAGE", Language.main_CCD_fail_key, ref Language.main_CCD_fail);
            //重复拍照
            GetIniString(loadfile, "LANGUAGE", Language.main_CCD_repeat_key, ref Language.main_CCD_repeat);
            //纠正值
            GetIniString(loadfile, "LANGUAGE", Language.main_CCD_correct_key, ref Language.main_CCD_correct);
            //原始值
            GetIniString(loadfile, "LANGUAGE", Language.main_CCD_original_key, ref Language.main_CCD_original);
            //偏移量
            GetIniString(loadfile, "LANGUAGE", Language.main_CCD_deviation_key, ref Language.main_CCD_deviation);
            //抓取坐标
            GetIniString(loadfile, "LANGUAGE", Language.main_CCD_getcoordinate_key, ref Language.main_CCD_getcoordinate);
            //状态
            GetIniString(loadfile, "LANGUAGE", Language.main_CCD_status_key, ref Language.main_CCD_status);
            //相机不启用
            GetIniString(loadfile, "LANGUAGE", Language.main_CCD_Unused_key, ref Language.main_CCD_Unused);
            //塗替
            GetIniString(loadfile, "LANGUAGE", Language.main_TuTi_key, ref Language.main_TuTi);
            //系统
            GetIniString(loadfile, "LANGUAGE", Language.main_system_key, ref Language.main_system);
            //手动
            GetIniString(loadfile, "LANGUAGE", Language.main_manual_key, ref Language.main_manual);
            //段取
            GetIniString(loadfile, "LANGUAGE", Language.main_change_molds_key, ref Language.main_change_molds);
            //返回原点
            GetIniString(loadfile, "LANGUAGE", Language.main_reset_key, ref Language.main_reset);
            //动作模式
            GetIniString(loadfile, "LANGUAGE", Language.main_action_mode_key, ref Language.main_action_mode);
            //通常
            GetIniString(loadfile, "LANGUAGE", Language.main_usual_key, ref Language.main_usual);
            //调整
            GetIniString(loadfile, "LANGUAGE", Language.main_adjustment_key, ref Language.main_adjustment);
            //制品样本
            GetIniString(loadfile, "LANGUAGE", Language.main_sample_key, ref Language.main_sample);
            //单次压合
            GetIniString(loadfile, "LANGUAGE", Language.main_single_key, ref Language.main_single);
            //制品检测张数
            GetIniString(loadfile, "LANGUAGE", Language.main_tested_products_key, ref Language.main_tested_products);
            //合格制品数
            GetIniString(loadfile, "LANGUAGE", Language.main_qualified_products_key, ref Language.main_qualified_products);
            //不合格制品数
            GetIniString(loadfile, "LANGUAGE", Language.main_defective_products_key, ref Language.main_defective_products);
            //断路
            GetIniString(loadfile, "LANGUAGE", Language.main_circuit_breaker_key, ref Language.main_circuit_breaker);
            //短路
            GetIniString(loadfile, "LANGUAGE", Language.main_short_circuit_key, ref Language.main_short_circuit);
            //高精度冲裁偏移M
            GetIniString(loadfile, "LANGUAGE", Language.main_blanking_offset_M_key, ref Language.main_blanking_offset_M);
            //冲裁偏移N
            GetIniString(loadfile, "LANGUAGE", Language.main_blanking_offset_N_key, ref Language.main_blanking_offset_N);
            //补材忘贴BY
            GetIniString(loadfile, "LANGUAGE", Language.main_materials_BY_key, ref Language.main_materials_BY);
            //压合次数
            GetIniString(loadfile, "LANGUAGE", Language.main_pressing_times_key, ref Language.main_pressing_times);
            //检查时间/张[sec]
            GetIniString(loadfile, "LANGUAGE", Language.main_Check_time_key, ref Language.main_Check_time);
            //不良率
            GetIniString(loadfile, "LANGUAGE", Language.main_defective_rate_key, ref Language.main_defective_rate);
            //相机工作模式
            GetIniString(loadfile, "LANGUAGE", Language.main_camera_mode_key, ref Language.main_camera_mode);
            //测试
            GetIniString(loadfile, "LANGUAGE", Language.main_camera_test_key, ref Language.main_camera_test);
            //次
            GetIniString(loadfile, "LANGUAGE", Language.main_camera_time_key, ref Language.main_camera_time);
            //条码
            GetIniString(loadfile, "LANGUAGE", Language.main_barcode_key, ref Language.main_barcode);
            #endregion
            #region CCD
            //光源
            GetIniString(loadfile, "LANGUAGE", Language.ccd_light_source_key, ref Language.ccd_light_source);
            //开启
            GetIniString(loadfile, "LANGUAGE", Language.ccd_open_key, ref Language.ccd_open);
            //关闭
            GetIniString(loadfile, "LANGUAGE", Language.ccd_close_key, ref Language.ccd_close);
            //取像制品压紧装置
            GetIniString(loadfile, "LANGUAGE", Language.ccd_compressing_device_key, ref Language.ccd_compressing_device);
            //上升
            GetIniString(loadfile, "LANGUAGE", Language.ccd_rise_key, ref Language.ccd_rise);
            //下降
            GetIniString(loadfile, "LANGUAGE", Language.ccd_fall_key, ref Language.ccd_fall);
            //执行
            GetIniString(loadfile, "LANGUAGE", Language.ccd_implement_key, ref Language.ccd_implement);
            //实时位置
            GetIniString(loadfile, "LANGUAGE", Language.ccd_realtime_position_key, ref Language.ccd_realtime_position);
            //自动定位
            GetIniString(loadfile, "LANGUAGE", Language.ccd_automatic_positioning_key, ref Language.ccd_automatic_positioning);
            //得分
            GetIniString(loadfile, "LANGUAGE", Language.ccd_score_key, ref Language.ccd_score);
            //设定
            GetIniString(loadfile, "LANGUAGE", Language.ccd_set_key, ref Language.ccd_set);
            //操作步骤：①拖拽绘制排除区域，尽可能选中内侧轮廓②拖拽绘制ROI小框，尽可能选中外侧轮廓
            GetIniString(loadfile, "LANGUAGE", Language.ccd_operation_steps_key, ref Language.ccd_operation_steps);
            //排除
            GetIniString(loadfile, "LANGUAGE", Language.ccd_exclude_key, ref Language.ccd_exclude);
            //光平衡
            GetIniString(loadfile, "LANGUAGE", Language.ccd_light_balance_key, ref Language.ccd_light_balance);
            //学习
            GetIniString(loadfile, "LANGUAGE", Language.ccd_study_key, ref Language.ccd_study);
            //成功
            GetIniString(loadfile, "LANGUAGE", Language.ccd_study_success_key, ref Language.ccd_study_success);
            //失败
            GetIniString(loadfile, "LANGUAGE", Language.ccd_study_fail_key, ref Language.ccd_study_fail);
            //保存
            GetIniString(loadfile, "LANGUAGE", Language.ccd_preservation_key, ref Language.ccd_preservation);

            #endregion
            #region frame form
            //返回
            GetIniString(loadfile, "LANGUAGE", Language.frame_Return_key, ref Language.frame_Return);
            //手动按键说明
            GetIniString(loadfile, "LANGUAGE", Language.frame_manual_key_description_key, ref Language.frame_manual_key_description);
            //原点
            GetIniString(loadfile, "LANGUAGE", Language.frame_origin_key, ref Language.frame_origin);
            //位置
            GetIniString(loadfile, "LANGUAGE", Language.frame_position_key, ref Language.frame_position);
            //操作
            GetIniString(loadfile, "LANGUAGE", Language.frame_operation_key, ref Language.frame_operation);

            #endregion
            #region document form
            //治具选择
            GetIniString(loadfile, "LANGUAGE", Language.doc_choose_fixtures_key, ref Language.doc_choose_fixtures);
            //重新读取
            GetIniString(loadfile, "LANGUAGE", Language.doc_reread_key, ref Language.doc_reread);
            #endregion
            #region barcode gun
            //条码枪
            GetIniString(loadfile, "LANGUAGE", Language.gun_barcode_scan_key, ref Language.gun_barcode_scan);
            //使用
            GetIniString(loadfile, "LANGUAGE", Language.gun_use_key, ref Language.gun_use);
            //停用
            GetIniString(loadfile, "LANGUAGE", Language.gun_disable_key, ref Language.gun_disable);
            //手持条码枪
            GetIniString(loadfile, "LANGUAGE", Language.gun_handheld_key, ref Language.gun_handheld);
            //康耐视条码枪
            GetIniString(loadfile, "LANGUAGE", Language.gun_cognex_key, ref Language.gun_cognex);


            #endregion
            #region PLC form
            //通信出错
            GetIniString(loadfile, "LANGUAGE", Language.plc_communicate_error_key, ref Language.plc_communicate_error);
            //接收
            GetIniString(loadfile, "LANGUAGE", Language.plc_receive_key, ref Language.plc_receive);
            //发送
            GetIniString(loadfile, "LANGUAGE", Language.plc_send_key, ref Language.plc_send);
            //显示通讯内容异常
            GetIniString(loadfile, "LANGUAGE", Language.plc_communicate_ex_key, ref Language.plc_communicate_ex);
            //轴
            GetIniString(loadfile, "LANGUAGE", Language.plc_axis_key, ref Language.plc_axis);
            //其他
            GetIniString(loadfile, "LANGUAGE", Language.plc_other_key, ref Language.plc_other);
            //通讯[调试]
            GetIniString(loadfile, "LANGUAGE", Language.plc_communication_key, ref Language.plc_communication);
            //打点轴
            GetIniString(loadfile, "LANGUAGE", Language.plc_mark_axis_key, ref Language.plc_mark_axis);
            //打点
            GetIniString(loadfile, "LANGUAGE", Language.plc_mark_key, ref Language.plc_mark);
            //回原点
            GetIniString(loadfile, "LANGUAGE", Language.plc_return_to_origin_key, ref Language.plc_return_to_origin);
            //定位速度
            GetIniString(loadfile, "LANGUAGE", Language.plc_position_speed_key, ref Language.plc_position_speed);
            //归原点速度
            GetIniString(loadfile, "LANGUAGE", Language.plc_origion_speed_key, ref Language.plc_origion_speed);
            //归原点爬行速度
            GetIniString(loadfile, "LANGUAGE", Language.plc_crawl_speed_key, ref Language.plc_crawl_speed);
            //JOG速度
            GetIniString(loadfile, "LANGUAGE", Language.plc_jog_speed_key, ref Language.plc_jog_speed);
            //加速度
            GetIniString(loadfile, "LANGUAGE", Language.plc_acceleration_key, ref Language.plc_acceleration);
            //减速度
            GetIniString(loadfile, "LANGUAGE", Language.plc_deceleration_key, ref Language.plc_deceleration);
            //轴报警解除
            GetIniString(loadfile, "LANGUAGE", Language.plc_release_alarm_key, ref Language.plc_release_alarm);
            //毫米
            GetIniString(loadfile, "LANGUAGE", Language.plc_millimeter_key, ref Language.plc_millimeter);
            //秒
            GetIniString(loadfile, "LANGUAGE", Language.plc_seconde_key, ref Language.plc_seconde);
            //打标等待位置
            GetIniString(loadfile, "LANGUAGE", Language.plc_mark_wait_position_key, ref Language.plc_mark_wait_position);
            //位置
            GetIniString(loadfile, "LANGUAGE", Language.plc_position_key, ref Language.plc_position);
            //实时位置
            GetIniString(loadfile, "LANGUAGE", Language.plc_realtime_position_key, ref Language.plc_realtime_position);
            //X轴
            GetIniString(loadfile, "LANGUAGE", Language.plc_axis_X_key, ref Language.plc_axis_X);
            //合模位置
            GetIniString(loadfile, "LANGUAGE", Language.plc_clamping_position_key, ref Language.plc_clamping_position);
            //Y轴
            GetIniString(loadfile, "LANGUAGE", Language.plc_axis_Y_key, ref Language.plc_axis_Y);
            //治具位置
            GetIniString(loadfile, "LANGUAGE", Language.plc_fixture_position_key, ref Language.plc_fixture_position);
            //逆向放置位置
            GetIniString(loadfile, "LANGUAGE", Language.plc_reverse_placement_key, ref Language.plc_reverse_placement);
            //放置位置
            GetIniString(loadfile, "LANGUAGE", Language.plc_place_position_key, ref Language.plc_place_position);
            //标记位置
            GetIniString(loadfile, "LANGUAGE", Language.plc_mark_position_key, ref Language.plc_mark_position);
            //段取进入位置
            GetIniString(loadfile, "LANGUAGE", Language.plc_changing_molds_position_key, ref Language.plc_changing_molds_position);
            //搬运轴
            GetIniString(loadfile, "LANGUAGE", Language.plc_axis_carry_key, ref Language.plc_axis_carry);
            //搬运上料位置
            GetIniString(loadfile, "LANGUAGE", Language.plc_loading_position_key, ref Language.plc_loading_position);
            //搬运下料位置
            GetIniString(loadfile, "LANGUAGE", Language.plc_remove_position_key, ref Language.plc_remove_position);
            //剥料轴
            GetIniString(loadfile, "LANGUAGE", Language.plc_axis_stripping_key, ref Language.plc_axis_stripping);
            //剥料轴速度
            GetIniString(loadfile, "LANGUAGE", Language.plc_axis_stripping_speed_key, ref Language.plc_axis_stripping_speed);
            //坐标
            GetIniString(loadfile, "LANGUAGE", Language.plc_coordinate_key, ref Language.plc_coordinate);
            //打点
            GetIniString(loadfile, "LANGUAGE", Language.plc_mark_point_key, ref Language.plc_mark_point);
            //扫码
            GetIniString(loadfile, "LANGUAGE", Language.plc_scan_key, ref Language.plc_scan);
            //拍照
            GetIniString(loadfile, "LANGUAGE", Language.plc_ccd_key, ref Language.plc_ccd);
            //下料-是否下压
            GetIniString(loadfile, "LANGUAGE", Language.plc_remove_key, ref Language.plc_remove);
            //下压
            GetIniString(loadfile, "LANGUAGE", Language.plc_pressing_key, ref Language.plc_pressing);
            //不下压
            GetIniString(loadfile, "LANGUAGE", Language.plc_no_pressing_key, ref Language.plc_no_pressing);
            //旋转汽缸
            GetIniString(loadfile, "LANGUAGE", Language.plc_cylinder_key, ref Language.plc_cylinder);
            //不旋转
            GetIniString(loadfile, "LANGUAGE", Language.plc_no_rotation_key, ref Language.plc_no_rotation);
            //旋转
            GetIniString(loadfile, "LANGUAGE", Language.plc_rotation_key, ref Language.plc_rotation);
            //时间
            GetIniString(loadfile, "LANGUAGE", Language.plc_time_key, ref Language.plc_time);
            //长延时
            GetIniString(loadfile, "LANGUAGE", Language.plc_long_delay_key, ref Language.plc_long_delay);
            //中延时
            GetIniString(loadfile, "LANGUAGE", Language.plc_mid_delay_key, ref Language.plc_mid_delay);
            //短延时
            GetIniString(loadfile, "LANGUAGE", Language.plc_short_delay_key, ref Language.plc_short_delay);

            #endregion 
            #region ICT Form
            //数据上传
            GetIniString(loadfile, "LANGUAGE", Language.ict_upload_data_key, ref Language.ict_upload_data);
            //启用
            GetIniString(loadfile, "LANGUAGE", Language.ict_upload_enable_key, ref Language.ict_upload_enable);
            //禁用
            GetIniString(loadfile, "LANGUAGE", Language.ict_upload_disable_key, ref Language.ict_upload_disable);

            #endregion
            #region system
            //指定系统运行动作
            GetIniString(loadfile, "LANGUAGE", Language.sys_specify_key, ref Language.sys_specify);
            //关闭电脑
            GetIniString(loadfile, "LANGUAGE", Language.sys_close_computer_key, ref Language.sys_close_computer);
            //重启电脑
            GetIniString(loadfile, "LANGUAGE", Language.sys_reset_computer_key, ref Language.sys_reset_computer);
            //关闭软件
            GetIniString(loadfile, "LANGUAGE", Language.sys_close_software_key, ref Language.sys_close_software);
            //版本升级
            GetIniString(loadfile, "LANGUAGE", Language.sys_version_upgrades_key, ref Language.sys_version_upgrades);
            //读取中
            GetIniString(loadfile, "LANGUAGE", Language.sys_read_in_key, ref Language.sys_read_in);
            //统计数置零
            GetIniString(loadfile, "LANGUAGE", Language.sys_statistics_number_zero_key, ref Language.sys_statistics_number_zero);

            #endregion
            #region 段取
            //请在手动模式下关闭低黏着装置后再更换
            GetIniString(loadfile, "LANGUAGE", Language.change_adjust_low_viscosity_key, ref Language.change_adjust_low_viscosity);
            //段取结束，手动调整吸附装置
            GetIniString(loadfile, "LANGUAGE", Language.change_adjust_vacumm_key, ref Language.change_adjust_vacumm);
            //准备调整相机位置
            GetIniString(loadfile, "LANGUAGE", Language.change_adjust_CCD_prepare_key, ref Language.change_adjust_CCD_prepare);
            //右启动键按下，开始读取移动存储盘
            GetIniString(loadfile, "LANGUAGE", Language.change_read_USB_key,ref Language.chagne_read_USB);
            //请放入制品
            GetIniString(loadfile, "LANGUAGE", Language.change_put_product_key, ref Language.change_put_product);
            //同时按下左右启动键，开始调整
            GetIniString(loadfile, "LANGUAGE", Language.change_twokeys_adjustment_key, ref Language.change_twokeys_adjustment);
            //从下治具取出段取用的隔离销
            GetIniString(loadfile, "LANGUAGE", Language.change_uninstall_isolating_key, ref Language.change_uninstall_isolating);
            //轴复位完成
            GetIniString(loadfile, "LANGUAGE", Language.change_axis_reset_complete_key, ref Language.change_axis_reset_complete);
            //开始轴复位
            GetIniString(loadfile, "LANGUAGE", Language.change_axis_start_reset_key, ref Language.change_axis_start_reset);
            //抬起完成
            GetIniString(loadfile, "LANGUAGE", Language.change_up_cylinder_complete_key, ref Language.change_up_cylinder_complete);
            //请同时按下左右启动键，抬起汽缸
            GetIniString(loadfile, "LANGUAGE", Language.change_twokeys_up_cylinder_key, ref Language.change_twokeys_up_cylinder);
            //压合完成
            GetIniString(loadfile, "LANGUAGE", Language.change_compression_complete_key, ref Language.change_compression_complete);
            //请同时按下左右启动键，开始压合
            GetIniString(loadfile, "LANGUAGE", Language.change_twokeys_compression_key, ref Language.change_twokeys_compression);
            //将上治具推到最里面
            GetIniString(loadfile, "LANGUAGE", Language.change_push_upper_key, ref Language.change_push_upper);
            //运动完成
            GetIniString(loadfile, "LANGUAGE", Language.change_runcomplete_key, ref Language.change_runcomplete);
            //请同时按下左右启动键，运行至压合位置
            GetIniString(loadfile, "LANGUAGE", Language.change_twokeys_key, ref Language.change_twokeys);
            //读取移动存储盘完成
            GetIniString(loadfile, "LANGUAGE", Language.change_readuse_complete_key, ref Language.change_readuse_complete);
            //等待按下右启动键
            GetIniString(loadfile, "LANGUAGE", Language.change_wait_rightkey_key, ref Language.change_wait_rightkey);
            //取消段取
            GetIniString(loadfile, "LANGUAGE", Language.change_cancel_key, ref Language.change_cancel);
            //用户取消段取
            GetIniString(loadfile, "LANGUAGE", Language.change_user_cancel_key, ref Language.change_user_cancel);
            //段取异常
            GetIniString(loadfile, "LANGUAGE", Language.change_ex_key, ref Language.change_ex);
            //开始段取
            GetIniString(loadfile, "LANGUAGE", Language.change_start_change_molds_key, ref Language.change_start_change_molds);
            //段取流程
            GetIniString(loadfile, "LANGUAGE", Language.change_molds_process_key, ref Language.change_molds_process);
            //是否系统复位
            GetIniString(loadfile, "LANGUAGE", Language.change_whether_reset_key, ref Language.change_whether_reset);
            //按下紧急停止键，交换[治具]
            GetIniString(loadfile, "LANGUAGE", Language.change_emergency_btn_key, ref Language.change_emergency_btn);
            //交换完成后，解除紧急停止状态
            GetIniString(loadfile, "LANGUAGE", Language.change_change_complete_key, ref Language.change_change_complete);
            //放置段取用的隔离销，将段取用的隔离销装到下治具上
            GetIniString(loadfile, "LANGUAGE", Language.change_isolating_installed_key, ref Language.change_isolating_installed);
            //上治具未推到最里面,确认段取用的隔离销是否装到治具上
            GetIniString(loadfile, "LANGUAGE", Language.change_upper_notin_key, ref Language.change_upper_notin);
            //确认段取用的隔离销是否装到治具上
            GetIniString(loadfile, "LANGUAGE", Language.change_ensure_isolating_key, ref Language.change_ensure_isolating);
            //插入移动存储盘，按[右开始键]，段取开始
            GetIniString(loadfile, "LANGUAGE", Language.change_insert_usb_key, ref Language.change_insert_usb);
            //请确认隔离销没有卡在上治具，然后同时按下左右启动键
            GetIniString(loadfile, "LANGUAGE", Language.change_isolating_not_stuck_key, ref Language.change_isolating_not_stuck);
            #endregion
            #region keyboard
            //最大值
            GetIniString(loadfile, "LANGUAGE", Language.key_max_key, ref Language.key_max);
            //最小值
            GetIniString(loadfile, "LANGUAGE", Language.key_min_key, ref Language.key_min);
            //确认
            GetIniString(loadfile, "LANGUAGE", Language.key_confirm_key, ref Language.key_confirm);
            //取消
            GetIniString(loadfile, "LANGUAGE", Language.key_cancel_key, ref Language.key_cancel);
            //数字超出范围
            GetIniString(loadfile, "LANGUAGE", Language.key_out_spectrum_key, ref Language.key_out_spectrum);
            //数据类型不满足
            GetIniString(loadfile, "LANGUAGE", Language.key_num_type_key, ref Language.key_num_type);
            //密码错误
            GetIniString(loadfile, "LANGUAGE", Language.key_password_error_key, ref Language.key_password_error);
            //小数位数超过限制
            GetIniString(loadfile, "LANGUAGE", Language.key_scale_out_key, ref Language.key_scale_out);
            #endregion
            #region manual
            //初始位置
            GetIniString(loadfile, "LANGUAGE", Language.manual_initial_position_key, ref Language.manual_initial_position);
            //治具位置
            GetIniString(loadfile, "LANGUAGE", Language.manual_fixture_position_key, ref Language.manual_fixture_position);
            //相机位置
            GetIniString(loadfile, "LANGUAGE", Language.manual_camera_position_key, ref Language.manual_camera_position);
            //逆向放置位置
            GetIniString(loadfile, "LANGUAGE", Language.manual_reverse_placement_key, ref Language.manual_reverse_placement);
            //放置位置
            GetIniString(loadfile, "LANGUAGE", Language.manual_place_position_key, ref Language.manual_place_position);
            //吸附装置调整
            GetIniString(loadfile, "LANGUAGE", Language.manual_adsorption_adjustment_key, ref Language.manual_adsorption_adjustment);
            //相机调整
            GetIniString(loadfile, "LANGUAGE", Language.manual_ccd_adjustment_key, ref Language.manual_ccd_adjustment);
            //打标菜单
            GetIniString(loadfile, "LANGUAGE", Language.manual_mark_menu_key, ref Language.manual_mark_menu);
            //上治具拆卸
            GetIniString(loadfile, "LANGUAGE", Language.manual_disassembly_upper_key, ref Language.manual_disassembly_upper);
            //下治具电磁阀
            GetIniString(loadfile, "LANGUAGE", Language.manual_solenoid_of_lower_key, ref Language.manual_solenoid_of_lower);
            //汽缸打开
            GetIniString(loadfile, "LANGUAGE", Language.manual_open_cylinder_key, ref Language.manual_open_cylinder);
            //汽缸关闭
            GetIniString(loadfile, "LANGUAGE", Language.manual_close_cylinder_key, ref Language.manual_close_cylinder);
            //压合装置
            GetIniString(loadfile, "LANGUAGE", Language.manual_pressing_device_key, ref Language.manual_pressing_device);
            //低粘着
            GetIniString(loadfile, "LANGUAGE", Language.manual_low_adhesion_key, ref Language.manual_low_adhesion);
            //打开
            GetIniString(loadfile, "LANGUAGE", Language.manual_open_key, ref Language.manual_open);
            //关闭
            GetIniString(loadfile, "LANGUAGE", Language.manual_close_key, ref Language.manual_close);
            //上升
            GetIniString(loadfile, "LANGUAGE", Language.manual_rise_key, ref Language.manual_rise);
            //下降
            GetIniString(loadfile, "LANGUAGE", Language.manual_fall_key, ref Language.manual_fall);

            #endregion
            #region alarm form
            //报警时间间隔
            GetIniString(loadfile, "LANGUAGE", Language.alarm_time_interval_key, ref Language.alarm_time_interval);
            //报警启动时间
            GetIniString(loadfile, "LANGUAGE", Language.alarm_start_time_key, ref Language.alarm_start_time);
            //剩余时间
            GetIniString(loadfile, "LANGUAGE", Language.alarm_remaining_time_key, ref Language.alarm_remaining_time);
            //打标次数设定
            GetIniString(loadfile, "LANGUAGE", Language.alarm_mark_times_key, ref Language.alarm_mark_times);

            #endregion
            #region mark form
            //保存
            GetIniString(loadfile, "LANGUAGE", Language.mark_save_key, ref Language.mark_save);
            //打标器更换设定值是否保存
            GetIniString(loadfile, "LANGUAGE", Language.mark_box_title_key, ref Language.mark_box_title);
            //下治具
            GetIniString(loadfile, "LANGUAGE", Language.mark_lower_mold_key, ref Language.mark_lower_mold);
            //放置位置
            GetIniString(loadfile, "LANGUAGE", Language.mark_place_position_key, ref Language.mark_place_position);
            //标记位置
            GetIniString(loadfile, "LANGUAGE", Language.mark_mark_position_key, ref Language.mark_mark_position);
            //打标器
            GetIniString(loadfile, "LANGUAGE", Language.mark_device_key, ref Language.mark_device);
            //等待位置
            GetIniString(loadfile, "LANGUAGE", Language.mark_waiting_position_key, ref Language.mark_waiting_position);
            //打标试运行
            GetIniString(loadfile, "LANGUAGE", Language.mark_marking_test_key, ref Language.mark_marking_test);
            //打标器更换
            GetIniString(loadfile, "LANGUAGE", Language.mark_device_change_key, ref Language.mark_device_change);
            //打标器更换设定
            GetIniString(loadfile, "LANGUAGE", Language.mark_device_change_setting_key, ref Language.mark_device_change_setting);
            //原点
            GetIniString(loadfile, "LANGUAGE", Language.mark_origin_key, ref Language.mark_origin);
            //实际位置
            GetIniString(loadfile, "LANGUAGE", Language.mark_actual_position_key, ref Language.mark_actual_position);
            //MARK点
            GetIniString(loadfile, "LANGUAGE", Language.mark_markpoint_key, ref Language.mark_markpoint);
            #endregion
            #region cylinder settings
            //旋转汽缸
            GetIniString(loadfile, "LANGUAGE", Language.cylinder_rotary_cylinder_key, ref Language.cylinder_rotary_cylinder);
            //旋转
            GetIniString(loadfile, "LANGUAGE", Language.cylinder_rotation_key, ref Language.cylinder_rotation);
            //回位
            GetIniString(loadfile, "LANGUAGE", Language.cylinder_restitution_key, ref Language.cylinder_restitution);
            //搬运轴
            GetIniString(loadfile, "LANGUAGE", Language.cylinder_axis_carry_key, ref Language.cylinder_axis_carry);
            //左
            GetIniString(loadfile, "LANGUAGE", Language.cylinder_left_key, ref Language.cylinder_left);
            //右
            GetIniString(loadfile, "LANGUAGE", Language.cylinder_right_key, ref Language.cylinder_right);
            //制品设定板
            GetIniString(loadfile, "LANGUAGE", Language.cylinder_board_key, ref Language.cylinder_board);
            #endregion
            #region msgbox
            //初始化异常
            GetIniString(loadfile, "LANGUAGE", Language.msg_init_ex_key, ref Language.msg_init_ex);
            //文档读取的区块数量
            GetIniString(loadfile, "LANGUAGE", Language.msg_read_block_num_key, ref Language.msg_read_block_num);
            //测试数量
            GetIniString(loadfile, "LANGUAGE", Language.msg_test_count_key, ref Language.msg_test_count);
            //显示数量不一致
            GetIniString(loadfile, "LANGUAGE", Language.msg_read_test_diff_key, ref Language.msg_read_test_diff);
            //请重新开启软件
            GetIniString(loadfile, "LANGUAGE", Language.msg_restart_key, ref Language.msg_restart);
            //打点数量不一致
            GetIniString(loadfile, "LANGUAGE", Language.mag_mark_count_diff_key, ref Language.mag_mark_count_diff);
            //文档读取的打标坐标数量
            GetIniString(loadfile, "LANGUAGE", Language.msg_read_mark_count_key, ref Language.msg_read_mark_count);
            //PLC异常
            GetIniString(loadfile, "LANGUAGE", Language.msg_PLC_ex_key, ref Language.msg_PLC_ex);
            //异常
            GetIniString(loadfile, "LANGUAGE", Language.msg_exception_key, ref Language.msg_exception);
            //检测到升级U盘插入，是否升级
            GetIniString(loadfile, "LANGUAGE", Language.msg_usb_insert_key, ref Language.msg_usb_insert);
            #endregion
            #region loading form
            //连接服务器
            GetIniString(loadfile, "LANGUAGE", Language.load_connectto_server_key, ref Language.load_connectto_server);
            //读取配置文件
            GetIniString(loadfile, "LANGUAGE", Language.load_ini_file_key, ref Language.load_ini_file);
            //读取配置文件完毕\r\n开始连接PLC
            GetIniString(loadfile, "LANGUAGE", Language.load_ini_complete_key, ref Language.load_ini_complete);
            //PLC Modbus开启成功\r\n开始连接EC测试主机
            GetIniString(loadfile, "LANGUAGE", Language.load_plc_connect_host_key, ref Language.load_plc_connect_host);
            //连接PLC成功\r\n开始连接EC测试主机
            GetIniString(loadfile, "LANGUAGE", Language.load_connect_host_key, ref Language.load_connect_host);
            //文档读取的坐标数量与测试数量不一致
            GetIniString(loadfile, "LANGUAGE", Language.load_count_diff_key, ref Language.load_count_diff);
            //数量不一致
            GetIniString(loadfile, "LANGUAGE", Language.load_count_diff_title_key, ref Language.load_count_diff_title);
            //当前模式启用相机，打开视觉软件
            GetIniString(loadfile, "LANGUAGE", Language.load_open_ccd_key, ref Language.load_open_ccd);
            //视觉软件开启成功
            GetIniString(loadfile, "LANGUAGE", Language.load_open_ccd_complete_key, ref Language.load_open_ccd_complete);
            //当前模式启用康耐视条码枪，打开条码枪
            GetIniString(loadfile, "LANGUAGE", Language.load_open_scan_key, ref Language.load_open_scan);
            //康耐视条码枪开启成功
            GetIniString(loadfile, "LANGUAGE", Language.load_open_scan_complete_key, ref Language.load_open_scan_complete);
            #endregion
            #region control
            //相机
            GetIniString(loadfile, "LANGUAGE", Language.com_ccd_key, ref Language.com_ccd);
            //拍照等待位置
            GetIniString(loadfile, "LANGUAGE", Language.com_ccd_waitposition_key, ref Language.com_ccd_waitposition);
            //扫码等待位置
            GetIniString(loadfile, "LANGUAGE", Language.com_scan_waitposition_key, ref Language.com_scan_waitposition);
            //相机中心位置
            GetIniString(loadfile, "LANGUAGE", Language.com_ccd_centerposition_key, ref Language.com_ccd_centerposition);
            //偏移
            GetIniString(loadfile, "LANGUAGE", Language.com_ccd_offset_key, ref Language.com_ccd_offset);
            //相机拍照位置
            GetIniString(loadfile, "LANGUAGE", Language.com_ccd_photoposition_key, ref Language.com_ccd_photoposition);
            //条码
            GetIniString(loadfile, "LANGUAGE", Language.com_scan_barcode_key, ref Language.com_scan_barcode);
            //长度
            GetIniString(loadfile, "LANGUAGE", Language.com_scan_length_key, ref Language.com_scan_length);
            //不是数字，无法执行
            GetIniString(loadfile, "LANGUAGE", Language.com_key_notnum_key, ref Language.com_key_notnum);
            //搬运
            GetIniString(loadfile, "LANGUAGE", Language.com_axis_name_key, ref Language.com_axis_name);
            //轴的实际值设置无效
            GetIniString(loadfile, "LANGUAGE", Language.com_axis_position_invil_key, ref Language.com_axis_position_invil);
            //轴最大值设定无效
            GetIniString(loadfile, "LANGUAGE", Language.com_axis_max_invil_key, ref Language.com_axis_max_invil);
            #endregion
            return false;
        }
    }
}
