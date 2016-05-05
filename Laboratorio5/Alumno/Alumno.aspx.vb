Public Class Alumno
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("usuario") IsNot Nothing Then

        Else
            Response.Redirect("../inicio.aspx")
        End If
    End Sub

    Protected Sub cerrar_Click(sender As Object, e As EventArgs) Handles cerrar.Click

        Application("cuantosalumnos") -= 1
        Application("listaalumnos").Remove(Session("usuario"))

        Session("usuario") = Nothing
        Session("dataSet") = Nothing
        Session("dataAdapter") = Nothing



        Response.Redirect("../inicio.aspx")
    End Sub

    Protected Sub boton_Click(sender As Object, e As EventArgs) Handles boton.Click

        Response.Redirect("TareasAlumno.aspx")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Response.Redirect("/Online.aspx")
    End Sub
End Class