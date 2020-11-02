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
        if (!IsPostBack)
        {
            Consumer cons = new Consumer();
            cons = (Consumer)Session["Create"];
            string cust_id = Session["cust_id"].ToString();
            SqlDataSource1.SelectCommand = "SELECT [card_no] FROM [payment] WHERE [cust_id]=" + cust_id;
            setCardDetails(null);
        }


    }

    protected void btn_Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerConfirm.aspx");
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {

        Consumer cons = (Consumer)Session["Create"];
        string cust_id = Session["cust_id"].ToString();

        Orders order = new Orders(Orders.getNewOrderId(), cons.getTotalCost(), "Unassigned", "Unassigned", cons.DDate.ToString(), cons.DTime.ToString(), cons.PDate.ToString(), cons.PTime.ToString(), "new", "Card", cons.PAddress.ToString(), cons.DAddress.ToString());
        Orders.OrderInsert(order, cust_id);
        Consumer.OrderItemInsert(cons, order.order_id);
        Response.Redirect("CustomerOrders.aspx");
    }

    protected void ddl_payment_SelectedIndexChanged(object sender, EventArgs e)
    {
        setCardDetails(ddl_payment.SelectedItem.Value);
    }

    protected void setCardDetails(string card_no)
    {
        string cust_id = Session["cust_id"].ToString();
        Payment payment = Payment.getPaymentByCardNo(cust_id, card_no);
   //     lbl_cvvNo.Text = payment.cvv_no;
        lbl_ccExpiry.Text = payment.cc_expiry;
    }

}