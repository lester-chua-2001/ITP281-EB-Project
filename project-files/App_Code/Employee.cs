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
public class Employee
{

    //private string _connStr = Properties.Settings.Default.DBConnStr;
    string _connStr = ConfigurationManager.ConnectionStrings["LoginDBContext"].ConnectionString;
    private string _emp_id = "";
    private string _emp_name = "";
    private string _email = ""; // this is another way to specify empty string
    private string _contact_no = "";
    private string _password = "";


    // Default constructor
    public Employee()
    {

    }

    // Constructor that take in all data required to build a Product object
    public Employee(string emp_id, string emp_name, string email,
                   string contact_no, string password)
    {
        _emp_id = emp_id;
        _emp_name = emp_name;
        _email = email;
        _contact_no = contact_no;
        _password = password;
    }

    public Employee(string emp_name, string email, string contact_no, string password)
    {
        _emp_name = emp_name;
        _email = email;
        _contact_no = contact_no;
        _password = password;
    }
    // Constructor that take in all except product ID

    // Constructor that take in only Product ID. The other attributes will be set to 0 or empty.

    // Get/Set the attributes of the Product object.
    // Note the attribute name (e.g. Product_ID) is same as the actual database field name.
    // This is for ease of referencing.
    public string Employee_ID
    {
        get { return _emp_id; }
        set { _emp_id = value; }
    }
    public string Employee_Name
    {
        get { return _emp_name; }
        set { _emp_name = value; }
    }
    public string Employee_Email
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
    public Employee getEmployee(string emp_id)
    {
        Employee empDetail = null;
        string emp_name, email, contact_no;
        string queryStr = "SELECT * FROM employee_info WHERE emp_id = @emp_id";
        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@emp_id", emp_id);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Check if there are any resultsets
        if (dr.Read())
        {
            emp_name = dr["emp_name"].ToString();
            email = dr["email"].ToString();
            contact_no = dr["contact_no"].ToString();
            password = dr["password"].ToString();
            empDetail = new Employee(emp_id, emp_name, email, contact_no, password);
        }
        else
        {
            empDetail = null;
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return empDetail;
    }

    //}

    //public List<Product> getProductAll()
    //{
    public List<Employee> getEmployeeAll()
    {
        List<Employee> empList = new List<Employee>();
        string emp_name, email, contact_no, emp_id;
        string queryStr = "SELECT * FROM employee_info Order By emp_id";
        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Continue to read the resultsets row by row if not the end
        while (dr.Read())
        {
            emp_id = dr["emp_id"].ToString();
            emp_name = dr["emp_name"].ToString();
            email = dr["email"].ToString();
            contact_no = dr["contact_No"].ToString();
            password = dr["password"].ToString();
            Employee a = new Employee(emp_id, emp_name, email, contact_no, password);
            empList.Add(a);
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return empList;
    }

    public int EmployeeInsert()
    {
        string msg = null;
        int result = 0;

        //1 QueryString
        string queryStr = "INSERT INTO employee_info(emp_name, email, contact_no, password)"
        + "values (@emp_name, @email, @contact_no, @password)";

        //2 Sqlconnection + SqlCommand
        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);

        //3 100% need this for Insert
        cmd.Parameters.AddWithValue("@emp_name", this.Employee_Name);
        cmd.Parameters.AddWithValue("@email", this.Employee_Email);
        cmd.Parameters.AddWithValue("@contact_no", this.Contact_No);
        cmd.Parameters.AddWithValue("@password", this.password);

        conn.Open();
        result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
        conn.Close();
        return result;
    }//end Insert

    public int EmployeeUpdate(string eId, string eName, string eEmail, string eNo)
    {
        string queryStr = "UPDATE employee_info SET" +
        " emp_name = @emp_name," +
        " email = @email," + " contact_no = @contact_no" +
        " WHERE emp_id = @emp_id";
        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@emp_id", eId);
        cmd.Parameters.AddWithValue("@emp_name", eName);
        cmd.Parameters.AddWithValue("@email", eEmail);
        cmd.Parameters.AddWithValue("@contact_no", eNo);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
        //}//end Update

    }
    public int EmployeeDelete(string ID)
    {
        string queryStr = "DELETE FROM employee_info WHERE emp_id = @emp_id ";
        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);

        //3 Depends on senario for Delete
        cmd.Parameters.AddWithValue("@emp_id", ID);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }

    public int Authentication(string aEmail, string aPassword)
    {

        string queryStr = "Select * from employee_info WHERE email = @email and password = @password";
        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@email", aEmail);
        cmd.Parameters.AddWithValue("@password", aPassword);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            return Convert.ToInt32(dr["emp_id"].ToString());
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