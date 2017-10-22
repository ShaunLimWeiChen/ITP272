<%@ Page Title="" Language="C#" MasterPageFile="~/LogReg.master" AutoEventWireup="true" CodeFile="successlogin.aspx.cs" Inherits="Users_successlogin"%>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" Runat="Server">
</asp:Content>
<asp:Content ID="Successfullogin" ContentPlaceHolderID="Maincontent" Runat="Server">
       <h2>Welcome to the Future!</h2>
       <asp:Label ID="DisplayUsername" runat="server"></asp:Label>
       <br /> 
       You will be redirected shortly.
       <br />
       <br />
       <br />
       <asp:Button ID="btnlogout" runat="server" OnClick="btnlogout_Click" Text="Logout" text-align="center" />
       <br />
</asp:Content>

