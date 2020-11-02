<%@ Page Title="" Language="C#" MasterPageFile="~/custnav.master" AutoEventWireup="true" CodeFile="CustomerSubscribe.aspx.cs" Inherits="CustomerSubscribe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-md-8" style="margin: auto; margin-top: 20px; background-color: ghostwhite; padding: 10px; border: 2px solid; border-radius: 10px;">
        <h5><b>Subscribe to Laundrix!</b></h5>
        <hr>
        <asp:Button ID="btn_subscribe" class="btn btn-light btn-outline-success" Style="vertical-align: middle" runat="server" OnClick="Subcribe_Click" Text="Subscribe" />
    </div>
</asp:Content>

