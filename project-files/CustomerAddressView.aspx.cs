using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerAddressView : System.Web.UI.Page
{
    
    AddressView aAddress = new AddressView();
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
        List<AddressView> addressList = new List<AddressView>();
        addressList = aAddress.getAddressAll(id);
        gv_ViewAddress.DataSource = addressList;
        gv_ViewAddress.DataBind();
    }


    protected void btn_home_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerForm.aspx");
    }
    protected void gv_ViewAddress_SelectedIndexChanged1(object sender, EventArgs e)
    {
        GridViewRow row = gv_ViewAddress.SelectedRow;

        int address_id = Convert.ToInt32(row.Cells[0].Text);

        Response.Redirect("CustomerAddressView.aspx?address_id=" + address_id);
    }
    protected void gv_ViewAddress_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int result = 0;
        AddressView addr = new AddressView();
        string categoryID = gv_ViewAddress.DataKeys[e.RowIndex].Value.ToString();
        result = addr.AddressDelete(categoryID);
       
        Response.Redirect("CustomerAddressView.aspx");
    }



    
}