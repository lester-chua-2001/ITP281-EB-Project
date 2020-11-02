<%@ Page Title="" Language="C#" MasterPageFile="~/custnav.master" AutoEventWireup="true" CodeFile="CustomerCreate.aspx.cs" Inherits="CustomerCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-md-8" style="margin: auto; margin-top: 20px; background-color: ghostwhite; padding: 5px; border: 2px solid; border-radius: 10px;">
        <table class="w-100">
            <tr>
                <td class="auto-style1" style="width: 376px">ORDERS</td>
                <td class="auto-style2" style="width: 256px">QUANTITY</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1" style="width: 376px">Tee Shirt/Polo Tee</td>
                <td class="auto-style2" style="width: 256px">
                    <asp:TextBox ID="tb_Tee" maxlength="3" Placeholder="$3 per kg" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1" style="width: 376px">Shorts</td>
                <td class="auto-style2" style="width: 256px">
                    <asp:TextBox ID="tb_Shorts" maxlength="3" Placeholder="$4 per kg" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1" style="width: 376px">Blazer/Jackets</td>
                <td class="auto-style2" style="width: 256px">
                    <asp:TextBox ID="tb_Jackets" maxlength="3" Placeholder="$4 per piece" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1" style="width: 376px">Formal Top/Pants</td>
                <td class="auto-style2" style="width: 256px">
                    <asp:TextBox ID="tb_Formal" maxlength="3" Placeholder="$6 per piece" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1" style="width: 376px">Jeans</td>
                <td class="auto-style2" style="width: 256px">
                    <asp:TextBox ID="tb_Jeans" maxlength="3" Placeholder="$4 per kg" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1" style="width: 376px">Bedsheets/Blanket</td>
                <td class="auto-style2" style="width: 256px">
                    <asp:TextBox ID="tb_Bed" maxlength="3" Placeholder="$5 per kg" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1" style="width: 376px">Curtain</td>
                <td class="auto-style2" style="width: 256px">
                    <asp:TextBox ID="tb_Curtain" maxlength="3" Placeholder="$5 per kg" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1" style="width: 376px">Delivery Date</td>
                <td class="auto-style2" style="width: 256px">
                    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged1" SelectedDate="2019-08-06">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1" style="width: 376px">Delivery Time</td>
                <td class="auto-style2" style="width: 256px">
                    <asp:TextBox ID="tb_delv" runat="server" Placeholder="0000 - 2359" minlength="4" MaxLength="4" OnTextChanged="tb_delv_TextChanged"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfv_DTime" runat="server" ControlToValidate="tb_delv" ErrorMessage="Please input a time" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1" style="width: 376px">Pickup Date</td>
                <td class="auto-style2" style="width: 256px">
                    <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" OnDayRender="Calendar2_DayRender" OnSelectionChanged="Calendar2_SelectionChanged" Width="200px" SelectedDate="2019-08-06">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1" style="width: 376px">Pickup Time</td>
                <td class="auto-style2" style="width: 256px">
                    <asp:TextBox ID="tb_pckup" Placeholder="0000 - 2359" minlength="4" MaxLength="4" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfv_PTime" runat="server" ControlToValidate="tb_pckup" minlength="4" maxlength="4" ErrorMessage="Please input a time" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1" style="width: 376px">Pickup Address</td>
                <td class="auto-style2" style="width: 256px">
                    <asp:DropDownList ID="ddl_PAddress" runat="server" DataSourceID="SqlDataSource2" DataTextField="address" DataValueField="address" OnSelectedIndexChanged="ddl_PAddress_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:LoginDBContext %>" SelectCommand="SELECT [address] FROM [address]" OnSelecting="SqlDataSource2_Selecting"></asp:SqlDataSource>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1" style="width: 376px">Delivery Address</td>
                <td class="auto-style2" style="width: 256px">
                    <asp:DropDownList ID="ddl_DAddress" runat="server" DataTextField="address" DataValueField="" OnSelectedIndexChanged="ddl_Daddress_SelectedIndexChanged" DataSourceID="SqlDataSource1">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LoginDBContext %>" SelectCommand="SELECT [address] FROM [address]"></asp:SqlDataSource>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <asp:Button ID="btn_Next" runat="server" OnClick="btn_Next_Click" Text="Next" CssClass="btn btn-outline-success" />
    </div>
</asp:Content>

