using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EmployeeView : System.Web.UI.Page
{
    View aOrder = new View();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["cust_id"] == null && Session["emp_id"] == null && Session["dvr_id"] == null && Session["admin_id"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            bind();
        }
    }

    protected void bind()
    {
        int id = Convert.ToInt32(Request.QueryString["orderID"]);
        List<View> ViewList = new List<View>();
        ViewList = aOrder.getOrderById(id);
        gvView.DataSource = ViewList;
        gvView.DataBind();
    }
}