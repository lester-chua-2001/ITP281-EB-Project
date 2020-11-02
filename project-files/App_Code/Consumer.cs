using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class Consumer
{
    static string _connStr = ConfigurationManager.ConnectionStrings["LoginDBContext"].ConnectionString;
    private string _tee;
    private string _shorts;
    private string _jacket;
    private string _formal;
    private string _jeans;
    private string _bed;
    private string _curtain;
    private string _ddate;
    private string _dtime;
    private string _pdate;
    private string _ptime;
    private string _paddress;
    private string _daddress;

    public Consumer()
    {

    }
    public Consumer(string p_tee, string p_shorts, string p_jacket, string p_formal, string p_jeans, string p_bed, string p_curtain, string p_ddate, string p_dtime, string p_pdate, string p_ptime, string p_paddress, string p_daddress)
    {
        this.Tee = p_tee;
        this.Shorts = p_shorts;
        this.Jacket = p_jacket;
        this.Formal = p_formal;
        this.Jeans = p_jeans;
        this.Bed = p_bed;
        this.Curtain = p_curtain;
        this.DDate = p_ddate;
        this.DTime = p_dtime;
        this.PDate = p_pdate;
        this.PTime = p_ptime;
        this.PAddress = p_paddress;
        this.DAddress = p_daddress;

    }
    public string Tee
    {
        get { return _tee; }
        set { _tee = value; }
    }
    public string Shorts
    {
        get { return _shorts; }
        set { _shorts = value; }
    }
    public string Jacket
    {
        get { return _jacket; }
        set { _jacket = value; }
    }
    public string Formal
    {
        get { return _formal; }
        set { _formal = value; }
    }
    public string Jeans
    {
        get { return _jeans; }
        set { _jeans = value; }
    }
    public string Bed
    {
        get { return _bed; }
        set { _bed = value; }
    }
    public string Curtain
    {
        get { return _curtain; }
        set { _curtain = value; }
    }
    public string DDate
    {
        get { return _ddate; }
        set { _ddate = value; }
    }
    public string DTime
    {
        get { return _dtime; }
        set { _dtime = value; }
    }
    public string PDate
    {
        get { return _pdate; }
        set { _pdate = value; }
    }
    public string PTime
    {
        get { return _ptime; }
        set { _ptime = value; }
    }
    public string PAddress
    {
        get { return _paddress; }
        set { _paddress = value; }
    }
    public string DAddress
    {
        get { return _daddress; }
        set { _daddress = value; }
    }

    public decimal getTotalCost()
    {
        decimal totalCost = 0;
        if (!String.IsNullOrEmpty(_tee))
            totalCost += 3 * Convert.ToInt32(_tee);
        if (!String.IsNullOrEmpty(_shorts))
            totalCost += 4 * Convert.ToInt32(_shorts);
        if (!String.IsNullOrEmpty(_jeans))
            totalCost += 4 * Convert.ToInt32(_jeans);
        if (!String.IsNullOrEmpty(_jacket))
            totalCost += 5 * Convert.ToInt32(_jacket);
        if (!String.IsNullOrEmpty(_formal))
            totalCost += 6 * Convert.ToInt32(_formal);
        if (!String.IsNullOrEmpty(_bed))
            totalCost += 5 * Convert.ToInt32(_bed);
        if (!String.IsNullOrEmpty(_curtain))
            totalCost += 5 * Convert.ToInt32(_curtain);

        return totalCost;
    }


    public static int OrderItemInsert(Consumer consumer, int order_id)
    {
        int result = 0;
        SqlCommand cmd = null;

        SqlConnection conn = new SqlConnection(_connStr);
        string queryStr = "INSERT INTO order_items(order_id, item_name, item_price, quantity, cleantype ) values (@order_id, @item_name, @item_price, @quantity, @cleantype)";

        conn.Open();
        SqlTransaction sqlTrans = conn.BeginTransaction();

        if (!String.IsNullOrEmpty(consumer.Tee))
        {
            cmd = new SqlCommand(queryStr, conn, sqlTrans);
            cmd.Parameters.AddWithValue("@order_id", order_id);
            cmd.Parameters.AddWithValue("@item_name", MemberInfoGetting.GetMemberName(() => consumer.Tee));
            cmd.Parameters.AddWithValue("@item_price", Convert.ToDecimal("3"));
            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(consumer.Tee));
            cmd.Parameters.AddWithValue("@cleantype", "-");
            cmd.ExecuteNonQuery();
        }
        if (!String.IsNullOrEmpty(consumer.Shorts))
        {
            cmd = new SqlCommand(queryStr, conn, sqlTrans);
            cmd.Parameters.AddWithValue("@order_id", order_id);
            cmd.Parameters.AddWithValue("@item_name", MemberInfoGetting.GetMemberName(() => consumer.Shorts));
            cmd.Parameters.AddWithValue("@item_price", Convert.ToDecimal("4"));
            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(consumer.Shorts));
            cmd.Parameters.AddWithValue("@cleantype", "-");
            cmd.ExecuteNonQuery();
        }
        if (!String.IsNullOrEmpty(consumer.Jeans))
        {
            cmd = new SqlCommand(queryStr, conn, sqlTrans);
            cmd.Parameters.AddWithValue("@order_id", order_id);
            cmd.Parameters.AddWithValue("@item_name", MemberInfoGetting.GetMemberName(() => consumer.Jeans));
            cmd.Parameters.AddWithValue("@item_price", Convert.ToDecimal("4"));
            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(consumer.Jeans));
            cmd.Parameters.AddWithValue("@cleantype", "-");
            cmd.ExecuteNonQuery();
        }
        if (!String.IsNullOrEmpty(consumer.Jacket))
        {
            cmd = new SqlCommand(queryStr, conn, sqlTrans);
            cmd.Parameters.AddWithValue("@order_id", order_id);
            cmd.Parameters.AddWithValue("@item_name", MemberInfoGetting.GetMemberName(() => consumer.Jacket));
            cmd.Parameters.AddWithValue("@item_price", Convert.ToDecimal("5"));
            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(consumer.Jacket));
            cmd.Parameters.AddWithValue("@cleantype", "Dry Clean");
            cmd.ExecuteNonQuery();
        }
        if (!String.IsNullOrEmpty(consumer.Formal))
        {
            cmd = new SqlCommand(queryStr, conn, sqlTrans);
            cmd.Parameters.AddWithValue("@order_id", order_id);
            cmd.Parameters.AddWithValue("@item_name", MemberInfoGetting.GetMemberName(() => consumer.Formal));
            cmd.Parameters.AddWithValue("@item_price", Convert.ToDecimal("6"));
            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(consumer.Formal));
            cmd.Parameters.AddWithValue("@cleantype", "Iron");
            cmd.ExecuteNonQuery();
        }
        if (!String.IsNullOrEmpty(consumer.Bed))
        {
            cmd = new SqlCommand(queryStr, conn, sqlTrans);
            cmd.Parameters.AddWithValue("@order_id", order_id);
            cmd.Parameters.AddWithValue("@item_name", MemberInfoGetting.GetMemberName(() => consumer.Bed));
            cmd.Parameters.AddWithValue("@item_price", Convert.ToDecimal("5"));
            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(consumer.Bed));
            cmd.Parameters.AddWithValue("@cleantype", "-");
            cmd.ExecuteNonQuery();
        }
        if (!String.IsNullOrEmpty(consumer.Curtain))
        {
            cmd = new SqlCommand(queryStr, conn, sqlTrans);
            cmd.Parameters.AddWithValue("@order_id", order_id);
            cmd.Parameters.AddWithValue("@item_name", MemberInfoGetting.GetMemberName(() => consumer.Curtain));
            cmd.Parameters.AddWithValue("@item_price", Convert.ToDecimal("5"));
            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(consumer.Curtain));
            cmd.Parameters.AddWithValue("@cleantype", "-");
            cmd.ExecuteNonQuery();
        }
        sqlTrans.Commit();
        conn.Close();
        return result;
    }
}