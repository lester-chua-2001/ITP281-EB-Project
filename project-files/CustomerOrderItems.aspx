<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerOrderItems.aspx.cs" Inherits="CustomerOrderItems" MasterPageFile="custnav.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <div class="container table-responsive table-condensed table-sm" style="margin: auto;">
        <asp:GridView ID="gv_ViewOrderItems" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px">
            <HeaderStyle
                BackColor="#606060"
                Height="35"
                ForeColor="White"
                Font-Bold="True" />
            <Columns>
                <asp:BoundField DataField="item_id" HeaderText="Order Reference" />
                <asp:BoundField DataField="item_name" HeaderText="Item Name" />
                <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                <asp:BoundField DataField="item_price" HeaderText="Item Price" />
                <asp:BoundField DataField="cleantype" HeaderText="Clean Type" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="btn_return" runat="server" OnClick="btn_return_Click" Text="Back" CssClass="btn btn-outline-dark"/>
    </div>

</asp:Content>
