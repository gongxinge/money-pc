using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FrmDetailList : Form
    {
        List<Model.BillDetailModel> list;
        public FrmDetailList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowListView();
        }

        private void ShowListView()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(string.Format(" d.ReceivableDay >='{0}'", dateTimePicker1.Value.Date.ToString("yyyy-MM-dd")));
            builder.Append(string.Format(" and d.ReceivableDay <='{0}'", dateTimePicker2.Value.Date.ToString("yyyy-MM-dd")));
            builder.Append(" and d.deleted =0");

            builder.Append(" order by ReceivableDay asc");

            list = DAL.BillDetailDAL.GetBacklog(builder.ToString());
            listView1.Items.Clear();
            this.groupBox1.Text = string.Format("{0}至{1}的收益统计", this.dateTimePicker1.Value.ToString("yyyy-MM-dd"), this.dateTimePicker2.Value.ToString("yyyy-MM-dd"));

            double benxi = 0;
            double lixi = 0;
            double benjin = 0;

            for (int i = 0; i < list.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = (listView1.Items.Count + 1).ToString();
                lvi.SubItems.Add(list[i].SiteName);
                lvi.SubItems.Add(list[i].SiteUserName);
                lvi.SubItems.Add(list[i].TotalMoney.ToString());
                lvi.SubItems.Add(list[i].Periods);
                lvi.SubItems.Add(list[i].ReceivableDay);
                //lvi.SubItems.Add(string.IsNullOrEmpty(list[i].ReceivedDay) ? "-" : list[i].ReceivedDay);
                //lvi.SubItems.Add(list[i].ReceivedPrincipalAndInterest > 0 ? list[i].ReceivedPrincipalAndInterest.ToString() : "-");
                lvi.SubItems.Add(list[i].ReceivablePrincipalAndInterest.ToString());
                lvi.SubItems.Add(list[i].ReceivableInterest.ToString());
                lvi.SubItems.Add((list[i].ReceivablePrincipalAndInterest - list[i].ReceivableInterest).ToString());
                lvi.SubItems.Add(list[i].Remark);
                lvi.SubItems.Add(list[i].Flag == 0 ? "待收" : "已收");

                benxi += list[i].ReceivablePrincipalAndInterest;
                lixi += list[i].ReceivableInterest;
                benjin += (list[i].ReceivablePrincipalAndInterest - list[i].ReceivableInterest);
                listView1.Items.Add(lvi);
            }

            lblInfo.Text = string.Format("应收本息: {0}        应收利息：{1}        应收本金：{2}", benxi, lixi, benjin);
            this.listView1.Visible = true;
        }

        private void FrmDetailList_Load(object sender, EventArgs e)
        {
            this.dateTimePicker1.Value = System.DateTime.Now.Date.AddDays(1 - System.DateTime.Now.Day);
            this.dateTimePicker2.Value = this.dateTimePicker1.Value.AddMonths(1).AddDays(-1);
            ShowListView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddMonths(-1);
            dateTimePicker2.Value = dateTimePicker2.Value.AddMonths(-1);
            ShowListView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddMonths(1);
            dateTimePicker2.Value = dateTimePicker2.Value.AddMonths(1);
            ShowListView();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //if (listView1.SelectedItems.Count > 0)
            //{
            //    int selectIndex = listView1.SelectedItems[0].Index;
            //    FrmReciveMoney frm = new FrmReciveMoney(list[selectIndex].ReceivableDay, list[selectIndex].ReceivablePrincipalAndInterest);
            //    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    {
            //        list[selectIndex].ReceivedPrincipalAndInterest = frm.receivable;
            //        //list[selectIndex].ReceivedDay = frm.receiveDay;
            //        bool flag = DAL.BillDetailDAL.ShouKuan(list[selectIndex]);
            //        if (flag)
            //        {
            //            //listView1.Items[selectIndex].SubItems[3].Text = list[selectIndex].ReceivedDay;
            //            listView1.Items[selectIndex].SubItems[4].Text = list[selectIndex].ReceivedPrincipalAndInterest.ToString();
            //        }
            //        else
            //        {
            //            MessageBox.Show("数据错误，请重启软软件后重新操作！");
            //        }

            //    }
            //}
        }

        private void 收款ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                if (DAL.BillDetailDAL.ShouKuan(list[listView1.SelectedItems[0].Index]))
                {
                    list[listView1.SelectedItems[0].Index].Flag = 1;
                    listView1.SelectedItems[0].SubItems[10].Text = "已收";

                    AppInfo.Instance.IsChanged = true;
                }
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right && listView1.SelectedItems.Count > 0)
            {
                if (list[listView1.SelectedItems[0].Index].Flag == 0)
                {
                    this.contextMenuStrip1.Items[0].Enabled = true;
                    this.contextMenuStrip1.Items[1].Enabled = false;
                }
                else
                {
                    this.contextMenuStrip1.Items[0].Enabled = false;
                    this.contextMenuStrip1.Items[1].Enabled = true;
                }
                this.contextMenuStrip1.Show(listView1, new Point(e.X, e.Y));
            }
        }

        private void 设为待收ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count > 0)
            {
                if (DAL.BillDetailDAL.QuXiaoShoukuan(list[listView1.SelectedItems[0].Index]))
                {
                    list[listView1.SelectedItems[0].Index].Flag = 0;
                    listView1.SelectedItems[0].SubItems[10].Text = "待收";

                    AppInfo.Instance.IsChanged = true;
                }
            }
        }

        ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();
        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.listView1.ListViewItemSorter = lvwColumnSorter;
            // 检查点击的列是不是现在的排序列.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // 重新设置此列的排序方法.
                if (lvwColumnSorter.Order == System.Windows.Forms.SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
                }
            }
            else
            {
                // 设置排序列，默认为正向排序
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
            }

            // 用新的排序方法对ListView排序
            this.listView1.Sort();

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                listView1.Items[i].SubItems[0].Text = (i + 1).ToString();
            }
        }
    }
}
