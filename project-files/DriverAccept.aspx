<%@ Page Title="" Language="C#" MasterPageFile="~/drivernav.master" AutoEventWireup="true" CodeFile="DriverAccept.aspx.cs" Inherits="DriverAccept" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    </br>
    <div class="container table-responsive table-condensed table-sm" style="margin: auto; justify-content: center;">
        <asp:gridview id="gvnew" runat="server" autogeneratecolumns="False" backcolor="White" bordercolor="Black" borderstyle="Solid" borderwidth="2px" datakeynames="order_id" onrowcancelingedit="gvnew_RowCancelingEdit" onrowediting="gvnew_RowEditing" onrowupdating="gvnew_RowUpdating" onselectedindexchanged="gvnew_SelectedIndexChanged">
                <HeaderStyle
                BackColor="#606060"
                Height="35"
                ForeColor="White"
                Font-Bold="True"/>
                <Columns>
                    <asp:BoundField DataField="order_id" HeaderText="Order ID" />
                    <asp:BoundField DataField="order_status" HeaderText="Order Status" />
                    <asp:BoundField DataField="payment_info" HeaderText="Payment Type" />
                    <asp:BoundField DataField="cust_id" HeaderText="Customer ID" />
                    <asp:BoundField DataField="Total_price" HeaderText="Price" />
                    <asp:BoundField DataField="todate" HeaderText="Collection Date" />
                    <asp:BoundField DataField="totime" HeaderText="Collection Time" />
                    <asp:BoundField DataField="pickupaddrid" HeaderText="Pick Up address" />
                    <asp:BoundField DataField="deliveryaddrid" HeaderText="Delivery address" />
                    <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-outline-success"/>
                    <asp:TemplateField>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Button ID="btn_Accepted" runat="server" Text="Pick Up" OnClick="btn_Accepted_Click" ControlStyle-CssClass="btn btn-outline-success"/>
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:gridview>
    </div>
</asp:Content>

