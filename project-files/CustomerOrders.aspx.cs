using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerOrders : System.Web.UI.Page
{
    CustomerView aOrders = new CustomerView();
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
        int id = Convert.ToInt32(Session["cust_id"]);
        List<CustomerView> orderList = new List<CustomerView>();
        orderList = aOrders.getOrdersAll(id);
        gv_ViewOrder.DataSource = orderList;
        gv_ViewOrder.DataBind();
    }


    protected void gv_ViewOrder_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gv_ViewOrder.SelectedRow;

        int order_id = Convert.ToInt32(row.Cells[0].Text);

        Response.Redirect("CustomerOrderItems.aspx?order_id=" + order_id);
    }

    protected void gv_ViewOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int result = 0;
        CustomerView ord = new CustomerView();
        string categoryID = gv_ViewOrder.DataKeys[e.RowIndex].Value.ToString();
        result = ord.OrderDelete(categoryID);
        if (result > 0)
        {
            Response.Write("<script>alert('Product Remove successfully');</script>");
        }
        else
        {
            Response.Write("<script>alert('Product Removal NOT successfully');</script>");
        }
        Response.Redirect("CustomerOrders.aspx");
    }



    protected void btn_home_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerForm.aspx");
    }
}