Imports System.Data
Imports System.Data.SqlClient
Imports System.Security.Cryptography

Partial Class registro
    Inherits System.Web.UI.Page


    Dim sql As SqlConnection
    Dim MisTablas As New DataTable
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet


    Sub New()
        sql = New SqlConnection("Data Source=laboratoriohads.database.windows.net;Initial Catalog=Lab;Persist Security Info=True;User ID=adminhads;Password=A1s2d3f4")
    End Sub


    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
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

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If existeUsuario() Then
            lblError.Visible = True
        Else
            lblError.Visible = False



            'Dim clave As Long = generarClave()

            ' Dim da As New SqlDataAdapter("insert into Usuarios values('" & txtCorreo.Text & "', '" & txtNombre.Text & "','" & txtPregunta.Text & "','" & txtRespuesta.Text & "','" & txtDNI.Text & ", '" & Boolean.TrueString & "','1','A','" & txtPassword.Text & ")", sql)
            ' Dim ds As New Data.DataSet
            ' da.Fill(ds)
            'MsgBox("Usuario insertado")

            'Dim envcorreo As New Laboratorio5.EnviarCorreo
            'envcorreo.enviarCorreo(clave, txtCorreo.Text)

            da = New SqlDataAdapter("SELECT * FROM Usuarios", sql)
            Dim builder As New SqlCommandBuilder(da)
            da.Fill(ds, "Usuarios")


            Dim md5Hash As MD5 = MD5.Create()
            Dim pass As String = GetMd5Hash(md5Hash, txtPassword.Text)


            MisTablas = ds.Tables("Usuarios")
            Dim dataRow As DataRow
            dataRow = MisTablas.NewRow()
            dataRow("email") = txtCorreo.Text
            dataRow("nombre") = txtNombre.Text
            dataRow("pregunta") = txtPregunta.Text
            dataRow("respuesta") = txtRespuesta.Text
            dataRow("dni") = txtDNI.Text
            dataRow("confirmado") = True
            dataRow("grupo") = "1"
            dataRow("tipo") = "A"
            dataRow("pass") = pass
            Try
                MisTablas.Rows.Add(dataRow)


                Try

                    da.Update(ds, "Usuarios")
                    ds.AcceptChanges()

                    'Errores.Text = "¡Tarea insertada correctamente!"
                Catch ex As Exception
                    'Errores.Text = "¡La tarea ya está insertada!"

                End Try
            Catch ex As Exception

                'Errores.Text = "Las horas deben tener un formato correcto!"
            End Try


            Response.Redirect("/inicio.aspx")

        End If

    End Sub

    Function existeUsuario() As Boolean

        Dim correo As String = txtCorreo.Text

        Dim da As New SqlDataAdapter("select * from Usuarios where email='" & correo & "'", sql)
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
End Class
