<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ImportarTareasXML.aspx.vb" Inherits="Laboratorio5.ImportarTareasXML" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 270px;
        }
        .auto-style3 {
            text-align: center;
        }
        .auto-style4 {
            width: 449px;
            text-align: center;
        }
        .auto-style5 {
            width: 449px;
            text-align: left;
            font-size: x-large;
            height: 30px;
        }
        .auto-style6 {
            width: 270px;
            text-align: left;
            font-size: x-large;
            height: 30px;
        }
        .auto-style7 {
            width: 270px;
            text-align: left;
        }
        .auto-style8 {
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <h1 class="auto-style3">PROFESORES<br />
            GESTIÓN DE TAREAS GENÉRICAS</h1>
        <table class="auto-style1">
            <tr>
                <td class="auto-style6"><strong>Asignatura a Importar:</strong></td>
                <td class="auto-style5"><strong>Lista de Tareas</strong></td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:DropDownList ID="lista" runat="server" Height="17px" Width="263px" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td rowspan="2">
                    <asp:Xml ID="Xml1" runat="server"></asp:Xml>
                    

                </td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Button ID="Button1" runat="server" Height="72px" Text="IMPORTAR XML" Width="255px" />
                    <br />
                    <br />
                    <asp:Label ID="Errores" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </div>
        <div class="auto-style8">
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" Text="Volver" />
        </div>
    </form>
</body>
</html>
