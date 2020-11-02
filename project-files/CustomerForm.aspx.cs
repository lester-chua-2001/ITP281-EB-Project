using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["cust_id"] == null && Session["emp_id"] == null && Session["dvr_id"] == null && Session["admin_id"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!Page.IsPostBack)
        {
            int cust_id = Convert.ToInt32(Session["cust_id"].ToString());
            Email_order cust = new Email_order();
            Email_order data = cust.getOrder(cust_id);
            lbl_custname.Text = null;
            lbl_custname.Text = data.cust_name.ToString();

        }
    }
    protected void btn_trackorder_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerOrders.aspx");
    }

    protected void btn_CreateOrder_Click1(object sender, EventArgs e)
    {
        Response.Redirect("CustomerCreate.aspx");
    }
}