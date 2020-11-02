using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Driver
/// </summary>
public class Driver
{
    string _connStr = ConfigurationManager.ConnectionStrings["LoginDBContext"].ConnectionString;
    private string _dvr_id = "";
    private string _dvr_name = "";
    private string _email = ""; // this is another way to specify empty string
    private string _contact_no = "";
    private string _password = "";
    public Driver()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Driver(string dvr_id, string dvr_name, string email,
                   string contact_no, string password)
    {
        _dvr_id = dvr_id;
        _dvr_name = dvr_name;
        _email = email;
        _contact_no = contact_no;
        _password = password;
    }

    public Driver(string dvr_name, string email, string contact_no, string password)
    {
        _dvr_name = dvr_name;
        _email = email;
        _contact_no = contact_no;
        _password = password;
    }
    // Constructor that take in all except product ID

    // Constructor that take in only Product ID. The other attributes will be set to 0 or dvrty.

    // Get/Set the attributes of the Product object.
    // Note the attribute name (e.g. Product_ID) is same as the actual database field name.
    // This is for ease of referencing.
    public string Driver_ID
    {
        get { return _dvr_id; }
        set { _dvr_id = value; }
    }
    public string Driver_Name
    {
        get { return _dvr_name; }
        set { _dvr_name = value; }
    }
    public string Driver_Email
    {
        get { return _email; }
        set { _email = value; }
    }
    public string Contact_No
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

    //public Product getProduct(string prodID)
    //{
    public Driver getDriver(string dvr_id)
    {
        Driver dvrDetail = null;
        string dvr_name, email, contact_no;
        string queryStr = "SELECT * FROM driver_info WHERE dvr_id = @dvr_id";
        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@dvr_id", dvr_id);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Check if there are any resultsets
        if (dr.Read())
        {
            dvr_name = dr["dvr_name"].ToString();
            email = dr["email"].ToString();
            contact_no = dr["contact_no"].ToString();
            password = dr["password"].ToString();
            dvrDetail = new Driver(dvr_id, dvr_name, email, contact_no, password);
        }
        else
        {
            dvrDetail = null;
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return dvrDetail;
    }

    //}

    //public List<Product> getProductAll()
    //{
    public List<Driver> getDriverAll()
    {
        List<Driver> dvrList = new List<Driver>();
        string dvr_name, email, contact_no, dvr_id;
        string queryStr = "SELECT * FROM driver_info Order By dvr_id";
        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Continue to read the resultsets row by row if not the end
        while (dr.Read())
        {
            dvr_id = dr["dvr_id"].ToString();
            dvr_name = dr["dvr_name"].ToString();
            email = dr["email"].ToString();
            contact_no = dr["contact_No"].ToString();
            password = dr["password"].ToString();
            Driver a = new Driver(dvr_id, dvr_name, email, contact_no, password);
            dvrList.Add(a);
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return dvrList;
    }

    public int DriverInsert()
    {
        string msg = null;
        int result = 0;

        //1 QueryString
        string queryStr = "INSERT INTO driver_info(dvr_name, email, contact_no, password)"
        + "values (@dvr_name, @email, @contact_no, @password)";

        //2 Sqlconnection + SqlCommand
        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);

        //3 100% need this for Insert
        cmd.Parameters.AddWithValue("@dvr_name", this.Driver_Name);
        cmd.Parameters.AddWithValue("@email", this.Driver_Email);
        cmd.Parameters.AddWithValue("@contact_no", this.Contact_No);
        cmd.Parameters.AddWithValue("@password", this.password);
        conn.Open();
        result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
        conn.Close();
        return result;
    }

    public int DriverUpdate(string eId, string eName, string eEmail, string eNo)
    {
        string queryStr = "UPDATE driver_info SET" +
        " dvr_name = @dvr_name," +
        " email = @email," + " contact_no = @contact_no" +
        " WHERE dvr_id = @dvr_id";
        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@dvr_id", eId);
        cmd.Parameters.AddWithValue("@dvr_name", eName);
        cmd.Parameters.AddWithValue("@email", eEmail);
        cmd.Parameters.AddWithValue("@contact_no", eNo);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
        //}//end Update

    }
    public int DriverDelete(string ID)
    {
        string queryStr = "DELETE FROM driver_info WHERE dvr_id = @dvr_id ";
        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);

        //3 Depends on senario for Delete
        cmd.Parameters.AddWithValue("@dvr_id", ID);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }

    public int Authentication(string aEmail, string aPassword)
    {
        string queryStr = "Select * from driver_info WHERE email = @email and password = @password";
        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@email", aEmail);
        cmd.Parameters.AddWithValue("@password", aPassword);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            return Convert.ToInt32(dr["dvr_id"].ToString());
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