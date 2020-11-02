<%@ Page Title="" Language="C#" MasterPageFile="~/drivernav.master" AutoEventWireup="true" CodeFile="DriverProfile.aspx.cs" Inherits="DriverProfile" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-md-8" style="margin: auto; margin-top: 20px; background-color: ghostwhite; padding: 5px; border: 2px solid; border-radius: 10px;">
        <div class="row" style="margin: 2px; padding: 5px; border-bottom: 1px solid; border-bottom-color: lightgray;">
            <div class="col-md-6" style="color: #FFC300">
                <label><b>Driver ID</b></label>
            </div>
            <div class="col-md-6">
                <asp:Label ID="lbl_dvr_id" runat="server" CssClass="form-control" Style="margin-right: 10px; background-color: gainsboro"> </asp:Label>
            </div>
        </div>
        <div class="row" style="margin: 2px; padding: 5px; border-bottom: 1px solid; border-bottom-color: lightgray;">
            <div class="col-md-6" style="color: #FFC300">
                <label><b>Driver Name</b></label>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="tb_dvr_name" runat="server" CssClass="form-control" Style="margin-right: 10px"> </asp:TextBox>
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
                <label><b>Password</b></label>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="tb_password" runat="server" CssClass="form-control" Style="margin-right: 10px"> </asp:TextBox>
            </div>
        </div>
        <div class="row" style="margin: 2px; padding: 5px; border-bottom: 1px solid; border-bottom-color: lightgray;">
            <div class="col-md-6" style="color: #FFC300">
                <label><b>Contact Number</b></label>
            </div>
            <div class="col-md-6">
                <asp:Textbox ID="tb_contact_no" runat="server" CssClass="form-control" Style="margin-right: 10px;"> </asp:Textbox>
            </div>
        </div>
        </br>
                <asp:Button ID="btn_update" runat="server" Text="Update" OnClick="btn_update_Click" class="btn btn-outline-success" Style="margin-left: 18px; margin-bottom: 5px;" />

        <asp:Button ID="btn_back" runat="server" Text="Back" OnClick="btn_back_Click" class="btn btn-outline-dark" Style="margin-bottom: 5px;" />
</asp:Content>

