using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using BusinessObjects;

namespace MyFirstWebApplication.Admin
{
    public partial class Administration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack == false)
            {
                CategoryList categories = new CategoryList();
                categories = categories.GetAll();
                ddlCategory.DataSource = categories.List;
                ddlCategory.DataBind(); // extra step required for web that isn't otherwise required in windows
            }
            
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (fuProduct.HasFile == true)
                {
                    String filepath = Server.MapPath("..//UploadedImages");
                    filepath = Path.Combine(filepath, fuProduct.FileName);
                    fuProduct.SaveAs(filepath);
                    lblStatus.Text = String.Format("Recieved {0} Content Type {1} Length {2}",
                        fuProduct.FileName, fuProduct.PostedFile.ContentType,
                        fuProduct.PostedFile.ContentLength);
                    Product product = new Product();
                    product.CategoryID = new Guid(ddlCategory.SelectedValue.ToString());
                    product.Name = txtName.Text;
                    product.Description = txtDescription.Text;
                    product.Price = Convert.ToDecimal(txtPrice.Text);
                    product.FilePath = filepath;

                    if(product.IsSavable() == true)
                    {
                        product = product.Save();
                    }
                }
            }
            catch(Exception ex)
            {
                lblStatus.Text = ex.Message;    
            }
            
        }
    }
}