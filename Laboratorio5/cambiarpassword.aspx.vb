Imports System.Data
Imports System.Data.SqlClient
Imports System.Security.Cryptography

Partial Class cambiarpassword
    Inherits System.Web.UI.Page

    Private sql As SqlConnection


    Sub New()
        sql = New SqlConnection("Data Source=laboratoriohads.database.windows.net;Initial Catalog=Lab;Persist Security Info=True;User ID=adminhads;Password=A1s2d3f4")
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim da As New SqlDataAdapter("select pregunta from Usuarios where email='" & Request.QueryString("correo") & "'", sql)
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

    Function GetMd5Hash(ByVal md5Hash As MD5, ByVal input As String) As String

        ' Convert the input string to a byte array and compute the hash.
        Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))

        ' Create a new Stringbuilder to collect the bytes
        ' and create a string.
        Dim sBuilder As New StringBuilder()

        ' Loop through each byte of the hashed data 
        ' and format each one as a hexadecimal string.
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i

        ' Return the hexadecimal string.
        Return sBuilder.ToString()

    End Function 'GetMd5Hash


    Protected Sub btnCambiar_Click(sender As Object, e As EventArgs) Handles btnCambiar.Click

        Dim da As New SqlDataAdapter("select * from Usuarios where email='" & Request.QueryString("correo") & "' and respuesta='" & txtRespuesta.Text & "'", sql)
        Dim ds As New Data.DataSet
        da.Fill(ds)

        Dim filas As Integer = ds.Tables(0).Rows.Count

        If filas = 1 Then
            Dim md5Hash As MD5 = MD5.Create()
            Dim pass As String = GetMd5Hash(md5Hash, txtPassword.Text)

            da = New SqlDataAdapter("update Usuarios set pass='" & pass & "' where email='" & Request.QueryString("correo") & "'", sql)
            ds = New Data.DataSet
            da.Fill(ds)

            Response.Redirect("/inicio.aspx")
        Else
            lblError.Visible = True
        End If

    End Sub

End Class
