using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerDetails : System.Web.UI.Page
{
    Customer aCust = new Customer();
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
        List<Customer> custList = new List<Customer>();
        custList = aCust.getCustomerAll();
        gvCustomer.DataSource = custList;
        gvCustomer.DataBind();
    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminHome.aspx");
    }


    protected void gvCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvCustomer.SelectedRow;
        string Customer_ID = row.Cells[0].Text;
        Response.Redirect("CustomerDetailsView.aspx?cust_id=" + Customer_ID);
    }

    protected void btn_addcustomer_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/RegistrationForm.aspx");
    }

    protected void gvCustomer_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvCustomer.EditIndex = e.NewEditIndex;
        bind();
    }

    protected void gvCustomer_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvCustomer.EditIndex = -1;
        bind();

    }

    protected void gvCustomer_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int result = 0;
        Customer cust = new Customer();
        GridViewRow row = (GridViewRow)gvCustomer.Rows[e.RowIndex];

        string cId = ((TextBox)row.Cells[0].Controls[0]).Text;
        string cName = ((TextBox)row.Cells[1].Controls[0]).Text;
        string cEmail = ((TextBox)row.Cells[2].Controls[0]).Text;
        string cNo = ((TextBox)row.Cells[3].Controls[0]).Text;
        string cMbrstatus = ((DropDownList)row.Cells[4].Controls[0]).Text;
        result = cust.CustomerUpdate(cId, cName, cEmail, cNo, cMbrstatus);
        if (result > 0)
        {
            Response.Write("<script>alert('Customer updated successfully');</script>");
        }
        else
        {
            Response.Write("<script>alert('Customer NOT updated');</script>");
        }
        gvCustomer.EditIndex = -1;
        bind();
    }

    protected void gvCustomer_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int result = 0;
        Customer cust = new Customer();
        string categoryID = gvCustomer.DataKeys[e.RowIndex].Value.ToString();
        result = cust.CustomerDelete(categoryID);
        if (result > 0)
        {
            Response.Write("<script>alert('Customer Remove successfully');</script>");
        }
        else
        {
            Response.Write("<script>alert('Customer Removal NOT successful');</script>");
        }
        Response.Redirect("CustomerDetails.aspx");
    }

    protected void IndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCustomer.PageIndex = e.NewPageIndex;
        bind();
    }

    protected void search_Click(object sender, EventArgs e)
    {
        List<Customer> custList = new List<Customer>();
        int cust_id;
        string email, cust_name, contact_no, mbr_status;
        string sqlquery = "select * from cust_info A where A.email like '%'+@email+'%' or A.cust_id like '%'+@cust_id+'%' or A.cust_name like '%'+@cust_name+'%' or A.contact_no like '%'+@contact_no+'%' or A.mbr_status like '%'+@mbr_status+'%'";
        string conn = ConfigurationManager.ConnectionStrings["LoginDBContext"].ConnectionString;
        SqlConnection sqlconn = new SqlConnection(conn);
        SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
        sqlcomm.CommandText = sqlquery;
        sqlcomm.Parameters.AddWithValue("cust_id", tbsearch.Text);
        sqlcomm.Parameters.AddWithValue("email", tbsearch.Text);
        sqlcomm.Parameters.AddWithValue("cust_name", tbsearch.Text);
        sqlcomm.Parameters.AddWithValue("contact_no", tbsearch.Text);
        sqlcomm.Parameters.AddWithValue("mbr_status", tbsearch.Text);
        sqlconn.Open();
        SqlDataReader dr = sqlcomm.ExecuteReader();
        //Continue to read the resultsets row by row if not the end
        while (dr.Read())
        {
            cust_id = Convert.ToInt32(dr["cust_id"].ToString());
            email = dr["email"].ToString();
            cust_name = dr["cust_name"].ToString();
            contact_no = dr["contact_no"].ToString();
            mbr_status = dr["mbr_status"].ToString();
            


            //DateTime todatetime = DateTime.Parse(dr["todatetime"].ToString());
            //DateTime frodatetime = DateTime.Parse(dr["todatetime"].ToString());

            Customer a = new Customer(cust_id, cust_name, email, contact_no, mbr_status);
            custList.Add(a);
        }
        sqlconn.Close();
        dr.Close();
        dr.Dispose();
        gvCustomer.DataSource = custList;
        gvCustomer.DataBind();
    }
}