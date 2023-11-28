<%@ Page Title="ListSolicitud" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListSolicitud.aspx.cs" Inherits="Vista.ListSolicitud" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <div>
            <asp:Label ID="Label2" runat="server" Text="Lista de solicitudes pendientes"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="209px">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Aprobar solicitud" Width="207px" OnClick="Approve"/>
        </div>
    </main>
</asp:Content>