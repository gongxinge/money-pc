using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace WindowsFormsApplication1.DAL
{
    public static class BillDetailDAL
    {
        public static List<Model.BillDetailModel> GetBillList(string whereStr = "")
        {
            List<Model.BillDetailModel> list = new List<Model.BillDetailModel>();

            string sql = "select * from billdetail";
            if (!string.IsNullOrEmpty(whereStr))
                sql = string.Format("{0} where {1}", sql, whereStr);
            DataTable dt = SQLiteHelper.GetDataTable(sql);
            Model.BillDetailModel model = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                model = DataBind(dt.Rows[i]);
                list.Add(model);
            }

            return list;
        }

        public static bool ShouKuan(Model.BillDetailModel detail)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update billinfo set");
            detail.ReceivedPeriod = detail.ReceivedPeriod + 1;  //已收期数加一

            if (detail.ReceivedPeriod > detail.ReceivablePeriod)
            {
                detail.ReceivedPeriod = detail.ReceivablePeriod;
            }
            builder.Append(" ReceivedPeriod=" + detail.ReceivedPeriod);

            if (detail.ReceivedPeriod == detail.ReceivablePeriod)
            {
                //最后一期收款
                builder.Append(" ,Flag=1");
            }

            builder.Append(string.Format(" where billid='{0}'", detail.BillID));

            builder.Append(string.Format(" | update billdetail set flag=1 where billdetailid='{0}'",
                detail.BillDetailID));

            bool flag = SQLiteHelper.UpdateData(builder.ToString(), true);

            return flag;
        }

        public static bool QuXiaoShoukuan(Model.BillDetailModel detail)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update billinfo set");
            detail.ReceivedPeriod = detail.ReceivedPeriod - 1;  //已收期数减一

            if (detail.ReceivedPeriod < 0)
                detail.ReceivedPeriod = 0;
            builder.Append(" ReceivedPeriod=" + detail.ReceivedPeriod);

            if (detail.ReceivedPeriod < detail.ReceivablePeriod)
            {
                //最后一期收款
                builder.Append(" ,Flag=0");
            }

            builder.Append(string.Format(" where billid='{0}'", detail.BillID));
            builder.Append(string.Format(" | update billdetail set flag=0 where billdetailid='{0}'",
                detail.BillDetailID));

            bool flag = SQLiteHelper.UpdateData(builder.ToString(), true);

            return flag;
        }

        private static Model.BillDetailModel DataBind(DataRow dr)
        {
            Model.BillDetailModel model = new Model.BillDetailModel();
            try
            {
                model.BillDetailID = dr["BillDetailID"].ToString();
                model.BillID = dr["BillID"].ToString();
                model.CreateTime = (DateTime)dr["CreateTime"];
                model.Deleted = int.Parse(dr["Deleted"].ToString());
                model.Flag = int.Parse(dr["Flag"].ToString());
                model.IsYuQi = int.Parse(dr["IsYuQi"].ToString());
                model.Periods = dr["Periods"].ToString();
                model.ReceivableDay = dr["ReceivableDay"].ToString();
                model.ReceivableInterest = double.Parse(dr["ReceivableInterest"].ToString());
                model.ReceivablePrincipalAndInterest = double.Parse(dr["ReceivablePrincipalAndInterest"].ToString());
                //model.ReceivedDay = dr["ReceivedDay"].ToString();
                model.UpdateTime = (DateTime)dr["UpdateTime"];
                model.ReceivedPrincipalAndInterest = double.Parse(dr["ReceivedPrincipalAndInterest"].ToString());
            }
            catch
            {
                throw;
            }

            return model;
        }

        /// <summary>
        /// 获取待办事项列表
        /// </summary>
        /// <param name="whereStr"></param>
        /// <returns></returns>
        public static List<Model.BillDetailModel> GetBacklog(string whereStr = "")
        {
            List<Model.BillDetailModel> list = new List<Model.BillDetailModel>();

            string sql = "select b.sitename,b.[SiteUserName],b.[TotalMoney],b.ReceivablePeriod,b.ReceivedPeriod,b.Remark,d.* from billdetail d left join billinfo b on d.[BillID]= b.billid";
            if (!string.IsNullOrEmpty(whereStr))
                sql = string.Format("{0} where {1}", sql, whereStr);
            DataTable dt = SQLiteHelper.GetDataTable(sql);
            if (dt != null)
            {
                Model.BillDetailModel model = null;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    model = DataBind(dt.Rows[i]);
                    model.SiteName = dt.Rows[i]["sitename"].ToString();
                    model.SiteUserName = dt.Rows[i]["SiteUserName"].ToString();
                    model.TotalMoney = double.Parse(dt.Rows[i]["TotalMoney"].ToString());
                    model.Remark = dt.Rows[i]["Remark"].ToString();
                    model.ReceivablePeriod = int.Parse(dt.Rows[i]["ReceivablePeriod"].ToString());
                    model.ReceivedPeriod = int.Parse(dt.Rows[i]["ReceivedPeriod"].ToString());
                    list.Add(model);
                }
            }
            return list;
        }
    }
}
