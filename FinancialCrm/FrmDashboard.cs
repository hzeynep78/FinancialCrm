using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialCrm.Models;

namespace FinancialCrm
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }

        FinancialCrmDBEntities db = new FinancialCrmDBEntities();
        int count = 0;

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            var totalBalance = db.TBL_BANK.Sum(x => x.Balance);
            lbltotalBalance.Text = totalBalance.ToString()+" ₺";

            var lastBankProcessAmount = db.TBL_PROCESS.OrderByDescending(x=>x.Id).Take(1).Select(y=>y.Amount).FirstOrDefault();
            lblLastProcessAmount.Text = lastBankProcessAmount.ToString() + " ₺";

            //Chart 1
            var bankData = db.TBL_BANK.Select(x => new
            {
                x.Title,
                x.Balance
            }).ToList();
            chart1.Series.Clear();
            var series = chart1.Series.Add("Series1");
            foreach (var item in bankData)
            {
                series.Points.AddXY(item.Title, item.Balance);
            }

            //Chart 2
            var bills = db.TBL_BILL.Select(x => new
            {
                x.Title ,
                x.Amount
            }).ToList();
            chart2.Series.Clear();
            var series1 = chart2.Series.Add("Faturalar");
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            foreach (var item in bills)
            {
                series1.Points.AddXY(item.Title,item.Amount);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;

            if (count % 4 == 1)
            {
                var bill = db.TBL_BILL.Where(x=>x.Title== "Elektrik Faturası").Select(y=>y.Amount).FirstOrDefault();
                lblBills.Text = "Elektrik Faturası";
                lblAmount.Text = bill.ToString()+" ₺";
            }
            if (count % 4 == 2)
            {
                var bill = db.TBL_BILL.Where(x => x.Title == "Doğalgaz Faturası").Select(y => y.Amount).FirstOrDefault();
                lblBills.Text = "Doğalgaz Faturası";
                lblAmount.Text = bill.ToString() + " ₺";
            }
            if (count % 4 == 0)
            {
                var bill = db.TBL_BILL.Where(x => x.Title == "Su Faturası").Select(y => y.Amount).FirstOrDefault();
                lblBills.Text = "Su Faturası";
                lblAmount.Text = bill.ToString() + " ₺";
            }
        }
    }
    
}
