Imports System.Data
Imports System.Data.SqlClient

Partial Class confirmar
    Inherits System.Web.UI.Page

    Private sql As SqlConnection

    Sub New()
        sql = New SqlConnection("Data Source=laboratoriohads.database.windows.net;Initial Catalog=Lab;Persist Security Info=True;User ID=adminhads;Password=A1s2d3f4")
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim clave As Integer = Request.QueryString("clave")
        Dim mbr As String = Request.QueryString("mbr")

        Dim da As New SqlDataAdapter("select * from usuarios where correo='" & mbr & "' and clave='" & clave & "'", sql)
        Dim ds As New Data.DataSet
        da.Fill(ds)

        Dim filas As Integer = ds.Tables(0).Rows.Count

        If filas = 1 Then

            da = New SqlDataAdapter("update usuarios set activado=1 where correo='" & mbr & "'", sql)
            da.Fill(ds)
        Else
            Response.Redirect("/inicio.aspx")
        End If

    End Sub



    Protected Sub btnInicio_Click(sender As Object, e As EventArgs) Handles btnInicio.Click
        Response.Redirect("/inicio.aspx")
    End Sub
End Class
