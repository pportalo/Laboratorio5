Imports System.Data
Imports System.Data.SqlClient


Partial Class registro
    Inherits System.Web.UI.Page

    Private sql As SqlConnection

    Sub New()
        sql = New SqlConnection("Data Source=laboratoriohads.database.windows.net;Initial Catalog=Lab;Persist Security Info=True;User ID=adminhads;Password=A1s2d3f4")
    End Sub


    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("/inicio.aspx")
    End Sub


    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If existeUsuario() Then
            lblError.Visible = True
        Else
            lblError.Visible = False



            Dim clave As Long = generarClave()

            Dim da As New SqlDataAdapter("insert into usuarios values('" & txtCorreo.Text & "', '" & txtPassword.Text & "','" & txtNombre.Text & "','" & txtApellidos.Text & "','" & txtDNI.Text & "','" & ddlPregunta.SelectedIndex & "','" & txtRespuesta.Text & "', '" & clave & "', '0')", sql)
            Dim ds As New Data.DataSet
            da.Fill(ds)
            'MsgBox("Usuario insertado")

            Dim envcorreo As New Laboratorio5.EnviarCorreo
            envcorreo.enviarCorreo(clave, txtCorreo.Text)

            Response.Redirect("/inicio.aspx")

        End If

    End Sub

    Function existeUsuario() As Boolean

        Dim correo As String = txtCorreo.Text

        Dim da As New SqlDataAdapter("select * from usuarios where correo='" & correo & "'", sql)
        Dim ds As New Data.DataSet
        da.Fill(ds)

        Dim filas As Integer = ds.Tables(0).Rows.Count

        Return filas = 1

    End Function


    Function generarClave() As Long
        Randomize()
        Dim NumConf As Long = CLng(Rnd() * 9000000) + 1000000
        Return NumConf
    End Function

    Protected Sub ddlPregunta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlPregunta.SelectedIndexChanged

    End Sub

    Protected Sub txtApellidos_TextChanged(sender As Object, e As EventArgs) Handles txtApellidos.TextChanged

    End Sub
End Class
