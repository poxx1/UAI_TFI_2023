<%@ Page Title="Corrupcion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Corrupcion.aspx.cs" Inherits="Vista.Corrupcion" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Corrupcion"></asp:Label>
        &nbsp;de la base de datos<br />
            <br />
            Opcion 1. Restaurar la base de datos a un estado previo (el mas reciente).<br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Restaurar" Width="124px" />
            <br />
            <br />
            Opcion 2. Recalcular los digitos verificadores pisando los cambios aplicados a la base de datos.<br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Recalcular" Width="120px" />
            <br />
        </div>
    </main>
</asp:Content>