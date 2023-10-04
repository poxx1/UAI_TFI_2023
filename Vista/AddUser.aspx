<%@ Page Title="AddUser" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="Vista.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title">Agregar usuario</h2>
        <br>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Dni"></asp:Label><br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label><br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label3" runat="server" Text="Apellido"></asp:Label><br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label4" runat="server" Text="Nombre de usuario"></asp:Label><br />
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label5" runat="server" Text="Password"></asp:Label><br />
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label6" runat="server" Text="Email"></asp:Label><br />
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label7" runat="server" Text="Telefono"></asp:Label><br />
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label8" runat="server" Text="Direccion"></asp:Label><br />
            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox><br><br />

            <asp:Button ID="Button1" runat="server" Text="Agregar usuario" OnClick="Button1_Click" OnClientClick="return confirm('Esta seguro que quiere agregar ese usuario?')" />
        </div>
    </main>
</asp:Content>
