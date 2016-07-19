using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using StaubliRobot;
using System.IO;

namespace LasMAN
{
    public partial class Frm_Monitor : Std_Form
    {
        bool RefreshScreen = true;
        DataView dv1 = new DataView();
        DataView dv2 = new DataView();
        int MoveId = 0;
        int PointType = 0;
        int TrajIndex = 0;
        string RecipeName;


        ////
        //DataView dvtraj = new DataView();
        //DataView dvpoint = new DataView();



        public Frm_Monitor()
        {
            InitializeComponent();
            this.CB_Prod.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Frm_Monitor_Load(object sender, EventArgs e)
        {
            dv1.Table = new System.Data.DataTable("Traj");
            dv2.Table = new System.Data.DataTable("Point");
            dv1.Table.Columns.Add();
            dv1.Table.Columns.Add();
            dv1.Table.Columns.Add();
            dv1.Table.Rows.Clear();
            //  GC_Traj.DataSource = dv1;
            //gv.Columns[0].Caption = "序号";
            //gv.Columns[1].Caption = "路径名称";
            //gv.Columns[2].Caption = "路径类型";



            dv2.Table.Columns.Add();
            dv2.Table.Columns.Add();
            dv2.Table.Columns.Add();
            dv2.Table.Columns.Add();
            dv2.Table.Columns.Add();
            dv2.Table.Columns.Add();
            dv2.Table.Columns.Add();
            dv2.Table.Columns.Add();
            dv2.Table.Rows.Clear();
            //GC_Cut.DataSource = dv2;
            //GV_Cut.Columns[0].Caption = "序号";
            //GV_Cut.Columns[1].Caption = "类型";
            //GV_Cut.Columns[2].Caption = "X/J1";
            //GV_Cut.Columns[3].Caption = "Y/J2";
            //GV_Cut.Columns[4].Caption = "Z/J3";
            //GV_Cut.Columns[5].Caption = "RX/J4";
            //GV_Cut.Columns[6].Caption = "RY/J5";
            //GV_Cut.Columns[7].Caption = "RZ/J6";

            if (TxtData.DataBase.SoapStaus && TxtData.DataBase.InterfaceType == 13)
            {

                if (TxtData.PublicData.ProductName == null || TxtData.DataBase.ProductName == null
                   || TxtData.DataBase.ProductName.Length < TxtData.PublicData.WorkPlaceCount || TxtData.PublicData.ProductName[0] == null || TxtData.PublicData.ProductName[0][0] == null
                    || TxtData.PublicData.ProductName[0][0] == ""

                    )
                //|| TxtData.PublicData.ProductName[i-1] != TxtData.DataBase.ProductName[i-1])
                {
                    FtpClient ftp = new FtpClient(TxtData.XMLConfigure.IpAddress);


                }

            }








        }
        bool Flag = false;
        private void timer_Refresh_Tick(object sender, EventArgs e)
        {
            //if (TxtData.DataBase.SoapStaus && TxtData.DataBase.PowerOn&&TxtData.DataBase.PresetData!=null&&TxtData.DataBase.PresetData.Length>=5)
            //{
            //    PB_1.EditValue = TxtData.DataBase.PresetData[0];
            //    PB_2.EditValue = TxtData.DataBase.PresetData[1];
            //    PB_3.EditValue = TxtData.DataBase.PresetData[2];
            //    PB_4.EditValue = TxtData.DataBase.PresetData[3];
            //    PB_5.EditValue = TxtData.DataBase.PresetData[4];

            //    CK_1.Checked = CK_2.Checked = CK_3.Checked = TxtData.DataBase.LaserOn;
            //    CK_5.Checked = TxtData.DataBase.FollowOn;
            //    CK_4.Checked = TxtData.DataBase.AirOn;
            //}
            //else
            //{
            //    PB_1.EditValue = "";
            //    PB_2.EditValue = "";
            //    PB_3.EditValue = "";
            //    PB_4.EditValue = "";
            //    PB_5.EditValue = "";

            //}

            //if (!TxtData.DataBase.SoapStaus || TxtData.DataBase.ToolMode != 4 || (!(TxtData.DataBase.InterfaceType == 13 || TxtData.DataBase.InterfaceType == 6)))
            //{
            //    if (RefreshScreen)
            //    {
            //        LL_Status.Text ="下位机状态:" +"通讯异常或者不在生产状态";
            //        LL_Home.Text = "零位:" + (TxtData.DataBase.IsHome ? "是" : "否");
            //        LL_TriggleMode.Text = "触发模式:" + TxtData.PublicData.TriggleModeText[TxtData.PublicData.TriggleMode];
            //        LL_CycleCount.Text = "周期:";
            //        LL_WorkPlace.Text = "工位:";
            //        LL_ProdcutName.Text = "产品名:";
            //      //  LL_PresetName.Text = "工艺名:" + "StaubliPreset";
            //        //LL_Speed.Text = "速度:";
            //        //LL_CycleTime.Text = "周期时间:";
            //        //LL_TrajName.Text = "路径号:" ;






            //    }


            //    return;
            //}
            //RefreshScreen = true;

            try
            {

               BT_Stop.Enabled = TxtData.DataBase.bCycle;
               BT_Start.Enabled = !TxtData.DataBase.bCycle;
                LL_Status.Text = "主控机械手臂状态:";
                LL_SlaveStatus.Text = "从控机械手臂状态:";
                LL_AxisHome.Text = "旋转轴是否回零:";
                //  LL_ProductStatus.Text = "周期:" + TxtData.DataBase.CycleIndex.ToString() + "->" + TxtData.DataBase.CycleCount.ToString();
                //   LL_.Text = "工位:" + TxtData.DataBase.WorkPlaceIndex.ToString() + "->" + TxtData.DataBase.WorkPlaceCount.ToString();
                LL_Time.Text = "周期时间:" + TxtData.DataBase.CycleTime.ToString();
                LL_Count.Text = "计数:" + TxtData.DataBase.ProductCount.ToString();

                //if (TxtData.DataBase.ProductName.Length>TxtData.DataBase.WorkPlaceIndex)
                //{
                //    LL_ProdcutName.Text = "产品名:" + TxtData.DataBase.ProductName[TxtData.DataBase.WorkPlaceIndex];
                //}

                // LL_PresetName.Text = "工艺名:StaubliPreset";
                //LL_Speed.Text = "速度:" +(TxtData.DataBase.RobotSpeed*60/1000).ToString()+"米/分";
                //LL_CycleTime.Text = "周期时间:" + TxtData.DataBase.CycleTime.ToString()+"秒";
                //LL_TrajName.Text = "路径号:" + TxtData.DataBase.TrajIndex.ToString();
                PBC_Process.Properties.Maximum = 12;
                int i = Math.Max(Math.Min(TxtData.DataBase.nProcedure, 12), 0);
                PBC_Process.Position = i;
                ce1.Checked = (i > 0);
                ce2.Checked = (i > 1);
                ce3.Checked = (i > 2);
                ce4.Checked = (i > 3);
                ce5.Checked = (i > 4);
                ce6.Checked = (i > 5);
                ce7.Checked = (i > 6);
                ce8.Checked = (i > 7);
                ce9.Checked = (i > 8);
                ce10.Checked = (i > 9);
                ce11.Checked = (i > 10);
                ce12.Checked = (i > 11);
                //ce13.Checked = (i > 12);
                //ce14.Checked = (i > 13);
                //ce15.Checked = (i > 14);
                //ce16.Checked = (i > 15);
                //ce17.Checked = (i > 16);
                //ce18.Checked = (i > 17);
                //ce19.Checked = (i > 18);
                //ce20.Checked = (i > 19);

                Flag = !Flag;
                ce1.Checked = (i == 1 ? Flag : ce1.Checked);
                ce2.Checked = (i == 2 ? Flag : ce2.Checked);
                ce3.Checked = (i == 3 ? Flag : ce3.Checked);
                ce4.Checked = (i == 4 ? Flag : ce4.Checked);
                ce5.Checked = (i == 5 ? Flag : ce5.Checked);
                ce6.Checked = (i == 6 ? Flag : ce6.Checked);
                ce7.Checked = (i == 7 ? Flag : ce7.Checked);
                ce8.Checked = (i == 8 ? Flag : ce8.Checked);
                ce9.Checked = (i == 9 ? Flag : ce9.Checked);
                ce10.Checked = (i == 10 ? Flag : ce10.Checked);
                ce11.Checked = (i == 11 ? Flag : ce11.Checked);
                ce12.Checked = (i == 12 ? Flag : ce12.Checked);
                //ce13.Checked = (i == 13 ? Flag : ce13.Checked);
                //ce14.Checked = (i == 14 ? Flag : ce14.Checked);
                //ce15.Checked = (i == 15 ? Flag : ce15.Checked);
                //ce16.Checked = (i == 16 ? Flag : ce16.Checked);
                //ce17.Checked = (i == 17 ? Flag : ce17.Checked);
                //ce18.Checked = (i == 18 ? Flag : ce18.Checked);
                //ce19.Checked = (i == 19 ? Flag : ce19.Checked);
                //ce20.Checked = (i == 20 ? Flag : ce20.Checked);

                ce1.ForeColor = ce2.ForeColor = ce3.ForeColor = ce4.ForeColor = ce4.ForeColor = ce6.ForeColor = Color.Black;
                ce7.ForeColor = ce5.ForeColor = ce8.ForeColor = ce9.ForeColor = ce10.ForeColor = ce11.ForeColor = ce12.ForeColor = Color.Black;

                //ce11.ForeColor = ce12.ForeColor = ce13.ForeColor = ce14.ForeColor = ce14.ForeColor = ce16.ForeColor = ce17.ForeColor = ce15.ForeColor = ce18.ForeColor = ce19.ForeColor = ce20.ForeColor = Color.Black;

                ce1.ForeColor = (i == 1 ? Color.Red : Color.Black);

                ce1.ForeColor = (i == 1 ? Color.Red : Color.Black);
                ce2.ForeColor = (i == 2 ? Color.Red : Color.Black);
                ce3.ForeColor = (i == 3 ? Color.Red : Color.Black);
                ce4.ForeColor = (i == 4 ? Color.Red : Color.Black);
                ce5.ForeColor = (i == 5 ? Color.Red : Color.Black);
                ce6.ForeColor = (i == 6 ? Color.Red : Color.Black);
                ce7.ForeColor = (i == 7 ? Color.Red : Color.Black);
                ce8.ForeColor = (i == 8 ? Color.Red : Color.Black);
                ce9.ForeColor = (i == 9 ? Color.Red : Color.Black);
                ce10.ForeColor = (i == 10 ? Color.Red : Color.Black);
                ce11.ForeColor = (i == 11 ? Color.Red : Color.Black);
                ce12.ForeColor = (i == 12 ? Color.Red : Color.Black);
                //ce13.ForeColor = (i == 13 ? Color.Red : Color.Black);
                //ce14.ForeColor = (i == 14 ? Color.Red : Color.Black);
                //ce15.ForeColor = (i == 15 ? Color.Red : Color.Black);
                //ce16.ForeColor = (i == 16 ? Color.Red : Color.Black);
                //ce17.ForeColor = (i == 17 ? Color.Red : Color.Black);
                //ce18.ForeColor = (i == 18 ? Color.Red : Color.Black);
                //ce19.ForeColor = (i == 19 ? Color.Red : Color.Black);
                //ce20.ForeColor = (i == 20 ? Color.Red : Color.Black);




            }
            catch (System.Exception ex)
            {

            }
        }
        //刷新表1


        private void BT_Pause_Click(object sender, EventArgs e)
        {
            if (!TxtData.DataBase.SoapStaus || TxtData.DataBase.ToolMode != 4 || (!(TxtData.DataBase.InterfaceType == 13 || TxtData.DataBase.InterfaceType == 6)))
            {
                MessageBox.Show("通讯异常或者不在生产状态");
                return;
            }
            if (MessageBox.Show("确定需要暂停？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
        }

        private void BT_Stop_Click(object sender, EventArgs e)
        {
            if (!TxtData.DataBase.SoapStaus || TxtData.DataBase.ToolMode != 4 || (!(TxtData.DataBase.InterfaceType == 13 || TxtData.DataBase.InterfaceType == 6)))
            {
                MessageBox.Show("通讯异常或者不在生产状态");
                return;
            }
            if (MessageBox.Show("确定需要停止？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            if (SoapInstance.SoapRead.SetAppdata("nInterfaceType", 9))
            {
                MessageBox.Show("设置成功!");
            }
            else
            {
                MessageBox.Show("设置下位机数据异常");
            }
        }

        private void checkEdit9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkEdit12_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void GC_Process_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ce2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ce7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ce9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void GC_Infor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer_log_Tick(object sender, EventArgs e)
        {
            try
            {
                string[] date = null;
                string[] Txt = null;
                if (!TxtData.DataBase.SoapStaus)
                {
                    return;
                }
                FtpClient ftp;
                if (RB_Master.Checked)
                {
                    ftp = new FtpClient(TxtData.XMLConfigure.IpAddress);
                    GB_Log.Text = "主控机械手臂日志记录";
                }
                else
                {
                    ftp = new FtpClient(TxtData.XMLConfigure.SlaveIpAddress);
                    GB_Log.Text = "从控机械手臂日志记录";
                }

                if (ftp.DownLoadLog() && PublicFunc.ReadCs8CLog(out date, out Txt))
                {
                    string[] datebuff = date;
                    string[] Txtbuff = Txt;

                    if (datebuff != null && Txtbuff != null && datebuff.Length > 1 && Txtbuff.Length > 1)
                    {

                        DataView dv = new DataView();
                        dv.Table = new System.Data.DataTable("Sequen");
                        dv.Table.Columns.Add();
                        dv.Table.Columns.Add();
                        dv.Table.Rows.Clear();

                        for (int i = datebuff.Length - 1; i >= 0; i--)
                        {
                            if (Txtbuff[i].IndexOf("COM-PC: destroy session") < 0 && Txtbuff[i].IndexOf("COM-PC: create session") < 0)
                            {
                                dv.Table.Rows.Add((object[])new string[] { datebuff[i], Txtbuff[i] });
                            }

                        }


                        GC_Alarm.DataSource = dv;
                        gv.Columns[0].Caption = "日期";
                        gv.Columns[1].Caption = "日志信息";

                    }
                }
            }
            catch
            {

            }

        }

        /// <summary>
        /// 清零
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (!TxtData.DataBase.SoapStaus)
            {
                MessageBox.Show("网络连接异常");
                return;
            }


            DialogResult result = MessageBox.Show("确定需要清零吗", "清零", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {

                if (StaubliRobot.SoapInstance.SoapRead.SetAppdata("nProcedure", 0))
              {
                  MessageBox.Show("设置成功");
              }
                else
                {
                    MessageBox.Show("设置失败");
                }




            }
        }

        private void BT_Stop_Click_1(object sender, EventArgs e)
        {
            if (!TxtData.DataBase.SoapStaus)
            {
                MessageBox.Show("网络连接异常");
                return;
            }
            if (StaubliRobot.SoapInstance.SoapRead.SetAppdata("bPcStopCycle", true))
            {
                //MessageBox.Show("设置成功");
            }
            else
            {
                MessageBox.Show("设置失败");
                return;
            }
            System.Threading.Thread.Sleep(1000);

            if (StaubliRobot.SoapInstance.SoapRead.SetAppdata("bPcStopCycle", false))
            {
                MessageBox.Show("设置成功");
            }
            else
            {
                MessageBox.Show("设置失败");
            }
        }

        private void BT_Start_Click(object sender, EventArgs e)
        {
            if (!TxtData.DataBase.SoapStaus)
            {
                MessageBox.Show("网络连接异常");
                return;
            }


            DialogResult result = MessageBox.Show("确定需要开始吗", "开始", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {

                if (StaubliRobot.SoapInstance.SoapRead.SetAppdata("bPcStartCycle", true))
                {
                    //MessageBox.Show("设置成功");
                }
                else
                {
                    MessageBox.Show("设置失败");
                    return;
                }
                System.Threading.Thread.Sleep(1000);

                if (StaubliRobot.SoapInstance.SoapRead.SetAppdata("bPcStartCycle", false))
                {
                    MessageBox.Show("设置成功");
                }
                else
                {
                    MessageBox.Show("设置失败");
                }

            }
        }

        private void CB_Prod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!TxtData.DataBase.SoapStaus)
            {
                MessageBox.Show("网络连接异常");
                return;
            }
            if (StaubliRobot.SoapInstance.SoapRead.SetAppdata("nPartType", 0))
            {
                MessageBox.Show("设置成功");
            }
            else
            {
                MessageBox.Show("设置失败");
            }

        }
    }




}
