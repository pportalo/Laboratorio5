Imports System.Data
Imports System.Data.SqlClient
Partial Class cambiarpassword
    Inherits System.Web.UI.Page

    Private sql As SqlConnection


    Sub New()
        sql = New SqlConnection("Data Source=laboratoriohads.database.windows.net;Initial Catalog=Lab;Persist Security Info=True;User ID=adminhads;Password=A1s2d3f4")
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim da As New SqlDataAdapter("select u.correo, u.respuesta, p.pregunta from usuarios u, preguntas p where u.ref_pregunta = p.id_pregunta and correo='" & Request.QueryString("correo") & "'", sql)
        Dim ds As New Data.DataSet
        da.Fill(ds)

        Dim filas As Integer = ds.Tables(0).Rows.Count

        If filas = 1 Then
            lblPregunta.Text = ds.Tables(0).Rows(0)("pregunta")

        Else
            Response.Redirect("/inicio.aspx")
        End If



    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Response.Redirect("/inicio.aspx")
    End Sub


    Protected Sub btnCambiar_Click(sender As Object, e As EventArgs) Handles btnCambiar.Click

        Dim da As New SqlDataAdapter("select * from usuarios where correo='" & Request.QueryString("correo") & "' and respuesta='" & txtRespuesta.Text & "'", sql)
        Dim ds As New Data.DataSet
        da.Fill(ds)

        Dim filas As Integer = ds.Tables(0).Rows.Count

        If filas = 1 Then
            da = New SqlDataAdapter("update usuarios set password='" & txtPassword.Text & "' where correo='" & Request.QueryString("correo") & "'", sql)
            ds = New Data.DataSet
            da.Fill(ds)

            Response.Redirect("/inicio.aspx")
        Else
            lblError.Visible = True
        End If

    End Sub

    Protected Sub txtRespuesta_TextChanged(sender As Object, e As EventArgs) Handles txtRespuesta.TextChanged

    End Sub

    Protected Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged

    End Sub
End Class
