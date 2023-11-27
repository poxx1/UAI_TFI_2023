<%@ Page Title="salidasXML" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="salidasXML.aspx.cs" Inherits="Vista.salidasXML" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Salidas XML"></asp:Label>
            <br />
            <br />
            Seleccione desde la botonera, que quiere exportar. En la grilla visualizara los datos exportados como XML.<br />
            <asp:GridView ID="GridView1" runat="server" Height="212px" Width="748px">
            </asp:GridView>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Pendientes" />
&nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Aprobadas" />
&nbsp;<asp:Button ID="Button3" runat="server" Text="Totales" OnClick="Button3_Click" />
        </div>
    </main>
</asp:Content>