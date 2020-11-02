<%@ Page Title="" Language="C#" MasterPageFile="drivernav.master" AutoEventWireup="true" CodeFile="Operations.aspx.cs" Inherits="Operations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="col-md-8" style="margin: auto; margin-top: 20px; background-color: ghostwhite; padding: 5px; border: 2px solid; border-radius: 10px;">
    <h4>
        Driver&#39;s Operation Notifications      
    </h4>
    <hr />
    <asp:scriptmanager id="ScriptManager1" runat="server">
    </asp:scriptmanager>
    <asp:updatepanel id="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Height="200px" Width="500px" CssClass="form-control" Style="margin-right: 10px; background-color:gainsboro; border:solid; justify-content:center"> 
                <asp:Label ID="Label1" runat="server" Font-Size="Large"></asp:Label>
            </asp:Panel> 
            <asp:Timer ID="Timer1" runat="server" Interval="2000" OnTick="Timer1_Tick"></asp:Timer>
        </ContentTemplate>
    </asp:updatepanel>
    </div>
</asp:Content>

