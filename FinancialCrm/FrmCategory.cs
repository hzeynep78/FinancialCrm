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
    public partial class FrmCategory : Form
    {
        public FrmCategory()
        {
            InitializeComponent();
        }

        FinancialCrmDBEntities  db = new FinancialCrmDBEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.TBL_CATEGORY.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string name = txtTitle.Text;

            TBL_CATEGORY category = new TBL_CATEGORY();
            category.Name = name;
            db.TBL_CATEGORY.Add(category);
            MessageBox.Show("Ekleme İşlemi Başarılı");
            db.SaveChanges();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string name = txtTitle.Text;

            var update = db.TBL_CATEGORY.Find(id);
            update.Name = name;
            MessageBox.Show("Güncelleme İşlemi Başarılı");
            db.SaveChanges();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);

            TBL_CATEGORY category = new TBL_CATEGORY();
            var delete = db.TBL_CATEGORY.Find(id);
            db.TBL_CATEGORY.Remove(delete);
            MessageBox.Show("Silme İşlemi Başarılı");
            db.SaveChanges();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmDashboard frmDashboard = new FrmDashboard();
            frmDashboard.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmBank bank = new FrmBank();
            bank.Show();
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

        private void button7_Click(object sender, EventArgs e)
        {
            FrmSettings settings = new FrmSettings();
            settings.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCategory category = new FrmCategory();
            category.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmSpending frmSpending = new FrmSpending();
            frmSpending.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
