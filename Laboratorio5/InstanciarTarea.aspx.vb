Imports System.Data.SqlClient

Public Class InstanciarTarea
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

            usuario.Text = Session("usuario")
            tarea.Text = Request.QueryString("codigo")

            da = New SqlDataAdapter("SELECT * FROM EstudiantesTareas WHERE Email = '" & Session("usuario") & "'", sql)
            Dim builder As New SqlCommandBuilder(da)
            da.Fill(ds, "EstudiantesTareas")
            MisTablas = ds.Tables("EstudiantesTareas")

            GridView1.DataSource = MisTablas
            GridView1.DataBind()
            Session("dataAdapter") = da
        Else
            Response.Redirect("inicio.aspx")
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MisTablas = ds.Tables("EstudiantesTareas")
        Dim dataRow As DataRow
        dataRow = MisTablas.NewRow()
        dataRow("Email") = usuario.Text
        dataRow("CodTarea") = tarea.Text
        Try

            dataRow("HEstimadas") = TextBox1.Text
            dataRow("HReales") = TextBox2.Text

            MisTablas.Rows.Add(dataRow)
            Try

                da.Update(ds, "EstudiantesTareas")
                ds.AcceptChanges()

                GridView1.DataSource = MisTablas
                GridView1.DataBind()
                Errores.Text = "¡Tarea instanciada correctamente!"
            Catch ex As Exception
                Errores.Text = "¡La tarea ya está instanciada!"

            End Try

        Catch ex As Exception

            Errores.Text = "Las horas deben tener un formato correcto!"
        End Try


    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("/TareasAlumno.aspx")
    End Sub

End Class