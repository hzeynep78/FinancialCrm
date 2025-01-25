using FinancialCrm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmSpending : Form
    {
        public FrmSpending()
        {
            InitializeComponent();
        }
        FinancialCrmDBEntities db = new FinancialCrmDBEntities();
        private void FrmSpending_Load(object sender, EventArgs e)
        {
            var category = db.TBL_CATEGORY.ToList();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            comboBox1.DataSource = category;
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.TBL_SPENDING.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            DateTime date = DateTime.Parse(txtDate.Text);
            decimal amount = decimal.Parse(txtAmount.Text);
            int category = (int)comboBox1.SelectedValue;

            TBL_SPENDING spend = new TBL_SPENDING();
            spend.Title = title;
            spend.Date = date;
            spend.Amount = amount;
            spend.CategoryId = category;
            db.TBL_SPENDING.Add(spend);
            MessageBox.Show("Ekleme İşlemi Başarılı");
            db.SaveChanges();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string title = txtTitle.Text;
            DateTime date = DateTime.Parse(txtDate.Text);
            decimal amount = decimal.Parse(txtAmount.Text);
            int category = (int)comboBox1.SelectedValue;

            var update = db.TBL_SPENDING.Find(id);
            update.Title = title;
            update.Date = date;
            update.Amount = amount;
            update.CategoryId = category;
            MessageBox.Show("Güncelleme İşlemi Başarılı");
            db.SaveChanges();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);

            var delete = db.TBL_SPENDING.Find(id);
            db.TBL_SPENDING.Remove(delete);
            MessageBox.Show("Silme İşlemi Başarılı");
            db.SaveChanges();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCategory category = new FrmCategory();
            category.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmBank frmBank = new FrmBank();
            frmBank.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmSpending frmSpending = new FrmSpending();
            frmSpending.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmBilling billing = new FrmBilling();
            billing.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmProcess process = new FrmProcess();
            process.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmDashboard frmDashboard = new FrmDashboard();
            frmDashboard.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmSettings settings = new FrmSettings();
            settings.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
