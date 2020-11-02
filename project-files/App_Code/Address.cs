using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class Address
{
    private int _address_id;
    private string _postal_code;
    private string _address;
    private string _cust_id;

    static string _connStr = ConfigurationManager.ConnectionStrings["LoginDBContext"].ConnectionString;
    public Address()
    {

    }

    public Address(string p_postal_code, string p_address, string p_cust_id)
    {
        _postal_code = p_postal_code;
        _address = p_address;
        _cust_id = p_cust_id;
    }

    public int address_id
    {
        get { return _address_id; }
        set { _address_id = value; }
    }

    public string postal_code
    {
        get { return _postal_code; }
        set { _postal_code = value; }
    }

    public string cust_id
    {
        get { return _cust_id; }
        set { _cust_id = value; }
    }

    public string address
    {
        get { return _address; }
        set { _address = value; }
    }

    public static Address getCustomerAddress(string p_cust_id, string p_address)
    {
        SqlCommand cmd = null;
        Address addr = new Address();
        SqlConnection conn = new SqlConnection(_connStr);
        if (String.IsNullOrEmpty(p_address))
        {
            string queryStr = "SELECT * FROM address where cust_id = @cust_id";
            cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@cust_id", p_cust_id);
        }
        else
        {
            string queryStr = "SELECT * FROM address where address = @address AND cust_id = @cust_id";
            cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@address", p_address);
            cmd.Parameters.AddWithValue("@cust_id", p_cust_id);
        }

        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {

            addr.address_id = Convert.ToInt32(dr["address_id"].ToString());
            addr.cust_id = dr["cust_id"].ToString();
            addr.address = dr["address"].ToString();

        }
        conn.Close();

        return addr;
    }
    public static int addressInsert(Address address)
    {
        int result = 0;
        string queryStr = "INSERT INTO address(postal_code, address, cust_id) VALUES(@postal_code, @address, @cust_id)";
        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@postal_code", address.postal_code);
        cmd.Parameters.AddWithValue("@address", address.address);
        cmd.Parameters.AddWithValue("@cust_id", address.cust_id);

        conn.Open();
        result += cmd.ExecuteNonQuery();
        conn.Close();
        return result;
    }
   
}