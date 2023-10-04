<%@ Page Title="FamiliaPatente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FamiliaPatente.aspx.cs" Inherits="Vista.Permissions" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <link rel="stylesheet" type="text/css" href="/Style/TreeView.css" />
    <main aria-labelledby="title">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Listar permisos" OnClick="Button1_Click" />
            <br />
            <br />
            <h4>Permisos de los usuarios:</h4>
            <br />
            <a>Seleccione </a>&nbsp;los elementos de las listas correspondientes
           
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
            <a>Patentes</a>
            <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList>
            <a>Familias</a>
            <asp:DropDownList ID="DropDownList3" runat="server" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged"></asp:DropDownList>
            <a>Familias con ID</a>
            <asp:DropDownList ID="DropDownList4" runat="server" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged"></asp:DropDownList>
            <br />
            <br />
            <div class="treeDiv">
                Lista de permisos:<asp:TreeView ID="TreeView1" runat="server" Width="84px" NodeStyle-CssClass="treeNode"
                    RootNodeStyle-CssClass="rootNode"
                    LeafNodeStyle-CssClass="leafNode" SelectedNodeStyle-CssClass="selectNode">
                </asp:TreeView>
                <asp:Button ID="Button4" runat="server" Text="Quitar permiso" />
            </div>
            <br />
            Nombre de la patente:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Guardar patente" />
            <br />
            <br />
            Nombre de la familia:
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Guardar familia" />
        </div>
    </main>
</asp:Content>
