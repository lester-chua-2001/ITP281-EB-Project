<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddNotification.aspx.cs" Inherits="AddNotification" MasterPageFile="Nav.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        
    <div class="col-md-8" style="margin: auto; margin-top: 20px; background-color: ghostwhite; padding: 5px; border: 2px solid; border-radius: 10px;">
            <div class="row" style="margin:2px; padding: 5px; border-bottom:1px solid; border-bottom-color: lightgray;">
                <div class="col-md-6" style="color: #FFC300">
                    <label><b>Enter Notification</b></label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="tb_noti" runat="server" CssClass="form-control" Style="margin-right: 10px" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
                    <asp:Button ID="btn_send" runat="server" OnClick="Button1_Click" Text="Send" CssClass="btn btn-light btn-outline-success" />
                    <asp:Label ID="Lbl_noti" runat="server" ForeColor="#66FF33"></asp:Label>

    <div>
    
    </div>
</asp:Content>
