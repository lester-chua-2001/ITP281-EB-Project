using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RegistrationForm : System.Web.UI.Page
{
    Customer cust = null;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        Session["CustName"] = tb_custname.Text;
        Session["Contact"] = tb_contact.Text;
        Session["Email"] = tb_email.Text;

        int result = 0;

        Customer cust = new Customer(tb_custname.Text, tb_email.Text, tb_contact.Text, tb_password.Text);
        result = cust.CustomerInsert();

        if (result > 0)
        {
            Response.Write("<script>alert('Insert successful');</script>");
        }
        else { Response.Write("<script>alert('Insert NOT successful');</script>"); }

        Response.Redirect("Login.aspx");
    }
}