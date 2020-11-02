<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/custnav.master" CodeFile="CustomerAddressView.aspx.cs" Inherits="CustomerAddressView" %>


    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
        <div class="container table-responsive table-condensed table-sm" style="margin: auto;">
        <asp:GridView ID="gv_ViewAddress" runat="server" AutoGenerateColumns="False" OnRowDeleting="gv_ViewAddress_RowDeleting" OnSelectedIndexChanged="gv_ViewAddress_SelectedIndexChanged1" DataKeyNames="address_id" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" Width="971px">
            <HeaderStyle
                BackColor="#606060"
                Height="35"
                ForeColor="White"
                Font-Bold="True" />
            <Columns>

                <asp:BoundField DataField="address" HeaderText="Address" />
                <asp:BoundField DataField="postal_code" HeaderText="Postal Code" />
                <asp:CommandField DeleteText="Delete Address" EditText="Edit Address" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <asp:Button CssClass="btn btn-dark" ID="btn_home" runat="server" OnClick="btn_home_Click" Text="Home" />
    
       </div>
</asp:Content>
    
