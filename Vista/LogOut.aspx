<%@ Page Title="Logout" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogOut.aspx.cs" Inherits="Vista.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %></h2>
         <div>
            <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label> <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
             <br/>
             <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Logout" />
             <br><br />
        </div>
    </main>
    <script>
    </script>
</asp:Content>