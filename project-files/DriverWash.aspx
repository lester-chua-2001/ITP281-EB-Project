<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DriverWash.aspx.cs" Inherits="WasherWash" MasterPageFile="empnav.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <div class="container table-responsive table-condensed table-sm" style="margin: auto; justify-content: center;">
        <asp:GridView ID="gvnew" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" DataKeyNames="order_id" OnRowCancelingEdit="gvnew_RowCancelingEdit" OnRowEditing="gvnew_RowEditing" OnRowUpdating="gvnew_RowUpdating" OnSelectedIndexChanged="gvnew_SelectedIndexChanged">
            <HeaderStyle
                BackColor="#606060"
                Height="35"
                ForeColor="White"
                Font-Bold="True" />
            <Columns>
                <asp:BoundField DataField="order_id" HeaderText="Order ID" />
                <asp:BoundField DataField="order_status" HeaderText="Order Status" />
                <asp:BoundField DataField="payment_info" HeaderText="Payment Type" />
                <asp:BoundField DataField="cust_id" HeaderText="Customer ID" />
                <asp:BoundField DataField="Total_price" HeaderText="Price" />
                <asp:BoundField DataField="frodate" HeaderText="Delivery Date" />
                <asp:BoundField DataField="frotime" HeaderText="Delivery" />
                <asp:BoundField DataField="pickupaddrid" HeaderText="Pick Up address" />
                <asp:BoundField DataField="deliveryaddrid" HeaderText="Delivery address" />
                <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-outline-success"/>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btn_Accepted" runat="server" Text="Washed" OnClick="btn_Accepted_Click" ControlStyle-CssClass="btn btn-outline-success"/>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

