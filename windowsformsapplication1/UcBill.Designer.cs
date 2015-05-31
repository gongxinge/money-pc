namespace WindowsFormsApplication1
{
    partial class UcBill
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSiteName = new System.Windows.Forms.Label();
            this.lblTotalMoney = new System.Windows.Forms.Label();
            this.lblWay = new System.Windows.Forms.Label();
            this.lblRate = new System.Windows.Forms.Label();
            this.lblReceivable = new System.Windows.Forms.Label();
            this.lblBeginDate = new System.Windows.Forms.Label();
            this.lblMonths = new System.Windows.Forms.Label();
            this.lblPeriods = new System.Windows.Forms.Label();
            this.pnlBillInfo = new System.Windows.Forms.Panel();
            this.lblSiteUserName = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblleft = new System.Windows.Forms.Label();
            this.lblremark = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNum = new System.Windows.Forms.Label();
            this.pnlBillInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSiteName
            // 
            this.lblSiteName.AutoSize = true;
            this.lblSiteName.Location = new System.Drawing.Point(142, 11);
            this.lblSiteName.Name = "lblSiteName";
            this.lblSiteName.Size = new System.Drawing.Size(53, 12);
            this.lblSiteName.TabIndex = 0;
            this.lblSiteName.Text = "红岭创投";
            // 
            // lblTotalMoney
            // 
            this.lblTotalMoney.AutoSize = true;
            this.lblTotalMoney.Location = new System.Drawing.Point(287, 11);
            this.lblTotalMoney.Name = "lblTotalMoney";
            this.lblTotalMoney.Size = new System.Drawing.Size(53, 12);
            this.lblTotalMoney.TabIndex = 1;
            this.lblTotalMoney.Text = "18000000";
            // 
            // lblWay
            // 
            this.lblWay.AutoSize = true;
            this.lblWay.Location = new System.Drawing.Point(495, 15);
            this.lblWay.Name = "lblWay";
            this.lblWay.Size = new System.Drawing.Size(53, 12);
            this.lblWay.TabIndex = 2;
            this.lblWay.Text = "等额本息";
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Location = new System.Drawing.Point(565, 11);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(23, 12);
            this.lblRate.TabIndex = 3;
            this.lblRate.Text = "18%";
            // 
            // lblReceivable
            // 
            this.lblReceivable.AutoSize = true;
            this.lblReceivable.Location = new System.Drawing.Point(141, 15);
            this.lblReceivable.Name = "lblReceivable";
            this.lblReceivable.Size = new System.Drawing.Size(35, 12);
            this.lblReceivable.TabIndex = 4;
            this.lblReceivable.Text = "28000";
            // 
            // lblBeginDate
            // 
            this.lblBeginDate.AutoSize = true;
            this.lblBeginDate.Location = new System.Drawing.Point(423, 11);
            this.lblBeginDate.Name = "lblBeginDate";
            this.lblBeginDate.Size = new System.Drawing.Size(65, 12);
            this.lblBeginDate.TabIndex = 7;
            this.lblBeginDate.Text = "2010-10-10";
            // 
            // lblMonths
            // 
            this.lblMonths.AutoSize = true;
            this.lblMonths.Location = new System.Drawing.Point(243, 15);
            this.lblMonths.Name = "lblMonths";
            this.lblMonths.Size = new System.Drawing.Size(41, 12);
            this.lblMonths.TabIndex = 8;
            this.lblMonths.Text = "18个月";
            // 
            // lblPeriods
            // 
            this.lblPeriods.AutoSize = true;
            this.lblPeriods.Location = new System.Drawing.Point(375, 15);
            this.lblPeriods.Name = "lblPeriods";
            this.lblPeriods.Size = new System.Drawing.Size(29, 12);
            this.lblPeriods.TabIndex = 9;
            this.lblPeriods.Text = "1/12";
            // 
            // pnlBillInfo
            // 
            this.pnlBillInfo.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlBillInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBillInfo.Controls.Add(this.lblNum);
            this.pnlBillInfo.Controls.Add(this.lblSiteUserName);
            this.pnlBillInfo.Controls.Add(this.label12);
            this.pnlBillInfo.Controls.Add(this.label11);
            this.pnlBillInfo.Controls.Add(this.lblleft);
            this.pnlBillInfo.Controls.Add(this.label10);
            this.pnlBillInfo.Controls.Add(this.label9);
            this.pnlBillInfo.Controls.Add(this.lblRate);
            this.pnlBillInfo.Controls.Add(this.lblBeginDate);
            this.pnlBillInfo.Controls.Add(this.lblSiteName);
            this.pnlBillInfo.Controls.Add(this.lblTotalMoney);
            this.pnlBillInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBillInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlBillInfo.Name = "pnlBillInfo";
            this.pnlBillInfo.Size = new System.Drawing.Size(862, 35);
            this.pnlBillInfo.TabIndex = 10;
            this.pnlBillInfo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pnlBillInfo_MouseDoubleClick);
            // 
            // lblSiteUserName
            // 
            this.lblSiteUserName.AutoSize = true;
            this.lblSiteUserName.Location = new System.Drawing.Point(643, 11);
            this.lblSiteUserName.Name = "lblSiteUserName";
            this.lblSiteUserName.Size = new System.Drawing.Size(119, 12);
            this.lblSiteUserName.TabIndex = 14;
            this.lblSiteUserName.Text = "平台用户名:一边玩去";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(514, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 12);
            this.label12.TabIndex = 12;
            this.label12.Text = "年利率:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(364, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 11;
            this.label11.Text = "借出日期:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(225, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 10;
            this.label10.Text = "借出金额:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(99, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "平台：";
            // 
            // lblleft
            // 
            this.lblleft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblleft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblleft.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblleft.Font = new System.Drawing.Font("宋体", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblleft.Location = new System.Drawing.Point(0, 0);
            this.lblleft.Name = "lblleft";
            this.lblleft.Size = new System.Drawing.Size(48, 33);
            this.lblleft.TabIndex = 8;
            this.lblleft.Text = "+";
            this.lblleft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblleft.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblremark
            // 
            this.lblremark.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblremark.Location = new System.Drawing.Point(625, 35);
            this.lblremark.Name = "lblremark";
            this.lblremark.Size = new System.Drawing.Size(237, 41);
            this.lblremark.TabIndex = 11;
            this.lblremark.Text = "备注:送了100000";
            this.lblremark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblPeriods);
            this.panel1.Controls.Add(this.lblReceivable);
            this.panel1.Controls.Add(this.lblWay);
            this.panel1.Controls.Add(this.lblMonths);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(605, 41);
            this.panel1.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(434, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "还款方式:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(80, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "应收本息:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(206, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "期限:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(314, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "还款状况:";
            // 
            // lblNum
            // 
            this.lblNum.BackColor = System.Drawing.Color.Transparent;
            this.lblNum.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblNum.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNum.Location = new System.Drawing.Point(51, 0);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(40, 32);
            this.lblNum.TabIndex = 16;
            this.lblNum.Text = "90";
            this.lblNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UcBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblremark);
            this.Controls.Add(this.pnlBillInfo);
            this.Name = "UcBill";
            this.Size = new System.Drawing.Size(862, 76);
            this.Load += new System.EventHandler(this.UcBill_Load);
            this.pnlBillInfo.ResumeLayout(false);
            this.pnlBillInfo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSiteName;
        private System.Windows.Forms.Label lblTotalMoney;
        private System.Windows.Forms.Label lblWay;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.Label lblReceivable;
        private System.Windows.Forms.Label lblBeginDate;
        private System.Windows.Forms.Label lblMonths;
        private System.Windows.Forms.Label lblPeriods;
        private System.Windows.Forms.Panel pnlBillInfo;
        private System.Windows.Forms.Label lblremark;
        private System.Windows.Forms.Label lblleft;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblSiteUserName;
        private System.Windows.Forms.Label lblNum;
    }
}
