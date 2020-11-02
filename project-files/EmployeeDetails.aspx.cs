using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EmployeeDetails : System.Web.UI.Page
{
    Employee aEmp = new Employee();
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
        List<Employee> empList = new List<Employee>();
        empList = aEmp.getEmployeeAll();
        gvEmployee.DataSource = empList;
        gvEmployee.DataBind();
    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("Admin.aspx");
    }

    protected void btn_addEmployee_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AddEmployee.aspx");
    }

    protected void gvEmployee_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvEmployee.EditIndex = e.NewEditIndex;
        bind();
    }

    protected void gvEmployee_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvEmployee.EditIndex = -1;
        bind();

    }

    protected void gvEmployee_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int result = 0;
        Employee emp = new Employee();
        GridViewRow row = (GridViewRow)gvEmployee.Rows[e.RowIndex];

        string eId = ((TextBox)row.Cells[0].Controls[0]).Text;
        string eName = ((TextBox)row.Cells[1].Controls[0]).Text;
        string eEmail = ((TextBox)row.Cells[2].Controls[0]).Text;
        string eNo = ((TextBox)row.Cells[3].Controls[0]).Text;
        result = emp.EmployeeUpdate(eId, eName, eEmail, eNo );
        if (result > 0)
        {
            Response.Write("<script>alert('Employee updated successfully');</script>");
        }
        else
        {
            Response.Write("<script>alert('Employee NOT updated');</script>");
        }
        gvEmployee.EditIndex = -1;
        bind();
    }

    protected void gvEmployee_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int result = 0;
        Employee emp = new Employee();
        string categoryID = gvEmployee.DataKeys[e.RowIndex].Value.ToString();
        result = emp.EmployeeDelete(categoryID);
        if (result > 0)
        {
            Response.Write("<script>alert('Employee Remove successfully');</script>");
        }
        else
        {
            Response.Write("<script>alert('Employee Removal NOT successful');</script>");
        }
        Response.Redirect("EmployeeDetails.aspx");
    }

    
}