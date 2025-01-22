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
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();
        }
        FinancialCrmDBEntities db = new FinancialCrmDBEntities();
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string password = txtPassword.Text;
            int id = int.Parse(txtId.Text);

            var update = db.TBL_USER.Find(id);
            update.Name = name;
            update.Password = password;
            MessageBox.Show("Güncelleme İşlemi Başarılı");
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
            FrmBank bank = new FrmBank();
            bank.Show();
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
    }
}
