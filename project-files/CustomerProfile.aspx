<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerProfile.aspx.cs" Inherits="CustomerProfile" MasterPageFile="~/custnav.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-md-8" style="margin: auto; margin-top: 20px; background-color: ghostwhite; padding: 5px; border: 2px solid; border-radius: 10px;">
        <div class="row" style="margin: 2px; padding: 5px; border-bottom: 1px solid; border-bottom-color: lightgray;">
            <div class="col-md-6" style="color: #FFC300">
                <label><b>Customer ID</b></label>
            </div>
            <div class="col-md-6">
                <asp:Label ID="lbl_custid" runat="server" CssClass="form-control" Style="margin-right: 10px; background-color:gainsboro"> </asp:Label>
            </div>
        </div>
        <div class="row" style="margin: 2px; padding: 5px; border-bottom: 1px solid; border-bottom-color: lightgray;">
            <div class="col-md-6" style="color: #FFC300">
                <label><b>Customer Name</b></label>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="tb_custname" runat="server" CssClass="form-control" Style="margin-right: 10px"> </asp:TextBox>
            </div>
        </div>
        <div class="row" style="margin: 2px; padding: 5px; border-bottom: 1px solid; border-bottom-color: lightgray;">
            <div class="col-md-6" style="color: #FFC300">
                <label><b>Email</b></label>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="tb_email" runat="server" CssClass="form-control" Style="margin-right: 10px"> </asp:TextBox>
            </div>
        </div>
        <div class="row" style="margin: 2px; padding: 5px; border-bottom: 1px solid; border-bottom-color: lightgray;">
            <div class="col-md-6" style="color: #FFC300">
                <label><b>Contact Number</b></label>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="tb_contactno" runat="server" CssClass="form-control" Style="margin-right: 10px"> </asp:TextBox>
            </div>
        </div>
        <div class="row" style="margin: 2px; padding: 5px; border-bottom: 1px solid; border-bottom-color: lightgray;">
            <div class="col-md-6" style="color: #FFC300">
                <label><b>Membership Status</b></label>
            </div>
            <div class="col-md-6">
                <asp:Label ID="lbl_mbrstatus" runat="server" CssClass="form-control" Style="margin-right: 10px ;background-color:gainsboro"> </asp:Label>
            </div>
        </div>
    </div>
        </br>
               <asp:Button class="btn btn-light btn-outline-dark" ID="btn_update" runat="server" Text="Update" OnClick="btn_update_Click" Style="margin-left: 18px; margin-bottom: 5px;" />

        <asp:Button class="btn btn-light btn-outline-dark" ID="btn_back" runat="server" Text="Back" OnClick="btn_back_Click" Style="margin-bottom: 5px;" />
</asp:Content>
