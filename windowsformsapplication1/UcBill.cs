using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class UcBill : UserControl
    {
        Action<UcBill, bool> action = null;
        public Model.BillModel billModel;
        private int num = 0;
        public UcBill()
        {
            InitializeComponent();
            billModel = new Model.BillModel();
        }

        public UcBill(Model.BillModel model, Action<UcBill, bool> action, int num)
        {
            InitializeComponent();
            billModel = model;
            this.action = action;
            this.num = num;
        }


        public UcBill(Action<UcBill, bool> action)
        {
            InitializeComponent();
            this.action = action;
            billModel = new Model.BillModel();
        }

        private void UcBill_Load(object sender, EventArgs e)
        {
            lblSiteName.Text = billModel.SiteName;
            lblSiteUserName.Text = string.IsNullOrEmpty(billModel.SiteUserName) ? "" : string.Format("平台用户名：{0}", billModel.SiteUserName);
            lblTotalMoney.Text = billModel.TotalMoney.ToString();
            lblBeginDate.Text = billModel.BeginDay;
            lblRate.Text = billModel.YearRete.ToString() + "%";
            lblPeriods.Text = string.Format("{0}/{1}", billModel.ReceivedPeriod, billModel.ReceivablePeriod);
            lblReceivable.Text = billModel.ReceivablePrincipalAndInterest.ToString();
            lblMonths.Text = string.Format("{0}个月", billModel.Deadline);
            lblremark.Text = string.IsNullOrEmpty(billModel.Remark) ? "" : string.Format("备注：{0}", billModel.Remark);
            lblWay.Text = GetDescription(billModel.WayOfRepayment, true);
            this.lblNum.Text = this.num.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (action != null)
            {
                bool he = lblleft.Text == "+";
                action(this, he);
                this.lblleft.Text = he ? "-" : "+";
            }
        }

        private void pnlBillInfo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            label3_Click(null, null);
        }


        public void SetHeFlag(bool hebing)
        {
            this.lblleft.Text = hebing ? "-" : "+";
        }


        /// <summary>
        /// 扩展方法，获得枚举的Description
        /// </summary>
        /// <param name="value">枚举值</param>
        /// <param name="nameInstead">当枚举值没有定义DescriptionAttribute，是否使用枚举名代替，默认是使用</param>
        /// <returns>枚举的Description</returns>
        public static string GetDescription(Enum value, Boolean nameInstead = true)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name == null)
            {
                return null;
            }

            System.Reflection.FieldInfo field = type.GetField(name);
            DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

            if (attribute == null && nameInstead == true)
            {
                return name;
            }
            return attribute == null ? null : attribute.Description;
        }
    }
}
