<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserWeb.aspx.cs" Inherits="SubwaySite.UserWeb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="User Web!!!!"></asp:Label>
    </div>
        <asp:Table ID="SubwayScheme" runat="server"></asp:Table>
        <asp:Panel ID="EmptySubway" runat="server"></asp:Panel>
        <asp:Button ID="disabler" runat="server" Text="Button" OnClick="disabler_Click" />
        <p>
        <asp:Button ID="Button1" runat="server" Text="Back" OnClick="Button1_Click" />
        </p>
    </form>
</body>
</html>
