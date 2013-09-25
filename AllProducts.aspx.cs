using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TFSDemo
{
    public partial class AllProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = ((DataLayer)Application["DataLayer"]).GetAllProducts();
            string ProductsTable = "<table><tr><td><B>Product ID</B></td><td><B>Product Name</B></td><td><B>Description</B></td></tr>";

            foreach (DataRow dr in dt.Rows)
            {
                ProductsTable += "<tr><td>" + dr[0] + "</td><td>" + dr[1] + "</td><td>" + dr[2] + "</td></tr>";
            }
            ProductsTable += "</table>";
            tblProducts.Text = ProductsTable;
        }
    }
}