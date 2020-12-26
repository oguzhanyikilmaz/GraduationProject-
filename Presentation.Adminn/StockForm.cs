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
    public partial class StockForm : Form
    {
        public StockForm()
        {
            InitializeComponent();
        }
        private async void ListProducts()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/Products"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject(apiResponse);
                    List<Products> products = JsonConvert.DeserializeObject<List<Products>>(apiResponse);
                    var product = (from p in products
                                   select new
                                   {
                                       p.Barcode,
                                       p.ProductName,
                                       p.Stock
                                   }).ToList();
                    dgvProducts.DataSource = product;

                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void StockForm_Load(object sender, EventArgs e)
        {
            ListProducts();
        }

        private async void txtProductName_TextChanged(object sender, EventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/Products"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject(apiResponse);
                    List<Products> products = JsonConvert.DeserializeObject<List<Products>>(apiResponse);
                    string search = txtProductName.Text;
                    var product = (from p in products where p.ProductName.Contains(search)
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

           
        

        

        

        private void lblCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

