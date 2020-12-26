using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Presentation.Adminn
{
    public partial class AdminControlsForm : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SenMessage(System.IntPtr hwnd,int wmsg,int wparam,int lparam);

        public AdminControlsForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Menu.Width == 250)
            {
                Menu.Width = 51;
            }
            else
            {
                Menu.Width = 250;
            }
        }

        private void pctBoxCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pctBoxMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            pctBoxMaximize.Visible = false;
            pictureBox4.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            pctBoxMaximize.Visible = true;
            pictureBox4.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SenMessage(this.Handle,0x112,0xf012,0);
        }
        private void FormInPanel(object form)
        {
            if (this.panelContainer.Controls.Count>0)
            {
                this.panelContainer.Controls.RemoveAt(0);
            }
            Form f = form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panelContainer.Controls.Add(f);
            this.panelContainer.Tag = f;
            f.Show();
        }
        private void btnProducts_Click(object sender, EventArgs e)
        {
            FormInPanel( new ProductForm());
        }

        private void btnStockControl_Click(object sender, EventArgs e)
        {
            FormInPanel(new StockForm());
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            FormInPanel(new CategoryForm());
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            FormInPanel(new ProductSold());
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            FormInPanel(new OrdersForm());
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            FormInPanel(new UsersForm());
        }

        private void AdminControlsForm_Load(object sender, EventArgs e)
        {
            FormInPanel(new ReportsForm());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormInPanel(new ReportsForm());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {   
            AdminLoginForm adminLoginForm = new AdminLoginForm();
            adminLoginForm.Show();
            this.Hide();
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            FormInPanel(new InvoiceForm());
        }
    }
}
