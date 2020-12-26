using Newtonsoft.Json;
using Presentation.Adminn.Models;
using System;
using System.Collections;
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
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
        }
        ArrayList p = new ArrayList();
        ArrayList c = new ArrayList();
        ArrayList q = new ArrayList();


        private async void ReportsForm_Load(object sender, EventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/Products"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject(apiResponse);
                    List<Products> products = JsonConvert.DeserializeObject<List<Products>>(apiResponse);
                    lblProducts.Text = products.Count.ToString();
                    foreach (var item in products)
                    {
                        p.Add(item.ProductName);
                    }
                    foreach (var item in products)
                    {
                        c.Add(item.Stock);
                    }
                    foreach (var item in products)
                    {
                        q.Add(item.QuantitySold);
                    }

                    chartProducts.Series[0].Points.DataBindXY(p, c);
                    chart1.Series[0].Points.DataBindXY(p, q);

                }
            }
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/Users"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject(apiResponse);
                    List<Users> users = JsonConvert.DeserializeObject<List<Users>>(apiResponse);
                    lblUser.Text = users.Count.ToString();
                }
            }
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/Orders"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject(apiResponse);
                    List<Orders> orders = JsonConvert.DeserializeObject<List<Orders>>(apiResponse);
                    lblOrders.Text = orders.Count.ToString();
                }
            }
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/Carts"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject(apiResponse);
                    List<Cart> carts = JsonConvert.DeserializeObject<List<Cart>>(apiResponse);
                    lblCarts.Text = carts.Count.ToString();
                }
            }
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/Carts"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject(apiResponse);
                    List<Cart> carts = JsonConvert.DeserializeObject<List<Cart>>(apiResponse);
                    var total = carts.Sum(c => c.TotalAmount);
                    lblTotal.Text = total.ToString();
                }
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHour.Text = DateTime.Now.ToLongTimeString(); /*DateTime.Now.ToString("hh:mm:ss ");*/
            lblDateTime.Text = DateTime.Now.ToLongDateString();
        }
    }
}
