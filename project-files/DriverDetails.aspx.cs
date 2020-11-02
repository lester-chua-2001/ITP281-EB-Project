using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DriverDetails : System.Web.UI.Page
{
    Driver advr = new Driver();
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
        List<Driver> dvrList = new List<Driver>();
        dvrList = advr.getDriverAll();
        gvDriver.DataSource = dvrList;
        gvDriver.DataBind();
    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("Admin.aspx");
    }

    protected void btn_addDriver_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AddDriver.aspx");
    }

    protected void gvDriver_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvDriver.EditIndex = e.NewEditIndex;
        bind();
    }

    protected void gvDriver_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvDriver.EditIndex = -1;
        bind();

    }

    protected void gvDriver_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int result = 0;
        Driver dvr = new Driver();
        GridViewRow row = (GridViewRow)gvDriver.Rows[e.RowIndex];

        string eId = ((TextBox)row.Cells[0].Controls[0]).Text;
        string eName = ((TextBox)row.Cells[1].Controls[0]).Text;
        string eEmail = ((TextBox)row.Cells[2].Controls[0]).Text;
        string eNo = ((TextBox)row.Cells[3].Controls[0]).Text;
        result = dvr.DriverUpdate(eId, eName, eEmail, eNo);
        if (result > 0)
        {
            Response.Write("<script>alert('Driver updated successfully');</script>");
        }
        else
        {
            Response.Write("<script>alert('Driver NOT updated');</script>");
        }
        gvDriver.EditIndex = -1;
        bind();
    }

    protected void gvDriver_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int result = 0;
        Driver dvr = new Driver();
        string categoryID = gvDriver.DataKeys[e.RowIndex].Value.ToString();
        result = dvr.DriverDelete(categoryID);
        if (result > 0)
        {
            Response.Write("<script>alert('Driver Remove successfully');</script>");
        }
        else
        {
            Response.Write("<script>alert('Driver Removal NOT successful');</script>");
        }
        Response.Redirect("DriverDetails.aspx");
    }
}
