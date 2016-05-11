<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Coordinacion.aspx.vb" Inherits="Laboratorio5.Coordinacion1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1>
    
        <asp:Label ID="Label4" runat="server" Text="COORDINACIÓN"></asp:Label>
        </h1>
    
        <br />
        <asp:Label ID="Label1" runat="server" Text="Seleccionar Asignatura:"></asp:Label>
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigo" DataValueField="codigo" Height="16px" Width="180px">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LabConnectionString1 %>" SelectCommand="SELECT [codigo] FROM [Asignaturas]"></asp:SqlDataSource>
        <br />
        <asp:Label ID="Resultado" runat="server" Text=""></asp:Label>
        &nbsp;<br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Consultar Horas" />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" Text="VOLVER" />
        <br />
    
    </div>
    </form>
</body>
</html>
