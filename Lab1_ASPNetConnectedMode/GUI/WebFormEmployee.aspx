<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormEmployee.aspx.cs" Inherits="Lab1_ASPNetConnectedMode.GUI.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 43%;
            height: 289px;
        }
        .auto-style2 {
            width: 492px;
        }
        .auto-style3 {
            text-align: center;
        }
        .auto-style4 {
            color: #FF0000;
        }
        .auto-style7 {
            width: 290px;
        }
        .auto-style8 {
            width: 536px;
        }
        .auto-style9 {
            width: 513px;
        }
        .auto-style10 {
            width: 454px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <table class="auto-style1">
                <tr>
                    <td class="auto-style3" colspan="5">
                        <h1 class="auto-style4"><strong>Employee Maintenance</strong></h1>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">Employee ID</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="txtEmployeeId" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style8">
                        <asp:Button ID="btnSave"  runat="server" OnClick="btnSave_Click" Text="Save" Width="96px" />
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">First Name</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style8">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" Width="96px" OnClick="btnUpdate_Click" />
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">Last Name</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style8">
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="96px" OnClick="btnDelete_Click" />
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">Job Title</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="txtJobTitle" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style8">
                        <asp:Button ID="btnListAll" runat="server"  class="btn btn-info" OnClick="btnListAll_Click" Text="List All" Width="96px" />
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style8">
                        <asp:Label ID="lblMsg" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">Search By</td>
                    <td class="auto-style9">
                        <asp:DropDownList ID="DropDownList1" runat="server" Height="26px" Width="167px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" Width="96px" OnClick="btnSearch_Click" />
                    </td>
                    <td class="auto-style7">
                        <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear List" />
                    </td>
                </tr>
            </table>
        </div>
        <h2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Employee List</h2>
        <div>
            <asp:GridView ID="GridView1" runat="server" Height="190px" Width="652px">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
