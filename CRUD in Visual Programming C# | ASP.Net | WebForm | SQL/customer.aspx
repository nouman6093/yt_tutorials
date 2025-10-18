<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="customer.aspx.cs" Inherits="yt_tutorial_crud.customer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 59%;
        }
        .auto-style2 {
            width: 268px;
        }
        .auto-style3 {
            width: 268px;
            height: 31px;
        }
        .auto-style4 {
            height: 31px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Customer Management System</h1>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style3">id</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="search" />
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
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="insert" />
                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="update" />
                        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="delete" />
                        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="view" />
                        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="clear" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" Width="415px">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
