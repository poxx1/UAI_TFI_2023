<%@ Page Title="AddFamilia" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddFamilia.aspx.cs" Inherits="Vista.AddFamilia" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        En este menu podra agregar una nueva familia para despues poder asignarle permisos</p>
    <p>
        Nombre de la familia:</p>
    <p>
        <asp:TextBox ID="TextBox1" runat="server" Width="219px"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Guardar familia" Width="222px" />
    </p>
</asp:Content>