using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login: System.Web.UI.Page
{
    Customer cust = new Customer();
    Employee emp = new Employee();
    Driver dvr = new Driver();
    Admin adm = new Admin();
    //
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void S_Click(object sender, EventArgs e)
    {

        int cust_id = cust.Authentication(tb_email.Text,tb_password.Text);
        int emp_id = emp.Authentication(tb_email.Text, tb_password.Text);
        int dvr_id = dvr.Authentication(tb_email.Text, tb_password.Text);
        int admin_id = adm.Authentication(tb_email.Text, tb_password.Text);


        if (cust_id > 0)
        {
            Session["cust_id"] = cust_id;
            Response.Redirect("CustomerForm.aspx");
        }
        else if(emp_id > 0)
        {
            Session["emp_id"] = emp_id;
            Response.Redirect("EmployeeHome.aspx");
        }
        else if(dvr_id > 0)
        {
            Session["dvr_id"] = dvr_id;
            Response.Redirect("DriverHome.aspx");
        }
        else if(admin_id > 0)
        {
            Session["admin_id"] = admin_id;
            Response.Redirect("AdminHome.aspx");
        }

        else
        {
            Lbl_Invalid.Text = "Sorry, login failed. Please try again!";
        }

    }
}