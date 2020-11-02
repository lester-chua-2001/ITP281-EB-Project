using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerDetailsView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["cust_id"] == null && Session["emp_id"] == null && Session["dvr_id"] == null && Session["admin_id"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!Page.IsPostBack)
        {
            string CustName = Request.QueryString["cust_id"];
            Customer cust = new Customer();
            Customer data = cust.getCustomer(CustName);

            tb_regdatetime.Text = DateTime.Now.ToString();
            tb_custid.Text = data.Customer_ID.ToString();
            tb_custname.Text = data.Customer_Name.ToString();
            tb_email.Text = data.Customer_Email.ToString();
            tb_contactno.Text = data.Contact_No.ToString();
            ddl_mbrstatus.Text = data.Membership_Status.ToString();
            tb_password.Text = data.password.ToString();
        }
    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerDetails.aspx");
    }

    protected void btn_update_Click(object sender, EventArgs e)
    {
        int result = 0;

        Customer cust = new Customer();

        result = cust.CustomerUpdate(tb_custid.Text, tb_custname.Text, tb_email.Text, tb_contactno.Text, ddl_mbrstatus.Text);
        if (result > 0)
        {
            Response.Write("<script>alert('Customer updated successfully');</script>");
        }
        else
        {
            Response.Write("<script>alert('Customer NOT updated');</script>");
        }
    }
}