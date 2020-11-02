using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for Product
/// </summary>
public class Email_orderDP
{

    //private string _connStr = Properties.Settings.Default.DBConnStr;

    //system configuration connectionstring settings_constr;
    string _connstr = ConfigurationManager.ConnectionStrings["LoginDBContext"].ConnectionString;
    private int _dvr_id = 0;
    private string _email = "";
    private string _dvr_name = "";
    private string _contact_no = "";
    private string _password = "";
 
    // Default constructor
    public Email_orderDP()
    {
    }

    // Constructor that take in all data required to build a Product object
    public Email_orderDP(int dvr_id, string email, string dvr_name, string contact_no, string password)
    {
        _dvr_id = dvr_id;
        _email = email;
        _dvr_name = dvr_name;
        _contact_no = contact_no;
        _password = password;
    }

    // Constructor that take in all except product ID
    public Email_orderDP(string email, string dvr_name, string contact_no, string password)
        : this(0, email, dvr_name, contact_no, password)
    {
    }

    // Constructor that take in only Product ID. The other attributes will be set to 0 or empty.
    public Email_orderDP(int dvr_id)
        : this(dvr_id, "", "", "", "")
    {
    }

    // Get/Set the attributes of the Product object.
    // Note the attribute name (e.g. Product_ID) is same as the actual database field name.
    // This is for ease of referencing.
    public int dvr_id
    {
        get { return _dvr_id; }
        set { _dvr_id = value; }
    }
    public string email
    {
        get { return _email; }
        set { _email = value; }
    }
    public string dvr_name
    {
        get { return _dvr_name; }
        set { _dvr_name = value; }
    }
    public string contact_no
    {
        get { return _contact_no; }
        set { _contact_no = value; }
    }
   
    public string password
    {
        get { return _password; }
        set { _password = value; }
    }
 
    //Below as the Class methods for some DB operations. 
    //We will revisit these section in our next practical

    public Email_orderDP getOrder(int dvr_id)
    {
        Email_orderDP orderDetail = null;

        string email, dvr_name, contact_no,  password;

        string queryStr = "Select * FROM driver_info WHERE dvr_id = @dvr_id";
        SqlConnection conn = new SqlConnection(_connstr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@dvr_id", dvr_id);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        //sheck if there are any resultsets
        if (dr.Read())
        {

            email = dr["email"].ToString();
            dvr_name = dr["dvr_name"].ToString();
            contact_no = dr["contact_no"].ToString();
            password = dr["password"].ToString();

            orderDetail = new Email_orderDP(dvr_id, email, dvr_name, contact_no, password);
        }
        else
        {
            orderDetail = null;
        }

        conn.Close();
        dr.Close();
        dr.Dispose();
        return orderDetail;
    }

    public List<Email_orderDP> getOrderAll()
    {
        List<Email_orderDP> orderList = new List<Email_orderDP>();

        int dvr_id;
        string email, dvr_name, contact_no,  password;
        string queryStr = "SELECT * FROM driver_info Order By dvr_id";
        SqlConnection conn = new SqlConnection(_connstr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Continue to read the resultsets row by row if not the end
        while (dr.Read())
        {
            dvr_id = Convert.ToInt32(dr["dvr_id"].ToString());
            email = dr["email"].ToString();
            dvr_name = dr["dvr_name"].ToString();
            contact_no = dr["contact_no"].ToString();
          
            password = dr["password"].ToString();

            Email_orderDP a = new Email_orderDP(dvr_id, email, dvr_name, contact_no, password);
            orderList.Add(a);
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return orderList;
    }
    public int DriverInsert()
    {
        string msg = null;
        int result = 0;

        //1 QueryString
        string queryStr = "INSERT INTO driver_info(cust_name, email, contact_no)"
        + "values (@dvr_name, @email, @contact_no)";

        //2 Sqlconnection + SqlCommand
        SqlConnection conn = new SqlConnection(_connstr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);

        //3 100% need this for Insert
        cmd.Parameters.AddWithValue("@dvr_name", this.dvr_name);
        cmd.Parameters.AddWithValue("@email", this.email);
        cmd.Parameters.AddWithValue("@contact_no", this.contact_no);
        conn.Open();
        result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
        conn.Close();
        return result;
    }//end Insert

    public int DriverUpdate(int dId, string dName, string dEmail, string dNo)
    {
        string queryStr = "UPDATE driver_info SET" +
        " dvr_name = @dvr_name," +
        " email = @email," + " contact_no = @contact_no" +
        " WHERE dvr_id = @dvr_id";
        SqlConnection conn = new SqlConnection(_connstr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@dvr_id", dId);
        cmd.Parameters.AddWithValue("@dvr_name", dName);
        cmd.Parameters.AddWithValue("@email", dEmail);
        cmd.Parameters.AddWithValue("@contact_no", dNo);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
        //}//end Update

    }

}
