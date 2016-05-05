<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Online.aspx.vb" Inherits="Laboratorio5.Online" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            height: 23px;
        }

        .auto-style3 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            
                                <h1 class="auto-style3">USUARIOS ONLINE</h1>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td>LISTA ALUMNOS</td>
                            <td>LISTA PROFESORES</td>
                        </tr>
                        <tr>
                            <td class="auto-style2">
                                <asp:ListBox ID="lista1" runat="server" Height="100px" Width="300px"></asp:ListBox>
                            </td>
                            <td class="auto-style2">
                                <asp:ListBox ID="lista2" runat="server" Height="100px" Width="300px"></asp:ListBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Total:
                    <asp:Label ID="lblalum" runat="server" Text=""></asp:Label>
                                <asp:Timer ID="Timer1" runat="server" Interval="5000" />
                            </td>
                            <td class="auto-style2">Total:
                    <asp:Label ID="lblprofe" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>

            </asp:UpdatePanel>

        </div>
        <asp:Button ID="Button1" runat="server" Text="VOLVER" />
    </form>
</body>
</html>
