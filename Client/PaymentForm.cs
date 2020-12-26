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

namespace Client
{
    public partial class PaymentForm : Form
    {
        List<CartDetails> carts = new List<CartDetails>();
        decimal p=0;
        string cartno="";
        int sonId = 0;
        decimal total = 0;
    
        public PaymentForm(decimal t,int sonıd,decimal toplam)
        {
            p = t;
            sonId = sonıd;
            total = toplam;
            
            
            InitializeComponent();
        }
        private async void ListCreditCarts()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/CreditCarts"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject(apiResponse);
                    List<CreditCarts> creditCarts = JsonConvert.DeserializeObject<List<CreditCarts>>(apiResponse);

                }
            }
        }
        public event EventHandler btnSales_Click;
        public async void CartGet(int id)
        {

            using (var httpClient = new HttpClient())
            {
                using (var res = await httpClient.GetAsync("https://localhost:44332/api/CartDetails/"))
                {
                    var apiResponse = await res.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject(apiResponse);
                    List<CartDetails> cartDetails = JsonConvert.DeserializeObject<List<CartDetails>>(apiResponse);
                    carts = cartDetails.Where(c => c.CartId == id).ToList();


                }
            }
        }

        private async void PaymentForm_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            serialPort1.BaudRate = 9600;
            serialPort1.PortName = "COM5";
            serialPort1.Open();

            
        }
        private async void CreditCartRead()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/CreditCarts"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject(apiResponse);
                    List<CreditCarts> creditCarts = JsonConvert.DeserializeObject<List<CreditCarts>>(apiResponse);
                    try
                    {
                        var creditcart = creditCarts.Where(c => c.CartNumber == Convert.ToInt32(cartno)).ToList();
                        if (creditcart.Count != 0)
                        {
                            label1.Text = "Lütfen Şifrenizi Giriniz ";
                            label2.Text = "";

                        }
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Geçersiz Kart !");
                    }
                }
            }
        }
        private void DisplayData_event(object sender, EventArgs e)
        {
            try
            {
                if (cartno==textBox1.Text)
                {
                    return;
                }
                else
                {
                    cartno = textBox1.Text;
                    CreditCartRead();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
 
            try
            {
                textBox1.Text = (serialPort1.ReadLine());
               

                this.Invoke(new EventHandler(DisplayData_event));
            }
            catch (Exception)
            {

                throw;
            }
            

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            decimal para = 0;
            string sifre="";
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/CreditCarts"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject(apiResponse);
                    List<CreditCarts> creditCarts = JsonConvert.DeserializeObject<List<CreditCarts>>(apiResponse);
                    var creditcart = creditCarts.Where(c =>c.CartNumber==Convert.ToInt32(textBox1.Text) && c.CartPassword == Convert.ToString(textBox2.Text)).ToList();
                    if (creditcart.Count != 0)
                    {
                        foreach (var item in creditcart)
                        {
                            para =Convert.ToDecimal( item.CardBalance);
                             sifre = Convert.ToString(item.CartPassword);
                        }
                        if (para!=p)
                        {

                            btnSales_Click?.Invoke(this, EventArgs.Empty);
                            CreditCarts cc = new CreditCarts();
                            cc.CartNumber = Convert.ToInt32(textBox1.Text);
                            cc.CardBalance = Convert.ToDecimal(para - p);
                            cc.CartPassword = Convert.ToString(sifre);
                            var convertM = JsonConvert.SerializeObject(cc);
                            var cont = new StringContent(convertM, Encoding.UTF8, "application/json");
                            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                            var respo = await httpClient.PutAsync("https://localhost:44332/api/CreditCarts", cont);
                            cartno = "";



                            //using (var res = await httpClient.GetAsync("https://localhost:44332/api/CartDetails"))
                            //{
                            //    var apiRes = await res.Content.ReadAsStringAsync();
                            //    //var result = JsonConvert.DeserializeObject(apiResponse);
                            //    List<CartDetails> cartDetails = JsonConvert.DeserializeObject<List<CartDetails>>(apiRes);
                            //    int son_id = int.Parse(cartDetails
                            //       .OrderByDescending(p => p.CartDetailsId)
                            //       .Select(r => r.CartDetailsId)
                            //       .First().ToString()
                            //           );
                            //cartdetailId = son_id;
                            //}
                        }

                                
                        else
                        {
                            MessageBox.Show("Yetersiz Bakiye !");
                            cartno = "";
                        }
                        

                    }
                    else
                    {
                        MessageBox.Show("Geçersiz Şifre !");
                    }
                    

                }
            }
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            textBox2.Text += "1";
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            textBox2.Text += "2";
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            textBox2.Text += "3";
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            textBox2.Text += "4";
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            textBox2.Text += "5";
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            textBox2.Text += "6";
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            textBox2.Text += "7";

        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            textBox2.Text += "8";
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            textBox2.Text += "9";
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            textBox2.Text += "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (textBox2.Text!="")
            {
                string degisken = textBox2.Text.Substring(0, textBox2.Text.Length - 1);

                textBox2.Text = degisken;
            }
        }
       
        string name;
        private async void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {



            



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
