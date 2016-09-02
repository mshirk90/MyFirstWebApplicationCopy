using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
using System.Web.Security;
using EmailHelper;

namespace MyFirstWebApplication.Acct
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnForgotPassword_Click(object sender, EventArgs e)
        {
            try
            {
                Customer customer = new Customer();
                customer = customer.Exists(txtEmail.Text);

                if (customer != null)
                {
                    String password = Membership.GeneratePassword(12, 1);
                    customer.Password = password;
                    customer.IsPasswordPending = true;
                    customer.Save();
                    Email.SendEmail(customer.Email, "Here is your Temporary Password", "Your password is: " + customer.Password);

                    DisplayEmail.Visible = true;
                }
                else
                {
                    ErrorMessage.Visible = true;
                }
                //6 CHANGE THE CODE IN THE LOGIN FORM TO REDIRECT TO CHANGE PASSWORD
                //  WHEN THE ISPASSWORDPENDING IS SET TO TRUE
            }
            catch (Exception ex)
            {
                ErrorMessage.Visible = true;
                FailureText.Text = ex.Message;
            }
        }
    }
}