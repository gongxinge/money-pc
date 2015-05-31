using System;
using System.Collections.Generic;

using System.Text;

namespace WindowsFormsApplication1.Model
{
    public class BillModel
    {
        /// <summary>
        /// 借款编号
        /// </summary>
        public string BillID { get; set; }
        /// <summary>
        /// 平台名称
        /// </summary>
        public string SiteName { get; set; }
        /// <summary>
        /// 平台用户名
        /// </summary>
        public string SiteUserName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 借款总额
        /// </summary>
        public double TotalMoney { get; set; }
        /// <summary>
        /// 年利率
        /// </summary>
        public double YearRete { get; set; }
        /// <summary>
        /// 期限
        /// </summary>
        public int Deadline { get; set; }
        /// <summary>
        /// 期限类型
        /// 1：天
        /// 2: 月
        /// </summary>
        public int DeadlineType { get; set; }
        ///// <summary>
        ///// 当前期数
        ///// 如：1/12
        ///// </summary>
        //public string Periods { get; set; }
        /// <summary>
        /// 应收期数
        /// </summary>
        public int ReceivablePeriod{get;set;}
        /// <summary>
        /// 已收期数
        /// </summary>
        public int ReceivedPeriod { get; set; }
        /// <summary>
        /// 应收本息
        /// </summary>
        public double ReceivablePrincipalAndInterest { get; set; }
        /// <summary>
        /// 已收本息
        /// </summary>
        public double ReceivedPrincipalAndInterest { get; set; }
        /// <summary>
        /// 还款方式
        /// </summary>
        public E_WayOfRepayment WayOfRepayment { get; set; }
        /// <summary>
        /// 奖励金额
        /// </summary>
        public double Reward { get; set; }
        /// <summary>
        /// 出借日期
        /// </summary>
        public string BeginDay { get; set; }
        /// <summary>
        /// 到期日期
        /// </summary>
        public string EndDay { get; set; }
        /// <summary>
        /// 逾期次数
        /// </summary>
        public int YuQiCount { get; set; }
        /// <summary>
        /// 删除标志 0:未删除 1:已删除
        /// </summary>
        public int Deleted { get; set; }
        /// <summary>
        /// 
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
}
