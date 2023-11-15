<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Start.aspx.cs" Inherits="Vista.Start" %>
<%@ Register Src="~/Customs/ValidatePassword.ascx" TagPrefix="Custom" TagName="ValidatePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

        <link rel="stylesheet" type="text/css" href="/Style/Login.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Login</h2>
            <p>
                <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label>
            </p>
                <asp:TextBox class="customTextbox" ID="TextBox1" runat="server"></asp:TextBox>
            <p>
                <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label>
            </p>
             <Custom:ValidatePassword ID="CustomPassword" runat="server" />       
            
            <asp:Button class="customButton" ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" />
        </div>
    </form>
</body>
</html>