using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class AppInfo
    {
        private static AppInfo appInfo;

        public static AppInfo Instance
        {
            get
            {
                if (appInfo == null)
                {
                    appInfo = new AppInfo();
                }
                return appInfo;
            }
        }

        public bool IsNetworking { get; set; }
        public bool IsChanged { get; set; }
    }
}
