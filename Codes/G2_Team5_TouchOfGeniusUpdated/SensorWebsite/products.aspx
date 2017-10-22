<%@ Page Title="" Language="C#" MasterPageFile="~/Product.master" AutoEventWireup="true" CodeFile="products.aspx.cs" Inherits="products" %>

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
                    <asp:Label ID="loginuser" runat="server"></asp:Label>
            &nbsp&nbsp
                    <asp:Label ID="Label2" runat="server" Text="User Login ID:"></asp:Label><asp:Label ID="Label4" runat="server"></asp:Label>
            &nbsp&nbsp
                    <asp:Label ID="Label5" runat="server" Text="Last Login: "></asp:Label>
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
<table class="nav-justified">
<table cellpadding="0" cellspacing="0" 
        
        style="color: rgb(0, 0, 0); font-family: &quot;Times New Roman&quot;; font-size: medium; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); width: 969px;">
        <tr>
            <td valign="top">
                <table cellpadding="0" cellspacing="0" style="width: 263px;">
                    <tr>
                        <td background="http://static.netduino.com/images/borders/horizontaldash.gif" 
                            colspan="3">
                            <img height="1" src="http://static.netduino.com/images/tpixel.gif" 
                                width="263" /></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <img height="8" src="http://static.netduino.com/images/tpixel.gif" width="1" /></td>
                    </tr>
                    <tr>
                        <td>
                            <img height="1" src="http://static.netduino.com/images/tpixel.gif" width="5" /></td>
                        <td width="253">
                            <table cellpadding="0" cellspacing="0" style="width: 253px;">
                                <tr>
                                    <td class="auto-style22" style="font-family: Tahoma; font-size: large;">
                                        Alarm($30)</td>
                                </tr>
                                <tr>
                                    <td>
                                        <img height="15" src="http://static.netduino.com/images/tpixel.gif" width="1" /><img 
                                            alt="" src="images/PIR.jpg" style="width: 400px; height: 400px" /></td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <img height="1" src="http://static.netduino.com/images/tpixel.gif" width="5" /></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <img height="45" src="http://static.netduino.com/images/tpixel.gif" width="1" />Smart 
                            Alarm SA 2700 Kit offers you an easy and efficient way to &quot;DIY security, DIY 
                            protection.&quot; You can set up this quality system.</td>
                    </tr>
                </table>
                <table cellpadding="0" cellspacing="0" style="width: 263px;">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" style="width: 263px;">
                                <tr>
                                    <td>
                                        <img height="1" src="http://static.netduino.com/images/tpixel.gif" width="5" /></td>
                                    <td width="253">
                                        <table cellpadding="0" cellspacing="0" style="width: 253px;">
                                            <tr>
                                                <td class="auto-style22" style="font-family: Tahoma; font-size: large;">
                                                    Smoke Detector($20s)</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <img height="15" src="http://static.netduino.com/images/tpixel.gif" width="1" /><asp:Image 
                                                        ID="Image4" runat="server" ImageUrl="~/images/sd8-1_03.jpg" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <img height="1" src="http://static.netduino.com/images/tpixel.gif" width="5" /></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <img height="45" src="http://static.netduino.com/images/tpixel.gif" width="1" />The 
                                        smoke detector SD-S1 provides the best safety and quality you can ever get 
                                        against potential fire hazard. This accessory triggers the alarm when detecting 
                                        smoke while its built-in siren will sound to give early warning.</td>
                                </tr>
                            </table>
                            <table cellpadding="0" cellspacing="0" style="width: 263px;">
                                <tr>
                                    <td>
                                        <img height="1" src="http://static.netduino.com/images/tpixel.gif" width="5" /></td>
                                </tr>
                            </table>
                            <img height="1" src="http://static.netduino.com/images/tpixel.gif" width="5" /></td>
                    </tr>
                </table>
            </td>
            <td>
                <img height="1" src="http://static.netduino.com/images/tpixel.gif" width="40" /></td>
            <td valign="top" style="width: 456px">
                <table cellpadding="0" cellspacing="0" style="width: 263px;">
                    <tr>
                        <td background="http://static.netduino.com/images/borders/horizontaldash.gif" 
                            colspan="3">
                            <img height="1" src="http://static.netduino.com/images/tpixel.gif" 
                                width="263" /></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <img height="8" src="http://static.netduino.com/images/tpixel.gif" width="1" /></td>
                    </tr>
                    <tr>
                        <td>
                            <img height="1" src="http://static.netduino.com/images/tpixel.gif" width="5" /></td>
                        <td width="253">
                            <table cellpadding="0" cellspacing="0" style="width: 253px;">
                                <tr>
                                    <td class="auto-style24" style="font-family: Tahoma; font-size: medium;">
                                        Motion Sensor($10)</td>
                                </tr>
                                <tr>
                                    <td>
                                        <img height="15" src="http://static.netduino.com/images/tpixel.gif" width="1" /><table cellpadding="0" cellspacing="0" style="width: 263px;">
                                            <tr>
                                                <td background="http://static.netduino.com/images/borders/horizontaldash.gif" 
                            colspan="3">
                                                    <img height="1" src="http://static.netduino.com/images/tpixel.gif" 
                                width="263" /></td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <img height="8" src="http://static.netduino.com/images/tpixel.gif" width="1" /></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <img height="1" src="http://static.netduino.com/images/tpixel.gif" width="5" /></td>
                                                <td width="253">
                                                    <table cellpadding="0" cellspacing="0" style="width: 253px;">
                                                        <tr>
                                                            <td>
                                                                <img height="15" src="http://static.netduino.com/images/tpixel.gif" width="1" /><asp:Image ID="Image2" runat="server" ImageUrl="~/images/o-IR29_13.jpg" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <img height="15" src="http://static.netduino.com/images/tpixel.gif" width="1" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table cellpadding="0" cellspacing="0" style="width: 253px;">
                                                                    <tr>
                                                                        <td>
                                                                            <img height="5" src="http://static.netduino.com/images/tpixel.gif" width="1" /></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <table style="width: 253px;" width="100%">
                                                                                <tr valign="top">
                                                                                    <td style="width: 20px;">
                                                                                        <span class="auto-style23" 
                                                                    style="font-family: Tahoma; font-size: small; border-color: rgb(160, 160, 160) rgb(255, 255, 255) rgb(255, 255, 255) rgb(160, 160, 160);">&nbsp;&#9679;</span></td>
                                                                                    <td>
                                                                                        IR-S1L is a passive-infrared motion detector that guards your premises with 
                                                                                        accurate detection vigilance. This accessory activates the alarm system when 
                                                                                        detecting a movement.
                                                                                    </td>
                                                                                </tr>
                                                                                <tr valign="top">
                                                                                    <td style="width: 20px;">
                                                                                        <span class="auto-style23" 
                                                                    style="font-family: Tahoma; font-size: small; border-color: rgb(160, 160, 160) rgb(255, 255, 255) rgb(255, 255, 255) rgb(160, 160, 160);">&nbsp;&nbsp;</span></td>
                                                                                    <td class="auto-style25" style="font-family: Tahoma; font-size: small;">
                                                                                        &nbsp;</td>
                                                                                </tr>
                                                                                <tr valign="top">
                                                                                    <td style="width: 20px;">
                                                                                        <span class="auto-style23" 
                                                                    style="font-family: Tahoma; font-size: small; border-color: rgb(160, 160, 160) rgb(255, 255, 255) rgb(255, 255, 255) rgb(160, 160, 160);">&nbsp;&nbsp;</span></td>
                                                                                    <td class="auto-style25" style="font-family: Tahoma; font-size: small;">
                                                                                        &nbsp;</td>
                                                                                </tr>
                                                                                <tr valign="top">
                                                                                    <td style="width: 20px;">
                                                                                        <span class="auto-style23" 
                                                                    style="font-family: Tahoma; font-size: small; border-color: rgb(160, 160, 160) rgb(255, 255, 255) rgb(255, 255, 255) rgb(160, 160, 160);">&nbsp;&nbsp;</span></td>
                                                                                    <td class="auto-style25" style="font-family: Tahoma; font-size: small;">
                                                                                        &nbsp;</td>
                                                                                </tr>
                                                                                <tr valign="top">
                                                                                    <td style="width: 20px;">
                                                                                        <span class="auto-style23" 
                                                                    style="font-family: Tahoma; font-size: small; border-color: rgb(160, 160, 160) rgb(255, 255, 255) rgb(255, 255, 255) rgb(160, 160, 160);">&nbsp;&nbsp;</span></td>
                                                                                    <td class="auto-style25" style="font-family: Tahoma; font-size: small;">
                                                                                        &nbsp;</td>
                                                                                </tr>
                                                                                <tr valign="top">
                                                                                    <td style="width: 20px;">
                                                                                        <span class="auto-style23" 
                                                                    style="font-family: Tahoma; font-size: small; border-color: rgb(160, 160, 160) rgb(255, 255, 255) rgb(255, 255, 255) rgb(160, 160, 160);">&nbsp;&nbsp;</span></td>
                                                                                    <td class="auto-style25" style="font-family: Tahoma; font-size: small;">
                                                                                        &nbsp;</td>
                                                                                </tr>
                                                                                <tr valign="top">
                                                                                    <td style="width: 20px;">
                                                                                        <span class="auto-style23" 
                                                                    style="font-family: Tahoma; font-size: small; border-color: rgb(160, 160, 160) rgb(255, 255, 255) rgb(255, 255, 255) rgb(160, 160, 160);">&nbsp;&nbsp;</span></td>
                                                                                    <td class="auto-style25" style="font-family: Tahoma; font-size: small;">
                                                                                        &nbsp;</td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <img height="1" src="http://static.netduino.com/images/tpixel.gif" width="5" /></td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style25" style="font-family: Tahoma; font-size: small;">
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <img height="1" src="http://static.netduino.com/images/tpixel.gif" width="5" /></td>
                    </tr>
                    </table>
            </td>
            <td>
                <img height="1" src="http://static.netduino.com/images/tpixel.gif" width="40" /></td>
            <td valign="top">
                &nbsp;</td>
        </tr>
    </table>
        <tr>
            <td class="col-md-12" >
            <asp:Label ID="lblusername" runat="server"></asp:Label>
            &nbsp&nbsp
                    <asp:Label ID="Label3" runat="server" Text="User Login ID:"></asp:Label><asp:Label ID="lblUserID" runat="server"></asp:Label>
                <asp:GridView ID="gvProducts" runat="server" Width="100%" 
                    HeaderStyle-CssClass="GridHeaderStyle" HeaderStyle-BackColor="#FDA30E" 
                    CssClass="table" Font-Size="Large" AutoGenerateColumns="False" 
                    onselectedindexchanged="gvProducts_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderStyle-Width="15%" HeaderText="Product">
                            <ItemTemplate>
                                <asp:Label ID="lblProductName" runat="server" Text='<%#Eval("ProductName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="45%" HeaderText="Image">
                            <ItemTemplate>
                                <asp:Image ID="lblImage" runat="server" Height="128px" ImageUrl='<%#Eval("Picture", "~/images/{0}") %>'></asp:Image>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="10%" HeaderText="Price">
                            <ItemTemplate>
                                <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("UnitPrice") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="20%" HeaderText="">
                            <ItemTemplate>  
                                <asp:LinkButton ID="btnAdd" runat="server" CssClass="single-item hvr-outline-out" CommandArgument='<%# Eval("ProductID") %>' OnClick="AddToCart">Add To Cart</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <script type = "text/javascript">
        function GoToCart() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Go to shopping cart?")) {
                window.location = "Cart.aspx";
            }
            document.forms[0].appendChild(confirm_value);
        }
</script>
</asp:Content>

