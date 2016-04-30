<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TareasAlumno.aspx.vb" Inherits="Laboratorio5.TareasAlumno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {}
        .auto-style2 {
            width: 255px;
        }
        .auto-style3 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1 class="auto-style3">ALUMNOS<br />
            GESTIÓN DE TAREAS</h1>
        <br />
    
        <table border="1" style="width: 533px">
            <tr>
                <td class="auto-style2">
                    <asp:DropDownList ID="lista" runat="server" AutoPostBack="True" Height="16px" Width="225px">
                    </asp:DropDownList>
                </td>
                <td rowspan="2">
                    <asp:CheckBoxList ID="columnas" runat="server" AutoPostBack="True">
                        <asp:ListItem Selected="True" Enabled="False">Código</asp:ListItem>
                        <asp:ListItem>Descripción</asp:ListItem>
                        <asp:ListItem>Horas</asp:ListItem>
                        <asp:ListItem>Tipo Tarea</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="ver" runat="server" Text="Ver Tareas" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1" colspan="2">
                    <asp:GridView ID="tabla" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="" Text="Instanciar" />
                            <asp:BoundField DataField="Codigo" HeaderText="Codigo" SortExpression="Codigo" />
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                            <asp:BoundField DataField="HEstimadas" HeaderText="Horas Estimadas" SortExpression="HEstimadas" />
                            <asp:BoundField DataField="TipoTarea" HeaderText="Tipo Tarea" SortExpression="TipoTarea" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    
        <br />
        <asp:Button ID="Button1" runat="server" Text="Volver" />
    
    </div>
    </form>
</body>
</html>
