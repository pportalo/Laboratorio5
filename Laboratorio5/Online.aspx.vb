Public Class Online
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Application("cuantosalumnos") Is Nothing Then
            lblalum.Text = 0
        Else
            lblalum.Text = Application("cuantosalumnos")
            lista1.DataSource = Application("listaalumnos")
            lista1.DataBind()
        End If
        If Application("cuantosprofesores") Is Nothing Then
            lblprofe.Text = 0
        Else
            lblprofe.Text = Application("cuantosprofesores")
            lista2.DataSource = Application("listaprofesores")
            lista2.DataBind()
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("inicio.aspx")
    End Sub
End Class