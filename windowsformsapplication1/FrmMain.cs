using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmBillAdd frm = new FrmBillAdd();
            frm.ShowDialog();
            GetInfo();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            FrmBillList frm = new FrmBillList();
            frm.ShowDialog();
            GetInfo();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmDetailList frm = new FrmDetailList();
            frm.ShowDialog();
            GetInfo();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (QiNiuHelper.DownloadFile())
            {
                AppInfo.Instance.IsNetworking = true;
                QiNiuHelper.CheckMonthFile();
            }
            else
            {
                MessageBox.Show("当前处于断网模式，建议不要修改数据！");
                AppInfo.Instance.IsNetworking = false;
            }
            GetInfo();
        }

        private void GetInfo()
        {
            string sql = "select sum(receivableprincipalandinterest) receivableprincipalandinterest,sum(receivableinterest) receivableinterest from billdetail where flag=0";
            DataTable dt = SQLiteHelper.GetDataTable(sql);

            double receivableprincipalandinterest = 0;
            double receivableinterest = 0;
            if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["receivableprincipalandinterest"] != DBNull.Value && dt.Rows[0]["receivableinterest"] != DBNull.Value)
            {
                receivableprincipalandinterest = Math.Round(double.Parse(dt.Rows[0]["receivableprincipalandinterest"].ToString()), 2);
                receivableinterest = Math.Round(double.Parse(dt.Rows[0]["receivableinterest"].ToString()), 2);
            }

            label1.Text = string.Format("待收本息：{0}\r\n\r\n待收本金：{1}\r\n\r\n待收利息：{2}", receivableprincipalandinterest, receivableprincipalandinterest - receivableinterest, receivableinterest);

        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AppInfo.Instance.IsNetworking && AppInfo.Instance.IsChanged)
            {
                QiNiuHelper.PutFile();
            }
        }

    }
}
