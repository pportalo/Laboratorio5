<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TareasProfesor.aspx.vb" Inherits="Laboratorio5.TareasProfesor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            width: 30%;
            height: 48px;
        }
        .auto-style4 {
            text-align: center;
            height: 48px;
        }
        .auto-style5 {
            width: 89%;
            height: 77px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1 class="auto-style5">PROFESORES<br />
            GESTIÓN DE TAREAS</h1>

    <table border="1" style="width: 946px">
  <tr>
    <td class="auto-style3">
        <asp:Label ID="Label1" runat="server" Text="Seleccionar Asignatura:"></asp:Label>
        <br />
        <asp:DropDownList ID="lista" runat="server" AutoPostBack="True" Height="27px" Width="270px">
        </asp:DropDownList>
      </td>
    <td class="auto-style4">
        <asp:Button ID="Button1" runat="server" Text="Insertar Nueva Tarea" />
      </td>
  </tr>
  <tr>
    <td class="auto-style1" colspan="2">
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Codigo" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                <asp:BoundField DataField="Codigo" HeaderText="Codigo" SortExpression="Codigo" ReadOnly="True" />
                <asp:BoundField DataField="HEstimadas" HeaderText="HEstimadas" SortExpression="HEstimadas" />
                <asp:CheckBoxField DataField="Explotacion" HeaderText="Explotacion" SortExpression="Explotacion" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LabConnectionString1 %>" SelectCommand="SELECT * FROM [TareasGenericas] WHERE ([CodAsig] = @CodAsig)" DeleteCommand="DELETE FROM [TareasGenericas] WHERE [Codigo] = @Codigo" InsertCommand="INSERT INTO [TareasGenericas] ([Codigo], [Descripcion], [CodAsig], [HEstimadas], [Explotacion], [TipoTarea]) VALUES (@Codigo, @Descripcion, @CodAsig, @HEstimadas, @Explotacion, @TipoTarea)" UpdateCommand="UPDATE [TareasGenericas] SET [Descripcion] = @Descripcion, [CodAsig] = @CodAsig, [HEstimadas] = @HEstimadas, [Explotacion] = @Explotacion, [TipoTarea] = @TipoTarea WHERE [Codigo] = @Codigo">
            <DeleteParameters>
                <asp:Parameter Name="Codigo" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Codigo" Type="String" />
                <asp:Parameter Name="Descripcion" Type="String" />
                <asp:Parameter Name="CodAsig" Type="String" />
                <asp:Parameter Name="HEstimadas" Type="Int32" />
                <asp:Parameter Name="Explotacion" Type="Boolean" />
                <asp:Parameter Name="TipoTarea" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="lista" DefaultValue="EDA1" Name="CodAsig" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="Descripcion" Type="String" />
                <asp:Parameter Name="CodAsig" Type="String" />
                <asp:Parameter Name="HEstimadas" Type="Int32" />
                <asp:Parameter Name="Explotacion" Type="Boolean" />
                <asp:Parameter Name="TipoTarea" Type="String" />
                <asp:Parameter Name="Codigo" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <br />
        <asp:Button ID="Button2" runat="server" Text="Volver" />
      </td>
  </tr>
  </table>
    </div>
    </form>
</body>
</html>
