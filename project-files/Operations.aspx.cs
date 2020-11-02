using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Operations : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["cust_id"] == null && Session["emp_id"] == null && Session["dvr_id"] == null && Session["admin_id"] == null)
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        string _connStr = ConfigurationManager.ConnectionStrings["LoginDBContext"].ConnectionString;
        string queryStr = "Select * from Notification Order by NotifId DESC";
        SqlConnection con = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = queryStr;
        cmd.Connection = con;
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {

            Label1.Text = ds.Tables[0].Rows[0]["Message"].ToString();

        }

        con.Close();
    }
}