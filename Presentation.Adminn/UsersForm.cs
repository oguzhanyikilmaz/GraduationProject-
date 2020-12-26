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
    public partial class UsersForm : Form
    {
        public UsersForm()
        {
            InitializeComponent();
        }
        private async void ListUsers()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/Users"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject(apiResponse);
                    List<Users> users = JsonConvert.DeserializeObject<List<Users>>(apiResponse);
                    //var product = (from p in products
                    //               select new
                    //               {
                    //                   p.Barcode,
                    //                   p.ProductName,
                    //                   p.Brand,
                    //                   p.Stock,
                    //                   p.Price
                    //               }).ToList();
                    dgvUsers.DataSource = users;

                }
            }
        }

        private async void UsersForm_Load(object sender, EventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/UserRoles"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject(apiResponse);
                    List<UserRoles> userRoles = JsonConvert.DeserializeObject<List<UserRoles>>(apiResponse);
                    cmbRole.DataSource = userRoles;
                    cmbRole.DisplayMember = "RoleName";
                    cmbRole.ValueMember = "RoleId";
                }

                using (var response = await httpClient.GetAsync("https://localhost:44332/api/Districts"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject(apiResponse);
                    List<Districts> districts = JsonConvert.DeserializeObject<List<Districts>>(apiResponse);
                    cmbDistrict.DataSource = districts;
                    cmbDistrict.DisplayMember = "DistrictName";
                    cmbDistrict.ValueMember = "DistrictId";
                }
            }
            ListUsers();

        }

        private async void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {

                    Users users = new Users();
                    users.FirstName = txtUserFirstName.Text;
                    users.LastName = txtUserLastName.Text;
                    users.UserName = txtUserName.Text;
                    users.UserPassword = txtPassword.Text;
                    users.Email = txtEmail.Text;
                    users.Addres = txtAdress.Text;
                    users.RoleId = Convert.ToInt32(cmbRole.SelectedValue);
                    users.DistrictId = Convert.ToInt32(cmbDistrict.SelectedValue);




                    var convertModel = JsonConvert.SerializeObject(users);
                    var content = new StringContent(convertModel, Encoding.UTF8, "application/json");
                    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");


                    var response = await httpClient.PostAsync("https://localhost:44332/api/Users", content);




                }
                ListUsers();
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen bilgileri kontrol ediniz !");
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {

                    Users users = new Users();
                    users.UserId = Convert.ToInt32(txtUserId.Text);
                    users.FirstName = txtUserFirstName.Text;
                    users.LastName = txtUserLastName.Text;
                    users.UserName = txtUserName.Text;
                    users.UserPassword = txtPassword.Text;
                    users.Email = txtEmail.Text;
                    users.Addres = txtAdress.Text;
                    users.RoleId = Convert.ToInt32(cmbRole.SelectedValue);
                    users.DistrictId = Convert.ToInt32(cmbDistrict.SelectedValue);




                    var convertModel = JsonConvert.SerializeObject(users);
                    var content = new StringContent(convertModel, Encoding.UTF8, "application/json");
                    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");


                    var response = await httpClient.PutAsync("https://localhost:44332/api/Users", content);




                }


                ListUsers();
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen bilgileri kontrol ediniz !");
            }
        }

        private async void dgvUsers_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/Users"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject(apiResponse);
                    List<Users> users = JsonConvert.DeserializeObject<List<Users>>(apiResponse);
                    foreach (var item in users)
                    {
                        if (item.UserId == Convert.ToInt32(dgvUsers.Rows[e.RowIndex].Cells["UserId"].Value))
                        {
                            txtUserId.Text = item.UserId.ToString();
                            txtUserFirstName.Text = item.FirstName;
                            txtUserLastName.Text = item.LastName;
                            txtUserName.Text = item.UserName;
                            txtPassword.Text = item.UserPassword;
                            txtEmail.Text = item.Email;
                            txtAdress.Text = item.Addres;
                            cmbRole.SelectedValue = item.RoleId;
                            cmbDistrict.SelectedValue = item.DistrictId;

                        }
                    }


                }
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {

                    Users users = new Users();
                    users.UserId = Convert.ToInt32(txtUserId.Text);
                    users.FirstName = txtUserFirstName.Text;
                    users.LastName = txtUserLastName.Text;
                    users.UserName = txtUserName.Text;
                    users.UserPassword = txtPassword.Text;
                    users.Email = txtEmail.Text;
                    users.Addres = txtAdress.Text;
                    users.RoleId = Convert.ToInt32(cmbRole.SelectedValue);
                    users.DistrictId = Convert.ToInt32(cmbDistrict.SelectedValue);




                    var convertModel = JsonConvert.SerializeObject(users);
                    var content = new StringContent(convertModel, Encoding.UTF8, "application/json");
                    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");


                    var response = await httpClient.DeleteAsync("https://localhost:44332/api/Users/" +Convert.ToInt32( users.UserId));




                }


                ListUsers();
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen bilgileri kontrol ediniz !");
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
