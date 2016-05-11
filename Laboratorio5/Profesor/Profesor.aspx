<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Profesor.aspx.vb" Inherits="Laboratorio5.Profesor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>PROFESORES<br />
            GESTIÓN DE TAREAS GENÉRICAS</h1>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Tareas Profesor" />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" Text="Importar Tareas XML" />
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" Text="Exportar Tareas XML" Visible="False" />
        <br />
        <br />
        <asp:Button ID="Button5" runat="server" Text="Coordinación"  Visible="False" />
        <br />
        <br />
        <asp:Button ID="Button4" runat="server" Height="25px" Text="Ver Usuarios Online" />
        <br />
        <br />
        <br />
        <asp:Button ID="cerrar" runat="server" Text="Cerrar Sesión" />
    </form>
</body>
</html>
