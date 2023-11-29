<%@ Page Title="UsuarioPatente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioPatente.aspx.cs" Inherits="Vista.UsuarioPatente" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <div>
            En este menu podra agregarle permisos a los usuarios correspondientes.<br />
            <br />
            Seleccionar usuario:<br />
            <asp:DropDownList ID="DropDownList1" runat="server" Height="52px" Width="199px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            Seleccionar permiso:<br />
            <asp:DropDownList ID="DropDownList2" runat="server" Height="52px" Width="199px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            Lista de permisos del usuario:<br />
            <asp:ListBox ID="ListBox1" runat="server" Width="201px"></asp:ListBox>
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" Height="24px" Text="Listar permisos del usuario" Width="232px" OnClick="Button2_Click" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Height="24px" Text="Agregar permiso al usuario" Width="233px" OnClick="Button3_Click" />
        </div>
    </main>
</asp:Content>