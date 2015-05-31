using System;
using System.Collections.Generic;

using System.Text;

namespace WindowsFormsApplication1.Model
{
    public partial class BillDetailModel
    {
        /// <summary>
        /// 明细编号
        /// </summary>
        public string BillDetailID { get; set; }
        /// <summary>
        /// 借款编号
        /// </summary>
        public string BillID { get; set; }
        /// <summary>
        /// 当前期数
        /// 如：1/12
        /// </summary>
        public string Periods { get; set; }
        /// <summary>
        /// 应收日期
        /// </summary>
        public string ReceivableDay { get; set; }
        /// <summary>
        /// 实际收款日期
        /// </summary>
        public string ReceivedDay { get; set; }
        /// <summary>
        /// 应收本息
        /// </summary>
        public double ReceivablePrincipalAndInterest { get; set; }
        /// <summary>
        /// 应收利息
        /// </summary>
        public double ReceivableInterest { get; set; }
        /// <summary>
        /// 实收本息
        /// </summary>
        public double ReceivedPrincipalAndInterest { get; set; }
        /// <summary>
        /// 是否逾期
        /// 0：未逾期 1：逾期
        /// </summary>
        public int IsYuQi { get; set; }
        /// <summary>
        /// 删除标志 0:未删除 1:已删除
        /// </summary>
        public int Deleted { get; set; }
        /// <summary>
        /// 0:未收取
        /// 2:已收取
        /// </summary>
        public int Flag { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }

    public partial class BillDetailModel
    {
        /// <summary>
        /// 平台名称
        /// </summary>
        public string SiteName { get; set; }
        /// <summary>
        /// 平台用户名
        /// </summary>
        public string SiteUserName { get; set; }
        /// <summary>
        /// 借款总额
        /// </summary>
        public double TotalMoney { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public string BillPeriods { get; set; }
        /// <summary>
        /// 应收期数
        /// </summary>
        public int ReceivablePeriod { get; set; }
        /// <summary>
        /// 已收期数
        /// </summary>
        public int ReceivedPeriod { get; set; }
    }
}
