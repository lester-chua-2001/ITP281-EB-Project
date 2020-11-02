<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Payment.aspx.cs" Inherits="CustomerConfirm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 405px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="col-md-8" style="margin: auto; margin-top: 20px; background-color: ghostwhite; padding: 5px; border: 2px solid; border-radius: 10px;">
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style2"><h1>Card Number:</h1></td>
                <td>
                    <asp:DropDownList ID="ddl_payment" runat="server" AutoPostBack="true" DataTextField="card_no" DataValueField="" OnSelectedIndexChanged="ddl_payment_SelectedIndexChanged" DataSourceID="SqlDataSource1">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LoginDBContext %>" SelectCommand="SELECT [card_no] FROM [payment]" ></asp:SqlDataSource>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
           
            <tr>
                <td class="auto-style2">
                    <h1>&nbsp;</h1>
                </td>
                <td class="auto-style2">
                    
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <h1>CC Expiry:</h1>
                </td>
                <td class="auto-style2">
                    <asp:Label ID="lbl_ccExpiry" runat="server" Font-Bold="True"></asp:Label>
                </td>
            </tr>

            <tr>
                <td class="auto-style2">
                    <asp:Button ID="btn_Back" runat="server" Height="70px" Text="Back" Width="173px" OnClick="btn_Back_Click" Font-Bold="True" />
                </td>
                <td>
                    <asp:Button ID="btn_Submit" runat="server" Height="80px" Text="Submit" Width="174px" OnClick="btn_Submit_Click" Font-Bold="True" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
        <br />
        <br />
    </form>
</body>
</html>
