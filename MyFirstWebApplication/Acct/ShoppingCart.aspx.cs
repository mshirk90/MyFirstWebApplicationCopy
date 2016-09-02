using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;

namespace MyFirstWebApplication.Acct
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ShoppingCart"] != null)
            {
                CartItemList shoppingCart = (CartItemList)Session["ShoppingCart"];
                gvShoppingCart.DataSource = shoppingCart.List;
                gvShoppingCart.DataBind();

                HyperLink hprCartItems = (HyperLink)Master.FindControl("hprCartItems");
                hprCartItems.Text = shoppingCart.TotalItems.ToString();
            }
        }
    }
}