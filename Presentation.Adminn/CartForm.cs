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
    public partial class CartForm : Form
    {
        public CartForm()
        {
            InitializeComponent();
        }

        private async void dgvProducts_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44332/api/Carts"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject(apiResponse);
                    List<Cart> carts = JsonConvert.DeserializeObject<List<Cart>>(apiResponse);
                    foreach (var item in carts)
                    {
                        if (item.CartId == Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["CartId"].Value))
                        {
                            txtOrderId.Text = item.CartId.ToString();
                            txtOrderDate.Text = item.SellBy.ToString();

                        }
                    }


                }
            }
        }

        private void CartForm_Load(object sender, EventArgs e)
        {

        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtOrderDate_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
