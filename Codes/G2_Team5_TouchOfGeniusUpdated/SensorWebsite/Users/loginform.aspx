<%@ Page Language="C#" AutoEventWireup="true" CodeFile="loginform.aspx.cs" Inherits="Users_loginform" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ITSE - Touch of Genius</title>

    <!-- CSS REFERENCES -->
    <link type="text/css" rel="Stylesheet" href="../Styles/mojojologin.css"/>
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:700,600" rel="Stylesheet" type="text/css">

</head>
<body>
    <form id="loginform" runat="server">
    <div class="box">
     <h1>Login</h1>
       
     <input type="text" id="username" name="username" value="Username" onFocus="field_focus(this, 'email');" onblur="field_blur(this, 'email');" class="email" />
     <input type="password" id="password" name="password" value="Password" onFocus="field_focus(this, 'email');" onblur="field_blur(this, 'email');" class="email" /> 

     <asp:Button class="btn" runat="server" Text="Sign In" ID="btnSignIn" onclick="Unnamed1_Click" />
     <asp:Button id="btn2" runat="server" Text="Sign Up" onclick="btn2_Click" />  

    </div>
    </form>

    <p>Forgot your password? <u style="color:#f1c40f;"> <a href="forgetpassword.aspx">Click Here!</a></u></p>

    <!-- Script References --> 
    <script src="../Scripts/mojojologin.js"></script>

</body>
</html>
