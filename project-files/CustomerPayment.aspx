<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerPayment.aspx.cs" Inherits="CustomerPayment" MasterPageFile="~/custnav.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row justify-content-center" style="margin-left: 0; margin-right: 0; padding-top: 20px">
        <div class="col-lg-8 col-sm-10" style="margin: auto; margin-top: 20px; margin-bottom: 20px; background-color: rgba(248,248,255 ,0.9); padding: 13px; border: 2px solid; border-radius: 10px;">
         <table class="w-100">
             <tr>
                <td class="auto-style1"><h1>Customer Payment Info</h1> </td>
            </tr>
           <tr>
                 
                <td class="auto-style1">Card Number: </td>
                <td class="auto-style2">
                    <asp:TextBox ID="tb_cardNo" minlength="16" MaxLength="16" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfv_ccNo" runat="server" ControlToValidate="tb_cardNo" ErrorMessage="Please input your Card Number" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
       
            <tr>
                <td class="auto-style1">CVV Number: </td>
                <td class="auto-style2">
                    <asp:TextBox ID="tb_cvvNo" type="password" minlength="3" MaxLength="3" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfv_cvvNo" runat="server" ControlToValidate="tb_cvvNo" Display="Dynamic" ErrorMessage="Please input your CVV Number" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Card Expiry:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="tb_cardExpiry" placeholder="MM/YYYY" minlength="7" maxlength="7" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfv_ccExp" runat="server" ControlToValidate="tb_cardExpiry" ErrorMessage="Please input your Card Expiry Date" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <asp:Button class=" btn btn-light btn-outline-success" ID="btn_Next" runat="server" OnClick="btn_Add_Click" Text="Add" />

            </div>
        </div>
</asp:Content>
