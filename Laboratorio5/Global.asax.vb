Imports System.Data.SqlClient
Imports System.Web.SessionState

Public Class Global_asax
    Inherits System.Web.HttpApplication
    Private sql As SqlConnection
    Private correoUsuario As String

    Sub New()
        sql = New SqlConnection("Data Source=laboratoriohads.database.windows.net;Initial Catalog=Lab;Persist Security Info=True;User ID=adminhads;Password=A1s2d3f4")
    End Sub

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena al iniciar la aplicación
        Dim alumnos As New Collection
        Dim profesores As New Collection
        alumnos.Clear()
        profesores.Clear()

        Application("cuantosalumnos") = 0
        Application("cuantosprofesores") = 0
        Application("listaalumnos") = alumnos
        Application("listaprofesores") = profesores

    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena al iniciar la sesión

        'Dim command As New SqlCommand("Select * from Usuarios where email='" & Session("usuario") & "';", sql)
        'Dim reader As SqlDataReader
        'Try
        '    sql.Open()
        '    reader = command.ExecuteReader()
        '    While (reader.Read)
        '        Dim tipo As String = reader("tipo")
        '        If (String.Equals(tipo, "A")) Then
        '            Application("cuantosalumnos") += 1
        '            Application("listaalumnos").Add(Session("usuario"))
        '        Else
        '            Application("cuantosprofesores") += 1
        '            Application("listaprofesores").Add(Session("usuario"))
        '        End If
        '    End While

        '    reader.Close()
        'Catch ex As Exception
        '    'MsgBox("Ha habido errores!")
        'End Try
        'sql.Close()

    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena al comienzo de cada solicitud
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena al intentar autenticar el uso
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena cuando se produce un error
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena cuando finaliza la sesión
        Dim command As New SqlCommand("Select * from Usuarios where email='" & Session("usuario") & "';", sql)
        Dim reader As SqlDataReader
        Try
            sql.Open()
            reader = command.ExecuteReader()
            While (reader.Read)
                Dim tipo As String = reader("tipo")
                If (String.Equals(tipo, "A")) Then
                    Application("cuantosalumnos") -= 1
                    Application("listaalumnos").Remove(Session("usuario"))
                Else
                    Application("cuantosprofesores") -= 1
                    Application("listaprofesores").Remove(Session("usuario"))
                End If
            End While

            reader.Close()
        Catch ex As Exception
            'MsgBox("Ha habido errores!")
        End Try
        sql.Close()
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena cuando finaliza la aplicación
    End Sub

End Class