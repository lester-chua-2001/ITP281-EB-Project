<%@ Page Title="" Language="C#" MasterPageFile="~/Nav.master" AutoEventWireup="true" CodeFile="CustomerDetails.aspx.cs" Inherits="CustomerDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <head>
        <title>Customer Details</title>
    </head>
    </br>
    <div class="form-inline my-2 my-lg-0" style="margin: auto; justify-content: center;">
        <asp:TextBox ID="tbsearch" runat="server" class="form-control mr-sm-2" placeholder="Search" onfocus="this.value=''" aria-label="Search"></asp:TextBox>
        <asp:Button ID="search" runat="server" Text="Search" OnClick="search_Click" CssClass="btn btn-light btn-outline-success my-2 my-sm-0"></asp:Button>
    </div>
    <br />
    <div class="container table-responsive table-condensed table-sm" style="margin: auto;">
        <asp:GridView ID="gvCustomer" DataKeyNames="Customer_ID" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px"
            OnSelectedIndexChanged="gvCustomer_SelectedIndexChanged" OnRowCancelingEdit="gvCustomer_RowCancelingEdit" OnRowEditing="gvCustomer_RowEditing" OnRowUpdating="gvCustomer_RowUpdating" OnRowDeleting="gvCustomer_RowDeleting"
            CssClass="table table-hover" AllowPaging="true"
            PageSize="10" OnPageIndexChanging="IndexChanging">
            <HeaderStyle
                BackColor="#606060"
                Height="35"
                ForeColor="White"
                Font-Bold="True" />
            <Columns>
                <asp:BoundField DataField="Customer_ID" HeaderText="Customer ID" />
                <asp:BoundField DataField="Customer_Name" HeaderText="Customer Name" />
                <asp:BoundField DataField="Customer_Email" HeaderText="Email" />
                <asp:BoundField DataField="Contact_No" HeaderText="Contact Number" />
                <asp:BoundField DataField="Membership_Status" HeaderText="Membership Status" />
                <asp:CommandField ShowSelectButton="true" SelectText="View" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>

    <br />
    <asp:Button class="btn btn-light btn-outline-dark" ID="btn_addcustomer" runat="server" Text="Add New Customer" OnClick="btn_addcustomer_Click" CausesValidation="false" Style="margin-left: 84px; padding: 5px" />


    <asp:Button class="btn btn-light btn-outline-dark" ID="btn_back" runat="server" OnClick="btn_back_Click" Text="Back" Style="padding: 5px" />
</asp:Content>

