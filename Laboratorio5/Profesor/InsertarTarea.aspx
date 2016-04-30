<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InsertarTarea.aspx.vb" Inherits="Laboratorio5.InsertarTarea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }

        .auto-style2 {
            width: 184px;
        }

        .auto-style3 {
            text-align: center;
            height: 26px;
        }

        .auto-style4 {
            width: 184px;
            height: 26px;
        }
        .auto-style5 {
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 class="auto-style1">PROFESORES<br />
                INSERTAR NUEVA TAREA</h1>
            <table style="width: 618px">
                <tr>
                    <td class="auto-style1">
                        <strong>
                            <asp:Label ID="Label1" runat="server" Text="Código"></asp:Label>
                        </strong>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="codigo" runat="server" Width="400px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <strong>
                            <asp:Label ID="Label2" runat="server" Text="Descripción"></asp:Label>
                        </strong>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="descripcion" runat="server" Height="93px" Width="400px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <strong>
                            <asp:Label ID="Label3" runat="server" Text="Asignatura"></asp:Label>
                        </strong>
                    </td>
                    <td class="auto-style4">
                        <asp:DropDownList ID="lista" runat="server" DataTextField="codigo" DataValueField="codigo" Height="16px" Width="400px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <strong>
                            <asp:Label ID="Label4" runat="server" Text="Horas Estimadas"></asp:Label>
                        </strong>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="horas" runat="server" Width="399px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <strong>
                            <asp:Label ID="Label5" runat="server" Text="Tipo Tarea"></asp:Label>
                        </strong>
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="tipo" runat="server" Height="28px" Width="400px">
                            <asp:ListItem>Laboratorio</asp:ListItem>
                            <asp:ListItem>Examen</asp:ListItem>
                            <asp:ListItem>Trabajo</asp:ListItem>
                            <asp:ListItem>Ejercicio</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1" colspan="2">
                        <asp:Label ID="Errores" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1" colspan="2">
                        <asp:Button ID="Button1" runat="server" Text="AÑADIR" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5" colspan="2">
                        <asp:Button ID="Button2" runat="server" Text="VER TAREAS" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
