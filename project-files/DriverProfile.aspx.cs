using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DriverProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["cust_id"] == null && Session["emp_id"] == null && Session["dvr_id"] == null && Session["admin_id"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!Page.IsPostBack)
        {
            int dvr_id = Convert.ToInt32(Session["dvr_id"].ToString());//Request.QueryString["dvr_id"];
            Email_orderDP dvr = new Email_orderDP();
            Email_orderDP data = dvr.getOrder(dvr_id);

            lbl_dvr_id.Text = data.dvr_id.ToString();
            tb_dvr_name.Text = data.dvr_name.ToString();
            tb_email.Text = data.email.ToString();
            tb_password.Text = data.password.ToString();
            tb_contact_no.Text = data.contact_no.ToString();
        }
    }

    protected void btn_update_Click(object sender, EventArgs e)
    {
        int result = 0;
        Email_orderDP dvr = new Email_orderDP();

        result = dvr.DriverUpdate(Convert.ToInt32(lbl_dvr_id.Text), tb_dvr_name.Text, tb_email.Text, tb_password.Text);
        if (result > 0)
        {
            Response.Write("<script>alert('Driver updated successfully');</script>");
        }
        else
        {
            Response.Write("<script>alert('Driver NOT updated');</script>");
        }
    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("DriverHome.aspx");
    }
}