using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerPayment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["cust_id"] == null && Session["emp_id"] == null && Session["dvr_id"] == null && Session["admin_id"] == null)
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void btn_Add_Click(object sender, EventArgs e)
    {
        string cust_id = Session["cust_id"].ToString();
        string postalCode = tb_postalCode.Text;
        string address = tb_address.Text;

        Address newAddress = new Address(postalCode, address, cust_id);
        Address.addressInsert(newAddress);

        Response.Redirect("CustomerAddressView.aspx");
    }

   
}