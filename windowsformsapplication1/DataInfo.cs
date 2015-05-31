using System;
using System.Collections.Generic;

using System.Text;
using System.ComponentModel;

namespace WindowsFormsApplication1
{
    public class DataInfo
    {

    }

    /// <summary>
    /// 还款方式
    /// 1:等额本息
    /// 2:等额本金
    /// 3:月付息到期付本
    /// 4:月付息按季付本
    /// </summary>
    public enum E_WayOfRepayment
    {
        /// <summary>
        /// 等额本息
        /// </summary>
        [Description("等额本息")]
        等额本息 = 0,
        /// <summary>
        /// 等额本金
        /// </summary>
        [Description("等额本金")]
        等额本金 = 1,
        /// <summary>
        /// 月付息到期付本
        /// </summary>
        [Description("月付息到期付本")]
        月付息到期付本 = 2,
        /// <summary>
        /// 月付息按季付本
        /// </summary>
        [Description("月付息按季付本")]
        月付息按季付本 = 3,
        /// <summary>
        /// 按天计息到期本息
        /// </summary>
        [Description("一次性本息")]
        一次性本息 = 4,
    }

    //public enum E_WayOfRepayment
    //{
    //    /// <summary>
    //    /// 等额本息
    //    /// </summary>
    //    [Description("等额本息")]
    //    EverageCapitalPlusInterest = 1,
    //    /// <summary>
    //    /// 等额本金
    //    /// </summary>
    //    [Description("等额本金")]
    //    EverageCapital = 2,
    //    /// <summary>
    //    /// 月付息到期付本
    //    /// </summary>
    //    [Description("月付息到期付本")]
    //    MonthInterestEndCapital = 3,
    //    /// <summary>
    //    /// 月付息按季付本
    //    /// </summary>
    //    [Description("月付息按季付本")]
    //    MonthInterestSeasonCapital = 4,
    //    /// <summary>
    //    /// 按天计息到期本息
    //    /// </summary>
    //    [Description("按天计息到期付本息")]
    //    DayInterestEndCapital = 5,
    //}
}
