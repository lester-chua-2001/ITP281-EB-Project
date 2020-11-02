<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="ResetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1>Reset Password</h1>
        <br />
        <div>
            <asp:Label ID="lblmsg" runat="server" Font-Size="XX-Large"></asp:Label>
        </div>
        <div>
        <asp:Label ID="lblpassword" runat="server" Text="New Password" Visible="False"></asp:Label>
        <asp:TextBox ID="tbnewpass" TextMode="Password" runat="server" Visible="False"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorpass" runat="server" ErrorMessage="Please enter your new password" ControlToValidate="tbnewpass" ForeColor="Red" Visible="False"></asp:RequiredFieldValidator>
        <br />
        <br />
        </div>
        <div>
        <asp:Label ID="lblretypepass" runat="server" Text="Confirm Password" Visible="False"></asp:Label>
        <asp:TextBox ID="tbconfirmpass" TextMode="Password"  runat="server" Visible="False" Wrap="False"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Both password must be the same!" ControlToValidate="tbnewpass" ControlToCompare="tbconfirmpass" ForeColor="Red" Visible="False"></asp:CompareValidator>
        <br />
        <br />
        </div>
        <div>
            <asp:Button ID="btrespass" runat="server" Text="Reset" Visible="False" OnClick="btrespass_Click"/>
        </div>
    </div>
    </form>
</body>
</html>
