using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Data.Common;
using System.Windows.Forms;



namespace WindowsFormsApplication1
{
    public abstract class SQLiteHelper
    {
        public static string ConnSqlLiteDbPath = Application.StartupPath + "\\data.dat";
        public static string ConnString
        {
            get
            {
                if (!System.IO.File.Exists(ConnSqlLiteDbPath))
                { CheckDataFile(ConnSqlLiteDbPath); }
                return string.Format(@"Data Source={0}", ConnSqlLiteDbPath);
            }
        }

        // 取datatable
        public static DataTable GetDataTable(string sSQL)
        {
            string sError;
            DataTable dt = null;
            sError = string.Empty;

            try
            {
                SQLiteConnection conn = new SQLiteConnection(ConnString);
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandText = sSQL;
                cmd.Connection = conn;
                SQLiteDataAdapter dao = new SQLiteDataAdapter(cmd);
                dt = new DataTable();
                dao.Fill(dt);
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }

            return dt;
        }

        // 取某个单一的元素
        public static object GetSingle(string sSQL)
        {
            DataTable dt = GetDataTable(sSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0][0];
            }

            return null;
        }

        // 取最大的ID
        public static Int32 GetMaxID(string sKeyField, string sTableName)
        {
            DataTable dt = GetDataTable("select ifnull(max([" + sKeyField + "]),0) asMaxID from [" + sTableName + "]");
            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0].ToString());
            }

            return 0;
        }

        // 执行 insert,update,delete 动作，也可以使用事务
        //public static bool UpdateData(out string sError, string sSQL, bool bUseTransaction = false)
        public static bool UpdateData(string sSQL, bool bUseTransaction = false)
        {
            int iResult = 0;
            //sError = string.Empty;

            if (!bUseTransaction)
            {
                try
                {
                    SQLiteConnection conn = new SQLiteConnection(ConnString);
                    conn.Open();
                    SQLiteCommand comm = new SQLiteCommand(conn);
                    comm.CommandText = sSQL;
                    iResult = comm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    //sError = ex.Message;
                    iResult = -1;
                }
            }
            else // 使用事务
            {
                DbTransaction trans = null;
                try
                {
                    SQLiteConnection conn = new SQLiteConnection(ConnString);
                    conn.Open();
                    trans = conn.BeginTransaction();
                    string[] sqls = sSQL.Split('|');
                    SQLiteCommand comm = new SQLiteCommand(conn);
                    for (int i = 0; i < sqls.Length; i++)
                    {
                        if (string.IsNullOrEmpty(sqls[i]))
                            continue;
                        comm.CommandText = sqls[i];
                        iResult = comm.ExecuteNonQuery();
                    }
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    //sError = ex.Message;
                    iResult = -1;
                    if (trans != null)
                        trans.Rollback();
                }
            }

            return iResult > 0;
        }

        public static void CheckDataFile(string datasource)
        {
            //string datasource = Application.StartupPath + "\\data.db";
            System.Data.SQLite.SQLiteConnection.CreateFile(datasource);
            //连接数据库
            System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection();
            System.Data.SQLite.SQLiteConnectionStringBuilder connstr = new System.Data.SQLite.SQLiteConnectionStringBuilder();
            connstr.DataSource = datasource;
            //connstr.Password = "admin";//设置密码，SQLite ADO.NET实现了数据库密码保护
            conn.ConnectionString = connstr.ToString();
            conn.Open();
            //创建表
            System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
            string sql = "CREATE TABLE billInfo (BillID varchar(50) PRIMARY KEY,SiteName varchar(50),SiteUserName varchar(50),TotalMoney decimal(5,2),YearRete decimal(5,2),Deadline interger ,DeadlineType interger,ReceivedPeriod interger,ReceivablePeriod interger,ReceivablePrincipalAndInterest decimal(5,2),ReceivedPrincipalAndInterest decimal(5,2),WayOfRepayment interger,Reward decimal(5,2),BeginDay varchar(20),EndDay varchar(20),YuQiCount interger,Deleted interger,Flag interger,Remark varchar(200),UpdateTime datetime,CreateTime datetime)";
            cmd.CommandText = sql;
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();

            sql = "Create Table billdetail(BillDetailID varchar(50) PRIMARY KEY,BillID varchar(50),Periods varchar(50),ReceivableDay varchar(20),ReceivedDay varchar(20),ReceivablePrincipalAndInterest decimal(5,2),ReceivableInterest decimal(5,2),ReceivedPrincipalAndInterest decimal(5,2),IsYuQi interger ,Deleted interger,Flag interger,UpdateTime datetime,CreateTime datetime)";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }

}

