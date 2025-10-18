<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="customer.aspx.cs" Inherits="yt_tutorial_3tier.customer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 74%;
        }
        .auto-style2 {
            width: 350px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Customer Management System</h1>
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">id</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        <asp:Button ID="Button6" runat="server" Text="search" OnClick="Button6_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">name</td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="insert" OnClick="Button1_Click" />
                        <asp:Button ID="Button2" runat="server" Text="update" OnClick="Button2_Click" />
                        <asp:Button ID="Button3" runat="server" Text="delete" OnClick="Button3_Click" />
                        <asp:Button ID="Button4" runat="server" Text="view" OnClick="Button4_Click" />
                        <asp:Button ID="Button5" runat="server" Text="clear" OnClick="Button5_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" Width="441px">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
