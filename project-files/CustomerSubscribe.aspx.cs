using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerSubscribe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["cust_id"] == null && Session["emp_id"] == null && Session["dvr_id"] == null && Session["admin_id"] == null)
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void Subcribe_Click(object sender, EventArgs e)
    {
        int result = 0;

        Customer cust = new Customer();

        result = cust.CustomerSubscribe("Subscriber", Session["cust_id"].ToString());

        if (result > 0)
        {
            Response.Write("<script>alert('Subcription successful');</script>");
        }
        else { Response.Write("<script>alert('Subscription NOT successful');</script>"); }

        Response.Redirect("CustomerForm.aspx");
    }
}