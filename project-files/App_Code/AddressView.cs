using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for AddressView
/// </summary>
public class AddressView
{
    static string _connStr = ConfigurationManager.ConnectionStrings["LoginDBContext"].ConnectionString;
    private int _address_id = 0;
    private string _postal_code = null;
    private string _address = null;
    private int _cust_id = 0;
    public AddressView()
    {
        
    }
    public AddressView(int address_id, string postal_code, string address, int cust_id)
    {
        _address_id = address_id;
        _postal_code = postal_code;
        _address = address;
        _cust_id = cust_id;
    }
    public AddressView(string postal_code, string address, int cust_id)
        : this(0, postal_code, address, cust_id)
    {

    }
    public AddressView(int address_id)
        : this(address_id, "", "", 0)
    {
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
    public string address
    {
        get { return _address; }
        set { _address = value; }
    }

    public List<AddressView> getAddressAll(int cust_id)
    {
        List<AddressView> addressList = new List<AddressView>();
        int address_id;


        string postal_code, address;
        string queryStr = "SELECT * FROM address WHERE cust_id = @cust_id Order By address_id";


        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@cust_id", cust_id);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        while (dr.Read())
        {
            address_id = Convert.ToInt32(dr["address_id"].ToString());
            postal_code = dr["postal_code"].ToString();
            address = dr["address"].ToString();

            AddressView a = new AddressView(address_id, postal_code, address, cust_id);
            addressList.Add(a);
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return addressList;
    }
    public int AddressUpdate(string address, string postal_code)
    {
        string queryStr = "UPDATE address SET" +
        " address = @address, " +
        " postal_code = @postal_code ";
        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@address", address);
        cmd.Parameters.AddWithValue("@postal_code", postal_code);
       
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }
    public int AddressDelete(string ID)
    {
        string queryStr = "DELETE FROM address WHERE address_id=@ID";
        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@ID", ID);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }
}