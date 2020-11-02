﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerOrdersAdmin : System.Web.UI.Page
{
    Orders aOrders = new Orders();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["cust_id"] == null && Session["emp_id"] == null && Session["dvr_id"] == null && Session["admin_id"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        if (!IsPostBack)
        {
            bind();
        }
    }
    protected void bind()
    {
        int id = Convert.ToInt32(Session["cust_id"]);
        List<Orders> orderList = new List<Orders>();
        orderList = aOrders.getOrdersAll();
        gv_Order.DataSource = orderList;
        gv_Order.DataBind();
    }
}