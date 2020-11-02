<%@ Page Title="" Language="C#" MasterPageFile="~/empnav.master" AutoEventWireup="true" CodeFile="EmployeeHome.aspx.cs" Inherits="EmployeeHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    </br>
    <div class="form-inline my-2 my-lg-0" style="margin: auto; justify-content: center;">
        <asp:TextBox ID="tbsearch" runat="server" class="form-control mr-sm-2" placeholder="Search" onfocus="this.value=''" aria-label="Search" ></asp:TextBox>
        <asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click" CssClass="btn btn-light btn-outline-success my-2 my-sm-0"></asp:Button>
&nbsp;&nbsp;&nbsp;&nbsp;<h2 style="color:gold"><b>|</b></h2>&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" CssClass="btn btn-primary dropdown-toggle">
            <asp:ListItem>New</asp:ListItem>
            <asp:ListItem>Accepted</asp:ListItem>
            <asp:ListItem>Collected</asp:ListItem>
            <asp:ListItem>Washing</asp:ListItem>
            <asp:ListItem>Ready</asp:ListItem>
            <asp:ListItem>Delivering</asp:ListItem>
            <asp:ListItem>Completed</asp:ListItem>
        </asp:DropDownList>
        &nbsp;<asp:Button ID="btn_reset" runat="server" OnClick="btn_reset_Click" Text="Reset" class="btn btn-light btn-outline-danger" />
    </div>
    </br>
    <div class="container table-responsive table-condensed table-sm" style="margin: auto;margin-bottom:20px;">
        <asp:GridView ID="gvOrder" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvOrder_SelectedIndexChanged"
            CssClass="mydatagrid" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowSorting="True" OnSorting="gvOrder_Sorting"
            currentsortfield="total_price" currentsortdirection="ASC" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px">
            <HeaderStyle
                BackColor="#606060"
                Height="35"
                ForeColor="White"
                Font-Bold="True" />
            <Columns>
                <asp:BoundField DataField="order_id" HeaderText="Order Reference" SortExpression="order_id" />
                <asp:BoundField DataField="total_price" HeaderText="Total Price" SortExpression="total_price" />
                <asp:BoundField DataField="pickupdvr" HeaderText="Pick Up Driver" SortExpression="pickupdvr" />
                <asp:BoundField DataField="deliverydvr" HeaderText="Delivery Driver" SortExpression="deliverydvr" />
                <asp:BoundField DataField="order_status" HeaderText="Order Status" SortExpression="order_status" />
                <asp:BoundField DataField="payment_info" HeaderText="Payment Information" SortExpression="payment_info" />
                <asp:BoundField DataField="todate" HeaderText="Collection Date" SortExpression="todate"></asp:BoundField>
                <asp:BoundField DataField="totime" HeaderText="Collection Time" SortExpression="totime" />
                <asp:BoundField DataField="frodate" HeaderText="Delivery Date" SortExpression="frodate" />
                <asp:BoundField DataField="frotime" HeaderText="Delivery Time" SortExpression="frotime" />
                <asp:BoundField DataField="pickupaddrid" HeaderText="Pick up Address" SortExpression="pickupaddrid" />
                <asp:BoundField DataField="deliveryaddrid" HeaderText="Delivery Address" SortExpression="deliveryaddrid" />
                <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-outline-success"/>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

