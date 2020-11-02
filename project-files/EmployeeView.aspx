<%@ Page Title="" Language="C#" MasterPageFile="~/empnav.master" AutoEventWireup="true" CodeFile="EmployeeView.aspx.cs" Inherits="EmployeeView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <div class="container table-responsive table-condensed table-sm" style="margin: auto; margin-bottom:20px;">
        <asp:gridview id="gvView" runat="server" cssclass="mydatagrid m-auto" headerstyle-cssclass="header" rowstyle-cssclass="rows"
            autogeneratecolumns="False" datakeynames="item_id"  BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px">
            
            <HeaderStyle
                BackColor="#606060"
                Height="35"
                ForeColor="White"
                Font-Bold="True" /><Columns>
                <asp:BoundField DataField="item_id" HeaderText="Item Reference" />
                <asp:BoundField DataField="item_name" HeaderText="Item Name" />
                <asp:BoundField DataField="item_price" HeaderText="Item Price" />
                <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                <asp:BoundField DataField="cleantype" HeaderText="Clean Type" />
                <asp:BoundField DataField="order_id" HeaderText="Order Reference" />
            </Columns>
        </asp:gridview>
    </div>
</asp:Content>

