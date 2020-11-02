using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Admin
/// </summary>
public class Admin
{
    string _connStr = ConfigurationManager.ConnectionStrings["LoginDBContext"].ConnectionString;
    public Admin()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int Authentication(string aEmail, string aPassword)
    {
        string queryStr = "Select * from admin WHERE email = @email and password = @password";
        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@email", aEmail);
        cmd.Parameters.AddWithValue("@password", aPassword);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            return Convert.ToInt32(dr["admin_id"].ToString());
        }

        else
        {
            return -1;
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
    }
}