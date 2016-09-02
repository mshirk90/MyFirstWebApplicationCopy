using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
using EmailHelper;

namespace MyFirstWebApplication.Acct
{
    public partial class Register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Customer customer = null;
            if (Session["Customer"] == null)
            {
                customer = new Customer();
            }
            else
            {
                customer = (Customer)Session["Customer"];
            }

            try
            {
                if (customer.EmailSent == false)
                {
                    customer.Register(txtFirstName.Text, txtLastName.Text, txtEmail.Text);
                    Session.Add("Customer", customer);
                }
            }
            catch (Exception ex)
            {
                // show the broken rules
                for (Int32 i = 0; i < customer.BrokenRules.Count; i++)
                {
                    CustomValidator cvRules = new CustomValidator();
                    cvRules.ErrorMessage = customer.BrokenRules.List[i].Rule;
                    cvRules.Enabled = true;
                    cvRules.IsValid = false;
                    cvRules.ValidationGroup = "vgRegister";
                    Page.Validators.Add(cvRules);
                    // customer.BrokenRules.List
                }
            }
            try
            {
                if (Page.IsValid == true)
                {
                    if (customer.EmailSent == false)
                    {
                        Email.SendEmail(customer.Email, "Registration Password", "Your password is: " + customer.Password);
                        lblStatus.Text = "Please check your email for creditials.";
                        customer.EmailSent = true;
                        customer.Save();
                    }
                    else
                    {
                        lblStatus.Text = "Email already sent.";
                    }
                }
            }
            catch(Exception exEmail)
            {
                lblStatus.Text = exEmail.Message;
            }
        }
    }
}