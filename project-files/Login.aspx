<%@ Page Title="" Language="C#" MasterPageFile="~/Nav2.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <head>
        <title>Login</title>
    </head>
    <style>
        
    </style>
    <div class="row justify-content-center" style="margin-left: 0; margin-right: 0; padding-top: 20px">
        <div class="col-lg-6 col-sm-10" style="margin: auto; margin-top: 20px; background-color: rgba(248,248,255 ,0.9); padding: 13px; border: 2px solid; border-radius: 10px;">
            <div class="form-group">
                <p class="display-4">
                    Laundrix Login
                </p>
                <hr />
            </div>
            <asp:Label ID="Lbl_Invalid" runat="server" ForeColor="Red"></asp:Label>
            <div class="form-group mb-2">
                <label>
                    Your Email</label>
                <asp:TextBox ID="tb_email" runat="server" type="email" CssClass="form-control" placeholder="Email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_email" runat="server" ErrorMessage="Please enter your email!" ControlToValidate="tb_email" ForeColor="Red" Display="Dynamic" CssClass="align-content-md-between"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group mb-2">
                <label>Password</label><br />
                <asp:TextBox ID="tb_password" runat="server" type="password" CssClass="form-control" placeholder="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_password" runat="server" ErrorMessage="Please enter your password!" ControlToValidate="tb_password" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group mb-2">
                <asp:HyperLink ID="hl_register" runat="server" NavigateUrl="~/RegistrationForm.aspx" class="badge badge-pill badge-primary" Style="padding:5px">Don't have an account? Sign Up Here</asp:HyperLink>
                <asp:HyperLink ID="hl_forgetpassword" runat="server" NavigateUrl="~/ForgetPassword.aspx" class="badge badge-pill badge-primary" Style="padding:5px">Forget Password?</asp:HyperLink>
                

            </div>
            <div class="form-group mb-1">
                <asp:Button class="btn btn-light btn-outline-success" ID="S" runat="server" Text="Login" OnClick="S_Click" />
            </div>
        </div>
    </div>

</asp:Content>

