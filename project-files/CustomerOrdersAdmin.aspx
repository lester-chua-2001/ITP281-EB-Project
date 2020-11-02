<%@ Page Title="" Language="C#" MasterPageFile="~/Nav.master" AutoEventWireup="true" CodeFile="CustomerOrdersAdmin.aspx.cs" Inherits="CustomerOrdersAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <div class="container table-responsive table-condensed table-sm" style="margin: auto;">
        <asp:GridView ID="gv_Order" runat="server" AutoGenerateColumns="False" DataKeyNames="order_id" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px">
            <HeaderStyle
                BackColor="#606060"
                Height="35"
                ForeColor="White"
                Font-Bold="True" />
            <Columns>
                <asp:BoundField HeaderText="Order Reference" DataField="order_id" />
                <asp:BoundField HeaderText="Total Price" DataField="total_price" />
                <asp:BoundField DataField="pickupdvr" HeaderText="Pick Up Driver" />
                <asp:BoundField DataField="deliverydvr" HeaderText="Delivery Driver" />
                <asp:BoundField HeaderText="Deliver Date" DataField="todate" />
                <asp:BoundField DataField="totime" HeaderText="Deliver Time" />
                <asp:BoundField DataField="frodate" HeaderText="Collection Date" />
                <asp:BoundField DataField="frotime" HeaderText="Collection Time" />
                <asp:BoundField DataField="order_status" HeaderText="Order Status" />
                <asp:BoundField DataField="payment_info" HeaderText="Payment Info" />
                <asp:BoundField DataField="pickupaddrid" HeaderText="Pick Up Address" />
                <asp:BoundField DataField="deliveryaddrid" HeaderText="Delivery Address" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

