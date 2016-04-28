Imports System.Data.SqlClient

Public Class TareasAlumno
    Inherits System.Web.UI.Page


    Dim sql As SqlConnection
    Dim MisTablas As New DataTable
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet

    Sub New()
        Sql = New SqlConnection("Data Source=laboratoriohads.database.windows.net;Initial Catalog=Lab;Persist Security Info=True;User ID=adminhads;Password=A1s2d3f4")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("usuario") IsNot Nothing Then
            If Page.IsPostBack Then
            Else
                da = New SqlDataAdapter("SELECT GruposClase.codigoasig, Asignaturas.Nombre from GruposClase JOIN Asignaturas ON Asignaturas.codigo = GruposClase.codigoasig WHERE GruposClase.codigo in (SELECT Grupo from EstudiantesGrupo where Email='" & Session("usuario") & "')", sql)
                da.Fill(ds, "MisAsignaturas")

                MisTablas = ds.Tables("MisAsignaturas")
                lista.DataTextField = "Nombre"
                lista.DataSource = MisTablas
                lista.DataBind()

                da = New SqlDataAdapter("SELECT TareasGenericas.Codigo, TareasGenericas.Descripcion, TareasGenericas.CodAsig, TareasGenericas.HEstimadas, TareasGenericas.Explotacion, TareasGenericas.TipoTarea, Asignaturas.Nombre FROM TareasGenericas JOIN Asignaturas ON Asignaturas.codigo=TareasGenericas.CodAsig WHERE Explotacion='true'", sql)
                Dim builder As New SqlCommandBuilder(da)
                da.Fill(ds, "Tareas")


                Session("dataSet") = ds
            End If

        Else
            Response.Redirect("inicio.aspx")
        End If
    End Sub

    Protected Sub GridView_Sorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs) Handles tabla.Sorting
        MisTablas = Session("dataSet").Tables("Tareas")
        Dim dv As New DataView(MisTablas)
        Dim asignatura As String = lista.SelectedValue

        dv.RowFilter = "Nombre='" & asignatura & "'"
        dv.Sort = e.SortExpression
        tabla.DataSource = dv
        tabla.DataBind()
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabla.SelectedIndexChanged
        Response.Redirect("InstanciarTarea.aspx?codigo=" &
        Me.tabla.SelectedRow.Cells(1).Text)
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles ver.Click, tabla.SelectedIndexChanged
        Try
            Dim asignatura As String = lista.SelectedValue

            If columnas.Items.Item(0).Selected Then
                tabla.Columns(1).Visible = True
            Else
                tabla.Columns(1).Visible = False
            End If

            If columnas.Items.Item(1).Selected Then
                tabla.Columns(2).Visible = True
            Else
                tabla.Columns(2).Visible = False
            End If

            If columnas.Items.Item(2).Selected Then
                tabla.Columns(3).Visible = True
            Else
                tabla.Columns(3).Visible = False
            End If

            If columnas.Items.Item(3).Selected Then
                tabla.Columns(4).Visible = True
            Else
                tabla.Columns(4).Visible = False
            End If

            MisTablas = Session("dataSet").Tables("Tareas")
            Dim dv As New DataView(MisTablas)
            dv.RowFilter = "Nombre='" & asignatura & "'"
            tabla.AllowSorting = True
            tabla.DataSource = dv
            tabla.DataBind()



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub Button1_Click1(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("/Alumno.aspx")
    End Sub
End Class