<%@ Page Title="MenuCarrito" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MenuCarrito.aspx.cs" Inherits="Vista.MenuCarrito" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <div>
            Carrito de compras<br />
            <br />
            Desde este menu podra revisar los items que eligio comprar y podra pasar a realizar el pago y la impresion de la factura correspondiente.<br />
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
        </div>
    </main>
</asp:Content>