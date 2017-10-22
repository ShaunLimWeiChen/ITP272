<%@ Page Language="C#" AutoEventWireup="true" CodeFile="registerform.aspx.cs" Inherits="Users_registerform" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ITSE - Touch of Genius</title>

    <!-- CSS REFERENCS -->
    <link href="../Styles/mojojologin.css" type="text/css" rel="Stylesheet">
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:700,600" rel="Stylesheet" type="text/css">

</head>
<body>
    <form id="registerform" runat="server">
    <div class="box">
     <h1>Register</h1>
     
     <input type="text" id="username" name="username" value="Username" onFocus="field_focus(this, 'email');" onblur="field_blur(this, 'email');" class="email" />
     <input type="password" id="password" name="password" value="Password" onFocus="field_focus(this, 'email');" onblur="field_blur(this, 'email');" class="email" />
     <!--input type="password" id="confirmpass" name="password" value="Password" onFocus="field_focus(this, 'email');" onblur="field_blur(this, 'email');" class="email" /> -->
     <input type="email" id="email" name="email" value="Email" onFocus="field_focus(this, 'email');" onblur="field_blur(this, 'email');" class="email" />  
     <asp:Button ID="btn2" Text="Register" Onlick="btn2_Click" runat="server" 
            onclick="btn2_Click"/>
    
    </div>
    </form>

    <br />
    <a href="loginform.aspx">Already a member?</a>

    <!-- Script References --> 
    <script type="text/javascript" src="../Scripts/mojojologin.js"></script>

</body>
</html>
