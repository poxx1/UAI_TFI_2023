<%@ Page Title="AddSolicitud" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddSolicitud.aspx.cs" Inherits="Vista.AddSolicitud" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Template para reutilizar"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Palabra a agregar"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox>
            <br />
            <br />
            Descripcion<br />
            <asp:TextBox ID="TextBox2" runat="server" Width="200px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Realizar solicitud" Width="132px" OnClick="Button1_Click" />
            <br />
        </div>
    </main>
</asp:Content>