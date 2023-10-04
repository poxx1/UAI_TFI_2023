<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsuarioPatente.aspx.cs" Inherits="Vista.UsuarioPatente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Button ID="Button1" runat="server" Text="Listar " />
        <br />
        <br />
        Seleccionar usuario:<br />
        <asp:DropDownList ID="DropDownList1" runat="server" Height="17px" Width="199px">
        </asp:DropDownList>
        <br />
        <br />
        Lista de permisos del usuario:<asp:TreeView ID="TreeView1" runat="server">
        </asp:TreeView>
        <asp:Button ID="Button2" runat="server" Height="24px" Text="Agregar permiso" Width="121px" />
    </form>
</body>
</html>
