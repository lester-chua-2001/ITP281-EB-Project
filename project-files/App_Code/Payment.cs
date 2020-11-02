using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Payment
/// </summary>
public class Payment
{
    private int _payment_id;
    private string _cust_id;
    private string _card_no;
    private string _cvv_no;
    private string _cc_expiry;
    static string _connStr = ConfigurationManager.ConnectionStrings["LoginDBContext"].ConnectionString;
    public Payment()
    {

    }
    public Payment(int p_payment_id, string p_cust_id, string p_card_no, string p_cvv_no, string p_cc_expiry)
    {
        _payment_id = p_payment_id;
        _cust_id = p_cust_id;
        _card_no = p_card_no;
        _cvv_no = p_cvv_no;
        _cc_expiry = p_cc_expiry;
    }

    public Payment(string p_cust_id, string p_card_no, string p_cvv_no, string p_cc_expiry)
    {
        _cust_id = p_cust_id;
        _card_no = p_card_no;
        _cvv_no = p_cvv_no;
        _cc_expiry = p_cc_expiry;
    }


    public int payment_id
    {
        get { return _payment_id; }
        set { _payment_id = value; }
    }

    public string cust_id
    {
        get { return _cust_id; }
        set { _cust_id = value; }
    }

    public string card_no
    {
        get { return _card_no; }
        set { _card_no = value; }
    }

    public string cvv_no
    {
        get { return _cvv_no; }
        set { _cvv_no = value; }
    }

    public string cc_expiry
    {
        get { return _cc_expiry; }
        set { _cc_expiry = value; }
    }

    public static Payment getPaymentByCardNo(string p_cust_id, string p_cardNo)
    {
        SqlCommand cmd = null;
        Payment payment = new Payment();
        SqlConnection conn = new SqlConnection(_connStr);
        if (String.IsNullOrEmpty(p_cardNo))
        {
            string queryStr = "SELECT * FROM payment where cust_id = @cust_id";
            cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@cust_id", p_cust_id);
        }
        else
        {
            string queryStr = "SELECT * FROM payment where card_no = @card_no AND cust_id = @cust_id";
            cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@card_no", p_cardNo);
            cmd.Parameters.AddWithValue("@cust_id", p_cust_id);
        }

        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            payment.payment_id = Convert.ToInt32(dr["payment_id"].ToString());
            payment.cust_id = dr["cust_id"].ToString();
            payment.card_no = dr["card_no"].ToString();
            payment.cvv_no = dr["cvv_no"].ToString();
            payment.cc_expiry = dr["cc_expiry"].ToString();
        }
        conn.Close();

        return payment;
    }

    public static int paymentInsert(Payment payment)
    {
        int result = 0;
        string queryStr = "INSERT INTO payment(cust_id,card_no,cvv_no,cc_expiry) VALUES(@cust_id, @card_no, @cvv_no, @cc_expiry)";
        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@cust_id", payment.cust_id);
        cmd.Parameters.AddWithValue("@card_no", payment.card_no);
        cmd.Parameters.AddWithValue("@cvv_no", payment.cvv_no);
        cmd.Parameters.AddWithValue("@cc_expiry", payment.cc_expiry);

        conn.Open();
        result += cmd.ExecuteNonQuery();
        conn.Close();
        return result;
    }
}