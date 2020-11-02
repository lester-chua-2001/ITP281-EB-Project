<%@ Page Title="" Language="C#" MasterPageFile="~/Nav2.master" AutoEventWireup="true" CodeFile="RegistrationForm.aspx.cs" Inherits="RegistrationForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <head>
        <title>Register Here!</title>
    </head>

    <div class="row justify-content-center" style="margin-left: 0; margin-right: 0; padding-top: 20px">
        <div class="col-lg-8 col-sm-10" style="margin: auto; margin-top: 20px; margin-bottom: 20px; background-color: rgba(248,248,255 ,0.9); padding: 13px; border: 2px solid; border-radius: 10px;">

            <div class="form-group">
                <p class="display-4">
                    <b>Laundrix Registration</b>
                </p>
                <hr />
            </div>

            <div class="form-group mb-2">
                <label>Your Name</label>
                <asp:TextBox ID="tb_custname" runat="server" CssClass="form-control" placeholder="Name" Style="padding: 5px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_name" runat="server" ControlToValidate="tb_custname" ErrorMessage="Enter your name" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group mb-2">
                <label>Contact Phone Number</label>
                <asp:TextBox ID="tb_contact" runat="server" CssClass="form-control" placeholder="Contact" Style="padding: 5px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_contact" runat="server" ErrorMessage="Enter your contact" ControlToValidate="tb_contact" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group mb-2">
                <label>Your Email</label>
                <asp:TextBox ID="tb_email" type="email" runat="server" CssClass="form-control" placeholder="Email" Style="padding: 5px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_email" runat="server" ErrorMessage="Enter your email" ControlToValidate="tb_email" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group mb-2">
                <label class="mb-0">Password</label><br />
                <small>Make sure your password is at least 8 characters.</small>
                <asp:TextBox ID="tb_password" runat="server" type="password" minlength="8" CssClass="form-control" placeholder="Password" Style="padding: 5px;"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_password" runat="server" ErrorMessage="Enter a password" ControlToValidate="tb_password" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group mb-2">
                <asp:TextBox ID="tb_cfmpassword" runat="server" type="password" CssClass="form-control" placeholder="Confirm Password" Style="padding: 5px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_cfmpassword" runat="server" ErrorMessage="Confirm your password" ControlToValidate="tb_cfmpassword" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cv_password" runat="server" ErrorMessage="Oops! Password do not match" ControlToCompare="tb_password" ControlToValidate="tb_cfmpassword" Display="Dynamic"></asp:CompareValidator>
            </div>

            <div class="form-group mb-1">
                <asp:Button class=" btn btn-light btn-outline-success" ID="Submit" runat="server" Text="Create Account" OnClick="Submit_Click" />
                <asp:HyperLink ID="hl_register" runat="server" NavigateUrl="~/AddDriver.aspx" class="badge badge-pill badge-primary" Style="padding: 5px; float: right;">Signing Up as our driver? Click Here!</asp:HyperLink>
            </div>
        </div>
    </div>
</asp:Content>

