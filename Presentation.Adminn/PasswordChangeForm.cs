using Newtonsoft.Json;
using Presentation.Adminn.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Adminn
{
    public partial class PasswordChangeForm : Form
    {
        public PasswordChangeForm()
        {
            InitializeComponent();
        }
        public bool Gonder( string icerik)
        {
            
            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("mailadresiniz@gmail.com");//buraya kendi gmail hesabınız
            //
            ePosta.To.Add(txtEmail.Text);//bura şifre unutanın maili textboxdan çekdiniz.
            ;

            ePosta.Subject = "Aktivasyon Kodu"; //butonda veri tabanı çekdikden sonra aldımız değer konu değeri
            //
            ePosta.Body = icerik;  // buda aktivasyon kodu
            //
            SmtpClient smtp = new SmtpClient();
            //
            smtp.Credentials = new System.Net.NetworkCredential("oguzhanyklmz27@gmail.com", "bayer1977");
            //kendi gmail hesabiniz var şifresi
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            object userState = ePosta;
            bool kontrol = true;
            try
            {
                smtp.SendAsync(ePosta, (object)ePosta);
            }
            catch (SmtpException ex)
            {
                kontrol = false;
                System.Windows.Forms.MessageBox.Show(ex.Message, "Mail Gönderme Hatasi");
            }
            return kontrol;

        }
        private void PasswordChangeForm_Load(object sender, EventArgs e)
        {

        }

        private async void btnGonder_Click(object sender, EventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/Users"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject(apiResponse);
                    List<Users> users = JsonConvert.DeserializeObject<List<Users>>(apiResponse);
                    var result = users.Where(u =>  u.Email == txtEmail.Text).ToList();
                    if (result.Count == 0)
                    {
                        MessageBox.Show("Kullanıcı Adı veya Mail Hatalı");
                    }
                    else
                    {
                        string a;

                        char[] harfler = { 'a', 'b', 'c', 'd', 'e', 'g', 'h', 'ş', 'v', 'n', 'm', 'o', 'ı', 'u', 't', 'y', 'r', 'p', 's', 'z', 'x', 'k', 'l' };

                        int[] sayılar = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

                        Random r = new Random();

                        a = Convert.ToString(harfler[r.Next(22)]) + Convert.ToString(harfler[r.Next(22)]) + Convert.ToString(sayılar[r.Next(9)]) + Convert.ToString(harfler[r.Next(22)]) + Convert.ToString(sayılar[r.Next(9)]) + Convert.ToString(sayılar[r.Next(9)]);
                        Gonder(a);
                        ActivisionCodeForm activisionCodeForm = new ActivisionCodeForm(a);
                        activisionCodeForm.Show();
                        this.Hide();

                    }
                }
            }
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
