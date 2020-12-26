using Newtonsoft.Json;
using Presentation.Adminn.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class SalesForm : Form
    {
        List<CartDetails> ress = new List<CartDetails>();
        //SerialPort sp = new SerialPort();
        //string veri;
        PaymentForm _paymentForm;
        public SalesForm()
        {
            
            InitializeComponent();
        }
        decimal toplam = 0;
        int sonId = 0;
        public async void Sales()
        {
            using (var httpClient = new HttpClient())
            {

                Cart cart = new Cart();
                cart.TotalAmount = Convert.ToDecimal(lblTotal.Text);

                var convertModel = JsonConvert.SerializeObject(cart);
                var content = new StringContent(convertModel, Encoding.UTF8, "application/json");
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");


                var response = await httpClient.PostAsync("https://localhost:44332/api/Carts", content);
                using (var res = await httpClient.GetAsync("https://localhost:44332/api/Carts"))
                {
                    var apiResponse = await res.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject(apiResponse);
                    List<Cart> carts = JsonConvert.DeserializeObject<List<Cart>>(apiResponse);
                    int son_id = int.Parse(carts
                      .OrderByDescending(p => p.CartId)
                      .Select(r => r.CartId)
                      .First().ToString()
                          );
                    sonId = son_id;



                    foreach (DataGridViewRow row in dgvProducts.Rows)
                    {
                        var re = await httpClient.GetAsync("https://localhost:44332/api/CartDetails");
                        var apiRes = await re.Content.ReadAsStringAsync();
                        List<CartDetails> ct = JsonConvert.DeserializeObject<List<CartDetails>>(apiRes);
                        if (Convert.ToInt32(row.Cells["ProductId"].Value) != 0)
                        {
                            var ress = ct.Where(c => c.CartId == son_id && c.ProductId == Convert.ToInt32(row.Cells["ProductId"].Value)).ToList();
                            if (ress.Count == 0)
                            {
                                CartDetails cartDetails = new CartDetails();
                                cartDetails.CartId = son_id;
                                cartDetails.ProductId = Convert.ToInt32(row.Cells["ProductId"].Value);
                                cartDetails.Price = Convert.ToDecimal(row.Cells["Price"].Value);
                                cartDetails.Quantity = Convert.ToInt16(row.Cells["Quantity"].Value);
                                var convert = JsonConvert.SerializeObject(cartDetails);
                                var cont = new StringContent(convert, Encoding.UTF8, "application/json");
                                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                                var resp = await httpClient.PostAsync("https://localhost:44332/api/CartDetails", cont);

                            }
                            else
                            {
                                int qua = 1;
                                CartDetails cartDetails = new CartDetails();
                                foreach (var item in ress)
                                {
                                    cartDetails.CartDetailsId = item.CartDetailsId;
                                    cartDetails.ProductId = item.ProductId;
                                    cartDetails.Price = item.Price;
                                    cartDetails.Quantity = item.Quantity;
                                }
                                cartDetails.CartId = son_id;
                                cartDetails.Quantity += Convert.ToInt16(qua);



                                var convertM = JsonConvert.SerializeObject(cartDetails);
                                var cont = new StringContent(convertM, Encoding.UTF8, "application/json");
                                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");


                                var respo = await httpClient.PutAsync("https://localhost:44332/api/CartDetails", cont);


                            }

                        }

                    }
                }
            }
            using (var httpClient = new HttpClient())
            {
                var re = await httpClient.GetAsync("https://localhost:44332/api/CartDetails");
                var apiRes = await re.Content.ReadAsStringAsync();
                List<CartDetails> ct = JsonConvert.DeserializeObject<List<CartDetails>>(apiRes);
                ress = ct.Where(c => c.CartId == sonId).ToList();
            }
            MessageBox.Show("Ödeme Başarıyla gerçekleşti");
            printPreviewDialog1.ShowDialog();
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void Total()
        {
            toplam = 0;
            for (int i = 0; i < dgvProducts.Rows.Count; ++i)
            {
                toplam += Convert.ToDecimal(dgvProducts.Rows[i].Cells[5].Value) * Convert.ToDecimal(dgvProducts.Rows[i].Cells[4].Value);
            }
            lblTotal.Text = toplam.ToString();
        }
        
           
        

        private void SalesForm_Load(object sender, EventArgs e)
        {
            
            textBox1.Focus();

        }
        
        //private void pBoxDelete_Click(object sender, EventArgs e)
        //{
        //    if
        //   (dgvProducts.SelectedRows.Count > 0)

        //    {
        //        dgvProducts.Rows.RemoveAt(dgvProducts.SelectedRows[0].Index);
        //        Total();
        //    }

        //    else

        //    {

        //        MessageBox.Show("Lütfen Silinecek Ürünü Seçin !");

        //    }
        //    Total();
        //    textBox1.Focus();
        //}

        private async void button1_Click(object sender, EventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/Products"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject(apiResponse);
                    List<Products> products = JsonConvert.DeserializeObject<List<Products>>(apiResponse);

                    var product = (from p in products
                                   where p.Barcode == textBox1.Text
                                   select new
                                   {
                                       p.ProductId,
                                       p.Barcode,
                                       p.ProductName,
                                       p.Brand,
                                       p.Price
                                   }).ToList();
                    int quantity = 1;

                    if (product.Count == 0)
                    {
                        MessageBox.Show("Ürün Bulunamadı !");
                    }
                    else
                    {
                        foreach (var item in product)
                        {
                            dgvProducts.Rows.Add(item.Barcode, item.ProductId, item.ProductName, item.Brand, quantity, item.Price);
                        }
                    }




                }
            }
            textBox1.Text = "";
            Total();
            textBox1.Focus();
        }
        private void FormInPanel(object form)
        {
            if (this.pnlPayment.Controls.Count > 0)
            {
                this.pnlPayment.Controls.RemoveAt(0);
            }
           
            _paymentForm.TopLevel = false;
            _paymentForm.Dock = DockStyle.Fill;
            this.pnlPayment.Controls.Add(_paymentForm);
            this.pnlPayment.Tag = _paymentForm;
            _paymentForm.Show();
        }

        //private async void pBoxPayment_Click(object sender, EventArgs e)
        //{
        //    _paymentForm = new PaymentForm(Convert.ToDecimal(lblTotal.Text));
        //    _paymentForm.btnSales_Click += btnSales_Click;
        //    if (this.pnlPayment.Controls.Count > 0)
        //    {
        //        this.pnlPayment.Controls.RemoveAt(0);
        //    }

        //    _paymentForm.TopLevel = false;
        //    _paymentForm.Dock = DockStyle.Fill;
        //    this.pnlPayment.Controls.Add(_paymentForm);
        //    this.pnlPayment.Tag = _paymentForm;
        //    _paymentForm.Show();
        //    //using (var httpClient = new HttpClient())
        //    //{

        //    //    Cart cart = new Cart();
        //    //    cart.TotalAmount = Convert.ToDecimal(lblTotal.Text);

        //    //    var convertModel = JsonConvert.SerializeObject(cart);
        //    //    var content = new StringContent(convertModel, Encoding.UTF8, "application/json");
        //    //    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");


        //    //    var response = await httpClient.PostAsync("https://localhost:44332/api/Carts", content);
        //    //    using (var res = await httpClient.GetAsync("https://localhost:44332/api/Carts"))
        //    //    {
        //    //        var apiResponse = await res.Content.ReadAsStringAsync();
        //    //        //var result = JsonConvert.DeserializeObject(apiResponse);
        //    //        List<Cart> carts = JsonConvert.DeserializeObject<List<Cart>>(apiResponse);
        //    //        int son_id = int.Parse(carts
        //    //          .OrderByDescending(p => p.CartId)
        //    //          .Select(r => r.CartId)
        //    //          .First().ToString()
        //    //              );



        //    //        foreach (DataGridViewRow row in dgvProducts.Rows)
        //    //        {
        //    //            var re = await httpClient.GetAsync("https://localhost:44332/api/CartDetails");
        //    //            var apiRes = await re.Content.ReadAsStringAsync();
        //    //            List<CartDetails> ct = JsonConvert.DeserializeObject<List<CartDetails>>(apiRes);
        //    //            if (Convert.ToInt32(row.Cells["ProductId"].Value) != 0)
        //    //            {
        //    //                var ress = ct.Where(c => c.CartId == son_id && c.ProductId == Convert.ToInt32(row.Cells["ProductId"].Value)).ToList();
        //    //                if (ress.Count == 0)
        //    //                {
        //    //                    CartDetails cartDetails = new CartDetails();
        //    //                    cartDetails.CartId = son_id;
        //    //                    cartDetails.ProductId = Convert.ToInt32(row.Cells["ProductId"].Value);
        //    //                    cartDetails.Price = Convert.ToDecimal(row.Cells["Price"].Value);
        //    //                    cartDetails.Quantity = Convert.ToInt16(row.Cells["Quantity"].Value);
        //    //                    var convert = JsonConvert.SerializeObject(cartDetails);
        //    //                    var cont = new StringContent(convert, Encoding.UTF8, "application/json");
        //    //                    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        //    //                    var resp = await httpClient.PostAsync("https://localhost:44332/api/CartDetails", cont);

        //    //                }
        //    //                else
        //    //                {
        //    //                    int qua = 1;
        //    //                    CartDetails cartDetails = new CartDetails();
        //    //                    foreach (var item in ress)
        //    //                    {
        //    //                        cartDetails.CartDetailsId = item.CartDetailsId;
        //    //                        cartDetails.ProductId = item.ProductId;
        //    //                        cartDetails.Price = item.Price;
        //    //                        cartDetails.Quantity = item.Quantity;
        //    //                    }
        //    //                    cartDetails.CartId = son_id;
        //    //                    cartDetails.Quantity += Convert.ToInt16(qua);



        //    //                    var convertM = JsonConvert.SerializeObject(cartDetails);
        //    //                    var cont = new StringContent(convertM, Encoding.UTF8, "application/json");
        //    //                    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");


        //    //                    var respo = await httpClient.PutAsync("https://localhost:44332/api/CartDetails", cont);


        //    //                }

        //    //            }

        //    //        }
        //    //    }
        //    //}
        //}

        private async void textBox1_Enter(object sender, EventArgs e)
        {

            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private async void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToLongDateString();
        }

        private async void btnSales_Click(object sender, EventArgs e)
        {
            Sales();
            
            //MainForm mainForm = new MainForm();
            //mainForm.Show();
            //this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }
        
        private async void btnFinish_Click(object sender, EventArgs e)
        {
                _paymentForm = new PaymentForm(Convert.ToDecimal(lblTotal.Text),sonId,toplam);
            _paymentForm.btnSales_Click += btnSales_Click;
            if (this.pnlPayment.Controls.Count > 0)
            {
                this.pnlPayment.Controls.RemoveAt(0);
            }

            _paymentForm.TopLevel = false;
            _paymentForm.Dock = DockStyle.Fill;
            this.pnlPayment.Controls.Add(_paymentForm);
            this.pnlPayment.Tag = _paymentForm;
            _paymentForm.Show();
           
        }

        private void btnProductDelete_Click(object sender, EventArgs e)
        {
            if
          (dgvProducts.SelectedRows.Count > 0)

            {
                dgvProducts.Rows.RemoveAt(dgvProducts.SelectedRows[0].Index);
                Total();
            }

            else

            {

                MessageBox.Show("Lütfen Silinecek Ürünü Seçin !");

            }
            Total();
            textBox1.Focus();
        }
        int i = 0;
        string name;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

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

            foreach (var item in ress)
            {
                foreach (DataGridViewRow d in dgvProducts.Rows)
                {
                    if (Convert.ToInt32(d.Cells["ProductId"].Value) != 0 && Convert.ToInt32(d.Cells["ProductId"].Value) == item.ProductId)
                    {
                       
                            name = d.Cells["ProductName"].Value.ToString();
                        
                    }
                }
               
                e.Graphics.DrawString(Convert.ToString(name), altbaslik, sb, 70, 190 + i * 30, st);
                e.Graphics.DrawString(Convert.ToString(item.Quantity), altbaslik, sb, 315, 190 + i * 30, st);
                e.Graphics.DrawString(Convert.ToString(item.Price), altbaslik, sb, 440, 190 + i * 30, st);
                
                i++;
            }
            e.Graphics.DrawString("-------------------------------------------------------------", altbaslik, sb, 70, 190 + 30 * dgvProducts.Rows.Count, st);
            e.Graphics.DrawString("Toplam Tutar : " + Convert.ToString(lblTotal.Text) + "  TL", altbaslik, sb, 450, 210 + 30 * dgvProducts.Rows.Count, st);




        }
    }
    }


