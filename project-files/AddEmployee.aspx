<%@ Page Title="" Language="C#" MasterPageFile="~/Nav.master" AutoEventWireup="true" CodeFile="AddEmployee.aspx.cs" Inherits="AddEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <div class="row justify-content-center" style="margin-left: 0; margin-right: 0; padding-top: 20px">
            <div class="col-lg-8 col-sm-10" style="margin: auto; margin-top: 20px; margin-bottom: 20px; background-color: rgba(248,248,255 ,0.9); padding: 13px; border: 2px solid; border-radius: 10px;">

                <div class="form-group">
                    <p class="display-4">
                        Employee Registration
                    </p>
                    <hr />
                </div>

                <div class="form-group">
                    <label>Employee Name</label>
                    <asp:TextBox ID="tb_empname" runat="server" CssClass="form-control" placeholder="Name" Style="padding: 5px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_name" runat="server" ControlToValidate="tb_empname" ErrorMessage="Enter Employee Name" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label>Employee Contact Number</label>
                    <asp:TextBox ID="tb_contact" runat="server" CssClass="form-control" placeholder="Contact" Style="padding: 5px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_contact" runat="server" ErrorMessage="Enter Employee Contact" ControlToValidate="tb_contact" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label>Employee Email</label>
                    <asp:TextBox ID="tb_email" runat="server" type="email" CssClass="form-control" placeholder="Email" Style="padding: 5px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_email" runat="server" ErrorMessage="Enter Employee Email" ControlToValidate="tb_email" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group mb-2">
                    <label class="mb-0">Password</label><br />
                    <asp:TextBox ID="tb_password" runat="server" type="password" CssClass="form-control" placeholder="Password" Style="padding: 5px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_password" runat="server" ErrorMessage="Enter a password" ControlToValidate="tb_password" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group mb-2">
                    <asp:TextBox ID="tb_cfmpassword" runat="server" type="password" CssClass="form-control" placeholder="Confirm Password" Style="padding: 5px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_cfmpassword" runat="server" ErrorMessage="Confirm your password" ControlToValidate="tb_cfmpassword" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group mb-1">
                    <asp:Button class="btn btn-light btn-outline-success" ID="Submit" runat="server" Text="Add Employee" OnClick="Addemp_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

