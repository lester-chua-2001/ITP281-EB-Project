<%@ Page Title="" Language="C#" MasterPageFile="~/Nav.master" AutoEventWireup="true" CodeFile="DriverDetails.aspx.cs" Inherits="DriverDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <head>
        <title>Driver Details</title>
    </head>

    <div class="container table-condensed table-sm " style="margin: auto;">
        <br />
        <asp:GridView ID="gvDriver" DataKeyNames="Driver_ID" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" CssClass="table table-hover" OnRowCancelingEdit="gvDriver_RowCancelingEdit" OnRowDeleting="gvDriver_RowDeleting" OnRowEditing="gvDriver_RowEditing" OnRowUpdating="gvDriver_RowUpdating">
            <HeaderStyle
                BackColor="#606060"
                Height="35"
                ForeColor="White"
                Font-Bold="True" />
            <Columns>
                <asp:BoundField DataField="Driver_ID" HeaderText="Driver ID" />
                <asp:BoundField DataField="Driver_Name" HeaderText="Driver Name" />
                <asp:BoundField DataField="Driver_Email" HeaderText="Email" />
                <asp:BoundField DataField="Contact_No" HeaderText="Contact Number" />

                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />

            </Columns>
        </asp:GridView>
    </div>
    <br />
    <asp:Button class="btn btn-light btn-outline-dark" ID="btn_addDriver" runat="server" Text="Add New Driver" OnClick="btn_addDriver_Click" CausesValidation="false" Style="margin-left: 84px; padding: 5px" />

    <asp:Button class="btn btn-light btn-outline-dark" ID="btn_back" runat="server" OnClick="btn_back_Click" Text="Back" Style="padding: 5px"/>
</asp:Content>

