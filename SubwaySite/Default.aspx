<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SubwaySite.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            width = 100%;
        }

        form {
            width = 100%;
        }

        #UserAdminPanel {
            width = 100%;
            margin = auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel runat="server" ID="UserAdminPanel" Height="100%" HorizontalAlign="Center" Width="100%" Wrap="False">
            <asp:Button ID="adminButton" runat="server" OnClick="Button1_Click" Text="Administrador" Width="113px" />
            <br />
            <asp:Button ID="userButton" runat="server" Text="Usuario" Width="115px" OnClick="userButton_Click" />
        </asp:Panel>
    </form>
</body>
</html>
