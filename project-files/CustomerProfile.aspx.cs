using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // only commenet the first line away when integration
        // if statement add to every single page there nids to lock in then can see
        //Session["cust_id"] = 5;
        if (Session["cust_id"] == null && Session["emp_id"] == null && Session["dvr_id"] == null && Session["admin_id"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!Page.IsPostBack)
        {
            int cust_id = Convert.ToInt32(Session["cust_id"].ToString());//Request.QueryString["cust_id"];
            Email_order cust = new Email_order();
            Email_order data = cust.getOrder(cust_id);

            lbl_custid.Text = data.cust_id.ToString();
            tb_custname.Text = data.cust_name.ToString();
            tb_email.Text = data.email.ToString();
            tb_contactno.Text = data.contact_no.ToString();
            lbl_mbrstatus.Text = data.mbr_status.ToString();
        }
    }

    protected void btn_update_Click(object sender, EventArgs e)
    {
        int result = 0;
        Email_order cust = new Email_order();

        result = cust.CustomerUpdate(Convert.ToInt32(lbl_custid.Text), tb_custname.Text, tb_email.Text, tb_contactno.Text);
        if (result > 0)
        {
            Response.Write("<script>alert('Customer updated successfully');</script>");
        }
        else
        {
            Response.Write("<script>alert('Customer NOT updated');</script>");
        }
    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerForm.aspx");
    }
}