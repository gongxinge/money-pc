using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Qiniu.RS;
using Qiniu.IO;

namespace WindowsFormsApplication1
{
    public partial class Frmtest2 : Form
    {
        public Frmtest2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PutRet ret = QiNiuHelper.PutFile();
            if (ret.OK)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(ret.Exception.Message);
            }
        }

        /// <summary>
        /// 上传文件测试
        /// </summary>
        /// <param name="bucket"></param>
        /// <param name="key"></param>
        /// <param name="fname"></param>
        public static void PutFile(string bucket, string key, string fname)
        {
            var policy = new PutPolicy(bucket, 3600);
            string upToken = policy.Token();
            PutExtra extra = new PutExtra();
            IOClient client = new IOClient();
            PutRet putret = client.PutFile(upToken, key, fname, extra);

            string str = putret.OK.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QiNiuHelper.DownloadFile();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (QiNiuHelper.Stat().OK)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("faild");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            QiNiuHelper.CheckMonthFile();
        } 





    }

    //// 摘要:
    ////    对bucket、key进行封装
    //public class EntryPath
    //{
    //    public EntryPath(string bucket, string key);

    //    public string Base64EncodedURI { get; }
    //    //
    //    // 摘要:
    //    //     七牛云存储空间名
    //    public string Bucket { get; }
    //    //
    //    // 摘要:
    //    //     文件key
    //    public string Key { get; }
    //    //
    //    // 摘要:
    //    //     bucket+ ":"+ key
    //    public string URI { get; }
    //}
    //// 摘要:
    ////     二元操作路径
    //public class EntryPathPair
    //{
    //    // 摘要:
    //    //     二元操作路径构造函数
    //    // 参数:
    //    //   bucket:
    //    //     源空间名称，目标空间名称
    //    //   keySrc:
    //    //     源文件key
    //    //   keyDest:
    //    //     目标文件key
    //    public EntryPathPair(string bucket, string keySrc, string keyDest);
    //    //
    //    // 摘要:
    //    //     二元操作路径构造函数
    //    // 参数:
    //    //   bucketSrc:
    //    //     源空间名称
    //    //   keySrc:
    //    //     源文件key
    //    //   bucketDest:
    //    //     目标空间名称
    //    //   keyDest:
    //    //     目标文件key
    //    public EntryPathPair(string bucketSrc, string keySrc, string bucketDest, string keyDest);

    //    // 摘要:
    //    //     bucketDest+":"+keyDest
    //    public string URIDest { get; }
    //    //
    //    // 摘要:
    //    //     bucketSrc+":"+keySrc
    //    public string URISrc { get; }
    //}
}
