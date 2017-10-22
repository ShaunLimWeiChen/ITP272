<%@ Page Title="" Language="C#" MasterPageFile="~/LogReg.master" AutoEventWireup="true" CodeFile="forgetpassword.aspx.cs" Inherits="Users_forgetpassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" Runat="Server">
</asp:Content>
<asp:Content ID="ForgetPass" ContentPlaceHolderID="Maincontent" Runat="Server">
    <h1 style="text-align: center; font-size: 80px;">
        Forgot Password</h1>
    <p style="text-align: center">
        &nbsp;</p>
    <p style="text-align: center">
        <asp:Label ID="Label1" runat="server" Font-Size="Large" Text="Email:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtEmail" runat="server" Font-Size="Medium"></asp:TextBox>
    </p>
    <p style="text-align: center">
        <asp:Label ID="lblEmail" runat="server" Font-Size="Large" Text="Label" 
            Visible="False"></asp:Label>
    </p>
    <p style="text-align: center">
        <asp:Button ID="btnForgotPassword" runat="server" 
            onclick="btnForgotPassword_Click" Text="Forgot Password" 
            Font-Size="Medium" />
    </p>
</asp:Content>

