<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLoginWeb.aspx.cs" Inherits="SubwaySite.AdminLoginWeb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel runat="server" ID="LoginPanel" HorizontalAlign="Center" Width="100%">
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="AdminWeb!!!!"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Usuario: "></asp:Label>
            <asp:TextBox ID="userInput" runat="server" OnTextChanged="TextBox1_TextChanged" style="margin-left: 0px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Contraseña: "></asp:Label>
            <asp:TextBox ID="passwordInput" runat="server" OnTextChanged="passwordInput_TextChanged" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="loginButton" runat="server" Text="Ingresar" OnClick="Button2_Click" />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Back" Height="28px" />
        </asp:Panel>
    </form>
</body>
</html>
