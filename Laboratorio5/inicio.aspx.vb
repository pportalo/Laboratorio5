Imports System.Data.SqlClient
Imports System.Security.Cryptography

Partial Class inicio
    Inherits System.Web.UI.Page

    Private sql As SqlConnection
    Private correoUsuario As String

    Sub New()
        sql = New SqlConnection("Data Source=laboratoriohads.database.windows.net;Initial Catalog=Lab;Persist Security Info=True;User ID=adminhads;Password=A1s2d3f4")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("usuario") IsNot Nothing Then
            'MsgBox("Ya hay una sesion abierta")
            Dim command As New SqlCommand("Select * from Usuarios where email='" & Session("usuario") & "';", sql)
            Dim reader As SqlDataReader
            Try
                sql.Open()
                reader = command.ExecuteReader()
                While (reader.Read)
                    Dim tipo As String = reader("tipo")
                    If (String.Equals(tipo, "A")) Then

                        Response.Redirect("~/Alumno/Alumno.aspx")

                    Else

                        Response.Redirect("~/Profesor/Profesor.aspx")

                    End If
                End While
                reader.Close()
            Catch ex As Exception
                'MsgBox("Ha habido errores!")
            End Try
            sql.Close()

        End If

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

    Function loguear() As Boolean

        Dim correo As String = txtUsuario.Text

        Dim md5Hash As MD5 = MD5.Create()
        Dim pass As String = GetMd5Hash(md5Hash, txtPassword.Text)

        Dim da As New SqlDataAdapter("select * from usuarios where email='" & correo & "' and pass='" & pass & "'", sql)
        Dim ds As New Data.DataSet
        da.Fill(ds)

        Dim filas As Integer = ds.Tables(0).Rows.Count

        If filas = 1 Then
            Return True
        Else
            Return False
        End If

    End Function


    Protected Sub btnLoguear_Click(sender As Object, e As EventArgs) Handles btnLoguear.Click

        If loguear() Then
            Session("usuario") = txtUsuario.Text

            Dim command As New SqlCommand("Select * from Usuarios where email='" & txtUsuario.Text & "';", sql)
            Dim reader As SqlDataReader
            Try
                sql.Open()
                reader = command.ExecuteReader()
                While (reader.Read)
                    Dim tipo As String = reader("tipo")
                    If (String.Equals(tipo, "A")) Then

                        FormsAuthentication.SetAuthCookie("alumno", True)

                        Application("cuantosalumnos") += 1
                        Application("listaalumnos").Add(txtUsuario.Text, txtUsuario.Text)
                        Response.Redirect("~/Alumno/Alumno.aspx")

                    Else
                        If (String.Equals(txtUsuario.Text, "vadillo@ehu.es")) Then
                            FormsAuthentication.SetAuthCookie("administrador", True)
                        Else
                            FormsAuthentication.SetAuthCookie("profesor", True)
                        End If

                        Application("cuantosprofesores") += 1
                        Application("listaprofesores").Add(txtUsuario.Text, txtUsuario.Text)
                        Response.Redirect("~/Profesor/Profesor.aspx")

                    End If
                End While
                reader.Close()
            Catch ex As Exception
                'MsgBox("Ha habido errores!")
            End Try
            sql.Close()
        Else
            lblError.Visible = True
        End If
    End Sub
    Protected Sub btnRegistro_Click(sender As Object, e As EventArgs) Handles btnRegistro.Click
        Response.Redirect("registro.aspx")
    End Sub
    Protected Sub btnCambiarPassword_Click(sender As Object, e As EventArgs) Handles btnCambiarPassword.Click

        If loguear() Then

            Response.Redirect("/cambiarpassword.aspx?correo=" & txtUsuario.Text)
        Else
            lblError.Visible = True
        End If

    End Sub
End Class
