using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerConfirm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Consumer cons = new Consumer();
        cons = (Consumer)Session["Create"];
        lbl_TotalCost.Text = "$" + String.Format("{0:n2}", cons.getTotalCost());
        lbl_DTime.Text = cons.DTime.ToString();
        lbl_PTime.Text = cons.PTime.ToString();
        lbl_DDate.Text = cons.DDate.ToString();
        lbl_PDate.Text = cons.PDate.ToString();
        lbl_PAddress.Text = cons.PAddress.ToString();
        lbl_DAddress.Text = cons.DAddress.ToString();

    }

    protected void btn_Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerCreate.aspx");
    }

    protected void btn_payCard_Click(object sender, EventArgs e)
    {
        Response.Redirect("Payment.aspx");
    }

    protected void btn_payCash_Click(object sender, EventArgs e)
    {
        Consumer cons = (Consumer)Session["Create"];
        string cust_id = Session["cust_id"].ToString();

        Orders order = new Orders(Orders.getNewOrderId(), cons.getTotalCost(), "Unassigned", "Unassigned", cons.DDate.ToString(), cons.DTime.ToString(), cons.PDate.ToString(), cons.PTime.ToString(), "new", "Cash", cons.PAddress.ToString(), cons.DAddress.ToString());
        Orders.OrderInsert(order, cust_id);
        Consumer.OrderItemInsert(cons, order.order_id);
        Response.Redirect("CustomerOrders.aspx");
    }

}