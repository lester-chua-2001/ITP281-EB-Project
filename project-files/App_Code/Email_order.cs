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
public class Email_order
{

    //private string _connStr = Properties.Settings.Default.DBConnStr;

    //system configuration connectionstring settings_constr;
    string _connstr = ConfigurationManager.ConnectionStrings["LoginDBContext"].ConnectionString;
    private int _custID = 0;
    private string _emailOrder = "";
    private string _custName = "";
    private string _contactNo = "";
    private string _mbrStatus = "";
    private string _password = "";
    private string _regdatetime = "";
    // Default constructor
    public Email_order()
    {
    }

    // Constructor that take in all data required to build a Product object
    public Email_order(int custID, string email, string custName, string contactNo, string mbrStatus, string password, string regdatetime)
    {
        _custID = custID;
        _emailOrder = email;
        _custName = custName;
        _contactNo = contactNo;
        _mbrStatus = mbrStatus;
        _password = password;
        _regdatetime = regdatetime;
    }

    // Constructor that take in all except product ID
    public Email_order(string email, string custName, string contactNo, string mbrStatus, string password, string regdatetime)
        : this(0, email, custName, contactNo, mbrStatus, password, regdatetime)
    {
    }

    // Constructor that take in only Product ID. The other attributes will be set to 0 or empty.
    public Email_order(int custID)
        : this(custID, "", "", "", "", "", "")
    {
    }

    // Get/Set the attributes of the Product object.
    // Note the attribute name (e.g. Product_ID) is same as the actual database field name.
    // This is for ease of referencing.
    public int cust_id
    {
        get { return _custID; }
        set { _custID = value; }
    }
    public string email
    {
        get { return _emailOrder; }
        set { _emailOrder = value; }
    }
    public string cust_name
    {
        get { return _custName; }
        set { _custName = value; }
    }
    public string contact_no
    {
        get { return _contactNo; }
        set { _contactNo = value; }
    }
    public string mbr_status
    {
        get { return _mbrStatus; }
        set { _mbrStatus = value; }
    }
    public string password
    {
        get { return _password; }
        set { _password = value; }
    }
    public string regdatetime
    {
        get { return _regdatetime; }
        set { _regdatetime = value; }
    }

    //Below as the Class methods for some DB operations. 
    //We will revisit these section in our next practical

    public Email_order getOrder(int custID)
    {
        Email_order orderDetail = null;

        string email, cust_name, contact_no, mbr_status, password, regdatetime;

        string queryStr = "Select * FROM cust_info WHERE cust_id = @custID";
        SqlConnection conn = new SqlConnection(_connstr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@custID", custID);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        //sheck if there are any resultsets
        if (dr.Read())
        {

            email = dr["email"].ToString();
            cust_name = dr["cust_name"].ToString();
            contact_no = dr["contact_no"].ToString();
            mbr_status = dr["mbr_status"].ToString();
            password = dr["password"].ToString();
            regdatetime = dr["regdatetime"].ToString();

            orderDetail = new Email_order(custID, email, cust_name, contact_no, mbr_status, password, regdatetime);
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

    public List<Email_order> getOrderAll()
    {
        List<Email_order> orderList = new List<Email_order>();

        int custID;
        string email, cust_name, contact_no, mbr_status, password, regdatetime;
        string queryStr = "SELECT * FROM cust_info Order By cust_id";
        SqlConnection conn = new SqlConnection(_connstr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Continue to read the resultsets row by row if not the end
        while (dr.Read())
        {
            custID = Convert.ToInt32(dr["cust_id"].ToString());
            email = dr["email"].ToString();
            cust_name = dr["cust_name"].ToString();
            contact_no = dr["contact_no"].ToString();
            mbr_status = dr["mbr_status"].ToString();
            password = dr["password"].ToString();
            regdatetime = dr["regdatetime"].ToString();

            Email_order a = new Email_order(custID, email, cust_name, contact_no, mbr_status, password, regdatetime);
            orderList.Add(a);
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return orderList;
    }
    public int CustomerInsert()
    {
        string msg = null;
        int result = 0;

        //1 QueryString
        string queryStr = "INSERT INTO cust_info(cust_name, email, contact_no)"
        + "values (@cust_name, @email, @contact_no)";

        //2 Sqlconnection + SqlCommand
        SqlConnection conn = new SqlConnection(_connstr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);

        //3 100% need this for Insert
        cmd.Parameters.AddWithValue("@cust_name", this.cust_name);
        cmd.Parameters.AddWithValue("@email", this.email);
        cmd.Parameters.AddWithValue("@contact_no", this.contact_no);
        conn.Open();
        result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
        conn.Close();
        return result;
    }//end Insert

    public int CustomerUpdate(int cId, string cName, string cEmail, string cNo)
    {
        string queryStr = "UPDATE cust_info SET" +
        " cust_name = @cust_name," +
        " email = @email," + " contact_no = @contact_no" +
        " WHERE cust_id = @cust_id";
        SqlConnection conn = new SqlConnection(_connstr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@cust_id", cId);
        cmd.Parameters.AddWithValue("@cust_name", cName);
        cmd.Parameters.AddWithValue("@email", cEmail);
        cmd.Parameters.AddWithValue("@contact_no", cNo);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
        //}//end Update

    }
}
