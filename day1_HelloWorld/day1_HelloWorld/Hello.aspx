<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hello.aspx.cs" Inherits="day1_HelloWorld.Hello" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LOGIN</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Login</h1>
            <div>
                <asp:Label runat="server" Text="Username" ID="Label1"></asp:Label>
                <asp:TextBox ID="txtUsername" runat="server" Class="form-control"></asp:TextBox>
            </div>
            <div>
                <asp:Label runat="server" Text="Password" ID="Label2"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Class="form-control"></asp:TextBox>&nbsp;
            </div>
            <div>
                <asp:Label ID="Label3" runat="server" Text="Remember me"></asp:Label>
                <asp:CheckBox ID="chRemeber" runat="server" />
            </div>
            <div>
                <asp:Button ID="btnLogin" runat="server" Text="Login" Class="btn btn-success" OnClick="btnLogin_Click" />
            </div>
            <div>
                <asp:Label ID="lbResult" runat="server" ForeColor="#FF0066"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
