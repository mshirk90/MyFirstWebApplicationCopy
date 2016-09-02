using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;

namespace MyFirstWebApplication
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dlProducts.ItemDataBound += DlProducts_ItemDataBound;
            

            ddlCategory.SelectedIndexChanged += DdlCategory_SelectedIndexChanged;
            if (Page.IsPostBack == false)
            {
                CategoryList categories = new CategoryList();
                categories = categories.GetAll();
                ddlCategory.DataSource = categories.List;
                ddlCategory.DataBind(); // extra step required for web that isn't otherwise required in windows
            }

            if (Session["ShoppingCart"] != null)
            {
                CartItemList shoppingCart = (CartItemList)Session["ShoppingCart"];
                HyperLink hprCartItems = (HyperLink)Master.FindControl("hprCartItems");
                hprCartItems.Text = shoppingCart.TotalItems.ToString();
            }
        }

        private void DlProducts_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                 e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton AddToCart = (LinkButton)e.Item.FindControl("lnkAddToCart");
                //AddToCart.Click += AddToCart_Click;
                if (Session["Customer"] != null)
                {
                    AddToCart.Visible = true;
                }
                else
                {
                    AddToCart.Visible = false;
                }
            }
        }

        public void AddToCart_Click(object sender, EventArgs e)
        {
            MasterPage masterpage = Page.Master;
            LinkButton lbAddToCart = (LinkButton)sender;
            CartItemList shoppingCart = null;
            Guid productId = new Guid(lbAddToCart.Attributes["productid"]);
            String name = lbAddToCart.Attributes["name"];
            Decimal price = Convert.ToDecimal(lbAddToCart.Attributes["price"]);

            if (Session["ShoppingCart"] == null)
            {
                shoppingCart = new CartItemList();
            }
            else
            {
                shoppingCart = (CartItemList)Session["ShoppingCart"];
            }

            if (shoppingCart.Exists(productId))
            {
                shoppingCart.IncrementQuantity(productId);
            }
            else
            {
                CartItem item = new CartItem();
                item.Id = productId;
                item.Name = name;
                item.Price = price;
                shoppingCart.List.Add(item);
            }
            Session["ShoppingCart"] = shoppingCart;

            if (shoppingCart != null)
            {
                HyperLink hprCartItems = (HyperLink)Master.FindControl("hprCartItems");
                hprCartItems.Text = shoppingCart.TotalItems.ToString();
            }
        }

        private void DdlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIndexChanged(ddlCategory.SelectedValue);
        }

        private void SelectedIndexChanged(string catId)
        {
            Guid categoryId = new Guid(catId);
            ProductList products = new ProductList();
            products.Path = Server.MapPath("UploadedImages");
            products = products.GetByCategoryId(categoryId);

            dlProducts.DataSource = products.List;
            dlProducts.DataBind();

        }
    }
}