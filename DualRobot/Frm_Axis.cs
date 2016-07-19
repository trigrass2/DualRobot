using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using StaubliRobot;

namespace LasMAN
{
    public partial class Frm_Axis : Std_Form
    {
        DataBaseManage db = new DataBaseManage();
        public Frm_Axis()
        {
            InitializeComponent();
        }

        private void BT_T1_Click(object sender, EventArgs e)
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

            //if (!SoapInstance.SoapRead.SetAppdata("nInterfaceType", 12))
            //{
            //    MessageBox.Show("设置下位机数据出错!");
            //    return;
            //}
            //TxtData.PublicData.ErrorCode = 0;
            //Frm_Wait frm = new Frm_Wait(true);
            //frm.ShowDialog();
            //Frm_Axis_Load(this, null);
        }

        private void Frm_Axis_Load(object sender, EventArgs e)
        {
                        db.SaveCs8cConfigure();
                        if (PublicFunc.ReadCs8CConfigure())
                        {
                            TE_S1.EditValue = TxtData.CS8CConfigure.Axis[0];
                            TE_S2.EditValue = TxtData.CS8CConfigure.Axis[1];
                           // TE_S3.EditValue = TxtData.CS8CConfigure.Axis[2];
                          //  RB_C1.Checked = TxtData.CS8CConfigure.EnableItem[5];
                        }

        }
        /// <summary>
        /// 对七轴参数进行修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_E1_Click(object sender, EventArgs e)
        {
          //  TxtData.CS8CConfigure.EnableItem[5] = RB_C1.Checked;
            TxtData.CS8CConfigure.Axis[0] = double.Parse(TE_S1.EditValue.ToString());
            TxtData.CS8CConfigure.Axis[1] = double.Parse(TE_S2.EditValue.ToString());
          //  TxtData.CS8CConfigure.Axis[2] =double.Parse( TE_S3.EditValue.ToString());
            if (!db.EditConfigure(TxtData.CS8CConfigure.EnableItem) || !db.EditConfigure(TxtData.CS8CConfigure.Axis, "AXIS7HOME"))
            {
                MessageBox.Show("数据库操作异常");
            }
            else
            {
                MessageBox.Show("成功");
            }
        }
    }
}
