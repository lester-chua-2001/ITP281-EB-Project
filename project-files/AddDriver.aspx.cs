using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddDriver : System.Web.UI.Page
{
    Driver dvr = null;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Adddvr_Click(object sender, EventArgs e)
    {
        int result = 0;

        Driver dvr = new Driver(tb_dvrname.Text, tb_email.Text, tb_contact.Text, tb_password.Text);
        result = dvr.DriverInsert();

        if (result > 0)
        {
            Response.Write("<script>alert('Driver Account Created!');</script>");
        }
        else { Response.Write("<script>alert('Driver Account NOT Created!');</script>"); }

        Response.Redirect("AdminHome.aspx");
    }
}