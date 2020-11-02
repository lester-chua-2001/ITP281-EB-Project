<%@ Page Title="" Language="C#" MasterPageFile="~/drivernav.master" AutoEventWireup="true" CodeFile="DriverDetail.aspx.cs" Inherits="DriverDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    </br>
    <div class="container table-responsive table-condensed table-sm" style="margin: auto;">
        <asp:GridView ID="gvnew" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" DataKeyNames="order_id" OnRowCancelingEdit="gvnew_RowCancelingEdit" OnRowEditing="gvnew_RowEditing" OnRowUpdating="gvnew_RowUpdating">
            <HeaderStyle
                BackColor="#606060"
                Height="35"
                ForeColor="White"
                Font-Bold="True" />
            <Columns>
                <asp:BoundField DataField="item_id" HeaderText="Item Reference" />
                <asp:BoundField DataField="item_name" HeaderText="Item Name" />
                <asp:BoundField DataField="item_price" HeaderText="Item Price" />
                <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                <asp:BoundField DataField="cleantype" HeaderText="Clean Type" />
                <asp:BoundField DataField="order_id" HeaderText="Order Reference" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

