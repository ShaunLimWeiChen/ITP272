<%@ Page Title="" Language="C#" MasterPageFile="~/Energy.master" AutoEventWireup="true" CodeFile="Energypage.aspx.cs" Inherits="Energypage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="LoginArea" Runat="Server">
<table id="loginstatus"class="nav-justified">
            <tr>
                <td style="height: 24px"><asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Timer ID="TimerTime" runat="server" Interval="1000" OnTick="TimerTime_Tick">
        </asp:Timer>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <asp:Label ID="lblDateToday" runat="server"></asp:Label>
                <asp:Label ID="lblTime" runat="server"></asp:Label>
                    <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label>
                    <asp:Label ID="lblusername" runat="server"></asp:Label>
            &nbsp&nbsp
                    <asp:Label ID="Label3" runat="server" Text="User Login ID:"></asp:Label><asp:Label ID="lblUserID" runat="server"></asp:Label>
            &nbsp&nbsp
                    <asp:Label ID="Label2" runat="server" Text="Last Login: "></asp:Label>
<asp:Label ID="lbllastlogin" runat="server"></asp:Label>
            &nbsp&nbsp&nbsp
            <asp:HyperLink ID="LogoutProfile" runat="server" NavigateUrl="Users/Logout.aspx">Logout</asp:HyperLink>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="TimerTime" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel></td>
            </tr>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                     <asp:HyperLink ID="LoginProfile" runat="server" NavigateUrl="Users/loginform.aspx">Login Here</asp:HyperLink>
                </ContentTemplate>
            </asp:UpdatePanel>
            </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="productContent1" Runat="Server">
 <asp:GridView ID="gvEnergyEfficiency" runat="server" BackColor="White" 
        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        Width="909px">
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#330099" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <SortedAscendingCellStyle BackColor="#FEFCEB" />
        <SortedAscendingHeaderStyle BackColor="#AF0101" />
        <SortedDescendingCellStyle BackColor="#F6F0C0" />
        <SortedDescendingHeaderStyle BackColor="#7E0000" />
    </asp:GridView>
    <br />
    <asp:Chart ID="chartEnergyEfficiency" runat="server" onload="chartEnergyEfficiency_Load">
        <Series>
            <asp:Series Name="Series1">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
    <br />
    <br />
 <a href='Sensordisplay.aspx'>More data</a>
</asp:Content>

