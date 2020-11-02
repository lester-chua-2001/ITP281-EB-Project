<%@ Page Title="" Language="C#" MasterPageFile="~/Nav.master" AutoEventWireup="true" CodeFile="EmployeeDetails.aspx.cs" Inherits="EmployeeDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <head>
        <title>Employee Details</title>
    </head>

    <div class="container table-condensed table-sm " style="margin: auto;">
        <br />
        <asp:GridView ID="gvEmployee" DataKeyNames="Employee_ID" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" CssClass="table table-hover" OnRowCancelingEdit="gvEmployee_RowCancelingEdit" OnRowDeleting="gvEmployee_RowDeleting" OnRowEditing="gvEmployee_RowEditing" OnRowUpdating="gvEmployee_RowUpdating">

            <HeaderStyle
                BackColor="#606060"
                Height="35"
                ForeColor="White"
                Font-Bold="True" />
            <Columns>
                <asp:BoundField DataField="Employee_ID" HeaderText="Employee ID" />
                <asp:BoundField DataField="Employee_Name" HeaderText="Employee Name" />
                <asp:BoundField DataField="Employee_Email" HeaderText="Email" />
                <asp:BoundField DataField="Contact_No" HeaderText="Contact Number" />

                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />

            </Columns>
        </asp:GridView>
    </div>
    <br />
    <asp:Button class="btn btn-light btn-outline-dark" ID="btn_addEmployee" runat="server" Text="Add New Employee" OnClick="btn_addEmployee_Click" CausesValidation="false" Style="margin-left: 84px; padding: 5px" />


    <asp:Button class="btn btn-light btn-outline-dark" ID="btn_back" runat="server" OnClick="btn_back_Click" Text="Back" Style="padding: 5px" />
</asp:Content>

