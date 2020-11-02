using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
public partial class ResetPassword : System.Web.UI.Page
{
    string cs = ConfigurationManager.ConnectionStrings["LoginDBContext"].ConnectionString;
    string GUIDvalue;
    DataTable dt = new DataTable();
    int cust_id;

    protected void Page_Load(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(cs))
        {
            GUIDvalue = Request.QueryString["cust_id"];
            if (GUIDvalue != null)
            {
                SqlCommand cmd = new SqlCommand("select * from forgetpassrequest where id='" + GUIDvalue + "'", con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    cust_id = Convert.ToInt32(dt.Rows[0][1]);
                }
                else
                {
                    lblmsg.Text = "Your Password Reset Link is Expired or Invalid ! Please Request for a new link !";
                    lblmsg.ForeColor = Color.Red;
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        if(!IsPostBack)
        {
            if(dt.Rows.Count !=0)
            {
                tbnewpass.Visible = true;
                tbconfirmpass.Visible = true;
                lblpassword.Visible = true;
                lblretypepass.Visible = true;
                btrespass.Visible = true;
            }
            else
            {
                lblmsg.Text = "Your Password Reset Link is Expired or Invalid ! Please Request for a new link !";
                lblmsg.ForeColor = Color.Red;
            }
        }
      }

    protected void btrespass_Click(object sender, EventArgs e)
    {
        if (tbnewpass.Text != "" && tbconfirmpass.Text != "" && tbnewpass.Text == tbconfirmpass.Text)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("update cust_info set Password='" + tbnewpass.Text + "' where cust_id='" + cust_id + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand("delete from forgetpassrequest where cust_id = '" + cust_id + "'", con);
                cmd2.ExecuteNonQuery();
                Response.Redirect("Login.aspx");
            }
        }
    }
}