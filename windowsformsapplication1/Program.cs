using System;
using System.Collections.Generic;

using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Qiniu.Conf.Config.ACCESS_KEY = "qo57JOuXycvPVv8TaWRd6x9Bh04DWIrK62v6yrDO";
            Qiniu.Conf.Config.SECRET_KEY = "tE_oynF4B42gnR7JBQZNPdizj17Ylde9m-WICGkI";
            //Application.Run(new Frmtest2());
            Application.Run(new FrmMain());
        }
    }
}
