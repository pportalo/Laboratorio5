Public Class prueba
    Inherits System.Web.UI.Page

    Dim Matriculado As New es.hol.sw14.Matriculas
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim algo As String
        'algo = "jvadillo001@ikasle.ehu.es"
        algo = TextBox1.Text
        Label1.Text = Matriculado.comprobar(algo)
    End Sub
End Class