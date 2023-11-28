<%@ Page Title="EditarCursos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarCursos.aspx.cs" Inherits="Vista.EditarCursos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <div>
            <p>
                Ingrese los detalles del curso que desea cambiar.</p>
            <p>
                Lista de cursos actuales.</p>
            <p>
                <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="198px">
                </asp:DropDownList>
            </p>
            <p>
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Seleccionar curso" Width="190px" />
            </p>
<p>
    Nombre
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </p>
<p>
    Detalles
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </p>
<p>
    Precio&nbsp;&nbsp;
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    </p>
<p>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Editar curso" Width="192px" />
</p>
    <p>
        &nbsp;Nota. Los precios de los cursos son en $ARS.</p>
        </div>
    </main>
</asp:Content>