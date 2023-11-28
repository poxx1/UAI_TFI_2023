<%@ Page Title="FamiliaPatente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FamiliaPatente.aspx.cs" Inherits="Vista.FamiliaPatente" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <link rel="stylesheet" type="text/css" href="/Style/TreeView.css" />
    <main aria-labelledby="title">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Listar permisos" OnClick="Button1_Click" />
            <br />
            <br />
            <h4>Permisos de los usuarios:</h4>
            <br />
            <a>Seleccione </a>los elementos de las listas correspondientes
            <br />
            <a>Patentes</a>
            <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <a>Familias</a>
            <asp:DropDownList ID="DropDownList3" runat="server" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged"></asp:DropDownList>
            <br />
            <br />
            <div class="treeDiv">
                Lista de permisos:<asp:TreeView ID="TreeView1" runat="server" Width="84px" NodeStyle-CssClass="treeNode"
                    RootNodeStyle-CssClass="rootNode"
                    LeafNodeStyle-CssClass="leafNode" SelectedNodeStyle-CssClass="selectNode">
                </asp:TreeView>
                <br />
            </div>
            <br />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Agregar permiso" Width="180px" />
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Quitar permiso" Width="180px" />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Guardar familia" />
            <br />
            <br />
        </div>
    </main>
</asp:Content>