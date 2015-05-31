using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FrmBillAdd : Form
    {
        public FrmBillAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.cmbWayOfRepayment.SelectedIndex == 0)
            {
                MessageBox.Show("请选择还款方式！");
                return;
            }

            Model.BillModel billModel = GetBillModel();
            List<Model.BillDetailModel> details = WayOfRepayment.GetDetailsByBillInfo(ref billModel);

            StringBuilder builder = new StringBuilder();
            builder.Append("Insert into billInfo (BillID ,SiteName,SiteUserName,TotalMoney,YearRete,Deadline,DeadlineType,ReceivedPeriod,ReceivablePeriod,ReceivablePrincipalAndInterest,ReceivedPrincipalAndInterest,WayOfRepayment,Reward,BeginDay,EndDay,YuQiCount,Deleted,Flag,Remark,UpdateTime,Createtime)");
            builder.Append(string.Format("Values('{0}','{1}','{2}',{3},{4},{5},{6},0,{7},{8},{9},{10},{11},'{12}','{13}',{14},{15},{16},'{17}','{18}','{19}')",
                billModel.BillID, billModel.SiteName, billModel.SiteUserName, billModel.TotalMoney, billModel.YearRete,
                billModel.Deadline, billModel.DeadlineType, billModel.ReceivablePeriod, billModel.ReceivablePrincipalAndInterest,
                billModel.ReceivedPrincipalAndInterest, (int)billModel.WayOfRepayment, billModel.Reward, billModel.BeginDay,
                billModel.EndDay, billModel.YuQiCount, billModel.Deleted, billModel.Deleted, billModel.Remark,
                billModel.UpdateTime.ToString("s"), billModel.CreateTime.ToString("s")));

            for (int i = 0; i < details.Count; i++)
            {
                builder.Append("|");    //语句分隔符
                builder.Append("Insert into billdetail( BillDetailID,BillID,Periods,ReceivableDay,ReceivedDay,ReceivablePrincipalAndInterest,ReceivableInterest,ReceivedPrincipalAndInterest,IsYuQi,Deleted,Flag,UpdateTime,CreateTime)");
                builder.Append(string.Format("Values('{0}','{1}','{2}','{3}','{4}',{5},{6},{7},{8},{9},{10},'{11}','{12}')",
                    details[i].BillDetailID, details[i].BillID, details[i].Periods, details[i].ReceivableDay,
                    details[i].ReceivedDay, details[i].ReceivablePrincipalAndInterest,
                    details[i].ReceivableInterest, details[i].ReceivedPrincipalAndInterest,
                    details[i].IsYuQi, details[i].Deleted, details[i].Flag, details[i].UpdateTime.ToString("s"),
                    details[i].CreateTime.ToString("s")));
            }


            bool flag = SQLiteHelper.UpdateData(builder.ToString(), true);
            if (flag)
            {
                AppInfo.Instance.IsChanged = true;
                MessageBox.Show("添加成功！");
            }
            else
            {
                MessageBox.Show("添加失败！");
            }
        }

        public void ShowList(List<Model.BillDetailModel> list)
        {
            this.listView1.Items.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = ((listView1.Items.Count + 1).ToString());
                lvi.SubItems.Add(list[i].Periods);
                lvi.SubItems.Add(list[i].ReceivableDay);
                lvi.SubItems.Add(list[i].ReceivablePrincipalAndInterest.ToString());
                lvi.SubItems.Add(list[i].ReceivableInterest.ToString());
                lvi.SubItems.Add((list[i].ReceivablePrincipalAndInterest - list[i].ReceivableInterest).ToString());

                listView1.Items.Add(lvi);
            }
        }

        private void FrmBillAdd_Load(object sender, EventArgs e)
        {
            cmbWayOfRepayment.DataSource = BindComboxEnumType<E_WayOfRepayment>.BindTypes;
            cmbWayOfRepayment.DisplayMember = "Name";
            cmbWayOfRepayment.ValueMember = "TypeValue";
            this.cmbWayOfRepayment.SelectedIndex = 2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.cmbWayOfRepayment.SelectedIndex == 0)
            {
                MessageBox.Show("请选择还款方式！");
                return;
            }

            Model.BillModel billModel = GetBillModel();
            List<Model.BillDetailModel> details = WayOfRepayment.GetDetailsByBillInfo(ref billModel);

            if (details != null && details.Count > 0)
                ShowList(details);
        }

        private Model.BillModel GetBillModel()
        {
            Model.BillModel billModel = new Model.BillModel();

            billModel.SiteName = txtSiteName.Text.Trim();
            billModel.SiteUserName = txtSiteUserName.Text.Trim();
            billModel.Remark = txtRemark.Text.Trim();
            billModel.BeginDay = this.dateTimePicker1.Value.ToString("yyyy-MM-dd");
            billModel.Deadline = int.Parse(txtDeadline.Text.Trim());
            billModel.DeadlineType = radioButton2.Checked ? 1 : 2; //按月：2   按天:1
            billModel.TotalMoney = double.Parse(txtTotalMoney.Text.Trim());
            billModel.YearRete = float.Parse(txtYearRate.Text.Trim()) / 100;
            billModel.WayOfRepayment = (E_WayOfRepayment)cmbWayOfRepayment.SelectedIndex;
            if (billModel.DeadlineType == 1)
                billModel.EndDay = DateTime.Parse(billModel.BeginDay).AddDays(billModel.Deadline).ToString("yyyy-MM-dd");
            else
                billModel.EndDay = DateTime.Parse(billModel.BeginDay).AddMonths(billModel.Deadline).ToString("yyyy-MM-dd");

            billModel.CreateTime = System.DateTime.Now;
            billModel.UpdateTime = System.DateTime.Now;

            return billModel;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                this.cmbWayOfRepayment.SelectedIndex = 4;
                //this.cmbWayOfRepayment.SelectedValue = (int)E_WayOfRepayment.一次性本息;
                this.cmbWayOfRepayment.Enabled = false;
            }
            else
            {
                this.cmbWayOfRepayment.Enabled = true;
            }
        }

    }

    public class BindComboxEnumType<T>
    {
        public string Name
        {
            get;
            set;
        }

        public string TypeValue
        {
            get;
            set;
        }

        private static readonly List<BindComboxEnumType<T>> bindTypes;

        static BindComboxEnumType()
        {
            bindTypes = new List<BindComboxEnumType<T>>();

            Type t = typeof(T);

            foreach (System.Reflection.FieldInfo field in t.GetFields())
            {
                if (field.IsSpecialName == false)
                {
                    BindComboxEnumType<T> bind = new BindComboxEnumType<T>();
                    bind.Name = field.Name;
                    bind.TypeValue = field.GetRawConstantValue().ToString();
                    bindTypes.Add(bind);
                }

            }
        }

        public static List<BindComboxEnumType<T>> BindTypes
        {
            get
            {
                return bindTypes;
            }
        }
    }
}
