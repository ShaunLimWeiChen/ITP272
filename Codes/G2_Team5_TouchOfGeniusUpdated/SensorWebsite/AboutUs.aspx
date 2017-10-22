<%@ Page Title="" Language="C#" MasterPageFile="~/About.master" AutoEventWireup="true" CodeFile="AboutUs.aspx.cs" Inherits="AboutUs" %>

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
                     <asp:HyperLink ID="LoginProfile" runat="server" NavigateUrl="Users/Login.aspx">Login Here</asp:HyperLink>
                </ContentTemplate>
            </asp:UpdatePanel>
            </table>
</asp:Content>
<asp:Content ID="Maincontentforweb" ContentPlaceHolderID="MainContent" Runat="Server">
  <p> Insight Tech Solutions Enterprise is a new company that provides high quality technical and 
        software development services to it&#39;s clients. Insight Tech Solutions was inaugarated
        on December 16, 2016. ITSE is a partnership, owned and operated by Thomas, Shaun, Wafiy and Clynton.
        Sensor
 1 

C
CLYNTON LOH THIAM WEE
   Reply all|
Today, 1:37 PM
LEE WAI KWONG, THOMAS 
About.txt
2 KB

 Download 

  Show email
Download 
About US
Company Description
Insight Tech Solutions Enterprise is a new company that provides high quality technical and software development services to it's clients. Insight Tech Solutions was inaugarated on December 16, 2016. ITSE is a partnership, owned and operated by Thomas, Shaun, Wafiy and Clynton.
Thomas, Shaun, Wafiy and Clynton came together in order to specialize in high quality technical and software development services to small and medium sized businesses.�

Mr Thomas's previous employment was with ACME acting as a technical engineer. Mr. Shaun's previous employment was with Computing Enterprise Associates acting as chief technical engineer. Mr Wafiy's previous employment was with Computing Enterprise Associates acting as senior software developer and Mr Clynton was a system administrator at Burnaby's Enterprise.
ITSE will target small to medium sized companies and government organizations within the Southern part of Michigan including Detroit and surrounding areas. ITSE will seek major contracts with medium sized firms.
Those contracts will be served with the assistance of strategic alliances, both with other engineering and software companies such as Microsoft, Hewlett Packard, Oracle, Apple, Google and Intel (letters of support attached in Appendix C) as well as other professional groups.
This will give the company the flexibility it needs to successfully secure and complete projects with varying elements. By using existing contracts and joint ventures with other consulting firms, ITSE is in a position to develop software and provide consultation for the market in Southern Michigan. By year 3, ITSE will expand to other markets such as Southern Ontario, Canada.
ITSE will be located at:
459 Duncan Avenue, Suite 1003�
Detroit, Michigan, United States of America
ITSE's mission statement is to:
Become a leader in software solutions and consultation services by providing the highest quality software and software engineering consultation services to our customers.</p>
</asp:Content>

