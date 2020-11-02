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
using System.Net.Mail;
using System.Net;

public partial class ForgetPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_sendemail_Click(object sender, EventArgs e)
    {
        Response.Redirect("ResetPassword.aspx");
    }

    protected void btn_sendemail_Click1(object sender, EventArgs e)
    {
        string cs = ConfigurationManager.ConnectionStrings["LoginDBContext"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand("select * from cust_info where email='" + tb_email.Text + "'", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if(dt.Rows.Count !=0)
            {
                string myGUID = Guid.NewGuid().ToString();
                int cust_id = Convert.ToInt32(dt.Rows[0][0]);
                SqlCommand cmd1 = new SqlCommand("insert into forgetpassrequest values('" + myGUID + "','" + cust_id + "', getdate())", con);
                cmd1.ExecuteNonQuery();

                // send email
                string toemailaddress = dt.Rows[0][1].ToString();
                string cust_name = dt.Rows[0][2].ToString();
                string emailbody = "Hi" + cust_name + ",<br/><br/> Click the link below to reset your password <br/><br/>http://localhost:3626/ResetPassword.aspx?cust_id=" + myGUID;
                MailMessage passrecmail = new MailMessage("ebusinessnyp@gmail.com", toemailaddress);
                passrecmail.Body = emailbody;
                passrecmail.IsBodyHtml = true;
                passrecmail.Subject = "Reset Password";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential()
                {
                    UserName = "ebusinessnyp@gmail.com",
                    Password = "Ebusiness"
                };
                smtp.EnableSsl = true;
                smtp.Send(passrecmail);

                lblpassrec.Text = "Check your email to reset your password";
                lblpassrec.ForeColor = Color.Green;
            }
            else
            {
                lblpassrec.Text = "Please type in a valid email address";
                lblpassrec.ForeColor = Color.Red;
            }

        }
    }
}