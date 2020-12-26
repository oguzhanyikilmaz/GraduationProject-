using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Adminn
{
    public partial class ActivisionCodeForm : Form
    {
        string kod;
        public ActivisionCodeForm(string a)
        {
            kod = a;
            InitializeComponent();
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Aktivasyon Kodu")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.LightGray;
                
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "Aktivasyon Kodu";
                txtEmail.ForeColor = Color.DimGray;
                
            }
        }

        private void ActivisionCodeForm_Load(object sender, EventArgs e)
        {

        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text==kod)
            {
                PasswordCreateForm passwordCreateForm = new PasswordCreateForm();
                passwordCreateForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı aktivasyon kodu girdiniz !");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
