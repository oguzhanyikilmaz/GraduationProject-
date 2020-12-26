using Newtonsoft.Json;
using Presentation.Adminn.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Adminn
{
    public partial class AdminLoginForm : Form
    {
        public AdminLoginForm()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            if (txtUserName.Text=="Kullanıcı Adı")
            {
                txtUserName.Text = "";
                txtUserName.ForeColor = Color.LightGray;
            }
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                txtUserName.Text = "Kullanıcı Adı";
                txtUserName.ForeColor = Color.DimGray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Şifre")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.LightGray;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Şifre";
                txtPassword.ForeColor = Color.DimGray;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AdminLoginForm_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/Users"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject(apiResponse);
                    List<Users> users = JsonConvert.DeserializeObject<List<Users>>(apiResponse);
                    var result = users.Where(u=>u.UserName==txtUserName.Text && u.UserPassword==txtPassword.Text).ToList();
                    if (result.Count==0)
                    {
                        MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı");
                    }
                    else
                    {
                        AdminControlsForm adminControlsForm = new AdminControlsForm();
                        adminControlsForm.Show();
                        this.Hide();
                    }
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PasswordChangeForm passwordChangeForm = new PasswordChangeForm();
            passwordChangeForm.Show();
            this.Hide();
        }
    }
}
