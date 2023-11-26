<%@ Page Title="MenuItems" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MenuItems.aspx.cs" Inherits="Vista.MenuItems" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <div>
            Menu de compras<br />
            <br />
            Desde este menu podra agregar sus items al carrito, y luego en el mismo, finalizar la compra.<br />
            <br />
            Lista de cursos<br />
            <asp:ListBox ID="ListBox1" runat="server" Height="126px" Width="300px"></asp:ListBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Agregar al carrito" Width="140px" />
            <br />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Ir al carrito" />
            <br />
        </div>
    </main>
</asp:Content>