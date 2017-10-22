<%@ Page Title="" Language="C#" MasterPageFile="~/Product.master" AutoEventWireup="true" CodeFile="cart.aspx.cs" Inherits="productpage" %>


<asp:Content ID="Content3" ContentPlaceHolderID="LoginArea" Runat="Server">
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
                    <asp:Label ID="Label4" runat="server" Text="Username:"></asp:Label>
                    <asp:Label ID="Label5" runat="server"></asp:Label>
            &nbsp&nbsp
                    <asp:Label ID="Label6" runat="server" Text="User Login ID:"></asp:Label><asp:Label ID="Label7" runat="server"></asp:Label>
            &nbsp&nbsp
                    <asp:Label ID="Label8" runat="server" Text="Last Login: "></asp:Label>
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
<asp:Content ID="Content1" ContentPlaceHolderID="productContent1" Runat="Server">
<asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label>
                    <asp:Label ID="lblusername" runat="server"></asp:Label>
            &nbsp&nbsp
                    <asp:Label ID="Label3" runat="server" Text="User Login ID:"></asp:Label><asp:Label ID="lblUserID" runat="server"></asp:Label>
            &nbsp&nbsp
                    <asp:Label ID="Label2" runat="server" Text="Last Login: "></asp:Label>
 <asp:GridView ID="gvProduct" runat="server" Width="100%" 
        HeaderStyle-CssClass="GridHeaderStyle" HeaderStyle-BackColor="#FDA30E" 
        CssClass="table" Font-Size="Large" AutoGenerateColumns="False" 
        DataKeyNames="Product_ID" OnRowCommand="gvProduct_RowCommand" 
        OnSelectedIndexChanged="gvProduct_SelectedIndexChanged" 
        onrowdeleted="gvProduct_RowDeleted" EmptyDataText="No items in cart">
        <Columns>
            <asp:BoundField DataField="Product_ID" HeaderText="Product ID" />
            <asp:ImageField HeaderText="Product Image" DataImageUrlField="Product_Image" DataImageUrlFormatString="~/images/{0}" >
                <ControlStyle Height="100px" />
                <ItemStyle Height="36px" />
            </asp:ImageField>
            <asp:BoundField DataField="Product_Name" HeaderText="Product Name" />
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="tb_Quantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:TextBox>
                    <br />
                    <asp:LinkButton ID="btn_Remove" runat="server" CommandArgument='<%# Eval("Product_ID") %>' CommandName="Remove">Remove</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Product_Price" DataFormatString="{0:C}" HeaderText="Unit Price" />
            <asp:BoundField DataField="TotalPrice" DataFormatString="{0:C}" HeaderText="Price" />
            <asp:CommandField ShowSelectButton="True" />
        </Columns>

<HeaderStyle BackColor="#FDA30E" CssClass="GridHeaderStyle"></HeaderStyle>
    </asp:GridView>
    Total Price: <asp:Label ID="lbl_TotalPrice" runat="server"></asp:Label>
    <br />
    <asp:Button ID="btn_update" runat="server" OnClick="btn_update_Click" Text="Update Cart" />
    <asp:Button ID="btn_clear" runat="server" OnClick="btn_clear_Click" Text="Clear Cart" />
    <asp:Button ID="btn_Checkout" runat="server" onclientclick="Confirm()" OnClick="btn_Checkout_Click" Text="Checkout" />
    <br />
    <asp:Label ID="lbl_Error" runat="server"></asp:Label>

      <%--JAVASCRIPT--%>
<script type = "text/javascript">

    function MouseEvents(objRef, evt) {
        var checkbox = objRef.getElementsByTagName("input")[0];

        if (objRef.rowIndex != 0) {
            if (evt.type == "mouseover") {
                objRef.style.backgroundColor = "gainsboro";
            }
            else {
                //objRef.style.backgroundColor = "#d8e9f3";
                objRef.style.backgroundColor = "white";
            }
        }
    }

    function Confirm() {
        var confirm_value = document.createElement("INPUT");
        confirm_value.type = "hidden";
        confirm_value.name = "confirm_value";
        if (confirm("Proceed to checkout?")) {
            confirm_value.value = "Yes";
        }
        else {
            confirm_value.value = "No";
        }
        document.forms[0].appendChild(confirm_value);
    }

</script>
    <%--/JAVASCRIPT--%>
</asp:Content>