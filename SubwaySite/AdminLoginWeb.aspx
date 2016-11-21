<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLoginWeb.aspx.cs" Inherits="SubwaySite.AdminLoginWeb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="AdminWeb!!!!"></asp:Label>
    </div>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Usuario"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="userInput" runat="server" OnTextChanged="TextBox1_TextChanged" style="margin-left: 0px"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Contraseña"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="passwordInput" runat="server" OnTextChanged="passwordInput_TextChanged"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="loginButton" runat="server" Text="Ingresar" OnClick="Button2_Click" />
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Back" Height="28px" />
        </p>
        </form>
</body>
</html>
