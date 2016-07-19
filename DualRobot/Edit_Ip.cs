using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using StaubliRobot;

namespace LasMAN
{
    public partial class Edit_Ip : DevExpress.XtraEditors.XtraForm
    {

        int Type = 0;
        DataBaseManage db = new DataBaseManage();
        public Edit_Ip()
        {
            InitializeComponent();
        }
        public Edit_Ip(int type)
        {
            InitializeComponent();
            Type = type;
        }

        private void Edit_Ip_Load(object sender, EventArgs e)
        {
            switch (Type)
            {
                case 1:
                    {
                        this.Text = "编辑主控控制器IP";
                        LL_Text.Text = "新主控控制器IP:";
                        LL_Mark.Text = "请输入新主控控制器IP";
                        break;
                    }

                case 2:
                    {
                        this.Text = "编辑从控控制器IP";
                        LL_Text.Text = "新从控控制器IP:";
                        LL_Mark.Text = "请输入新从控控制器IP";
                        break;
                    }



            }
        }

        private void BT_ok_Click(object sender, EventArgs e)
        {
            if (TB_Code.Text.Trim() == "")
            {
                MessageBox.Show("输入不能为空！");
                return;

            }

            string[] data = TB_Code.Text.Trim().Split('.');
            if (data.Length != 4)
            {

                MessageBox.Show("输入位数不正确！");
                return;

            }
            if (Type==1)
            {
                TxtData.XMLConfigure.IpAddress = TB_Code.Text.Trim();
            }

            else
            {
                TxtData.XMLConfigure.SlaveIpAddress = TB_Code.Text.Trim();
            }


            if (!db.EditIp(TxtData.XMLConfigure.IpAddress, TxtData.XMLConfigure.SlaveIpAddress))
            {
                MessageBox.Show("数据库出错");
                return;

            }

            this.Close();
        }

        private void BT_Cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}
