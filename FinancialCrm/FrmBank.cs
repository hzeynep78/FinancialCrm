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
    public partial class FrmBank : Form
    {
        public FrmBank()
        {
            InitializeComponent();
        }

        FinancialCrmDBEntities db = new FinancialCrmDBEntities();

        private void FrmBank_Load(object sender, EventArgs e)
        {
            var ziraat = db.TBL_BANK.Where(x => x.Title == "Ziraat Bankası").Select(y => y.Balance).FirstOrDefault();
            var vakifbank = db.TBL_BANK.Where(x => x.Title == "Vakıfbank").Select(y => y.Balance).FirstOrDefault();
            var isbank = db.TBL_BANK.Where(x => x.Title == "İş Bankası").Select(y => y.Balance).FirstOrDefault();

            lblZiraat.Text = ziraat.ToString() + " ₺";
            lblVakifbank.Text = vakifbank.ToString() + " ₺";
            lblIs.Text = isbank.ToString() + " ₺";


            var process1 = db.TBL_PROCESS.OrderByDescending(x=>x.Id).Take(1).FirstOrDefault();
            lblProcess1.Text = process1.Description+"-"+process1.Amount+"-"+process1.Date;
            var process2 = db.TBL_PROCESS.OrderByDescending(x => x.Id).Take(2).Skip(1).FirstOrDefault();
            lblProcess2.Text = process2.Description + "-" + process2.Amount + "-" + process2.Date;
            var process3 = db.TBL_PROCESS.OrderByDescending(x => x.Id).Take(3).Skip(2).FirstOrDefault();
            lblProcess3.Text = process3.Description + "-" + process3.Amount + "-" + process3.Date;
            var process4 = db.TBL_PROCESS.OrderByDescending(x => x.Id).Take(4).Skip(3).FirstOrDefault();
            lblProcess4.Text = process4.Description + "-" + process4.Amount + "-" + process4.Date;
            var process5 = db.TBL_PROCESS.OrderByDescending(x => x.Id).Take(5).Skip(4).FirstOrDefault();
            lblProcess5.Text = process5.Description + "-" + process5.Amount + "-" + process5.Date;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmBilling billing = new FrmBilling();
            billing.Show();
            this.Hide();
        }
    }
}
