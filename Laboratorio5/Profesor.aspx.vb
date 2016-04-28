Public Class Profesor
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("usuario") IsNot Nothing Then

        Else
            Response.Redirect("inicio.aspx")
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Response.Redirect("TareasProfesor.aspx")
    End Sub

    Protected Sub cerrar_Click(sender As Object, e As EventArgs) Handles cerrar.Click
        Session("usuario") = Nothing
        Response.Redirect("/inicio.aspx")
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Response.Redirect("/ImportarTareasXML.aspx")
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Response.Redirect("/ExportarTareasXML.aspx")
    End Sub
End Class