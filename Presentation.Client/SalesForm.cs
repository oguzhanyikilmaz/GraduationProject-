using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Client
{
    public partial class SalesForm : Form
    {
        public SalesForm()
        {
            InitializeComponent();
        }
        int toplam = 0;

        private void SalesForm_Load(object sender, EventArgs e)
        {

        }
        private void Total()
        {
            for (int i = 0; i < dgvProducts.Rows.Count; ++i)
            {
                toplam += Convert.ToInt32(dgvProducts.Rows[i].Cells[2].Value);
            }
            lblTotal.Text = toplam.ToString();
        }

        private void pBoxDelete_Click(object sender, EventArgs e)
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
        }
    }
}
