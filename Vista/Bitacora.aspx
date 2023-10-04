<%@ Page Title="Bitacora" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bitacora.aspx.cs" Inherits="Vista.Bitacora" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Style/DataGrid.css" rel="stylesheet" />
    <main aria-labelledby="title">
         <div>
             <asp:Button ID="Button1" runat="server" Text="Listar bitacora" OnClick="Button1_Click" />
             <br><br/>
        </div>
        <div>
            <h4>Logs guardados en la bitacora:</h4>
            <asp:GridView class="mGrid" ID="GridView1" runat="server"></asp:GridView>
        </div>
    </main>
</asp:Content>