using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.Common;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int qixian = int.Parse(textBox1.Text.Trim());
            double totalmoney = double.Parse(txtjine.Text.Trim());
            double pref = double.Parse(textBox2.Text.Trim());
            double[][] infos = WayOfRepayment.EverageCapital(qixian, totalmoney, pref);

            StringBuilder builder = new StringBuilder();
            builder.Append("等额本金\r\n");
            builder.Append("期数  回款金额    利息\r\n");
            for (int i = 0; i < qixian; i++)
            {
                builder.Append(string.Format("{0}      {1}       {2}\r\n", i + 1, infos[0][i], infos[1][i]));
            }
            this.richTextBox1.Text = builder.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int qixian = int.Parse(textBox1.Text.Trim());
            double totalmoney = double.Parse(txtjine.Text.Trim());
            double pref = double.Parse(textBox2.Text.Trim());
            double[][] infos = WayOfRepayment.EverageCapitalPlusInterest(qixian, totalmoney, pref);

            StringBuilder builder = new StringBuilder();
            builder.Append("等额本息\r\n");
            builder.Append("期数  回款金额    利息\r\n");
            for (int i = 0; i < qixian; i++)
            {
                builder.Append(string.Format("{0}      {1}       {2}\r\n", i + 1, infos[0][i], infos[1][i]));
            }
            this.richTextBox1.Text = builder.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int qixian = int.Parse(textBox1.Text.Trim());
            double totalmoney = double.Parse(txtjine.Text.Trim());
            double pref = double.Parse(textBox2.Text.Trim());
            double[][] infos = WayOfRepayment.MonthInterestEndCapital(qixian, totalmoney, pref);

            StringBuilder builder = new StringBuilder();
            builder.Append("按月还息到期还本\r\n");
            builder.Append("期数  回款金额    利息\r\n");
            for (int i = 0; i < qixian; i++)
            {
                builder.Append(string.Format("{0}      {1}       {2}\r\n", i + 1, infos[0][i], infos[1][i]));
            }
            this.richTextBox1.Text = builder.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int qixian = int.Parse(textBox1.Text.Trim());
            double totalmoney = double.Parse(txtjine.Text.Trim());
            double pref = double.Parse(textBox2.Text.Trim());
            double[][] infos = WayOfRepayment.MonthInterestSeasonCapital(qixian, totalmoney, pref);

            StringBuilder builder = new StringBuilder();
            builder.Append("按月还息按季还本\r\n");
            builder.Append("期数  回款金额    利息\r\n");
            for (int i = 0; i < qixian; i++)
            {
                builder.Append(string.Format("{0}      {1}       {2}\r\n", i + 1, infos[0][i], infos[1][i]));
            }
            this.richTextBox1.Text = builder.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //string datasource = Application.StartupPath + "\\data.db";
            //System.Data.SQLite.SQLiteConnection.CreateFile(datasource);
            ////连接数据库
            //System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection();
            //System.Data.SQLite.SQLiteConnectionStringBuilder connstr = new System.Data.SQLite.SQLiteConnectionStringBuilder();
            //connstr.DataSource = datasource;
            ////connstr.Password = "admin";//设置密码，SQLite ADO.NET实现了数据库密码保护
            //conn.ConnectionString = connstr.ToString();
            //conn.Open();
            ////创建表
            //System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
            //string sql = "CREATE TABLE bill (billid varchar(20) PRIMARY KEY,sitename varchar(50),totalmoney decimal(10,2),yearrete decimal(5,2),deadline  varchar(50),deadlinetype interger ,received decimal(10,2),notreceive decimal(10,2),WayOfRepayment interger,beginday varchar(20),endday varchar(20),updatetime time,createtime time)";
            //cmd.CommandText = sql;
            //cmd.Connection = conn;
            //cmd.ExecuteNonQuery();

            //sql = "create table billdetail(billdetailid varchar(20) PRIMARY KEY,billid varchar(20),enday varchar(20),receiveInterest decimal(10,2),receiveMoney decimal(10,2),SurplusPayment decimal(10,2),flag interger,updatetime time,createtime time)";
            //cmd.CommandText = sql;
            //cmd.ExecuteNonQuery();
            //conn.Open();





            ////插入数据
            //sql = "INSERT INTO test VALUES(’dotnetthink’,'123’)";
            //cmd.CommandText = sql;
            //cmd.Connection = conn;
            //cmd.ExecuteNonQuery();
            ////取出数据
            //sql = "SELECT * FROM test";
            //cmd.CommandText = sql;
            //System.Data.SQLite.SQLiteDataReader reader = cmd.ExecuteReader();
            //StringBuilder sb = new StringBuilder();
            //while (reader.Read())
            //{
            //    sb.Append("username:").Append(reader.GetString(0)).Append("\n")
            //    .Append("password:").Append(reader.GetString(1));
            //}
            //MessageBox.Show(sb.ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SQLiteHelper.ConnSqlLiteDbPath = Application.StartupPath + "\\data.db";
            string sql = "insert into bill (billid,sitename ,totalmoney ,yearrete ,deadline  ,deadlinetype,received ,notreceive ,WayOfRepayment ,beginday ,endday ,updatetime,createtime) values('{0}','{1}' ,{2} ,{3},{4},{5},{6} ,{7},{8} ,'{9}','{10}','{11}','{11}')";
            sql = string.Format(sql, Guid.NewGuid().ToString(), "红岭创投", "10000", "0.12", "12", "2", 0, 0, 1, "2014-01-01", "2015-01-01", DateTime.Now.ToString("yyyy-MM-dd HH:ss:mm"));

            SQLiteHelper.UpdateData(sql);

        }
    }
}
