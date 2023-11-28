<%@ Page Title="Template" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Backup.aspx.cs" Inherits="Vista.Backup" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <div>
            Backup
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Realizar backup" OnClick="Button2_Click" />
            <br />
            <br />
            <br />
            Restore<br />
            <br />
            Seleccione el archivo de backup de la base de datos que desea restaurar:<br />
            <asp:FileUpload ID="FileUpload1" runat="server" Width="539px" />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Realizar restore" OnClick="Button1_Click" />
            <br />
            <br />
        </div>
    </main>
</asp:Content>