<%@ Page Title="UsuarioPatente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioPatente.aspx.cs" Inherits="Vista.UsuarioPatente" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <div>
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
            <asp:Button ID="Button2" runat="server" Height="24px" Text="Agregar permiso" Width="121px" OnClick="Button2_Click" />
        </div>
    </main>
</asp:Content>