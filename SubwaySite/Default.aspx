<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SubwaySite.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="adminButton" runat="server" OnClick="Button1_Click" Text="Administrador" Width="113px" />
        
    
    </div>
        <p>
        <asp:Button ID="userButton" runat="server" Text="Usuario" Width="115px" OnClick="userButton_Click" />
        </p>
    </form>
</body>
</html>
