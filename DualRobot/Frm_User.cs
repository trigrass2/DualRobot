using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using StaubliRobot;

namespace LasMAN
{
    public partial class Frm_User : Std_Form
    {
        DataBaseManage db = new DataBaseManage();
        public Frm_User()
        {
            InitializeComponent();
        }

        private void Frm_User_Load(object sender, EventArgs e)
        {
            TableShow();
            db.GetPopedom(ref TxtData.PublicData.ScreenEnable);
            CBE_Screen_SelectedIndexChanged(this, null);
          db.GetIp(ref TxtData.XMLConfigure.IpAddress, ref  TxtData.XMLConfigure.SlaveIpAddress);
            TE_IP.Text = TxtData.XMLConfigure.IpAddress;
            TE_SlaveIP.Text = TxtData.XMLConfigure.SlaveIpAddress;
        }

        private void TableShow()
        {
            GC_User.DataSource = db.GetDV_User();
            if (gv.RowCount > 0)
            {


                gv.Columns.Remove(gv.Columns["PASSWORD"]);
                gv.Columns.Remove(gv.Columns["BP1"]);
                gv.Columns.Remove(gv.Columns["BP2"]);
                gv.Columns.Remove(gv.Columns["BP3"]);
                gv.Columns.Remove(gv.Columns["BP4"]);
                gv.Columns.Remove(gv.Columns["REMARK"]);
                gv.Columns.Remove(gv.Columns["CELLPHONE"]);
                gv.Columns.Remove(gv.Columns["FAX"]);

                //gv.Columns.Remove(gv.Columns["ARRAY_XCOUNT"]);
                //gv.Columns.Remove(gv.Columns["ARRAY_XOFFSET"]);
                //gv.Columns.Remove(gv.Columns["ARRAY_YCOUNT"]);
                //gv.Columns.Remove(gv.Columns["ARRAY_YOFFSET"]);
                ////gv.Columns.Remove(gv.Columns["OFFSET_X"]);
                ////************************************************
                gv.Columns["USER"].Caption = "用户名";
                gv.Columns["NAME"].Caption = "名称";
                gv.Columns["ACCESSLEVEL"].Caption = "权限";
                gv.Columns["EMAIL"].Caption = "电子邮件";
                gv.Columns["TELEPHONE"].Caption = "电话";
             
                


            }
        }

        private void BT_Delete_Click(object sender, EventArgs e)
        {
            if (gv.RowCount == 0)
            {
               MessageBox.Show("没有选择项");
                return;
            }
            if (MessageBox.Show("确定需要删除吗？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            string Name = gv.GetFocusedRowCellValue("USER").ToString();
            db.DeleteUser(Name);

              Frm_User_Load(this,null);


        }

        private void BT_Edit_Click(object sender, EventArgs e)
        {
            if (gv.RowCount==0)
            {
                MessageBox.Show("没有可编辑项");
                return;
            }
            string Name = gv.GetFocusedRowCellValue("USER").ToString();
            Edit_User frm = new Edit_User(Name);
            frm.ShowDialog();
            Frm_User_Load(this, null);
        }

        private void BT_Add_Click(object sender, EventArgs e)
        {
            Edit_User frm = new Edit_User();
            frm.ShowDialog();
            Frm_User_Load(this, null);
        }
        /// <summary>
        /// 用户定义
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_OK_Click(object sender, EventArgs e)
        {
            int Index = CBE_Screen.SelectedIndex;
            for (int i = 0; i < CBC_Check.ItemCount;i++ )
            {
               // TxtData.PublicData.ScreenEnable[Index,i]=CBC_Check.Items.
              //  CBC_Check.SetItemChecked(i,);
                TxtData.PublicData.ScreenEnable[Index, i] = CBC_Check.GetItemChecked(i);
            }
            db.EditPopedom(TxtData.PublicData.ScreenEnable);
         
        }

        private void CBE_Screen_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Index = CBE_Screen.SelectedIndex;
            for (int i = 0; i < CBC_Check.ItemCount; i++)
            {
                // TxtData.PublicData.ScreenEnable[Index,i]=CBC_Check.Items.
                CBC_Check.SetItemChecked(i, TxtData.PublicData.ScreenEnable[Index, i]); 
               // TxtData.PublicData.ScreenEnable[Index, i] = CBC_Check.GetItemChecked(i);
            }

        }

        private void BT_BackupDB_Click(object sender, EventArgs e)
        {
            string FileName;
            if ((FileName = PublicFunc.SfD_Show("LasMAN.mdb", "数据库文件(*.mdb)|*.mdb")) == null)
            {
                return;
            }
            if (System.IO.File.Exists(Application.StartupPath + "\\LasMAN.mdb"))
            {
                System.IO.File.Copy(Application.StartupPath + "\\LasMAN.mdb", FileName, true);
            }
        }

        private void BT_ImportDB_Click(object sender, EventArgs e)
        {
            string FileName;
            if ((FileName = PublicFunc.OpenDir_Show(Application.StartupPath, "数据库文件(*.mdb)|*.mdb")) == null)
            {
                return;
            }
            if (System.IO.File.Exists(FileName))
            {
                System.IO.File.Copy(FileName, Application.StartupPath + "\\LasMAN.mdb", true);
            }
        }

        private void BT_EditIP_Click(object sender, EventArgs e)
        {
            string Buff = TxtData.XMLConfigure.IpAddress;
            Edit_Ip frm = new Edit_Ip(1);
            frm.ShowDialog();
          //  Frm_Cs8cConfig_Load(this, null);
            if (TxtData.XMLConfigure.IpAddress != Buff)
            {
                // TxtData.DataBase.SoapStaus = false;
                // SoapInstance.SoapRead = new SoapClient(TxtData.XMLConfigure.IpAddress);

                MessageBox.Show("请关闭软件并重新打开");
            }
        }

        private void BT_EditSlaveIp_Click(object sender, EventArgs e)
        {
            string Buff = TxtData.XMLConfigure.SlaveIpAddress;
            Edit_Ip frm = new Edit_Ip(2);
            frm.ShowDialog();
         //   Frm_Cs8cConfig_Load(this, null);
            if (TxtData.XMLConfigure.SlaveIpAddress!= Buff)
            {
                // TxtData.DataBase.SoapStaus = false;
                // SoapInstance.SoapRead = new SoapClient(TxtData.XMLConfigure.IpAddress);

                MessageBox.Show("请关闭软件并重新打开");
            }
        }

    }
}
