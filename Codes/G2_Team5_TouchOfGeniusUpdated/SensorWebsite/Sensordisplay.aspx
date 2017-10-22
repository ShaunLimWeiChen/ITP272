<%@ Page Title="" Language="C#" MasterPageFile="~/Sensor.master" AutoEventWireup="true" EnableEventValidation="false"  CodeFile="Sensordisplay.aspx.cs" Inherits="Sensordisplay" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="LoginStatus" ContentPlaceHolderID="LoginArea" Runat="Server">
    <table id="loginstatus"class="nav-justified">
            <tr>
                <td style="height: 24px">
        <asp:Timer ID="TimerTime" runat="server" Interval="1000" OnTick="TimerTime_Tick">
        </asp:Timer>
        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
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
            <asp:HyperLink ID="LogoutProfile" runat="server" NavigateUrl="~/UserLogout.aspx">Logout</asp:HyperLink>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="TimerTime" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel></td>
            </tr>
            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                <ContentTemplate>
                     <asp:HyperLink ID="LoginProfile" runat="server" NavigateUrl="Users/Login.aspx">Login Here</asp:HyperLink>
                </ContentTemplate>
            </asp:UpdatePanel>
            </table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1 class="style4">
        <span class="style3"><strong>WEATHER WEBSERVICE</strong></span><br />

    </h1>
    <h1 class="style4">

        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" Text="Get Weather Information" runat="server" 
        OnClick="GetWeatherInfo" Font-Size="Small" />
        <br />
        <br />
    </h1>
    <table id="tblWeather" runat="server" border="0" cellpadding="0" cellspacing="0"
        visible="false">
        <tr>
            <th colspan="2" class="style1">
                Weather Information
            </th>
        </tr>
        <tr>
            <td rowspan="3">
                <asp:Image ID="imgWeatherIcon" runat="server" />
            </td>
        </tr>
        <tr>
            <td bgcolor="White" class="hover_row">
                <asp:Label ID="lblCity_Country" runat="server" CssClass="style7" />
                <asp:Image ID="imgCountryFlag" runat="server" />
                <asp:Label ID="lblDescription" runat="server" CssClass="style7" />
                <br class="style7" />
                <span class="style7">Humidity:
                </span>
                <asp:Label ID="lblHumidity" runat="server" CssClass="style7" />
            </td>
        </tr>
        <tr>
            <td bgcolor="White" class="bold">
                <span class="style6">Temperature: (Min: </span>
                <asp:Label ID="lblTempMin" runat="server" CssClass="style6" />
                <span class="style6">Max:
                </span>
                <asp:Label ID="lblTempMax" runat="server" CssClass="style6" />
                <span class="style6">Day:
                </span>
                <asp:Label ID="lblTempDay" runat="server" CssClass="style6" />
                <span class="style6">Night:
                </span>
                <asp:Label ID="lblTempNight" runat="server" CssClass="style6" />
                <span class="style6">)</span><span class="style5"> </span>
                <br />
            </td>
        </tr>
    </table>
    <hr />
    <h1 class="style2">
        <strong>SENSOR DATA</strong></h1>
    <br />
   <%-- Chart type
    <asp:DropDownList ID="ddlChart" runat="server" AutoPostBack="True" 
        onselectedindexchanged="ddlChart_SelectedIndexChanged" Width="265px" 
        Font-Size="Medium">
        <asp:ListItem>Column</asp:ListItem>
        <asp:ListItem Value="StackedArea"></asp:ListItem>
        <asp:ListItem Value="StackedBar"></asp:ListItem>
        <asp:ListItem Value="StackedColumn"></asp:ListItem>
        <asp:ListItem Value="Area"></asp:ListItem>
        <asp:ListItem Value="Bar"></asp:ListItem>
        <asp:ListItem Value="Bubble"></asp:ListItem>
        <asp:ListItem Value="Funnel"></asp:ListItem>
        <asp:ListItem Value="Kagi"></asp:ListItem>
        <asp:ListItem Value="FastPoint"></asp:ListItem>
        <asp:ListItem Value="FastLine"></asp:ListItem>
        <asp:ListItem Value="Line"></asp:ListItem>
        <asp:ListItem Value="Spline"></asp:ListItem>
        <asp:ListItem Value="SplineArea"></asp:ListItem>
        <asp:ListItem Value="SplineRange"></asp:ListItem>
        <asp:ListItem Value="Renko"></asp:ListItem>
        <asp:ListItem Value="Stock"></asp:ListItem>
    </asp:DropDownList>--%>

    &nbsp;&nbsp;<br />
    <h1 class="center">
        TEMPERATURE SENSOR&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </h1>
    <br />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>
    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="TempID" DataSourceID="Temperature" AllowPaging="True" 
        AllowSorting="True" 
        onpageindexchanging="GridView3_PageIndexChanging" 
        onselectedindexchanging="GridView3_SelectedIndexChanging" 
        Font-Size="Medium" BackColor="White" BorderColor="#CC9966" 
        BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        EmptyDataText="No Temperature Data" 
        onrowdatabound="GridView3_RowDataBound">
        <Columns>
            <asp:BoundField DataField="TempID" HeaderText="TempID" InsertVisible="False" 
                ReadOnly="True" SortExpression="TempID" />
            <asp:BoundField DataField="Timestamp" HeaderText="Timestamp" 
                SortExpression="Timestamp" />
            <asp:BoundField DataField="Temperature" HeaderText="Temperature" 
                SortExpression="Temperature" />
        </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="Black" />
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#330099" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <SortedAscendingCellStyle BackColor="#FEFCEB" />
        <SortedAscendingHeaderStyle BackColor="#AF0101" />
        <SortedDescendingCellStyle BackColor="#F6F0C0" />
        <SortedDescendingHeaderStyle BackColor="#7E0000" />
    </asp:GridView>
    </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    <asp:Chart ID="ChartTemperature" AutoPostBack="True" runat="server" DataSourceID="TemperatureData" 
        Palette="Fire" Width="645px">
        <Series>
            <asp:Series BackSecondaryColor="255, 192, 255" BorderColor="192, 0, 192" 
                Color="255, 192, 255" Name="Temperature" Palette="Bright" 
                XValueMember="Timestamp" YValueMembers="Temperature" YValuesPerPoint="2" 
                ChartArea="Temperature">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="Temperature">
                <Area3DStyle Enable3D="True" />
            </asp:ChartArea>
        </ChartAreas>
        <Titles>
            <asp:Title Name="Title1" Text="Temperature Data">
            </asp:Title>
        </Titles>
    </asp:Chart>
    <br />
    </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:Button ID="btnRefreshTemperature" runat="server" 
        onclick="btnRefreshTemperature_Click" Text="Refresh Chart" />
    <asp:Button ID="btnExecuteChart" runat="server" Font-Size="Small" 
        onclick="btnExecuteChart_Click" Text="Export Temp Chart" />
    <br />
    <asp:SqlDataSource ID="Temperature" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SensorDatabaseConnectionString %>" 
        SelectCommand="SELECT [TempID], [Timestamp], [Temperature] FROM [Temperature]">
    </asp:SqlDataSource>
    
    <h1 class="center">
        ULTRASONIC SENSOR</h1>
    
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
<ContentTemplate>
    <br />
    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="UltrasonicID" DataSourceID="Ultrasonic" AllowPaging="True" 
        AllowSorting="True" onpageindexchanging="GridView4_PageIndexChanging" 
        Font-Size="Medium" BackColor="White" BorderColor="#336666" 
        BorderStyle="Double" BorderWidth="3px" CellPadding="4" 
        GridLines="Horizontal" EmptyDataText="No Ultrasonic Data" 
        onrowdatabound="GridView4_RowDataBound">
        <Columns>
            <asp:BoundField DataField="UltrasonicID" HeaderText="UltrasonicID" 
                InsertVisible="False" ReadOnly="True" SortExpression="UltrasonicID" />
            <asp:BoundField DataField="Distance" HeaderText="Distance" 
                SortExpression="Distance" />
            <asp:BoundField DataField="Timestamp" HeaderText="Timestamp" 
                SortExpression="Timestamp" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="Black" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#487575" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#275353" />
    </asp:GridView>
    </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
<ContentTemplate>
    <asp:Chart ID="ChartUltrasonic" AutoPostBack="True" runat="server" DataSourceID="UltrasonicSensor" 
        Width="642px" Palette="SeaGreen">
        <Series>
            <asp:Series BackSecondaryColor="Lime" BorderColor="Lime" ChartType="StackedArea" 
                Color="Lime" Name="Distance" XValueMember="Timestamp" YValueMembers="Distance" 
                YValuesPerPoint="4" ChartArea="Distance">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="Distance">
                <Area3DStyle Enable3D="True" />
            </asp:ChartArea>
        </ChartAreas>
        <Titles>
            <asp:Title Name="Title1" Text="Ultrasonic Data">
            </asp:Title>
        </Titles>
    </asp:Chart>
    <br />
    </ContentTemplate>
    </asp:UpdatePanel>
    <h1 class="center">
    <br />
    <asp:Button ID="btnRefreshUltrasonic" runat="server" 
        onclick="btnRefreshUltrasonic_Click" Text="Refresh Chart" />
    <asp:Button ID="btnExecuteChartUltra" runat="server" Font-Size="Small" 
        onclick="btnExecuteChartUltra_Click" Text="Export Ultrasonic Chart" 
            CssClass="active" />
        <br />
    <br />
        MOTION SENSOR</h1>
    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
    <ContentTemplate>
    <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="MotionID" DataSourceID="Motion" 
        onpageindexchanging="GridView5_PageIndexChanging" Font-Size="Medium" 
        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" EmptyDataText="No Motion Data" 
        onrowdatabound="GridView5_RowDataBound" AllowPaging="True" AllowSorting="True">
        <Columns>
            <asp:BoundField DataField="MotionID" HeaderText="MotionID" 
                InsertVisible="False" ReadOnly="True" SortExpression="MotionID" />
            <asp:BoundField DataField="Timestamp" HeaderText="Timestamp" 
                SortExpression="Timestamp" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="Black" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>
    </ContentTemplate>
    </asp:UpdatePanel>
    <h1 class="center">
        RFID TAG<br />
    </h1>
    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
    <ContentTemplate>
    <%--<asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" DataSourceID="RFID" 
        onpageindexchanging="GridView6_PageIndexChanging" Font-Size="Medium" 
        CellPadding="4" ForeColor="#333333" GridLines="None" 
        EmptyDataText="No RFID Data" ondatabound="GridView6_DataBound" 
        onrowdatabound="GridView6_RowDataBound" AllowPaging="True" AllowSorting="True" 
            onselectedindexchanged="GridView6_SelectedIndexChanged"> 
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="RfidID" HeaderText="RfidID" 
                SortExpression="RfidID" />
            <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" 
                SortExpression="DateCreated" />
            <asp:BoundField DataField="UserID" HeaderText="UserID" 
                SortExpression="UserID" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="Black" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    &nbsp;<asp:SqlDataSource ID="Ultrasonic" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SensorDatabaseConnectionString %>" 
        SelectCommand="SELECT [UltrasonicID], [Distance], [Timestamp] FROM [Ultrasonic]">
    </asp:SqlDataSource>

    
    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
    <ContentTemplate>
    <%--<asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="UserID" DataSourceID="SqlDataSource1" BackColor="White" 
        BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        EmptyDataText="No users" GridLines="Horizontal" 
        onrowdatabound="GridView7_RowDataBound" AllowPaging="True" AllowSorting="True" 
            Font-Size="Small">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:BoundField DataField="UserID" HeaderText="UserID" InsertVisible="False" 
                ReadOnly="True" SortExpression="UserID" />
            <asp:BoundField DataField="Username" HeaderText="Username" 
                SortExpression="Username" />
            <asp:BoundField DataField="Password" HeaderText="Password" 
                SortExpression="Password" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" 
                SortExpression="DateCreated" />
            <asp:BoundField DataField="LastLogin" HeaderText="LastLogin" 
                SortExpression="LastLogin" />
            <asp:BoundField DataField="AccessLevel" HeaderText="AccessLevel" 
                SortExpression="AccessLevel" />
        </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="Black" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <SortedAscendingCellStyle BackColor="#F4F4FD" />
        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
        <SortedDescendingCellStyle BackColor="#D8D8F0" />
        <SortedDescendingHeaderStyle BackColor="#3E3277" />
    </asp:GridView>--%>
    </ContentTemplate>
    </asp:UpdatePanel>

    <asp:SqlDataSource ID="Motion" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SensorDB %>" 
        SelectCommand="SELECT [MotionID], [Timestamp] FROM [Motion]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="RFID" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SensorDB %>" 
        SelectCommand="SELECT [RfidID], [DateCreated], [UserID] FROM [RFID]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="TemperatureData" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SensorDatabaseConnectionString %>" 
        SelectCommand="SELECT [Temperature], [Timestamp] FROM [Temperature]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="UltrasonicSensor" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SensorDatabaseConnectionString %>" 
        SelectCommand="SELECT [Timestamp], [Distance] FROM [Ultrasonic]">
    </asp:SqlDataSource>
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SensorDatabaseConnectionString %>" 
        SelectCommand="SELECT [UserID], [Username], [Password], [Email], [DateCreated], [LastLogin], [AccessLevel] FROM [Users]">
    </asp:SqlDataSource>
    <br />
    
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
<ContentTemplate>
    </ContentTemplate>
    </asp:UpdatePanel>
        <asp:Button ID="btnExecute" runat="server" onclick="btnExecute_Click" 
        Text="Export All Data To Excel" Font-Size="Medium" />
  
<style type="text/css">
    body
    {
        font-family: Arial;
        font-size: 10pt;
    }
    td
    {
        cursor: pointer;
    }
    .hover_row
    {
        background-color: #A1DCF2;
    }
    table
        {
        }
        table th
        {

        }
        table th, table td
        {

        }
        table, table table td
        {        text-align: center;
        margin-right: 0px;
    }
    .style1
    {
        font-size: large;
    }
    .style2
    {
        text-align: center;
        font-family: Arial;
        font-size: xx-large;
    }
    .style3
    {
        font-size: xx-large;
        text-align: center;
        font-weight: bold;
    }
    .style4
    {
        text-align: center;
    }
    .style5
    {
        background-color: #FFFFFF;
    }
    .style6
    {
        color: #000000;
        background-color: #FFFFFF;
    }
    .style7
    {
        color: #000000;
    }
</style>

    <br />
    <br />
    <a href="Energypage.aspx">Back</a>
</asp:Content>

