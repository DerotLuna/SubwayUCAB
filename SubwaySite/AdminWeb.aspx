<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminWeb.aspx.cs" Inherits="SubwaySite.AdminWeb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .inlineBlock {
            display:inline-block;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel runat="server" ID="ButtonPanel" Width="100%">
            <asp:Panel ID="AdminPanel" runat="server" CssClass="inlineBlock" HorizontalAlign="Center" Width="33%">
                <asp:Button ID="NuevoAdministadorButton" runat="server" OnClick="NuevoAdministadorButton_Click" Text="Nuevo Administrador" Width="194px" />
                <br />
                <asp:Button ID="BorrarAdministradorButton" runat="server" OnClick="BorrarAdministradorButton_Click" Text="Borrar Adminitrador" Width="194px" />
                <br />
                <asp:Button ID="MotrasAdministradorButton" runat="server" OnClick="MotrasAdministradorButton_Click" Text="Mostrar Administrador" />
            </asp:Panel>
            <asp:Panel ID="LinePanel" runat="server" CssClass="inlineBlock" HorizontalAlign="Center" Width="33%">
                <asp:Button ID="NuevaLineaButton" runat="server" OnClick="NuevaLineaButton_Click" Text="Nueva Linea" Width="194px" />
                <br />
                <asp:Button ID="DeleteLineButton" runat="server" OnClick="DeleteLineButton_Click" Text="Borrar Linea" Width="194px" />
                <br />
                <asp:Button ID="ShowLineButton" runat="server" OnClick="ShowLineButton_Click" Text="Mostrar Lineas" Width="194px" />
            </asp:Panel>
            <asp:Panel ID="StationPanel" runat="server" CssClass="inlineBlock" HorizontalAlign="Center" Width="33%">
                <asp:Button ID="NuevaEstacionButton" runat="server" OnClick="NuevaEstacionButton_Click" Text="Nueva Estacion" Width="194px" />
                <br />
                <asp:Button ID="DeleteStationButton" runat="server" OnClick="DeleteStationButton_Click" Text="Borrar Estacion" Width="194px" />
                <br />
                <asp:Button ID="ShowStationsButton" runat="server" OnClick="ShowStationsButton_Click" Text="Mostrar Estaciones" Width="194px" />    
            </asp:Panel>
        <br />
        </asp:Panel>
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
                <asp:Table ID="AdminTable" runat="server">
                    <asp:TableRow runat="server" TableSection="TableHeader">
                        <asp:TableCell runat="server">Nombre</asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:Panel>
            <br />
            <asp:Panel ID="ShowLinePanel" runat="server" Visible="false">
                <asp:Table ID="LineTable" runat="server" >
                    <asp:TableRow runat="server" TableSection="TableHeader">
                        <asp:TableCell ID="NombreHeaderCell" runat="server" BorderStyle="Inset">Nombre</asp:TableCell>
                        <asp:TableCell ID="StatusLine" runat="server" BorderStyle="Solid">Estado</asp:TableCell>
                        <asp:TableCell runat="server" HorizontalAlign="Center">Estaciones</asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:Panel>
            <br />
            <asp:Panel ID="ShowStationPanel" runat="server" Visible="false">
                <asp:Table ID="StationTable" runat="server">
                    <asp:TableRow runat="server" TableSection="TableHeader">
                        <asp:TableCell runat="server">Nombre</asp:TableCell>
                        <asp:TableCell runat="server">Linea</asp:TableCell>
                        <asp:TableCell runat="server">Operativo</asp:TableCell>
                        <asp:TableCell runat="server">Transferencia</asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:Panel>
        
    </form>
</body>
</html>
