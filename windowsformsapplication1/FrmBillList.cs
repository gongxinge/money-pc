using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FrmBillList : Form
    {

        List<Model.BillDetailModel> list = null;
        public FrmBillList()
        {
            InitializeComponent();
        }

        private void FrmBillList_Load(object sender, EventArgs e)
        {
            this.ShowBillInfo();
        }

        private int lastControlIndex = -1;

        private void ShowControlsIndex(UcBill ucBill, bool hebing)
        {
            if (hebing)
            {
                //展开
                int billIndex = this.flowLayoutPanel1.Controls.IndexOf(ucBill);
                int viewIndex = this.flowLayoutPanel1.Controls.IndexOf(this.listView1);

                if (lastControlIndex != -1)
                {
                    ((UcBill)this.flowLayoutPanel1.Controls[lastControlIndex]).SetHeFlag(false);
                }

                if (viewIndex < billIndex)
                {
                    this.flowLayoutPanel1.Controls.SetChildIndex(this.listView1, billIndex);
                }
                else
                {
                    this.flowLayoutPanel1.Controls.SetChildIndex(this.listView1, billIndex + 1);
                }

                lastControlIndex = this.flowLayoutPanel1.Controls.IndexOf(ucBill);

                ShowBillDetail(ucBill.billModel.BillID);
            }
            else
            {
                //展开
                this.listView1.Visible = false;
            }
        }

        /// <summary>
        /// 显示借款列表
        /// </summary>
        private void ShowBillInfo()
        {
            foreach (Control item in this.flowLayoutPanel1.Controls)
            {
                if (item.Tag == null)
                {
                    flowLayoutPanel1.Controls.Remove(item);
                }
            }
            this.listView1.Visible = false;

            List<Model.BillModel> list = DAL.BillDAL.GetBillList("deleted=0 and flag=0 order by beginday");
            Action<UcBill, bool> action = new Action<UcBill, bool>(ShowControlsIndex);
            for (int i = 0; i < list.Count; i++)
            {
                UcBill ucbill = new UcBill(list[i], action, i + 1);
                this.flowLayoutPanel1.Controls.Add(ucbill);
            }

        }

        /// <summary>
        /// 显示还款计划
        /// </summary>
        /// <param name="billID"></param>
        private void ShowBillDetail(string billID)
        {
            list = DAL.BillDetailDAL.GetBillList(string.Format(" deleted=0 and billid='{0}' order by ReceivableDay", billID));

            listView1.Items.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = ((listView1.Items.Count + 1).ToString());
                lvi.SubItems.Add(list[i].Periods);
                lvi.SubItems.Add(list[i].ReceivableDay);
                //lvi.SubItems.Add(string.IsNullOrEmpty(list[i].ReceivedDay) ? "-" : list[i].ReceivedDay);
                //lvi.SubItems.Add(list[i].ReceivedPrincipalAndInterest > 0 ? list[i].ReceivedPrincipalAndInterest.ToString() : "-");
                lvi.SubItems.Add(list[i].ReceivablePrincipalAndInterest.ToString());
                lvi.SubItems.Add(list[i].ReceivableInterest.ToString());
                lvi.SubItems.Add((list[i].ReceivablePrincipalAndInterest - list[i].ReceivableInterest).ToString());
                lvi.SubItems.Add(list[i].Flag == 0 ? "待收" : "已收");

                listView1.Items.Add(lvi);
            }

            if (listView1.Items.Count > 12)
            {
                listView1.Size = new Size(listView1.Size.Width, 300);
            }
            else
            {
                listView1.Size = new Size(listView1.Size.Width, 50 + listView1.Items.Count * 22);
            }
            this.listView1.Visible = true;
        }

        /// <summary>
        /// 收款
        /// </summary>
        private void ReceiveMondy()
        {
            int selectIndex = listView1.SelectedItems[0].Index;
            FrmReciveMoney frm = new FrmReciveMoney(list[selectIndex].ReceivableDay, list[selectIndex].ReceivablePrincipalAndInterest);
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                list[selectIndex].ReceivedPrincipalAndInterest = frm.receivable;
                //list[selectIndex].ReceivedDay = frm.receiveDay;
                bool flag = DAL.BillDetailDAL.ShouKuan(list[selectIndex]);
                if (flag)
                {
                    //listView1.Items[selectIndex].SubItems[3].Text = list[selectIndex].ReceivedDay;
                    listView1.Items[selectIndex].SubItems[4].Text = list[selectIndex].ReceivedPrincipalAndInterest.ToString();
                }
                else
                {
                    MessageBox.Show("数据错误，请重启软软件后重新操作！");
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowBillInfo();
        }

    }
}
