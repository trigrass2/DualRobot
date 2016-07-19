using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using StaubliRobot;



namespace LasMAN
{
    public partial class Frm_Position : Std_Form
    {
        DataBaseManage db = new DataBaseManage();
        bool Master = false;
        public Frm_Position(bool master)
        {
            InitializeComponent();
            if (System.IO.File.Exists(Application.StartupPath + "\\RobotShow.jpg"))
            {
                this.PE_Robot.Image = Image.FromFile(Application.StartupPath + "\\RobotShow.jpg");
            }
            Master = master;
        }

        private void GC_Tool_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BT_TeachHome_Click(object sender, EventArgs e)
        {
            Teach(15);
        }

        private void BT_TeachTool_Click(object sender, EventArgs e)
        {
            Teach(14);
        }

        private void BT_EditHome_Click(object sender, EventArgs e)
        {
            //Edit_HomeTcp frm = new Edit_HomeTcp(false);
            //frm.ShowDialog();
            //ReadHomeTcp();
        }

        private void BT_EditTool_Click(object sender, EventArgs e)
        {
            //Edit_HomeTcp frm = new Edit_HomeTcp(true);
            //frm.ShowDialog();
            //ReadHomeTcp();
        }


        private void Teach(int Flag)
        {


            //if (TxtData.DataBase.InterfaceType != 9)
            //{
            //    MessageBox.Show("下位机请切换到空闲界面!");
            //    return;
            //}

            //if (TxtData.DataBase.ToolMode != 1)
            //{
            //    MessageBox.Show("请切换到手动模式!");
            //    return;
            //}
            //TxtData.PublicData.ErrorCode = StaubliRobot.SoapInstance.SoapRead.SetAppdata("nInterfaceType",Flag) ? 40 : 12;
            ////Frm_Wait frm = new Frm_Wait("",true);
            ////frm.ShowDialog();
            ////ReadHomeTcp();

        }




        //private void ReadHomeTcp()
        //{
        //    if (db.SaveCs8cConfigure())
        //    {

        //        PublicFunc.ReadCs8CConfigure();
        //        LL_J1.Text ="J1:"+ TxtData.CS8CConfigure.Home[0].ToString();
        //        LL_J2.Text = "J2:" + TxtData.CS8CConfigure.Home[1].ToString();
        //        LL_J3.Text = "J3:" + TxtData.CS8CConfigure.Home[2].ToString();
        //        LL_J4.Text = "J4:" + TxtData.CS8CConfigure.Home[3].ToString();
        //        LL_J5.Text = "J5:" + TxtData.CS8CConfigure.Home[4].ToString();
        //        LL_J6.Text = "J6:" + TxtData.CS8CConfigure.Home[5].ToString();


        //        LL_T1.Text = "X:" + TxtData.CS8CConfigure.Tool[0].ToString();
        //        LL_T2.Text = "Y:" + TxtData.CS8CConfigure.Tool[1].ToString();
        //        LL_T3.Text = "Z:" + TxtData.CS8CConfigure.Tool[2].ToString();
        //        LL_T4.Text = "RX:" + TxtData.CS8CConfigure.Tool[3].ToString();
        //        LL_T5.Text = "RY" + TxtData.CS8CConfigure.Tool[4].ToString();
        //        LL_T6.Text = "RZ:" + TxtData.CS8CConfigure.Tool[5].ToString();




        //    }
        //}

        private void Frm_Position_Load(object sender, EventArgs e)
        {
          //  ReadHomeTcp();
            if (TxtData.DataBase.SoapStaus)
            {

                TxtData.DataBase.ValVersion = SoapInstance.SoapRead.GetControllerVersion();
                TxtData.DataBase.RobotType = SoapInstance.SoapRead.GetArmType();
                TxtData.DataBaseSlave.ValVersion = SoapInstance.SoapWrite.GetControllerVersion();
                TxtData.DataBaseSlave.RobotType = SoapInstance.SoapWrite.GetArmType();

            }
            else
            {
                return;
            }
     
                LL_RobotType.Text = "机器人类型:" + TxtData.DataBase.RobotType;
                LL_Val.Text = "Val3版本:" + TxtData.DataBase.ValVersion;
                LL_IP.Text = "IP:" + TxtData.XMLConfigure.IpAddress;
   
              //  LL_RobotType.Text = "机器人类型:" + TxtData.DataBaseSlave.RobotType;
              //  LL_Val.Text = "Val3版本:" + TxtData.DataBaseSlave.ValVersion;
                SLL_RobotType.Text = "机器人类型:" + TxtData.DataBaseSlave.RobotType;
                SLL_Val.Text = "Val3版本:" + TxtData.DataBaseSlave.ValVersion;
                SLL_IP.Text = "IP:" + TxtData.XMLConfigure.SlaveIpAddress;


        }

        private void timer_Refresh_Tick(object sender, EventArgs e)
        {
            if (TxtData.DataBase.SoapStaus
                && TxtData.DataBase.CurrentJoint != null //&& TxtData.DataBase.CurrentJoint.Length == 6
                && TxtData.DataBase.CurrentPoint != null //&& TxtData.DataBase.CurrentPoint.Length == 6
                && TxtData.DataBaseSlave.CurrentJoint != null// && TxtData.DataBaseSlave.CurrentJoint.Length == 6
                && TxtData.DataBaseSlave.CurrentPoint != null //&& TxtData.DataBaseSlave.CurrentPoint.Length == 6
                )
            {
                LL_J1.Text = "J1:" + TxtData.DataBase.CurrentJoint[0].ToString("0.00");
                LL_J2.Text = "J2:" + TxtData.DataBase.CurrentJoint[1].ToString("0.00");
                LL_J3.Text = "J3:" + TxtData.DataBase.CurrentJoint[2].ToString("0.00");
                LL_J4.Text = "J4:" + TxtData.DataBase.CurrentJoint[3].ToString("0.00");
                LL_J5.Text = "J5:" + TxtData.DataBase.CurrentJoint[4].ToString("0.00");
                LL_J6.Text = "J6:" + TxtData.DataBase.CurrentJoint[5].ToString("0.00");


                LL_T1.Text = "X:" + TxtData.DataBase.CurrentPoint[0].ToString("0.00");
                LL_T2.Text = "Y:" + TxtData.DataBase.CurrentPoint[1].ToString("0.00");
                LL_T3.Text = "Z:" + TxtData.DataBase.CurrentPoint[2].ToString("0.00");
                LL_T4.Text = "RX:" + TxtData.DataBase.CurrentPoint[3].ToString("0.00");
                LL_T5.Text = "RY" + TxtData.DataBase.CurrentPoint[4].ToString("0.00");
                LL_T6.Text = "RZ:" + TxtData.DataBase.CurrentPoint[5].ToString("0.00");




                LL_J1S.Text = "J1:" + TxtData.DataBaseSlave.CurrentJoint[0].ToString("0.00");
                LL_J2S.Text = "J2:" + TxtData.DataBaseSlave.CurrentJoint[1].ToString("0.00");
                LL_J3S.Text = "J3:" + TxtData.DataBaseSlave.CurrentJoint[2].ToString("0.00");
                LL_J4S.Text = "J4:" + TxtData.DataBaseSlave.CurrentJoint[3].ToString("0.00");
                LL_J5S.Text = "J5:" + TxtData.DataBaseSlave.CurrentJoint[4].ToString("0.00");
                LL_J6S.Text = "J6:" + TxtData.DataBaseSlave.CurrentJoint[5].ToString("0.00");


                SLL_T1.Text = "X:" + TxtData.DataBaseSlave.CurrentPoint[0].ToString("0.00");
                SLL_T2.Text = "Y:" + TxtData.DataBaseSlave.CurrentPoint[1].ToString("0.00");
                SLL_T3.Text = "Z:" + TxtData.DataBaseSlave.CurrentPoint[2].ToString("0.00");
                SLL_T4.Text = "RX:" + TxtData.DataBaseSlave.CurrentPoint[3].ToString("0.00");
                SLL_T5.Text = "RY" + TxtData.DataBaseSlave.CurrentPoint[4].ToString("0.00");
                SLL_T6.Text = "RZ:" + TxtData.DataBaseSlave.CurrentPoint[5].ToString("0.00");

            }
        }

        private void labelControl11_Click(object sender, EventArgs e)
        {

        }

        private void labelControl14_Click(object sender, EventArgs e)
        {

        }

    }
}
