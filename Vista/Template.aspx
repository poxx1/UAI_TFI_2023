<%@ Page Title="Template" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Template.aspx.cs" Inherits="Vista.Template" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Template para reutilizar"></asp:Label>
        </div>
    </main>
</asp:Content>