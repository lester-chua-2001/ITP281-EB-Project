<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="ForgetPassword.aspx.cs" Inherits="ForgetPassword" MasterPageFile="~/Nav2.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row justify-content-center" style="margin-left: 0; margin-right: 0; padding-top: 20px">
        <div class="col-lg-8 col-sm-10" style="margin: auto; margin-top: 20px; margin-bottom: 20px; background-color: rgba(248,248,255 ,0.9); padding: 13px; border: 2px solid; border-radius: 10px;">
            <div class="form-group">
                <p class="display-4">
                    Forget Password
                </p>
                <hr dir="ltr" />
            </div>
            <div class="form-group">
                <p>
                    Verification Email to change your password will be sent to you shortly.
                </p>
            </div>
            <asp:Label ID="lblpassrec" runat="server"></asp:Label>

            <div>
                <p>Email</p>
                <asp:TextBox ID="tb_email" runat="server"></asp:TextBox>
                <asp:Button ID="btn_sendemail" runat="server" Text="Send" OnClick="btn_sendemail_Click1" class="btn btn-light btn-outline-success"/>

            </div>
        </div>
</asp:Content>
