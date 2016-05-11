Public Class Coordinacion1
    Inherits System.Web.UI.Page
    Dim LaMedia As New CoorMedia.CoordinacionSoapClient
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("usuario") IsNot Nothing Then

        Else
            Response.Redirect("../inicio.aspx")
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim media As Double
        media = LaMedia.media(DropDownList1.SelectedValue)
        If media.Equals(-1) Then
            Resultado.Text = "No hay horas subidas para esta asignatura"
        Else
            Resultado.Text = "La media de horas dedicadas es: " & media & " horas."
        End If

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Response.Redirect("Profesor.aspx")
    End Sub
End Class