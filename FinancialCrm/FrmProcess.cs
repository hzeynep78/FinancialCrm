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
    public partial class FrmProcess : Form
    {
        public FrmProcess()
        {
            InitializeComponent();
        }

        FinancialCrmDBEntities db = new FinancialCrmDBEntities();

        private void FrmProcess_Load(object sender, EventArgs e)
        {
            comboBox2.Items.AddRange(new string[] {"Gelen Havale","GidenHavale"});
            var banks = db.TBL_BANK.ToList();
            comboBox1.DisplayMember = "Title";
            comboBox1.ValueMember = "Id";
            comboBox1.DataSource = banks;      
        }


        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.TBL_PROCESS.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            decimal amount = decimal.Parse(txtAmount.Text);
            DateTime date = DateTime.Parse(txtDate.Text);
            string type = comboBox2.Text;
            int bank = (int)comboBox1.SelectedValue;

            TBL_PROCESS process = new TBL_PROCESS();
            process.Description = title;
            process.Amount = amount;
            process.Date = date;
            process.Type = type;
            process.BankId = bank;
            db.TBL_PROCESS.Add(process);
            MessageBox.Show("Ekleme İşlemi Başarılı");
            db.SaveChanges();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string title = txtTitle.Text;
            decimal amount = decimal.Parse(txtAmount.Text);
            DateTime date = DateTime.Parse(txtDate.Text);
            string type = comboBox2.Text;
            int bank = (int)comboBox1.SelectedValue;

            var update = db.TBL_PROCESS.Find(id);
            update.Description = title;
            update.Amount = amount;
            update.Date = date;
            update.Type = type;
            update.BankId = bank;
            MessageBox.Show("Güncelleme İşlemi Başarılı");
            db.SaveChanges();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id =int.Parse(txtId.Text);

            var delete = db.TBL_PROCESS.Find(id);
            db.TBL_PROCESS.Remove(delete);
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
