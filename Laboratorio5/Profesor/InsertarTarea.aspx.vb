Imports System.Data.Common
Imports System.Data.SqlClient

Public Class InsertarTarea
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


        da = New SqlDataAdapter("SELECT * FROM TareasGenericas", sql)
        Dim builder As New SqlCommandBuilder(da)
        da.Fill(ds, "TareasGenericas")

        MisTablas = ds.Tables("TareasGenericas")
        Dim dataRow As DataRow
        dataRow = MisTablas.NewRow()
        dataRow("Codigo") = codigo.Text
        dataRow("Descripcion") = descripcion.Text
        dataRow("CodAsig") = lista.SelectedValue
        Try
            dataRow("HEstimadas") = horas.Text
            dataRow("Explotacion") = True
            dataRow("TipoTarea") = tipo.SelectedValue
            MisTablas.Rows.Add(dataRow)


            Try

                da.Update(ds, "TareasGenericas")
                ds.AcceptChanges()

                Errores.Text = "¡Tarea insertada correctamente!"
            Catch ex As Exception
                Errores.Text = "¡La tarea ya está insertada!"

            End Try
        Catch ex As Exception

            Errores.Text = "Las horas deben tener un formato correcto!"
        End Try




        ' Dim command As New SqlCommand("INSERT INTO TareasGenericas (Codigo, Descripcion, CodAsig, HEstimadas, Explotacion, TipoTarea)VALUES ('" & codigo.Text & "','" & descripcion.Text & "','" & lista.SelectedValue & "','" & horas.Text & "','1','" & tipo.SelectedValue & "');", sql)
        ' Dim reader As SqlDataReader
        ' Try
        ' sql.Open()
        ' reader = command.ExecuteReader()
        ' Catch ex As Exception
        ' MsgBox("Ha habido errores!")
        ' Errores.Text = "¡La tarea NO se ha insertado! Ha habido algún problema con la conexión"
        ' End Try
        ' sql.Close()
        ' Errores.Text = "¡La tarea se ha insertado!"


    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Response.Redirect("TareasProfesor.aspx")
    End Sub
End Class