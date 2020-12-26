using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Admin
{
    public partial class AdminControl : Form
    {
        private int childFormNumber = 0;

        public AdminControl()
        {
            InitializeComponent();
        }

        private void GetForm(Form form)
        {
            pnlForm.Controls.Clear();
            form.MdiParent = this;
            form.FormBorderStyle = FormBorderStyle.None;
            pnlForm.Controls.Add(form);
            form.Show();
        }
        private void ürünİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm();
            GetForm(productForm);
        }

        private void ürünlerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
