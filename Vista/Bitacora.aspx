<%@ Page Title="Bitacora" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bitacora.aspx.cs" Inherits="Vista.Bitacora" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Style/DataGrid.css" rel="stylesheet" />
    <main aria-labelledby="title">
         <div>
             Fecha&nbsp;&nbsp;
             Desde:
             <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;Hasta:
             <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="Button1" runat="server" Text="Aplicar filtros" OnClick="Button1_Click" />
             <br />
             <br />
             Usuario:
             <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
             </asp:DropDownList>
&nbsp; Criticidad:
             <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack=True OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
             </asp:DropDownList>
&nbsp;Ordenar por:
             <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack=True Height="25px" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
             </asp:DropDownList>
             <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
             <br />
             Secuencia de ordenado<br />
             <asp:CheckBox ID="CheckBox1" runat="server" Text="Descendente" />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Odernar" />
             <br />
             <br />
             <br/>
        </div>
        <div>
            <h4>Logs guardados en la bitacora:</h4>
            <asp:GridView class="mGrid" ID="GridView1" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" runat="server"></asp:GridView>
        </div>
    </main>
</asp:Content>