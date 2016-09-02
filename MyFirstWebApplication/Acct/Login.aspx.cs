using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
using System.Web.UI.HtmlControls;

namespace MyFirstWebApplication.Acct
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // READ THE COOKIE
            if(Request.Cookies["CustomerCookies"] != null && Convert.ToBoolean(Request.Cookies["CustomerCookies"]["RememberMe"]) == true)
            {
                txtEmail.Text = Request.Cookies["CustomerCookies"]["UserName"];
                txtPassword.Text = Request.Cookies["CustomerCookies"]["Password"];
                CustomerLogin();
            }
        }

        private void CustomerLogin()
        {
            Customer customer = new Customer();
            customer = customer.Login(txtEmail.Text, txtPassword.Text);

            if (customer == null)
            {
                lblStatus.Text = "Invalid Username or Password";
            }
            else if (customer.Version == 0 || customer.IsPasswordPending == true)
            {
                Session.Add("Customer", customer);
                Response.Redirect("ChangePassword.aspx");
            }
            else
            {
                if (this.RememberMe.Checked == true)
                {
                    Response.Cookies["CustomerCookies"]["UserName"] = txtEmail.Text;
                    Response.Cookies["CustomerCookies"]["Password"] = txtPassword.Text;
                    Response.Cookies["CustomerCookies"]["FirstName"] = customer.FirstName;
                    Response.Cookies["CustomerCookies"]["LastName"] = customer.LastName;
                    Response.Cookies["CustomerCookies"]["RememberMe"] = "true";

                    Response.Cookies["CustomerCookies"]["LastVisited"] = DateTime.Now.ToLongDateString();
                    Response.Cookies["CustomerCookies"].Expires = DateTime.MaxValue;
                }
                ((HtmlGenericControl)this.Master.FindControl("ddlPreferences")).Visible = false;
                Session.Add("Customer", customer);
                Response.Redirect("~/Default.aspx");
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            CustomerLogin();
        }
    }
}