<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Client.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding:10px; margin:10px" >
            <table>
                <tr>
                    <td>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="ID" Width="100px"></asp:Label>
                    </td>
                    <td>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Name" Width="100px"></asp:Label>
                    </td>
                    <td>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
            <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Gender" Width="100px"></asp:Label>
                    </td>
                    <td>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
            <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Date of birth" Width="100px"></asp:Label>
                    </td>
                    <td>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
            <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Employee Type" Width="100px"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                            <asp:ListItem Value="-1">Select Employee Type</asp:ListItem>
                            <asp:ListItem Value="1">Full Time Employee</asp:ListItem>
                            <asp:ListItem Value="2">Part Time Employee</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                 <tr id="trAnnualSalary" runat="server" visible="false">
                    <td>
            <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Annual Salary" Width="100px"></asp:Label>

                    </td>
                    <td>
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr id="trHourlyPay" runat="server" visible="false">
                    <td>
            <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Hourly Pay" Width="100px"></asp:Label>

                    </td>
                    <td>
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr id="trHoursWorked" runat="server" visible="false">
                    <td>
            <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Hours worked" Width="100px"></asp:Label>
                    </td>
                    <td>
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>

            <asp:Button ID="Button1" runat="server" Text="Get Employee" OnClick="Button1_Click" />
            &nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Save Employee" OnClick="Button2_Click" />
            
            <br />
            <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="#009933"></asp:Label>
            
        </div>
    </form>
</body>
</html>
