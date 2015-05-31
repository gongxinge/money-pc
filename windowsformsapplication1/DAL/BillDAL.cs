using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace WindowsFormsApplication1.DAL
{
    public static class BillDAL
    {
        public static List<Model.BillModel> GetBillList(string whereStr)
        {
            List<Model.BillModel> list = new List<Model.BillModel>();
            string sql = "select * from billinfo";
            if (!string.IsNullOrEmpty(whereStr))
                sql = string.Format("{0} where {1}", sql, whereStr);

            //string sql = "select * from billinfo where deleted=0 order by flag,endday";
            DataTable dt = SQLiteHelper.GetDataTable(sql);
            Model.BillModel model = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                model = new Model.BillModel();
                #region
                try
                {
                    model.BeginDay = dt.Rows[i]["beginday"].ToString();
                    model.BillID = dt.Rows[i]["BillID"].ToString();
                    model.CreateTime = (DateTime)dt.Rows[i]["CreateTime"];
                    model.Deadline = int.Parse(dt.Rows[i]["Deadline"].ToString());
                    model.DeadlineType = int.Parse(dt.Rows[i]["DeadlineType"].ToString());
                    model.Deleted = int.Parse(dt.Rows[i]["Deleted"].ToString());
                    model.EndDay = dt.Rows[i]["EndDay"].ToString();
                    model.Flag = int.Parse(dt.Rows[i]["Flag"].ToString());
                    model.ReceivablePeriod = int.Parse(dt.Rows[i]["ReceivablePeriod"].ToString());
                    model.ReceivedPeriod = int.Parse(dt.Rows[i]["ReceivedPeriod"].ToString());
                    model.ReceivablePrincipalAndInterest = double.Parse(dt.Rows[i]["ReceivablePrincipalAndInterest"].ToString());
                    model.ReceivedPrincipalAndInterest = double.Parse(dt.Rows[i]["ReceivedPrincipalAndInterest"].ToString());
                    model.Remark = dt.Rows[i]["Remark"].ToString();
                    model.Reward = double.Parse(dt.Rows[i]["Reward"].ToString());
                    model.SiteName = dt.Rows[i]["SiteName"].ToString();
                    model.SiteUserName = dt.Rows[i]["SiteUserName"].ToString();
                    model.TotalMoney = double.Parse(dt.Rows[i]["TotalMoney"].ToString());
                    model.UpdateTime = (DateTime)dt.Rows[i]["UpdateTime"];
                    model.WayOfRepayment = (E_WayOfRepayment)(int.Parse(dt.Rows[i]["WayOfRepayment"].ToString()));
                    model.YearRete = double.Parse(dt.Rows[i]["YearRete"].ToString());
                    model.YuQiCount = int.Parse(dt.Rows[i]["YuQiCount"].ToString());
                }
                catch (Exception ex)
                {
                    throw;
                }
                #endregion
                list.Add(model);
            }
            return list;
        }
    }
}
