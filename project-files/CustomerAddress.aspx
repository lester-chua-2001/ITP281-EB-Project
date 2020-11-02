<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerAddress.aspx.cs" Inherits="CustomerPayment" MasterPageFile="~/custnav.master"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row justify-content-center" style="margin-left: 0; margin-right: 0; padding-top: 20px">
        <div class="col-lg-8 col-sm-10" style="margin: auto; margin-top: 20px; margin-bottom: 20px; background-color: rgba(248,248,255 ,0.9); padding: 13px; border: 2px solid; border-radius: 10px;">
         <table class="w-100">
             <tr>
                <td class="auto-style1" style="width: 465px"><h1>Customer Address Info</h1> </td>
            </tr>
           <tr>
                <td class="auto-style1" style="width: 465px; height: 36px;">Address: </td>
                <td class="auto-style2" style="height: 36px">
                    <asp:TextBox ID="tb_address" runat="server"></asp:TextBox>
                </td>
                <td style="height: 36px">
                    <asp:RequiredFieldValidator ID="rfv_address" runat="server" Display="Dynamic" ErrorMessage="Please input an Address"  ForeColor="Red" ControlToValidate="tb_address"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1" style="width: 465px">Postal Code: </td>
                <td class="auto-style2">
                    <asp:TextBox ID="tb_postalCode" minlength="6" maxlength="6" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ErrorMessage="Please input a Postal Code" ForeColor="Red" ControlToValidate="tb_postalCode"></asp:RequiredFieldValidator>
                </td>
            </tr>
            
            <tr>
                <td class="auto-style1" style="width: 465px">
                <asp:Button class=" btn btn-light btn-outline-success" ID="btn_Add" runat="server" OnClick="btn_Add_Click" Text="Add" />
                </td>
               
              
                <td>
                    &nbsp;</td>
            </tr>
            
        </table>
 </div>
        </div>
</asp:Content>