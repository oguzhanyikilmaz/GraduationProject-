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
    public partial class OrdersForm : Form
    {
        string userıd;
        HttpClient httpClient = new HttpClient();
        public OrdersForm()
        {
            InitializeComponent();
        }
        private async void ListOrders()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/Orders"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject(apiResponse);
                    List<Orders> orders = JsonConvert.DeserializeObject<List<Orders>>(apiResponse);

                    dgvInvoice.DataSource = orders;

                }
            }
        }
        List<OrderDetails> orderDetails = new List<OrderDetails>();
        List<Products> products = new List<Products>();
        private async void dgvInvoice_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            userıd = "";
            using (var httpClient = new HttpClient())
            {
                var re = await httpClient.GetAsync("https://localhost:44332/api/OrderDetails/"+ Convert.ToInt32(dgvInvoice.Rows[e.RowIndex].Cells["OrderId"].Value));
                var apiRes = await re.Content.ReadAsStringAsync();
                List<OrderDetails> orderdetails = JsonConvert.DeserializeObject<List<OrderDetails>>(apiRes);
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/Orders"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject(apiResponse);
                    List<Orders> orders = JsonConvert.DeserializeObject<List<Orders>>(apiResponse);
                    
                    foreach (var item in orders)
                    {
                        if (item.OrderId == Convert.ToInt32(dgvInvoice.Rows[e.RowIndex].Cells["OrderId"].Value))
                        {
                            txtNo.Text = Convert.ToString(item.OrderId);
                            txtTotalAmount.Text = Convert.ToString(item.TotalAmount);
                            dateTimePicker.Value = Convert.ToDateTime(item.OrderDate);
                            txtFirstName.Text = item.FirstName;
                            txtLastName.Text = item.LastName;
                            txtPhone.Text = item.Phone;
                            txtMail.Text = item.Email;
                            txtCity.Text = item.Province;
                            txtAdress.Text = item.Addres;
                            orderDetails = orderdetails;
                            userıd = item.UserId;

                        }
                    }
                    var ress = await httpClient.GetAsync("https://localhost:44332/api/Products");
                    var apiResss = await ress.Content.ReadAsStringAsync();
                    products = JsonConvert.DeserializeObject<List<Products>>(apiResss);
                }
            }
        }
        
        private async void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {

                    Orders orders = new Orders();
                    orders.FirstName = txtFirstName.Text;
                    orders.LastName = txtLastName.Text;
                    orders.Phone = txtPhone.Text;
                    orders.Email = txtMail.Text;
                    orders.Addres = txtAdress.Text;
                    orders.TotalAmount = Convert.ToDecimal(txtTotalAmount.Text);
                    orders.OrderDate = Convert.ToDateTime(dateTimePicker.Value);
                   


                    var convertModel = JsonConvert.SerializeObject(orders);
                    var content = new StringContent(convertModel, Encoding.UTF8, "application/json");
                    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");


                    var response = await httpClient.PostAsync("https://localhost:44332/api/Orders", content);




                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lütfen kayıt bilgilerini kontrol ediniz !");
            }
            ListOrders();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                using (var httpClient = new HttpClient())
                {
                    Orders orders = new Orders();
                    orders.OrderId = Convert.ToInt32(txtNo.Text);
                    orders.FirstName = txtFirstName.Text;
                    orders.LastName = txtLastName.Text;
                    orders.Phone = txtPhone.Text;
                    orders.Email = txtMail.Text;
                    orders.Addres = txtAdress.Text;
                    orders.TotalAmount = Convert.ToDecimal(txtTotalAmount.Text);
                    orders.OrderDate = Convert.ToDateTime(dateTimePicker.Value);
                    orders.UserId = userıd;


                    var convertModel = JsonConvert.SerializeObject(orders);
                    var content = new StringContent(convertModel, Encoding.UTF8, "application/json");
                    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");


                    var response = await httpClient.PutAsync("https://localhost:44332/api/Orders", content);
                }


               
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen bilgileri kontrol ediniz !");
            }
            ListOrders();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                List<OrderDetails> orderDetails = new List<OrderDetails>();
                Orders orders = new Orders();
                orders.OrderId = Convert.ToInt32(txtNo.Text);
                orders.FirstName = txtFirstName.Text;
                orders.LastName = txtLastName.Text;
                orders.Phone = txtPhone.Text;
                orders.Email = txtMail.Text;
                orders.Addres = txtAdress.Text;
                orders.TotalAmount = Convert.ToDecimal(txtTotalAmount.Text);
                orders.OrderDate = Convert.ToDateTime(dateTimePicker.Value);
                orders.UserId = userıd;

                using (var response_2 = await httpClient.GetAsync("https://localhost:44332/api/OrderDetails"))
                {
                    var apiResponse_ = await response_2.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject(apiResponse);
                    orderDetails = JsonConvert.DeserializeObject<List<OrderDetails>>(apiResponse_);
                }
                var result = orderDetails.Where(x => x.OrderId == Convert.ToInt32(txtNo.Text)).ToList();
                foreach (var item in result)
                {
                    var res = await httpClient.DeleteAsync("https://localhost:44332/api/OrderDetails/" + item.OrderDetailsId);
                }

                var convertModel = JsonConvert.SerializeObject(orders);
                var content = new StringContent(convertModel, Encoding.UTF8, "application/json");
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");


                var response = await httpClient.DeleteAsync("https://localhost:44332/api/Orders/" + orders.OrderId);


                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lütfen terkar deneyiniz !");
            }
            ListOrders();
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            try
            {
                ListOrders();
            }
            catch (Exception)
            {

                MessageBox.Show("Sipariş Bulunamadı");
            }
            
        }
        int i = 0;
        decimal t = 0;
        string name;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            i = 0;
            t = 0;
            Font baslik = new Font("Verdana", 15, FontStyle.Bold);
            Font altbaslik = new Font("Verdana", 12, FontStyle.Regular);
            Font icerik = new Font("Verdana", 10);
            SolidBrush sb = new SolidBrush(Color.Black);

            StringFormat st = new StringFormat();
            st.Alignment = StringAlignment.Near;
            e.Graphics.DrawString("SHOPPİNG MARKET", baslik, sb, 200, 100, st);

            e.Graphics.DrawString("------------------------------", altbaslik, sb, 200, 120, st);
            e.Graphics.DrawString("Ürün Adı                        Miktar               Fiyat", altbaslik, sb, 70, 150, st);
            e.Graphics.DrawString("-----------------------------------------------------------", altbaslik, sb, 70, 170, st);

            foreach (var item in orderDetails)
            {
                foreach (var d in products)
                {
                    if (Convert.ToInt32(d.ProductId) != 0 && Convert.ToInt32(d.ProductId) == item.ProductId)
                    {

                        name = d.ProductName.ToString();

                    }
                }

                e.Graphics.DrawString(Convert.ToString(name), altbaslik, sb, 70, 190 + i * 30, st);
                e.Graphics.DrawString(Convert.ToString(item.Quantity), altbaslik, sb, 315, 190 + i * 30, st);
                e.Graphics.DrawString(Convert.ToString(item.Price), altbaslik, sb, 440, 190 + i * 30, st);
                t += Convert.ToDecimal(item.Price * item.Quantity);
                i++;
            }
            e.Graphics.DrawString("-------------------------------------------------------------", altbaslik, sb, 70, 190 + 30 * orderDetails.Count, st);
            e.Graphics.DrawString("Toplam Tutar : " + Convert.ToString(t) + "  TL", altbaslik, sb, 350, 210 + 30 * orderDetails.Count, st);



        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }
    }
}