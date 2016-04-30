<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ExportarTareasXML.aspx.vb" Inherits="Laboratorio5.ExportarTareasXML" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-decoration: underline;
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
                <td class="auto-style6"><strong>Asignatura a Exportar:</strong></td>
                <td class="auto-style5"><strong>Lista de Tareas</strong></td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:DropDownList ID="lista" runat="server" Height="17px" Width="263px" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td rowspan="2">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Codigo" DataSourceID="SqlDataSource1">
                        <Columns>
                            <asp:BoundField DataField="Codigo" HeaderText="CODIGO" ReadOnly="True" SortExpression="Codigo" />
                            <asp:BoundField DataField="Descripcion" HeaderText="DESCRIPCION" SortExpression="Descripcion" />
                            <asp:BoundField DataField="HEstimadas" HeaderText="HORAS EST." SortExpression="HEstimadas" />
                        </Columns>
                    </asp:GridView>
                    

                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LabConnectionString1 %>" SelectCommand="SELECT * FROM [TareasGenericas] WHERE ([CodAsig] = @CodAsig)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="lista" Name="CodAsig" PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    

                </td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Button ID="Button1" runat="server" Height="72px" Text="EXPORTAR XML" Width="255px" />
                    <br />
                    <br />
                    <asp:Label ID="Errores" runat="server" Text=""></asp:Label>
                    <br />
                </td>
            </tr>
        </table>
    </div>
        <div class="auto-style8">
        <asp:Button ID="Button2" runat="server" Text="Volver" />

            <br />
            <br />
            <h3 class="auto-style1">Tareas Exportadas</h3>

    <asp:DataGrid runat="server" ID="articleList" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingItemStyle BackColor="White" />
                <Columns>
                    <asp:HyperLinkColumn DataNavigateUrlField="FullName" DataTextField="Name" HeaderText="File Name" />
                    <asp:BoundColumn DataField="LastWriteTime" HeaderText="Last Write Time" 
                        DataFormatString="{0:d}" >
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Length" HeaderText="File Size"
                        DataFormatString="{0:#,### bytes}" >
                    </asp:BoundColumn>
                </Columns>

                <EditItemStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <ItemStyle BackColor="#EFF3FB" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />

            </asp:DataGrid>
            <br />
    </div>
    </form>
</body>
</html>
