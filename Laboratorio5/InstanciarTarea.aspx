<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InstanciarTarea.aspx.vb" Inherits="Laboratorio5.InstanciarTarea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 1171px;
            height: 90px;
            text-align: center;
        }
        .auto-style3 {
            width: 156px;
        }
        .auto-style4 {
            width: 145px;
        }
        .auto-style5 {
            text-align: center;
        }
        .auto-style6 {
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style6">
        <h1 class="auto-style2">ALUMNOS<br />
                INSTANCIAR NUEVA TAREA</h1>
    <table border="1" style="width: 343px">
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="usuario" runat="server" Text=""></asp:Label>
                   </td>
                <td class="auto-style5" rowspan="6">
                    <asp:GridView ID="GridView1" runat="server">
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label2" runat="server" Text="Tarea"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="tarea" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label3" runat="server" Text="Horas Estimadas"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label4" runat="server" Text="Horas Reales"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" colspan="2">
                    <asp:Label ID="Errores" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" colspan="2">
                    <asp:Button ID="Button1" runat="server" Text="Crear Tarea" Width="275px" />
                </td>
            </tr>
            </table>
        <asp:Button ID="Button2" runat="server" Text="Ver Tareas" />
        <br />
    </div>
    </form>
</body>
</html>
