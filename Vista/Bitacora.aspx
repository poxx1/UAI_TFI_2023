<%@ Page Title="Bitacora" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bitacora.aspx.cs" Inherits="Vista.Bitacora" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Style/DataGrid.css" rel="stylesheet" />
    <main aria-labelledby="title">
         <div>
             <asp:Button ID="Button1" runat="server" Text="Listar bitacora" OnClick="Button1_Click" />
             &nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Odernar" />
             <br>
             <br />
             Ordenar por&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <br />
             <asp:ListBox ID="ListBox1" runat="server">
                 <asp:ListItem>Id</asp:ListItem>
                 <asp:ListItem>Fecha</asp:ListItem>
                 <asp:ListItem>Usuario</asp:ListItem>
             </asp:ListBox>
&nbsp;&nbsp;
             <br />
             <br />
             Secuencia de ordenado<br />
             <asp:CheckBox ID="CheckBox1" runat="server" Text="Descendente" />
             <br />
             <br/>
        </div>
        <div>
            <h4>Logs guardados en la bitacora:</h4>
            <asp:GridView class="mGrid" ID="GridView1" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" runat="server"></asp:GridView>
        </div>
    </main>
</asp:Content>