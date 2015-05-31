using System;
using System.Collections.Generic;

using System.Text;

namespace WindowsFormsApplication1
{
    public class WayOfRepayment
    {
        #region 返回二维数组
        /// <summary>
        /// 方式：等本金还款
        /// </summary>
        /// <param name="nDeadline">期限</param>
        /// <param name="fMoney">总金额</param>
        /// <param name="dRate">年利率</param>
        /// <returns>交错数组:(1.月还款额,2.月利息)</returns>
        public static double[][] EverageCapital(int nDeadline, double fMoney, double yRate)
        {
            double[][] arr = new double[2][];//声明交错数组

            double[] fPrincipal = new double[nDeadline]; //本金
            double[] fSparePrin = new double[nDeadline];//剩余本金
            double[] fMonthRate = new double[nDeadline];//月利息
            double[] fMonthMoney = new double[nDeadline];//月还款额

            for (int i = 0; i < nDeadline; i++)
            {
                fPrincipal[i] = fMoney / nDeadline;
                if (i == 0)
                {
                    fSparePrin[i] = fMoney - fPrincipal[i];//剩余本金
                    fMonthRate[i] = Math.Round(fMoney * (yRate / 12), 2);//月利息
                }
                else
                {
                    fSparePrin[i] = fSparePrin[i - 1] - fPrincipal[i];//剩余本金
                    fMonthRate[i] = Math.Round(fSparePrin[i - 1] * (yRate / 12), 2);//月利息=上个月的剩余本金×利率
                }

                fMonthMoney[i] = Math.Round(fPrincipal[i] + fMonthRate[i], 2);
            }

            arr[0] = fMonthMoney;//月还款
            arr[1] = fMonthRate;//月利息

            return arr;
        }

        /// <summary>
        /// 方式：等本息还款
        /// </summary>
        /// <param name="nDeadline">期限</param>
        /// <param name="fMoney">总金额</param>
        /// <param name="dRate">年利率</param>
        /// <returns>交错数组:(1.月还款额,，2.利息)</returns>
        public static double[][] EverageCapitalPlusInterest(int nDeadline, double fMoney, double yRate)
        {
            double[][] arr = new double[2][];//声明交错数组

            int i;
            double tlnAcct = 0, tdepAcct = 0;

            double[] lnAcctbal = new double[nDeadline]; /*贷款余额*/
            double[] depAcctbal = new double[nDeadline]; /*总还款*/
            double[] payrateAcct = new double[nDeadline]; /*每月应还利息*/
            double[] payAcct = new double[nDeadline]; /*每月应还款*/
            double[] paybaseAcct = new double[nDeadline]; /*每月应还本金*/

            tlnAcct = fMoney;

            for (i = 0; i < nDeadline; i++)
            {
                paybaseAcct[i] = Math.Round((Math.Pow((1 + yRate / 12), i + 1) - Math.Pow((1 + yRate / 12), i)) / (Math.Pow((1 + yRate / 12), nDeadline) - 1) * fMoney, 2);
                payrateAcct[i] = Math.Round(tlnAcct * yRate / 12, 2);
                payAcct[i] = Math.Round(paybaseAcct[i] + payrateAcct[i], 2);
                lnAcctbal[i] = tlnAcct - paybaseAcct[i];
                depAcctbal[i] = tdepAcct + payAcct[i];
                tdepAcct = depAcctbal[i];
                tlnAcct = tlnAcct - paybaseAcct[i];
            }

            arr[0] = payAcct;//月还款
            //arr[1] = paybaseAcct;//月本金
            arr[1] = payrateAcct;//月利息

            return arr;
        }

        /// <summary>
        /// 方式：按月付息到期还本
        /// </summary>
        /// <param name="nDeadline">期限</param>
        /// <param name="fMoney">总金额</param>
        /// <param name="dRate">年利率</param>
        /// <returns>交错数组:(1.月还款额   2.利息)</returns>
        public static double[][] MonthInterestEndCapital(int nDeadline, double fMoney, double yRate)
        {
            double[][] arr = new double[2][];//声明交错数组
            double[] depAcctbal = new double[nDeadline]; /*总还款*/
            double[] payrateAcct = new double[nDeadline]; /*每月应还利息*/

            double interest = fMoney * yRate / 12;
            for (int i = 0; i < nDeadline; i++)
            {
                payrateAcct[i] = interest;
                depAcctbal[i] = interest;
                if (i == nDeadline)
                    depAcctbal[nDeadline - 1] = interest + fMoney;
            }

            arr[0] = depAcctbal;
            arr[1] = payrateAcct;
            return arr;
        }

        /// <summary>
        /// 方式：按月付息按季还本
        /// </summary>
        /// <param name="nDeadline">期限</param>
        /// <param name="fMoney">总金额</param>
        /// <param name="dRate">年利率</param>
        /// <returns>交错数组:(1.月还款额   2.利息)</returns>
        public static double[][] MonthInterestSeasonCapital(int nDeadline, double fMoney, double yRate)
        {
            double[][] arr = new double[2][];//声明交错数组
            double[] depAcctbal = new double[nDeadline]; /*总还款*/
            double[] payrateAcct = new double[nDeadline]; /*每月应还利息*/

            int curMonth;   //当前期数
            double curMoney;   //当前未还本金
            int seasonCount = nDeadline % 3 > 0 ? nDeadline / 3 + 1 : nDeadline / 3;    //分成几季
            double seasonCapital = fMoney / seasonCount;    //每季应还的本金
            double interest;    //每月应还利息
            for (int i = 0; i < seasonCount; i++)
            {
                curMoney = fMoney - seasonCapital * i;
                interest = curMoney * yRate / 12;

                for (int j = 1; j <= 3; j++)
                {
                    curMonth = i * 3 + j;
                    if (curMonth < nDeadline && curMonth % 3 == 0 && curMonth != 0)
                    {
                        depAcctbal[curMonth - 1] = interest + seasonCapital;
                        payrateAcct[curMonth - 1] = interest;
                    }
                    else if (curMonth < nDeadline)
                    {
                        depAcctbal[curMonth - 1] = interest;
                        payrateAcct[curMonth - 1] = interest;
                    }
                    else if (curMonth == nDeadline)
                    {
                        depAcctbal[curMonth - 1] = interest + seasonCapital;
                        payrateAcct[curMonth - 1] = interest;
                    }
                }
            }

            arr[0] = depAcctbal;
            arr[1] = payrateAcct;
            return arr;
        }
        #endregion


        /// <summary>
        /// 根据投资条件计算还款计划
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<Model.BillDetailModel> GetDetailsByBillInfo(ref Model.BillModel model)
        {
            List<Model.BillDetailModel> list = null;
            if (model.WayOfRepayment == E_WayOfRepayment.等额本息)
            {
                list = GetDetailsByEveragePrincipalAndInterest(model);
            }
            else if (model.WayOfRepayment == E_WayOfRepayment.等额本金)
            {
                list = GetDetailsByEveragePrincipal(model);
            }
            else if (model.WayOfRepayment == E_WayOfRepayment.月付息到期付本)
            {
                list = GetDetailsByMonthInterestEndPrincipal(model);
            }
            else if (model.WayOfRepayment == E_WayOfRepayment.月付息按季付本)
            {
                list = GetDetailsByMonthInterestSeasonCapital(model);
            }
            else if (model.WayOfRepayment == E_WayOfRepayment.一次性本息)
            {
                list = GetDetailsByToEnd(model);
            }

            if (list != null && list.Count > 0)
            {
                model.BillID = Guid.NewGuid().ToString();
                //model.Periods = string.Format("0/{0}", list[0].Periods.Split('/')[1]);
                model.ReceivablePeriod = list.Count;
                model.EndDay = list[list.Count - 1].ReceivableDay;
                model.YearRete = Math.Round(model.YearRete * 100, 2);

                for (int i = 0; i < list.Count; i++)
                {
                    model.ReceivablePrincipalAndInterest += list[i].ReceivablePrincipalAndInterest;
                    list[i].BillID = model.BillID;
                    list[i].BillDetailID = Guid.NewGuid().ToString();
                    list[i].UpdateTime = DateTime.Now;
                    list[i].CreateTime = DateTime.Now;
                }
                model.ReceivablePrincipalAndInterest = Math.Round(model.ReceivablePrincipalAndInterest, 2);
            }

            return list;
        }

        /// <summary>
        /// 等额本金还款
        /// </summary>
        /// <param name="billModel"></param>
        /// <returns></returns>
        public static List<Model.BillDetailModel> GetDetailsByEveragePrincipal(Model.BillModel billModel)
        {
            List<Model.BillDetailModel> details = new List<Model.BillDetailModel>();

            Model.BillDetailModel detail = null;
            double montyMoney = billModel.TotalMoney / billModel.Deadline;  //月还款本金
            double SurplusPayment = 0;
            DateTime beginDay = DateTime.Parse(billModel.BeginDay);
            for (int i = 0; i < billModel.Deadline; i++)
            {
                detail = new Model.BillDetailModel();
                if (i == 0)
                {
                    SurplusPayment = billModel.TotalMoney - montyMoney;//剩余本金
                    detail.ReceivableInterest = Math.Round(billModel.TotalMoney * (billModel.YearRete / 12), 2);//月利息
                }
                else
                {
                    detail.ReceivableInterest = Math.Round(SurplusPayment * (billModel.YearRete / 12), 2);//月利息=上个月的剩余本金×利率
                    SurplusPayment = SurplusPayment - montyMoney;//剩余本金
                }

                detail.ReceivablePrincipalAndInterest = Math.Round(montyMoney + detail.ReceivableInterest, 2);
                detail.ReceivableDay = beginDay.AddMonths(i + 1).ToString("yyyy-MM-dd");
                detail.Periods = string.Format("{0}/{1}", i + 1, billModel.Deadline);

                details.Add(detail);
            }
            return details;
        }

        /// <summary>
        /// 等额本息还款
        /// </summary>
        /// <param name="billModel"></param>
        /// <returns></returns>
        public static List<Model.BillDetailModel> GetDetailsByEveragePrincipalAndInterest(Model.BillModel billModel)
        {
            List<Model.BillDetailModel> details = new List<Model.BillDetailModel>();

            double tlnAcct = 0;
            tlnAcct = billModel.TotalMoney;

            Model.BillDetailModel detail = null;
            DateTime beginDay = DateTime.Parse(billModel.BeginDay);
            for (int i = 0; i < billModel.Deadline; i++)
            {
                detail = new Model.BillDetailModel();
                double paybaseAcct = (Math.Pow((1 + billModel.YearRete / 12), i + 1) - Math.Pow((1 + billModel.YearRete / 12), i)) / (Math.Pow((1 + billModel.YearRete / 12), billModel.Deadline) - 1) * billModel.TotalMoney;
                detail.ReceivableInterest = tlnAcct * billModel.YearRete / 12;   //利息
                detail.ReceivablePrincipalAndInterest = Math.Round(paybaseAcct + detail.ReceivableInterest, 2);  //还款总额
                detail.ReceivableInterest = Math.Round(detail.ReceivableInterest, 2);
                tlnAcct = tlnAcct - paybaseAcct;

                detail.ReceivableDay = beginDay.AddMonths(i + 1).ToString("yyyy-MM-dd");
                detail.Periods = string.Format("{0}/{1}", i + 1, billModel.Deadline);
                details.Add(detail);
            }

            return details;
        }

        /// <summary>
        /// 月还息到期还本
        /// </summary>
        /// <param name="billModel"></param>
        /// <returns></returns>
        public static List<Model.BillDetailModel> GetDetailsByMonthInterestEndPrincipal(Model.BillModel billModel)
        {
            List<Model.BillDetailModel> details = new List<Model.BillDetailModel>();

            double[] depAcctbal = new double[billModel.Deadline]; /*总还款*/
            //double[] payrateAcct = new double[bill.Deadline]; /*每月应还利息*/

            double interest = Math.Round((billModel.TotalMoney * billModel.YearRete / 12), 2);
            Model.BillDetailModel detail = null;
            DateTime beginDay = DateTime.Parse(billModel.BeginDay);
            for (int i = 0; i < billModel.Deadline; i++)
            {
                detail = new Model.BillDetailModel();
                detail.ReceivableInterest = interest;
                if ((i + 1) == billModel.Deadline)
                    detail.ReceivablePrincipalAndInterest = interest + billModel.TotalMoney;
                else
                    detail.ReceivablePrincipalAndInterest = interest;

                detail.ReceivableDay = beginDay.AddMonths(i + 1).ToString("yyyy-MM-dd");
                detail.Periods = string.Format("{0}/{1}", i + 1, billModel.Deadline);
                details.Add(detail);
            }

            return details;
        }

        /// <summary>
        /// 按月计息按季还款
        /// </summary>
        /// <param name="billModel"></param>
        /// <returns></returns>
        public static List<Model.BillDetailModel> GetDetailsByMonthInterestSeasonCapital(Model.BillModel billModel)
        {
            List<Model.BillDetailModel> details = new List<Model.BillDetailModel>();

            int curMonth;   //当前期数
            double curMoney;   //当前未还本金
            int seasonCount = billModel.Deadline % 3 > 0 ? billModel.Deadline / 3 + 1 : billModel.Deadline / 3;    //分成几季
            double seasonCapital = Math.Round(billModel.TotalMoney / seasonCount);    //每季应还的本金
            double interest;    //每月应还利息

            DateTime beginDay = DateTime.Parse(billModel.BeginDay);
            for (int i = 0; i < seasonCount; i++)
            {
                curMoney = billModel.TotalMoney - seasonCapital * i;
                interest = Math.Round((curMoney * billModel.YearRete / 12), 2);

                Model.BillDetailModel detail = null;
                for (int j = 1; j <= 3; j++)
                {
                    detail = new Model.BillDetailModel();
                    curMonth = i * 3 + j;
                    if (curMonth < billModel.Deadline && curMonth % 3 == 0 && curMonth != 0)
                    {
                        detail.ReceivablePrincipalAndInterest = interest + seasonCapital;
                        detail.ReceivableInterest = interest;
                    }
                    else if (curMonth < billModel.Deadline)
                    {
                        detail.ReceivablePrincipalAndInterest = interest;
                        detail.ReceivableInterest = interest;
                    }
                    else if (curMonth == billModel.Deadline)
                    {
                        detail.ReceivablePrincipalAndInterest = interest + seasonCapital;
                        detail.ReceivableInterest = interest;
                    }
                    detail.ReceivableDay = beginDay.AddMonths((i * 3) + j).ToString("yyyy-MM-dd");
                    detail.Periods = string.Format("{0}/{1}", (i * 3) + j, billModel.Deadline);
                    details.Add(detail);
                }
            }


            return details;
        }

        /// <summary>
        /// 按日计息按月还息到期还本
        /// </summary>
        /// <param name="bill"></param>
        /// <returns></returns>
        public static List<Model.BillDetailModel> GetDetailsByDayMonthInterestSeasonCapital(Model.BillModel bill)
        {
            List<Model.BillDetailModel> details = new List<Model.BillDetailModel>();


            return details;
        }

        /// <summary>
        /// 按天计息到期一次性还本息
        /// </summary>
        /// <param name="billModel"></param>
        /// <returns></returns>
        public static List<Model.BillDetailModel> GetDetailsByToEnd(Model.BillModel billModel)
        {
            List<Model.BillDetailModel> details = new List<Model.BillDetailModel>();
            Model.BillDetailModel detail = new Model.BillDetailModel();
            double interest = 0;
            if (billModel.DeadlineType == 1)
            {
                //按天总利息
                interest = Math.Round(billModel.YearRete / 365 * billModel.Deadline * billModel.TotalMoney, 2);
            }
            else
            {
                //按月总利息
                interest = Math.Round(billModel.YearRete / 12 * billModel.Deadline * billModel.TotalMoney, 2);    //总利息
            }

            detail.ReceivableInterest = interest;
            detail.ReceivablePrincipalAndInterest = billModel.TotalMoney + interest;
            detail.ReceivableDay = billModel.EndDay;
            detail.Periods = "1/1";
            details.Add(detail);

            return details;
        }
    }
}
