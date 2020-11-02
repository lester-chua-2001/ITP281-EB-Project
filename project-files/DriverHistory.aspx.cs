using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

[System.Web.Script.Services.ScriptService]
public partial class DriverHistory : System.Web.UI.Page
{
    OrderDriver aOrder = new OrderDriver();
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
        List<OrderDriver> orderList = new List<OrderDriver>();
        orderList = aOrder.getOrderAll();
        gvnew.DataSource = orderList;
        gvnew.DataBind();
    }



    protected void gvnew_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvnew.EditIndex = e.NewEditIndex;
        bind();
    }



    protected void gvnew_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvnew.EditIndex = -1;
        bind();
    }


    protected void gvnew_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int result = 0;
        OrderHistory order = new OrderHistory();
        GridViewRow row = (GridViewRow)gvnew.Rows[e.RowIndex];
        string order_id = gvnew.DataKeys[e.RowIndex].Value.ToString();
        string pickupdvr = ((TextBox)row.Cells[1].Controls[0]).Text;
        string deliverydvr = ((TextBox)row.Cells[2].Controls[0]).Text;
        string order_status = ((TextBox)row.Cells[3].Controls[0]).Text;
        string payment_info = ((TextBox)row.Cells[4].Controls[0]).Text;
        string cust_id = ((TextBox)row.Cells[5].Controls[0]).Text;
        string total_price = ((TextBox)row.Cells[6].Controls[0]).Text;
        string todate = ((TextBox)row.Cells[7].Controls[0]).Text;
        string totime = ((TextBox)row.Cells[8].Controls[0]).Text;
        string frodate = ((TextBox)row.Cells[9].Controls[0]).Text;
        string frotime = ((TextBox)row.Cells[10].Controls[0]).Text;
        string pickupaddrid = ((TextBox)row.Cells[11].Controls[0]).Text;
        string deliveryaddrid = ((TextBox)row.Cells[12].Controls[0]).Text;
        result = order.Orderupdate(order_id, pickupdvr, deliverydvr, order_status, payment_info, cust_id, total_price, todate, totime, frodate, frotime, pickupaddrid, deliveryaddrid);
        if (result > 0)
        {
            Response.Write("<script>alert('Product updated successfully');</script>");
        }
        else
        {
            Response.Write("<script>alert('Product NOT updated');</script>");
        }
        gvnew.EditIndex = -1;
        bind();
    }

    protected void gvnew_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvnew.SelectedRow;

        int orderID = Convert.ToInt32(row.Cells[0].Text);

        Response.Redirect("DriverDetail.aspx?orderID=" + orderID);
    }


    protected void btn_Accepted_Click(object sender, EventArgs e)
    {
        // Get button from the gridview, sender is the object of the butotn
        Button btn = (Button)sender;

        // Gets the row of the button in the gridview
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;


        // Gets the order id from the gridview
        string order_id = gvr.Cells[0].Text;

        // Create object and use the method
        OrderDriver orders = new OrderDriver();
        int result = orders.orderUpdateStatus(order_id, "Accepted");

        string email;
        /*
         * Open database and using customer pk to find it 
         *         string customer_ID = gvr.Cells[3].Text; 
         *         customer.getcustomer(customer_Id); //get single customer data out from database
         *         email = customer.email.tostring(); // make string email to the customer email
         * */
        Email_orderDriver Eo = new Email_orderDriver();
        string customer_ID = gvr.Cells[3].Text;
        Email_orderDriver customer = Eo.getOrder(customer_ID);
        email = customer.email.ToString();

        //Response.Write(String.Format("<script>alert('{0}');</script>", email));

        if (result > 0)
        { // If validated properly
            Response.Write("<script>alert('Product updated');</script>");

            //ADD EMAIL HERE
            string psender = "ebusinessnyp@gmail.com";
            string subject = "Confirmation of order";
            string body = "Please check your collection and delivery time.";

            try
            {

                MailMessage message = new MailMessage(psender, email, subject, body);
                message.IsBodyHtml = true;

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("ebusinessnyp@gmail.com", "Ebusiness");
                client.Send(message);

            }
            catch (Exception ex)
            {

            }
        }
        else
        { // If something went wrong
            Response.Write("<script>alert('Product NOT updated');</script>");
        }

        //Reload the table
        bind(); // NOTE THAT WHEN YOU UPDATE TO ACCEPTED, IT WILL NOT SHOW ON DRIVER.ASPX BECAUSE BIND() VARIABLE IS "NEW" (Line 21)


        //NEW PLAN
        //click pickup update status to collected

        //BELOW IS OLD PLAN
        /*
        Session["orderID"] = 1; //change 1 to order id of the row you click 
        Session["hello"] = "pickup";


        //in other aspx.cs page_load
        if(Session["hello"].Equals("pickup"))
        {
            //display all the pickup info
        }
        else if (Session["hello"].Equals("delivery"))
        { //display all the pickup info

        }
        */



    }


}