<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminWeb.aspx.cs" Inherits="SubwaySite.AdminWeb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="NuevoAdministadorButton" runat="server" Text="Nuevo Administrador" OnClick="NuevoAdministadorButton_Click" />
        <asp:Button ID="NuevaLineaButton" runat="server" Text="Nueva Linea" OnClick="NuevaLineaButton_Click" />
        <asp:Button ID="NuevaEstacionButton" runat="server" Text="Nueva Estacion" OnClick="NuevaEstacionButton_Click" />
        <br />
        <asp:Button ID="BorrarAdministradorButton" runat="server" OnClick="BorrarAdministradorButton_Click" Text="Borrar Adminitrador" />
        <asp:Button ID="DeleteLineButton" runat="server" OnClick="DeleteLineButton_Click" Text="Borrar Linea" />
        <asp:Button ID="DeleteStationButton" runat="server" OnClick="DeleteStationButton_Click" Text="Borrar Estacion" />
        <br />
        <asp:Button ID="MotrasAdministradorButton" runat="server" OnClick="MotrasAdministradorButton_Click" Text="Mostrar Administrador" />
        <asp:Button ID="ShowLineButton" runat="server" OnClick="ShowLineButton_Click" Text="Mostrar Lineas" />
        <asp:Button ID="ShowStationsButton" runat="server" OnClick="ShowStationsButton_Click" Text="Mostrar Estaciones" />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Panel ID="AdministradorForm" runat="server" Visible="false">
            <%-- <div id="AdministradorForm" style="visibility:hidden"> --%>
                <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label>
                <asp:TextBox ID="nombreAdministradorInput" runat="server" OnTextChanged="nombreAdministradorInput_TextChanged"></asp:TextBox>
                <br/>
                <asp:Label ID="Label2" runat="server" Text="Clave: "></asp:Label>
                <asp:TextBox ID="claveAdministradorInput" runat="server"></asp:TextBox>
            <%-- </div> --%>
            <br />
            <asp:Button ID="GuardarAdministradorButton" runat="server" OnClick="GuardarAdministradorButton_Click" Text="Guardar" />
        </asp:Panel>
        <asp:Panel ID="NuevaLineaForm" runat="server" Visible="false">
            <asp:Label ID="NuevaLineaLabel" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="NombreLineaInput" runat="server" />
            <asp:Button ID="GuardarLineaButton" Text="Guardar" runat="server" OnClick="GuardarLineaButton_Click" />
        </asp:Panel>
        <asp:Panel ID="NuevaEstacionForm" runat="server" Visible="false">
            <asp:Label Text="*Nombre: " runat="server" />
            <asp:TextBox runat="server" ID="nombreEstacionInput" Height="22px" Width="128px" />
            <br />
            <asp:Label ID="LineLabel" runat="server" Text="Linea"></asp:Label>
            <asp:DropDownList ID="LineaList" runat="server">
                <asp:ListItem Text="[Empty]" />
            </asp:DropDownList>
            <br/>
            <asp:Label Text="Izquierda" runat="server" />
            <asp:DropDownList ID="estacionIzquierdaList" runat="server">
                <asp:ListItem Text="[Empty]" />
                <asp:ListItem Text="[Empty]" />
                <asp:ListItem Text="[Empty]" />
                <asp:ListItem Text="[Empty]" />
                <asp:ListItem Text="[Empty]" />
                <asp:ListItem Text="[Empty]" />
                <asp:ListItem Text="[Empty]" />
                <asp:ListItem Text="[Empty]" />
                <asp:ListItem Text="[Empty]" />
                <asp:ListItem Text="[Empty]" />
                <asp:ListItem Text="[Empty]" />
                <asp:ListItem Text="[Empty]" />
                <asp:ListItem Text="[Empty]" />
            </asp:DropDownList>
            <br />
            <asp:Label Text="Derecha" runat="server" />
            <asp:DropDownList runat="server" ID="estacionDerechaList">
                <asp:ListItem Text="[Empty]" />
            </asp:DropDownList>
            <br />
            <asp:Button ID="GuardarEstacionButton" runat="server" Text="Guardar" OnClick="GuardarEstacionButton_Click" />
            <br />
            <br />
            </asp:Panel>
            <asp:Panel ID="DeleteAdminPanel" runat="server" Visible="false">
                <asp:Label ID="Label3" runat="server" Text="Lista de administradores"></asp:Label>
                <asp:DropDownList ID="DeleteAdminList" runat="server">
                    <asp:ListItem>[Empty]</asp:ListItem>
                </asp:DropDownList>
            </asp:Panel>
            <br />
            <asp:Panel ID="DeleteLinePanel" runat="server" Visible="false">
                <asp:Label ID="Label4" runat="server" Text="Lista de lineas"></asp:Label>
                <asp:DropDownList ID="DeleteLineList" runat="server" >
                    <asp:ListItem>[Empty]</asp:ListItem>
                </asp:DropDownList>
            </asp:Panel>
            <br />
            <asp:Panel ID="DeleteStationPanel" runat="server" Visible="false">
                <asp:Label ID="Label5" runat="server" Text="Lista de estationces"></asp:Label>
                <asp:DropDownList ID="DeleteStationList" runat="server">
                    <asp:ListItem>[Empty]</asp:ListItem>
                </asp:DropDownList>
            </asp:Panel>
            <br />
            <asp:Panel ID="ShowAdminPanel" runat="server" Visible="false">
                <asp:Table ID="ShowAdminTable" runat="server">
                </asp:Table>
            </asp:Panel>
            <br />
            <asp:Panel ID="ShowLinePanel" runat="server" Visible="false">
                <asp:Table ID="ShowLineTable" runat="server" >
                </asp:Table>
            </asp:Panel>
            <br />
            <asp:Panel ID="ShowStationPanel" runat="server" Visible="false">
                <asp:Table ID="ShowStationTable" runat="server">
                </asp:Table>
            </asp:Panel>
        
    </form>
</body>
</html>
