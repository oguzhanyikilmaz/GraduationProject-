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
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }
        private async void ListCategory()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/Categories"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject(apiResponse);
                    List<Categories> categories = JsonConvert.DeserializeObject<List<Categories>>(apiResponse);
                    var categorie = (from c in categories
                                   select new
                                   {
                                       c.CategoryId,
                                       c.CategoryName
                            
                                   }).ToList();
                    dgvCategories.DataSource = categorie;

                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            ListCategory();
        }

        private async void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {

                    Categories categories = new Categories();
                    categories.CategoryName = txtCategoryName.Text;





                    var convertModel = JsonConvert.SerializeObject(categories);
                    var content = new StringContent(convertModel, Encoding.UTF8, "application/json");
                    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");


                    var response = await httpClient.PostAsync("https://localhost:44332/api/Categories", content);




                }
                ListCategory();
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

                    Categories categories = new Categories();
                    categories.CategoryId = Convert.ToInt32(txtCategoryId.Text);
                    categories.CategoryName = txtCategoryName.Text;
                    var convertModel = JsonConvert.SerializeObject(categories);
                    var content = new StringContent(convertModel, Encoding.UTF8, "application/json");
                    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");


                    var response = await httpClient.PutAsync("https://localhost:44332/api/Categories", content);




                }


                ListCategory();
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen bilgileri kontrol ediniz !");
            }
        }

        private async void dgvCategories_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/Categories"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject(apiResponse);
                    List<Categories> categories = JsonConvert.DeserializeObject<List<Categories>>(apiResponse);
                    foreach (var item in categories)
                    {
                        if (item.CategoryId == Convert.ToInt32(dgvCategories.Rows[e.RowIndex].Cells["CategoryId"].Value))
                        {
                            txtCategoryId.Text = item.CategoryId.ToString();
                            txtCategoryName.Text = item.CategoryName;

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

                    Categories categories = new Categories();
                    categories.CategoryId = Convert.ToInt32(txtCategoryId.Text);
                    categories.CategoryName = txtCategoryName.Text;




                    var convertModel = JsonConvert.SerializeObject(categories);
                    var content = new StringContent(convertModel, Encoding.UTF8, "application/json");
                    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");


                    var response = await httpClient.DeleteAsync("https://localhost:44332/api/Categories/" + categories.CategoryId);
                }


                ListCategory();
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen bilgileri kontrol ediniz !");
            }
        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
