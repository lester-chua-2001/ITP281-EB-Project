using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerOrderItems : System.Web.UI.Page
{
    Items bOrder = new Items();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            bind();
        }
    }
    protected void bind()
    {
        int id = Convert.ToInt32(Request.QueryString["order_id"]);
        List<Items> orderItemList = new List<Items>();
        orderItemList = bOrder.getOrderItems(id);
        gv_ViewOrderItems.DataSource = orderItemList;
        gv_ViewOrderItems.DataBind();
    }

    protected void btn_return_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerOrders.aspx");
    }
}
