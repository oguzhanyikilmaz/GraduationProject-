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
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }
        int quantitysold = 0;
        private async void ListProducts()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/Products"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject(apiResponse);
                    List<Products> products = JsonConvert.DeserializeObject<List<Products>>(apiResponse);
                    //var product = (from p in products
                    //               select new
                    //               {
                    //                   p.Barcode,
                    //                   p.ProductName,
                    //                   p.Brand,
                    //                   p.Stock,
                    //                   p.Price
                    //               }).ToList();
                    dgvProducts.DataSource = products;

                }
            }
        }
       

        private async void ProductForm_Load(object sender, EventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/Categories"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject(apiResponse);
                    List<Categories> categories = JsonConvert.DeserializeObject<List<Categories>>(apiResponse);
                    cmbCategory.DataSource = categories;
                    cmbCategory.DisplayMember = "CategoryName";
                    cmbCategory.ValueMember = "CategoryId";
                }
            }

            ListProducts();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private async void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {

                    Products products = new Products();
                    products.ProductName = txtProductName.Text;
                    products.Brand = txtBrand.Text;
                    products.Barcode = txtBarcode.Text;
                    products.Stock = Convert.ToInt16(txtUnitsInStock.Text);
                    products.Price = Convert.ToDecimal(txtUnitPrice.Text);
                    products.CategoryId = Convert.ToInt32(cmbCategory.SelectedValue);




                    var convertModel = JsonConvert.SerializeObject(products);
                    var content = new StringContent(convertModel, Encoding.UTF8, "application/json");
                    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");


                    var response = await httpClient.PostAsync("https://localhost:44332/api/Products", content);




                }
                ListProducts();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lütfen giriş bilgilerini kontrol ediniz !");
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                
                using (var httpClient = new HttpClient())
                {
                   
                    Products products = new Products();
                    products.ProductId = Convert.ToInt32(txtProductId.Text);
                    products.ProductName = txtProductName.Text;
                    products.Brand = txtBrand.Text;
                    products.Barcode = txtBarcode.Text;
                    products.Stock = Convert.ToInt16(txtUnitsInStock.Text);
                    products.Price = Convert.ToDecimal(txtUnitPrice.Text);
                    products.CategoryId = Convert.ToInt32(cmbCategory.SelectedValue);
                    products.QuantitySold = Convert.ToInt32( quantitysold);
                    
                    var convertModel = JsonConvert.SerializeObject(products);
                    var content = new StringContent(convertModel, Encoding.UTF8, "application/json");
                    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");


                    var response = await httpClient.PutAsync("https://localhost:44332/api/Products", content);
                }


                ListProducts();
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen bilgileri kontrol ediniz !");
            }
        }
       
        private async void dgvProducts_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/Products"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject(apiResponse);
                    List<Products> products = JsonConvert.DeserializeObject<List<Products>>(apiResponse);
                    foreach (var item in products)
                    {
                        if (item.ProductId == Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["ProductId"].Value))
                        {
                            txtProductId.Text = item.ProductId.ToString();
                            txtProductName.Text = item.ProductName;
                            txtBrand.Text = item.Brand;
                            txtBarcode.Text = item.Barcode;
                            txtUnitPrice.Text = item.Price.ToString();
                            txtUnitsInStock.Text = item.Stock.ToString();
                            cmbCategory.SelectedValue = item.CategoryId;
                            quantitysold = Convert.ToInt32( item.QuantitySold);

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

                    Products products = new Products();
                    products.ProductId = Convert.ToInt32(txtProductId.Text);
                    products.ProductName = txtProductName.Text;
                    products.Brand = txtBrand.Text;
                    products.Barcode = txtBarcode.Text;
                    products.Stock = Convert.ToInt16(txtUnitsInStock.Text);
                    products.Price = Convert.ToDecimal(txtUnitPrice.Text);
                    products.CategoryId = Convert.ToInt32(cmbCategory.SelectedValue);

                    var convertModel = JsonConvert.SerializeObject(products);
                    var content = new StringContent(convertModel, Encoding.UTF8, "application/json");
                    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");


                    var response = await httpClient.DeleteAsync("https://localhost:44332/api/Products/" + products.ProductId);




                }


                ListProducts();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Bu ürün satışta olduğundan silinemiyor !");
            }
        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/Products"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject(apiResponse);
                    List<Products> products = JsonConvert.DeserializeObject<List<Products>>(apiResponse);
                    string search = txtProductName.Text;
                    var product = (from p in products
                                   where p.ProductName.Contains(search)
                                   select new
                                   {
                                       p.Barcode,
                                       p.ProductName,
                                       p.Stock
                                   }).ToList();
                    if (product.Count == 0)
                    {
                        MessageBox.Show("Ürün bulunamadı !");
                    }
                    else
                    {
                        dgvProducts.DataSource = product;
                    }


                }

            }
        }
    }
}
