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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        FinancialCrmDBEntities db = new FinancialCrmDBEntities();


        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password))
            {
                label4.Text = "Lütfen tüm alanları doldurun."; // Alanların boş bırakılmadığını kontrol et
            }
            else
            {
                var control = db.TBL_USER.FirstOrDefault(x => x.Name == name && x.Password == password);

                if (control != null) // Kullanıcı bulunduysa
                {
                    FrmBank bank = new FrmBank();
                    bank.Show();
                    this.Hide(); // Yeni formu aç ve mevcut formu gizle
                }
                else
                {
                    label4.Text = "Kullanıcı adı veya şifre hatalı."; // Hatalı giriş mesajı
                }
            }
        }
    }
}
