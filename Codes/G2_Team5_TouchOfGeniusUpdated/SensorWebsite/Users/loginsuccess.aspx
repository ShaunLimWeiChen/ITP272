<%@ Page Language="C#" AutoEventWireup="true" CodeFile="loginsuccess.aspx.cs" Inherits="loginsuccess" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ITSE - Touch of Genius</title>

    <!-- CSS REFERENCES -->
    <link href="../Styles/mojojologin.css" type="text/css" rel="Stylesheet"/>
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:700,600" rel="Stylesheet" type="text/css">

</head>
<body>
    <form id="successlogin" runat="server">
    <div class="box">
     <h1>Welcome to the Future! <asp:Label ID="displaytext" runat="server"></asp:Label></h1>
      
    <asp:Button ID="btn2" runat="server" Text="Sign out" onclick="btn2testing_Click" />

    </div>
    </form>

    <!-- Script References --> 
    <script src="../Scripts/mojojologin.js"></script>

</body>
</html>
