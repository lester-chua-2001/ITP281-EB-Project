<%@ Page Title="" Language="C#" MasterPageFile="~/Nav.master" AutoEventWireup="true" CodeFile="CustomerDetailsView.aspx.cs" Inherits="CustomerDetailsView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <head>
        <title>View Customer Details</title>
    </head>
    <body>

        <div class="col-md-8" style="margin: auto; margin-top: 20px; background-color: ghostwhite; padding: 5px; border: 2px solid; border-radius: 10px;">
            <div class="row" style="margin:2px; padding: 5px; border-bottom:1px solid; border-bottom-color: lightgray;">
                <div class="col-md-6" style="color: #FFC300">
                    <label><b>Registered Datetime</b></label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="tb_regdatetime" runat="server" Enabled="False" CssClass="form-control" Style="margin-right: 10px"> </asp:TextBox>
                </div>
            </div>
            <div class="row" style="margin:2px; padding: 5px; border-bottom:1px solid; border-bottom-color: lightgray;">
                <div class="col-md-6" style="color: #FFC300">
                    <label><b>Customer ID</b></label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="tb_custid" runat="server" Enabled="False" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row" style="margin:2px; padding: 5px; border-bottom:1px solid; border-bottom-color: lightgray;">
                <div class="col-md-6" style="color: #FFC300">
                    <label><b>Customer Name</b></label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="tb_custname" runat="server" Enabled="False" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row" style="margin:2px; padding: 5px; border-bottom:1px solid; border-bottom-color: lightgray;">
                <div class="col-md-6" style="color: #FFC300">
                    <label><b>Email</b></label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="tb_email" runat="server" Enabled="False" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row" style="margin:2px; padding: 5px; border-bottom:1px solid; border-bottom-color: lightgray;">
                <div class="col-md-6" style="color: #FFC300">
                    <label><b>Contact Number</b></label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="tb_contactno" runat="server" Enabled="False" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row" style="margin:2px; padding: 5px; border-bottom:1px solid; border-bottom-color: lightgray;">
                <div class="col-md-6" style="color: #FFC300">
                    <label><b>Membership Status</b></label>
                </div>
                <div class="col-md-6">
                    <asp:DropDownList ID="ddl_mbrstatus" runat="server" CssClass="form-control btn-outline-info">
                        <asp:ListItem Selected="True">Member</asp:ListItem>
                        <asp:ListItem>Subscriber</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row" style="margin:2px; padding: 5px; border-bottom:1px solid; border-bottom-color: lightgray;">
                <div class="col-md-6" style="color: #FFC300">
                    <label><b>Password</b></label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="tb_password" runat="server" Type="password" Enabled="False" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <br />
            <asp:Button ID="btn_update" runat="server" Text="Update" OnClick="btn_update_Click" class="btn btn-outline-success" style="margin-left:18px; margin-bottom:5px;"/>

            <asp:Button ID="btn_back" runat="server" Text="Back" OnClick="btn_back_Click" class="btn btn-outline-dark" style="margin-bottom:5px;"/>
        </div>
        



    </body>
</asp:Content>

