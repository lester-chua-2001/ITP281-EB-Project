using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class EmployeeHome : System.Web.UI.Page
{
    Order aOrder = new Order();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["cust_id"] == null && Session["emp_id"] == null && Session["dvr_id"] == null && Session["admin_id"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            bind();
            if (!Page.IsPostBack)
            {
                DropDownList1.Items.Insert(0, new ListItem("All", "All"));
            }
        }
    }

    protected void bind()
    {
        List<Order> orderList = new List<Order>();
        orderList = aOrder.getOrderAll("total_price", "ASC");
        gvOrder.DataSource = orderList;
        gvOrder.DataBind();
    }

    protected void gvOrder_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvOrder.SelectedRow;

        int orderID = Convert.ToInt32(row.Cells[0].Text);

        Response.Redirect("EmployeeView.aspx?orderID=" + orderID);
    }


    protected void btn_reset_Click(object sender, EventArgs e)
    {
        List<Order> orderList = new List<Order>();
        orderList = aOrder.getOrderAll("total_price", "ASC");
        gvOrder.DataSource = orderList;
        gvOrder.DataBind();
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string mainconn = ConfigurationManager.ConnectionStrings["LoginDBContext"].ConnectionString;
        //SqlConnection sqlconn = new SqlConnection(mainconn);
        //string sqlquery = "select A.order_id, A.total_price, A.pickupdvr, A.deliverydvr, A.todate, A.totime, A.frodate, A.frotime, A.order_status, A.payment_info, A.pickupaddrid, A.deliveryaddrid,(select address from address B where B.address_id = A.pickupaddrid) as pickupaddr, (select address from address C where C.address_id = A.deliveryaddrid) as deliveryaddr from laundry_order A where order_status ='"+DropDownList1.SelectedItem.Text+"'";
        //SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
        //sqlconn.Open();
        //SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);
        //gvOrder.DataSource = dt;
        //gvOrder.DataBind();
        //sqlconn.Close();

        var employee = new Order();

        gvOrder.DataSource = employee.filterstatus(DropDownList1.SelectedItem.Text);
        gvOrder.DataBind();
    }


    protected void btnsearch_Click(object sender, EventArgs e)
    {
        List<Order> orderList = new List<Order>();
        int orderID;
        string pickupdvr, deliverydvr, orderStatus, paymentInfo, todate, totime, frodate, frotime, pickupaddrid, deliveryaddrid;
        decimal total_Price;
        string sqlquery = "select * from laundry_order D where D.pickupaddrid like '%'+@address+'%' or D.deliveryaddrid like '%'+@address+'%' or D.todate like '%'+@todate+'%' or D.frodate like '%'+@frodate+'%' or D.totime like '%'+@totime+'%' or D.frotime like '%'+@frotime+'%' or D.payment_info like '%'+@payment_info+'%'";
        string conn = ConfigurationManager.ConnectionStrings["LoginDBContext"].ConnectionString;
        SqlConnection sqlconn = new SqlConnection(conn);
        SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
        sqlcomm.CommandText = sqlquery;
        sqlcomm.Parameters.AddWithValue("address", tbsearch.Text);
        sqlcomm.Parameters.AddWithValue("todate", tbsearch.Text);
        sqlcomm.Parameters.AddWithValue("frodate", tbsearch.Text);
        sqlcomm.Parameters.AddWithValue("totime", tbsearch.Text);
        sqlcomm.Parameters.AddWithValue("frotime", tbsearch.Text);
        sqlcomm.Parameters.AddWithValue("payment_info", tbsearch.Text);
        sqlconn.Open();
        SqlDataReader dr = sqlcomm.ExecuteReader();
        //Continue to read the resultsets row by row if not the end
        while (dr.Read())
        {
            orderID = Convert.ToInt32(dr["order_id"].ToString());
            total_Price = decimal.Parse(dr["total_price"].ToString());
            pickupdvr = dr["pickupdvr"].ToString();
            deliverydvr = dr["deliverydvr"].ToString();
            orderStatus = dr["order_status"].ToString();
            paymentInfo = dr["payment_info"].ToString();
            todate = Convert.ToDateTime(dr["todate"].ToString()).ToShortDateString();
            totime = dr["totime"].ToString();
            frodate = Convert.ToDateTime(dr["frodate"].ToString()).ToShortDateString();
            frotime = dr["frotime"].ToString();
            pickupaddrid = dr["pickupaddrid"].ToString();
            deliveryaddrid = dr["deliveryaddrid"].ToString();

            //pickupaddr = dr["pickupaddr"].ToString();
            //deliveryaddr = dr["deliveryaddr"].ToString();



            //DateTime todatetime = DateTime.Parse(dr["todatetime"].ToString());
            //DateTime frodatetime = DateTime.Parse(dr["todatetime"].ToString());

            Order a = new Order(orderID, total_Price, pickupdvr, deliverydvr, orderStatus, paymentInfo, todate, totime, frodate, frotime, pickupaddrid, deliveryaddrid);
            orderList.Add(a);
        }
        sqlconn.Close();
        dr.Close();
        dr.Dispose();
        gvOrder.DataSource = orderList;
        gvOrder.DataBind();
    }

    protected void gvOrder_Sorting(object sender, GridViewSortEventArgs e)
    {
        //Response.Write("Sort Expression = " + e.SortExpression);
        //Response.Write("Sort Direction = " + e.SortDirection.ToString());

        SortDirection sortDirection = SortDirection.Ascending;
        string sortField = string.Empty;

        SortGridview((GridView)sender, e, out sortDirection, out sortField);
        string strSortDirection = sortDirection == SortDirection.Ascending ? "ASC" : "DESC";

        gvOrder.DataSource = aOrder.getOrderAll(e.SortExpression, strSortDirection);
        gvOrder.DataBind();
    }
    private void SortGridview(GridView gridView, GridViewSortEventArgs e, out SortDirection sortDirection, out string sortField)
    {
        sortField = e.SortExpression;
        sortDirection = e.SortDirection;

        if (gridView.Attributes["CurrentSortField"] != null && gridView.Attributes["CurrentSortDirection"] != null)
        {
            if (sortField == gridView.Attributes["CurrentSortField"])
            {
                if (gridView.Attributes["CurrentSortDirection"] == "ASC")
                {
                    sortDirection = SortDirection.Descending;
                }
                else
                {
                    sortDirection = SortDirection.Ascending;
                }
            }

            gridView.Attributes["CurrentSortField"] = sortField;
            gridView.Attributes["CurrentSortDirection"] = (sortDirection == SortDirection.Ascending ? "ASC" : "DESC");
        }
    }
}