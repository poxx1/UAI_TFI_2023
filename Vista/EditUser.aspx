<%@ Page Title="Edit user" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="Vista.EditUser" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Editar usuario"></asp:Label>
             <br />
            <br />
            Elegir el usuario a editar<br />
            <asp:ListBox ID="ListBox1" runat="server" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"></asp:ListBox>
                <br />
                <div>
            <asp:Label ID="Label2" runat="server" Text="Dni"></asp:Label><br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label3" runat="server" Text="Nombre"></asp:Label><br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label4" runat="server" Text="Apellido"></asp:Label><br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label5" runat="server" Text="Nombre de usuario"></asp:Label><br />
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label6" runat="server" Text="Password"></asp:Label><br />
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label7" runat="server" Text="Email"></asp:Label><br />
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label8" runat="server" Text="Telefono"></asp:Label><br />
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label9" runat="server" Text="Direccion"></asp:Label><br />
            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox><br><br />

            <asp:Button ID="Button1" runat="server" Text="Editar usuario" OnClick="Button1_Click" />
                    <br />
                    <br />
            <asp:Button ID="Button2" runat="server" Text="Desbloquear usuario" OnClick="Button2_Click" />
        </div>
        </div>
    </main>
</asp:Content>
