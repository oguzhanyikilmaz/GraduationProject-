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
    public partial class PasswordCreateForm : Form
    {
        public PasswordCreateForm()
        {
            InitializeComponent();
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.LightGray;
                
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "Email";
                txtEmail.ForeColor = Color.DimGray;
                
            }
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/Users"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject(apiResponse);
                    List<Users> users = JsonConvert.DeserializeObject<List<Users>>(apiResponse);
                    var result = users.Where(u => u.Email == txtEmail.Text).ToList();
                    if (result.Count == 0)
                    {
                        MessageBox.Show("Mail Hatalı");
                    }
                    else
                    {
                        Users user = new Users();
                        foreach (var item in users)
                        {
                            user.UserId = Convert.ToInt32(item.UserId);
                            user.FirstName = item.FirstName;
                            user.LastName =item.LastName;
                            user.UserName = item.UserName;
                            user.Addres = item.Addres;
                            user.RoleId = Convert.ToInt32(item.RoleId);
                            user.DistrictId = Convert.ToInt32(item.DistrictId);
                        }           
                        user.UserPassword = txtPassword.Text;
                        user.Email = txtEmail.Text;
                        
                        var convertModel = JsonConvert.SerializeObject(user);
                            var content = new StringContent(convertModel, Encoding.UTF8, "application/json");
                            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");


                            var resp = await httpClient.PutAsync("https://localhost:44332/api/Users", content);
                        AdminLoginForm adminLoginForm = new AdminLoginForm();
                        adminLoginForm.Show();
                        this.Hide();
                        }
                    }
                }
            }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Yeni Şifre")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.LightGray;

            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Yeni Şifre";
                txtPassword.ForeColor = Color.DimGray;

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    }

