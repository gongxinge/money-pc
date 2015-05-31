using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FrmTest : Form
    {
        public FrmTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate(this.richTextBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string jsfile = System.IO.Path.Combine(Environment.CurrentDirectory, "test.js");
            //HtmlElement element = webBrowser1.Document.CreateElement("script");
            //element.Id = "newjs";
            //element.SetAttribute("type", "text/javascript");
            //element.SetAttribute("src", jsfile);
            //webBrowser1.Document.Body.AppendChild(element);
            //webBrowser1.Document.InvokeScript("test");

            //HtmlElement script = webBrowser1.Document.CreateElement("script");
            //script.SetAttribute("type", "text/javascript");
            //script.SetAttribute("text", "function _func(){location.href='/portal/app/exchangeFlow.jsp?type=shakeTime'}");
            //HtmlElement head = webBrowser1.Document.Body.AppendChild(script);
            //webBrowser1.Document.InvokeScript("_func");

            //webBrowser1.Document.InvokeScript("shake.again()");

            webBrowser1.Refresh();
        }

        private void FrmTest_Load(object sender, EventArgs e)
        {
            //禁止显示拖放到webBrowser上的文件
            this.webBrowser1.AllowWebBrowserDrop = false;
            //禁止使用IE浏览器快捷键
            this.webBrowser1.WebBrowserShortcutsEnabled = false;
            //禁止显示右键菜单
            //this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            //禁止显示脚本错误
            this.webBrowser1.ScriptErrorsSuppressed = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate("http://shake.sd.chinamobile.com/shake?method=draw&r=0.27736783218154915");
        }

        bool Shaking = false;
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (this.webBrowser1.ReadyState == WebBrowserReadyState.Complete)
            {
                if (Shaking)
                {
                    if (!System.Text.RegularExpressions.Regex.IsMatch(webBrowser1.DocumentText, "再试试吧"))
                    {
                        System.Threading.Thread.Sleep(1000);
                        //this.webBrowser1.Navigate("http://shake.sd.chinamobile.com/shake?method=draw&r=0.27736783218154915");
                    }
                    else
                    {
                        MessageBox.Show("摇奖完毕！");
                    }
                }
                else
                {
                    this.webBrowser1.Navigate("http://shake.sd.chinamobile.com/shake?method=draw&r=0.27736783218154915");
                    Shaking = true;
                }
            }
        }
    }
}
