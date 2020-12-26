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
    public partial class InvoiceForm : Form
    {
        public InvoiceForm()
        {
            InitializeComponent();
        }
        private async void ListCart()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/Carts"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject(apiResponse);
                    List<Cart> carts = JsonConvert.DeserializeObject<List<Cart>>(apiResponse);
                    
                    dgvInvoice.DataSource = carts;

                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        List<CartDetails> cartDetails = new List<CartDetails>();
        List<Products> products = new List<Products>();

        private async void dgvInvoice_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                var re = await httpClient.GetAsync("https://localhost:44332/api/CartDetails");
                var apiRes = await re.Content.ReadAsStringAsync();
                List<CartDetails> ct = JsonConvert.DeserializeObject<List<CartDetails>>(apiRes);
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/Carts"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject(apiResponse);
                    List<Cart> carts = JsonConvert.DeserializeObject<List<Cart>>(apiResponse);
                    foreach (var item in carts)
                    {
                        if (item.CartId == Convert.ToInt32(dgvInvoice.Rows[e.RowIndex].Cells["CartId"].Value))
                        {
                            txtNo.Text = Convert.ToString(item.CartId);
                            txtAmount.Text = Convert.ToString(item.TotalAmount);
                            dateTimePicker.Value =Convert.ToDateTime( item.SellBy);
                             cartDetails = ct.Where(c => c.CartId == Convert.ToInt32(dgvInvoice.Rows[e.RowIndex].Cells["CartId"].Value)).ToList();

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

                    Cart cart = new Cart();
                    cart.TotalAmount = Convert.ToDecimal(txtAmount.Text);
                    cart.SellBy = Convert.ToDateTime(dateTimePicker.Value);



                    var convertModel = JsonConvert.SerializeObject(cart);
                    var content = new StringContent(convertModel, Encoding.UTF8, "application/json");
                    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");


                    var response = await httpClient.PostAsync("https://localhost:44332/api/Carts", content);




                }
                ListCart();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lütfen kayıt bilgilerini kontrol ediniz !");
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                using (var httpClient = new HttpClient())
                {
                    Cart cart = new Cart();
                    cart.CartId =Convert.ToInt32(txtNo.Text);
                    cart.TotalAmount = Convert.ToInt32(txtAmount.Text);
                    cart.SellBy = Convert.ToDateTime(dateTimePicker.Value);
                    

                    var convertModel = JsonConvert.SerializeObject(cart);
                    var content = new StringContent(convertModel, Encoding.UTF8, "application/json");
                    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");


                    var response = await httpClient.PutAsync("https://localhost:44332/api/Carts", content);
                }


                ListCart();
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen bilgileri kontrol ediniz !");
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {

                    Cart cart = new Cart();
                    cart.CartId = Convert.ToInt32(txtNo.Text);
                    cart.TotalAmount = Convert.ToDecimal(txtAmount.Text);
                    cart.SellBy = Convert.ToDateTime(dateTimePicker.Value);

                    var convertModel = JsonConvert.SerializeObject(cart);
                    var content = new StringContent(convertModel, Encoding.UTF8, "application/json");
                    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");


                    var response = await httpClient.DeleteAsync("https://localhost:44332/api/Carts/" + cart.CartId);




                }


                ListCart();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Fatura Tarihi Değiştirilemez !");
            }
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            ListCart();
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

            foreach (var item in cartDetails)
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
            e.Graphics.DrawString("-------------------------------------------------------------", altbaslik, sb, 70, 190 + 30 * cartDetails.Count, st);
            e.Graphics.DrawString("Toplam Tutar : " + Convert.ToString(t) + "  TL", altbaslik, sb, 350, 210 + 30 * cartDetails.Count, st);





        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }
    }
}
