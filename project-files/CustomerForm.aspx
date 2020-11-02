<%@ Page Title="" Language="C#" MasterPageFile="~/custnav.master" AutoEventWireup="true" CodeFile="CustomerForm.aspx.cs" Inherits="CustomerForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="margin:10px;">
     <h3>Welcome
     <asp:Label ID="lbl_custname" runat="server"></asp:Label>,<asp:Button ID="btn_CreateOrder" CssClass="btn btn-dark" runat="server" OnClick="btn_CreateOrder_Click1" Text="Submit a new order" />
&nbsp;<asp:Button ID="btn_trackorder" runat="server" OnClick="btn_trackorder_Click" Text="Track your current orders" CssClass="btn btn-dark"/>
        </h3>
    </div>
    
</asp:Content>

