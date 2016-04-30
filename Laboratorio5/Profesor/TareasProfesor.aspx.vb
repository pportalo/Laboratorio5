Imports System.Data.SqlClient

Public Class TareasProfesor
    Inherits System.Web.UI.Page

    Dim sql As SqlConnection
    Dim MisTablas As New DataTable
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet


    Sub New()
        sql = New SqlConnection("Data Source=laboratoriohads.database.windows.net;Initial Catalog=Lab;Persist Security Info=True;User ID=adminhads;Password=A1s2d3f4")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("usuario") IsNot Nothing Then
            If Page.IsPostBack Then
            Else
                da = New SqlDataAdapter("SELECT Asignaturas.codigo, Asignaturas.Nombre FROM ProfesoresGrupo INNER JOIN Asignaturas INNER JOIN GruposClase ON Asignaturas.codigo = GruposClase.codigoasig ON ProfesoresGrupo.codigogrupo = GruposClase.codigo WHERE ProfesoresGrupo.email='" & Session("usuario") & "'", sql)
                da.Fill(ds, "AsignaturasProfesor")

                MisTablas = ds.Tables("AsignaturasProfesor")
                lista.DataTextField = "codigo"
                lista.DataSource = MisTablas
                lista.DataBind()
                lista.Items.Item(0).Attributes.Add("selected", "selected")
            End If

        Else
            Response.Redirect("../inicio.aspx")
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Response.Redirect("InsertarTarea.aspx")
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("Profesor.aspx")
    End Sub
End Class