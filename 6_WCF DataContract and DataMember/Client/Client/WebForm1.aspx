<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Client.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding:10px; margin:10px" >
            
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="ID" Width="100px"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Name" Width="100px"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Gender" Width="100px"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Date of birth" Width="100px"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Get Employee" OnClick="Button1_Click" />
            &nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Save Employee" OnClick="Button2_Click" />
            
            <br />
            <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="#009933"></asp:Label>
            
        </div>
    </form>
</body>
</html>
