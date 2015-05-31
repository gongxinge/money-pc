using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FrmReciveMoney : Form
    {
        public double receivable = 0;
        public string receiveDay = string.Empty;
        public FrmReciveMoney(string day, double r)
        {
            InitializeComponent();
            receiveDay = day;
            receivable = r;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text.Trim(), out receivable))
            {
                this.receiveDay = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show("请输入有效的实际收到的本息金额！");
                this.textBox1.Text = string.Empty;
            }
        }

        private void FrmReciveMoney_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = receivable.ToString();
            this.dateTimePicker1.Value = DateTime.Parse(receiveDay);
        }
    }
}
