<%@ Page Title="MenuAgregarItems" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MenuAgregarItems.aspx.cs" Inherits="Vista.MenuAgregarItems" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    Ingrese los detalles del curso que desea agregar al sistema.</p>
<p>
    Nombre
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </p>
<p>
    Detalles
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </p>
<p>
    Precio&nbsp;&nbsp;
    <asp:TextBox ID="TextBox3" runat="server" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>
    </p>
<p>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Agregar curso" />
</p>
    <p>
        &nbsp;Nota. Los precios de los cursos son en $ARS.</p>
</asp:Content>