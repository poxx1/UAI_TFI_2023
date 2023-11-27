<%@ Page Title="MenuItems" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MenuItems.aspx.cs" Inherits="Vista.MenuItems" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <div>
            Menu de compras<br />
            <br />
            Desde este menu podra agregar sus items al carrito, y luego en el mismo, finalizar la compra.<br />
            <br />
            Lista de cursos<br />
            <asp:ListBox ID="ListBox1" runat="server" Height="126px" Width="513px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"></asp:ListBox>
            <br />
            <br />
            Precio:
            <asp:Label ID="Label3" runat="server" Text="prec"></asp:Label>
            <br />
            Descripcion:
            <asp:Label ID="Label2" runat="server" Text="desc"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Agregar al carrito" Width="140px" OnClick="Button1_Click" />
            <br />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Ir al carrito" OnClick="Button2_Click" />
            <br />
        </div>
    </main>
</asp:Content>