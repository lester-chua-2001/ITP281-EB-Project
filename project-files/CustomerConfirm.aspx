<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerConfirm.aspx.cs" Inherits="CustomerConfirm" %>

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
        .auto-style3 {
            width: 405px;
            height: 49px;
        }
        .auto-style4 {
            height: 49px;
        }
        .auto-style5 {
            width: 405px;
            height: 26px;
        }
        .auto-style6 {
            height: 26px;
        }
    </style>
</head>
<body>
    
    <form id="form1" runat="server">
    <div class="col-md-8" style="margin: auto; margin-top: 20px; background-color: ghostwhite; padding: 5px; border: 2px solid; border-radius: 10px;">
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <h1 style="margin-right: 0px">Your total cost will be :</h1>
                </td>
                <td>
                    <asp:Label ID="lbl_TotalCost" runat="server" Font-Bold="True" Height="50px" Width="300px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <h1>Delivery Date :</h1>
                </td>
                <td>
                    <asp:Label ID="lbl_DDate" runat="server" Font-Bold="True" Height="50px" Width="300px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <h1>Delivery Time:</h1>
                </td>
                <td>
                    <asp:Label ID="lbl_DTime" runat="server" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <h1>Pickup Date:</h1>
                </td>
                <td>
                    <asp:Label ID="lbl_PDate" runat="server" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <h1>Pickup Time:</h1>
                </td>
                <td class="auto-style4">
                    <asp:Label ID="lbl_PTime" runat="server" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <h1>Pickup Address</h1>
                </td>
                <td>
                    <asp:Label ID="lbl_PAddress" runat="server" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <h1>Delivery Address</h1>
                </td>
                <td class="auto-style6">
                    <asp:Label ID="lbl_DAddress" runat="server" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="btn_Back" runat="server" Height="70px" Text="Back" Width="173px" OnClick="btn_Back_Click" Font-Bold="True" />
                </td>
                <td>
                    <asp:Button ID="btn_payCard" runat="server" Height="80px" Text="Payment (Card)" Width="174px" OnClick="btn_payCard_Click" Font-Bold="True" />
                </td>
                <td>
                    <asp:Button ID="btn_payCash" runat="server" Height="80px" Text="Payment (Cash)" Width="174px" OnClick="btn_payCash_Click" Font-Bold="True" />
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