<%@ Page Title="ListUser" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListUser.aspx.cs" Inherits="Vista.ListUser" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <link href="/Style/DataGrid.css" rel="stylesheet" />
    <main aria-labelledby="title">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Listar usuarios" OnClick="Button1_Click"/>
            <br><br/>
        </div>
        <div>
            <h4>Detalles de los usuarios:</h4>
            <br>
            <asp:GridView class="mGrid" ID="GridView1" autogeneratecolumns="false" runat="server" OnRowDataBound="GridView1_RowDataBound">
                <columns>
                    <asp:boundfield datafield="Id" headertext="Id"/>
                    <asp:boundfield datafield="Dni" headertext="Dni"/>
                    <asp:boundfield datafield="Name" headertext="Name"/>
                    <asp:boundfield datafield="LastName" headertext="LastName"/>
                    <asp:boundfield datafield="NickName" headertext="NickName"/>
                    <asp:boundfield datafield="Mail" headertext="Email"/>
                    <asp:boundfield datafield="Phone" headertext="Phone"/>
                    <asp:boundfield datafield="Adress" headertext="Address"/>
                </columns>
           </asp:GridView>
     
        </div>
    </main>
</asp:Content>