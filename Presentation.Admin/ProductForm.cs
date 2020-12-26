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
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }
        //private void ListProducts()
        //{
        //    NorthwindEntities db = new NorthwindEntities();
        //    //LINQ(Language Integrated Query)
        //    var products = (from p in db.Products
        //                    select new
        //                    {
        //                        p.ProductID,
        //                        p.ProductName,
        //                        p.UnitsInStock,
        //                        p.UnitPrice
        //                    }).ToList();
        //    dgvProducts.DataSource = products;
        //}

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ProductForm_Load(object sender, EventArgs e)
        {

        }
    }
}
