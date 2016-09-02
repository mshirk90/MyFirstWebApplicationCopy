using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;

namespace MyFirstWebApplication.Acct
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Customer"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            Customer customer = (Customer)Session["Customer"];

            if(txtOldPassword.Text == customer.Password)
            {
                if(txtNewPassword.Text == txtConfirmPassword.Text)
                {
                    customer.Password = txtNewPassword.Text;
                    if (customer.IsSavable() == true)
                    {
                        customer.Save();
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        // SHOW BROKEN RULES
                        foreach(BrokenRule br in customer.BrokenRules.List)
                        {
                            AddCustomError(br.Rule);
                        }
                    }
                }
            }
        }
        private void AddCustomError(String message)
        {
            CustomValidator cv = new CustomValidator();
            cv.ErrorMessage = message;
            cv.Enabled = true;
            cv.ValidationGroup = "vgChangePassword";
            cv.IsValid = false;
            Page.Validators.Add(cv);
        }
    }
}