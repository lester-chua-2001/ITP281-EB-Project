<%@ Page Title="" Language="C#" MasterPageFile="~/Nav2.master" AutoEventWireup="true" CodeFile="AddDriver.aspx.cs" Inherits="AddDriver" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <div class="row justify-content-center" style="margin-left: 0; margin-right: 0; padding-top: 20px">
            <div class="col-lg-8 col-sm-10" style="margin: auto; margin-top: 20px; margin-bottom: 20px; background-color: rgba(248,248,255 ,0.9); padding: 13px; border: 2px solid; border-radius: 10px;">

                <div class="form-group">
                    <p class="display-4">
                        Driver's Registration
                    </p>
                    <hr />
                </div>

                <div class="form-group">
                    <label>Driver Name</label>
                    <asp:TextBox ID="tb_dvrname" runat="server" CssClass="form-control" placeholder="Name" Style="padding: 5px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_name" runat="server" ControlToValidate="tb_dvrname" ErrorMessage="Enter Employee Name" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label>Driver Contact Number</label>
                    <asp:TextBox ID="tb_contact" runat="server" CssClass="form-control" placeholder="Contact" Style="padding: 5px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_contact" runat="server" ErrorMessage="Enter Employee Contact" ControlToValidate="tb_contact" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label>Driver Email</label>
                    <asp:TextBox ID="tb_email" runat="server" type="email" CssClass="form-control" placeholder="Email" Style="padding: 5px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_email" runat="server" ErrorMessage="Enter Employee Email" ControlToValidate="tb_email" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group mb-2">
                    <label class="mb-0">Password</label><br />
                    <small>Make sure your password is at least 8 characters.</small>
                    <asp:TextBox ID="tb_password" runat="server" type="password" minlength="8" CssClass="form-control" placeholder="Password" Style="padding: 5px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_password" runat="server" ErrorMessage="Enter a password" ControlToValidate="tb_password" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group mb-2">
                    <asp:TextBox ID="tb_cfmpassword" runat="server" type="password" CssClass="form-control" placeholder="Confirm Password" Style="padding: 5px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_cfmpassword" runat="server" ErrorMessage="Confirm your password" ControlToValidate="tb_cfmpassword" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group mb-1">
                    <asp:Button class="btn btn-light btn-outline-success" ID="Submit" runat="server" Text="Create Driver Account" OnClick="Adddvr_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

