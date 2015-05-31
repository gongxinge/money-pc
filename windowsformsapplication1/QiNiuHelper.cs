using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Qiniu.IO;
using Qiniu.RS;
using Qiniu.RPC;
using System.Threading;

namespace WindowsFormsApplication1
{
    public class QiNiuHelper
    {

        private static string bucket = "p2pdata";
        private static string key = "p2p/data.dat";
        private static string domain = "7xirah.com1.z0.glb.clouddn.com";
        private static string fileName = System.IO.Path.Combine(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "data.dat");

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="bucket"></param>
        /// <param name="key"></param>
        /// <param name="fname"></param>
        public static PutRet PutFile()
        {
            var policy = new PutPolicy(bucket, 3600);
            string upToken = policy.Token();
            PutExtra extra = new PutExtra();
            IOClient client = new IOClient();
            PutRet ret = client.PutFile(upToken, key, fileName, extra);

            if (ret.OK)
                System.Configuration.ConfigurationManager.AppSettings["HashCode"] = ret.Hash;
            return ret;
        }

        /// <summary>
        /// 获取下载连接
        /// </summary>
        /// <returns></returns>
        public static string MakeGetToken()
        {
            string baseUrl = GetPolicy.MakeBaseUrl(domain, key);
            return GetPolicy.MakeRequest(baseUrl);
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="downLoadUrl">文件的url路径</param>
        /// <param name="saveFullName">需要保存在本地的路径(包含文件名)</param>
        /// <returns></returns>
        public static bool DownloadFile()
        {
            if (Stat().Hash == System.Configuration.ConfigurationManager.AppSettings["HashCode"])
                return true;


            string downLoadUrl = MakeGetToken();
            bool flagDown = false;
            System.Net.HttpWebRequest httpWebRequest = null;
            try
            {
                //根据url获取远程文件流
                httpWebRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(downLoadUrl);

                System.Net.HttpWebResponse httpWebResponse = (System.Net.HttpWebResponse)httpWebRequest.GetResponse();
                System.IO.Stream sr = httpWebResponse.GetResponseStream();

                //创建本地文件写入流
                System.IO.Stream sw = new System.IO.FileStream(fileName, System.IO.FileMode.Create);

                long totalDownloadedByte = 0;
                byte[] by = new byte[1024];
                int osize = sr.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    totalDownloadedByte = osize + totalDownloadedByte;
                    sw.Write(by, 0, osize);
                    osize = sr.Read(by, 0, (int)by.Length);
                }
                System.Threading.Thread.Sleep(100);
                flagDown = true;
                sw.Close();
                sr.Close();
            }
            catch (System.Exception ex)
            {
                if (httpWebRequest != null)
                    httpWebRequest.Abort();
            }
            return flagDown;
        }


        /// <summary>
        /// 查看单个文件属性信息
        /// </summary>
        public static Entry Stat(string fileKey = "")
        {
            fileKey = string.IsNullOrEmpty(fileKey) ? key : fileKey;
            RSClient client = new RSClient();
            Entry entry = client.Stat(new EntryPath(bucket, fileKey));

            return entry;
        }

        public static void CheckMonthFile()
        {
            string monthfile = DateTime.Now.ToString("yyyy-MM");
            if (monthfile != System.Configuration.ConfigurationManager.AppSettings["LastMonth"])
            {

                try
                {
                    monthfile = string.Format("p2p/bak/{0}.dat", monthfile);

                    if (!Stat(monthfile).OK)
                    {
                        Copy(monthfile);
                    }
                    System.Configuration.ConfigurationManager.AppSettings["LastMonth"] = monthfile;
                }
                catch
                { }
            }

        }

        /// <summary>
        /// 复制单个文件
        /// </summary>
        /// <param name="keySrc">需要复制的文件key</param>
        /// <param name="keyDest">标文件key</param>
        public static CallRet Copy(string keyDest)
        {
            RSClient client = new RSClient();
            CallRet ret = client.Copy(new EntryPathPair(bucket, key, bucket, keyDest));
            return ret;
        }
    }
}
