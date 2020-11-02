using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class CustomerCreate : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["cust_id"] == null && Session["emp_id"] == null && Session["dvr_id"] == null && Session["admin_id"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            string cust_id = Session["cust_id"].ToString();
            SqlDataSource1.SelectCommand = "SELECT [address] FROM [address] WHERE [cust_id]=" + cust_id;
            SqlDataSource2.SelectCommand = "SELECT [address] FROM [address] WHERE [cust_id]=" + cust_id;
            setAddress(null);
        }
    }
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        DateTime pastday = e.Day.Date;
        DateTime date = DateTime.Now;
        int year = date.Year;
        int month = date.Month;
        int day = date.Day;
        DateTime today = new DateTime(year, month, day);
        if (pastday.CompareTo(today) < 0)
        {
            e.Cell.BackColor = System.Drawing.Color.Gray;
            e.Day.IsSelectable = false;
        }
    }
    protected void Calendar2_DayRender(object sender, DayRenderEventArgs e)
    {
        DateTime pastday = e.Day.Date;
        DateTime date = DateTime.Now;
        int year = date.Year;
        int month = date.Month;
        int day = date.Day;
        DateTime today = new DateTime(year, month, day);
        if (pastday.CompareTo(today) < 0)
        {
            e.Cell.BackColor = System.Drawing.Color.Gray;
            e.Day.IsSelectable = false;
        }
    }
    protected void btn_Next_Click(object sender, EventArgs e)
    {
        string Tee = tb_Tee.Text;
        string Shorts = tb_Shorts.Text;
        string Jacket = tb_Jackets.Text;
        string Formal = tb_Formal.Text;
        string Jeans = tb_Jeans.Text;
        string Bed = tb_Bed.Text;
        string Curtain = tb_Curtain.Text;
        string DTime = tb_delv.Text;
        string PTime = tb_pckup.Text;

        string DDate = Calendar1.SelectedDate.Date.ToString("dd/MM/yyyy");

        string PDate = Calendar2.SelectedDate.Date.ToString("dd/MM/yyyy");

        string PAddress = ddl_PAddress.SelectedItem.Value;
        string DAddress = ddl_DAddress.SelectedItem.Value;




        Consumer cons = new Consumer(Tee, Shorts, Jacket, Formal, Jeans, Bed, Curtain, DDate, DTime, PDate, PTime, PAddress, DAddress);
        Session["Create"] = cons;

        Response.Redirect("CustomerConfirm.aspx");
    }








    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {

    }

    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {

    }

    protected void Calendar1_SelectionChanged1(object sender, EventArgs e)
    {

    }



    protected void ddl_PAddress_SelectedIndexChanged(object sender, EventArgs e)
    {
        setAddress(ddl_PAddress.SelectedItem.Value);
    }

    protected void ddl_Daddress_SelectedIndexChanged(object sender, EventArgs e)
    {
        setAddress(ddl_DAddress.SelectedItem.Value);
    }
    protected void setAddress(string address)
    {
        string cust_id = Session["cust_id"].ToString();
        Address addr = Address.getCustomerAddress(cust_id, address);

    }

    protected void SqlDataSource2_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }

    protected void tb_delv_TextChanged(object sender, EventArgs e)
    {

    }
}