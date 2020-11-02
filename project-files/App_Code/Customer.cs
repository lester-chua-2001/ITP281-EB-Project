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
public class Customer
{

    //private string _connStr = Properties.Settings.Default.DBConnStr;
    string _connStr = ConfigurationManager.ConnectionStrings["LoginDBContext"].ConnectionString;
    private string _cust_id = "";
    private string _cust_name = "";
    private string _email = ""; // this is another way to specify empty string
    private string _contact_no = "";
    private string _mbr_status = "";
    private string _regdatetime = "";
    private string _password = "";


    // Default constructor
    public Customer()
    {

    }

    // Constructor that take in all data required to build a Product object
    public Customer(string cust_id, string cust_name, string email,
                   string contact_no, string mbr_status, string regdatetime, string password)
    {
        _cust_id = cust_id;
        _cust_name = cust_name;
        _email = email;
        _contact_no = contact_no;
        _mbr_status = mbr_status;
        _regdatetime = regdatetime;
        _password = password;
    }

    public Customer(string cust_name, string email, string contact_no, string password)
    {
        _cust_name = cust_name;
        _email = email;
        _contact_no = contact_no;
        _password = password;
        _regdatetime = Convert.ToString(DateTime.Now);
    }

    public Customer(int cust_id, string cust_name, string email, string contact_no, string mbr_status)
    {
        _cust_id = Convert.ToString(cust_id);
        _cust_name = cust_name;
        _email = email;
        _contact_no = contact_no;
        _mbr_status = mbr_status;
    }

    public Customer(string email, string password)
    {

    }


    // Constructor that take in all except product ID
    /*
    public Customer(string cust_name, string email, string contact_no, string mbr_status, string regdatetime)
    {
        _cust_name = cust_name;
        _email = email;
        _contact_no = contact_no;
        _mbr_status = mbr_status;
        _regdatetime = regdatetime;
    }
    */

    // Constructo
    /*r that take in only Product ID. The other attributes will be set to 0 or empty.
    public Customer(string cust_id)
        : this(cust_id, "", "", "","",)
    {
    }*/

    // Get/Set the attributes of the Product object.
    // Note the attribute name (e.g. Product_ID) is same as the actual database field name.
    // This is for ease of referencing.
    public string Customer_ID
    {
        get { return _cust_id; }
        set { _cust_id = value; }
    }
    public string Customer_Name
    {
        get { return _cust_name; }
        set { _cust_name = value; }
    }
    public string Customer_Email
    {
        get { return _email; }
        set { _email = value; }
    }
    public string Contact_No
    {
        get { return _contact_no; }
        set { _contact_no = value; }
    }
    public string Membership_Status
    {
        get { return _mbr_status; }
        set { _mbr_status = value; }
    }

    public string regdatetime
    {
        get { return _regdatetime; }
        set { _regdatetime = value; }
    }

    public string password
    {
        get { return _password; }
        set { _password = value; }
    }


    //Below as the Class methods for some DB operations. 
    //We will revisit these section in our next practical

    //public Product getProduct(string prodID)
    //{
    public Customer getCustomer(string cust_id)
    {
        Customer custDetail = null;
        string cust_name, email, contact_no, mbr_status;
        string queryStr = "SELECT * FROM cust_info WHERE cust_id = @cust_id";
        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@cust_id", cust_id);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Check if there are any resultsets
        if (dr.Read())
        {
            cust_name = dr["cust_name"].ToString();
            email = dr["email"].ToString();
            contact_no = dr["contact_no"].ToString();
            mbr_status = dr["mbr_status"].ToString();
            regdatetime = dr["regdatetime"].ToString();
            password = dr["password"].ToString();
            custDetail = new Customer(cust_id, cust_name, email, contact_no, mbr_status, regdatetime, password);
        }
        else
        {
            custDetail = null;
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return custDetail;
    }

    //}

    //public List<Product> getProductAll()
    //{
    public List<Customer> getCustomerAll()
    {
        List<Customer> custList = new List<Customer>();
        string cust_name, email, contact_no, mbr_status, cust_id;
        string queryStr = "SELECT * FROM cust_info Order By cust_id";
        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Continue to read the resultsets row by row if not the end
        while (dr.Read())
        {
            cust_id = dr["cust_id"].ToString();
            cust_name = dr["cust_name"].ToString();
            email = dr["email"].ToString();
            contact_no = dr["contact_No"].ToString();
            mbr_status = dr["mbr_status"].ToString();
            regdatetime = dr["regdatetime"].ToString();
            password = dr["password"].ToString();
            Customer a = new Customer(cust_id, cust_name, email, contact_no, mbr_status, regdatetime, password);
            custList.Add(a);
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return custList;
    }

    public int CustomerInsert()
    {
        string msg = null;
        int result = 0;

        //1 QueryString
        string queryStr = "INSERT INTO cust_info(cust_name, email, contact_no, regdatetime, password)"
        + "values (@cust_name, @email, @contact_no, @regdatetime, @password)";

        //2 Sqlconnection + SqlCommand
        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);

        //3 100% need this for Insert
        cmd.Parameters.AddWithValue("@cust_name", this.Customer_Name);
        cmd.Parameters.AddWithValue("@email", this.Customer_Email);
        cmd.Parameters.AddWithValue("@contact_no", this.Contact_No);
        cmd.Parameters.AddWithValue("@regdatetime", this.regdatetime);
        cmd.Parameters.AddWithValue("@password", this.password);

        conn.Open();
        result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
        conn.Close();
        return result;
    }//end Insert

    public int CustomerDelete(string ID)
    {
        string queryStr = "DELETE FROM cust_info WHERE cust_id = @cust_id ";
        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);

        //3 Depends on senario for Delete
        cmd.Parameters.AddWithValue("@cust_id", ID);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }//end Delete
    //}//end Delete

    //{
    public int CustomerUpdate(string cId, string cName, string cEmail, string cNo, string cMbrstatus)
    {
        string queryStr = "UPDATE cust_info SET" +
        " cust_name = @cust_name," +
        " email = @email," + " contact_no = @contact_no," +
        " mbr_status = @mbr_status" +
        " WHERE cust_id = @cust_id";
        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@cust_id", cId);
        cmd.Parameters.AddWithValue("@cust_name", cName);
        cmd.Parameters.AddWithValue("@email", cEmail);
        cmd.Parameters.AddWithValue("@contact_no", cNo);
        cmd.Parameters.AddWithValue("@mbr_status", cMbrstatus);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
        //}//end Update

    }

    public int Authentication(string aEmail, string aPassword)
    {

        string queryStr = "Select * from cust_info WHERE email = @email and password = @password";
        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@email", aEmail);
        cmd.Parameters.AddWithValue("@password", aPassword);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            return Convert.ToInt32(dr["cust_id"].ToString());
        }

        else
        {
            return -1;
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
    }

    public int CustomerSubscribe(string cMbrstatus, string cId)
    {
        string queryStr = "UPDATE cust_info SET" +
        " mbr_status = @mbr_status" +
        " WHERE cust_id = @cust_id";
        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@mbr_status", cMbrstatus);
        cmd.Parameters.AddWithValue("@cust_id", cId);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
        //}//end Update

    }

}


