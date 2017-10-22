<%@ Page Title="" Language="C#" MasterPageFile="~/Smarthome.master" AutoEventWireup="true" CodeFile="Smarthome.aspx.cs" Inherits="Smarthome" %>

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

</asp:Content>

