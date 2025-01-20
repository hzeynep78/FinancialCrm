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
    public partial class FrmBilling : Form
    {
        public FrmBilling()
        {
            InitializeComponent();
        }

        FinancialCrmDBEntities db = new FinancialCrmDBEntities();
        private void FrmBilling_Load(object sender, EventArgs e)
        {
            var values =db.TBL_BILL.ToList();
            dataGridView1.DataSource = values; 
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.TBL_BILL.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            decimal amount = decimal.Parse(txtAmount.Text);
            string period = txtPeriod.Text;

            TBL_BILL bills = new TBL_BILL();
            bills.Title = title;
            bills.Amount = amount;
            bills.Period = period;
            db.TBL_BILL.Add(bills);
            MessageBox.Show("Ekleme İşlemi Başarılı");
            db.SaveChanges();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);

            TBL_BILL bills = new TBL_BILL();
            var delete = db.TBL_BILL.Find(id);
            db.TBL_BILL.Remove(delete);
            MessageBox.Show("Silme İşlemi Başarılı");
            db.SaveChanges();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            decimal amount = decimal.Parse(txtAmount.Text);
            string period = txtPeriod.Text;
            int id = int.Parse(txtId.Text);

            var update = db.TBL_BILL.Find(id);
            update.Title = title;
            update.Amount = amount;
            update.Period = period;
            MessageBox.Show("Güncelleme İşlemi Başarılı");
            db.SaveChanges();
            
        }

        private void btnBank_Click(object sender, EventArgs e)
        {
            FrmBank bank = new FrmBank();
            bank.Show();
            this.Hide();
        }
    }
}
