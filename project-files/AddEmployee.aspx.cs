using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddEmployee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["cust_id"] == null && Session["emp_id"] == null && Session["dvr_id"] == null && Session["admin_id"] == null)
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void Addemp_Click(object sender, EventArgs e)
    {
        int result = 0;

        Employee emp = new Employee(tb_empname.Text, tb_email.Text, tb_contact.Text, tb_password.Text);
        result = emp.EmployeeInsert();

        if (result > 0)
        {
            Response.Write("<script>alert('Employee Added');</script>");
        }
        else { Response.Write("<script>alert('Employee NOT Added');</script>"); }

        Response.Redirect("AdminHome.aspx");
    }
}