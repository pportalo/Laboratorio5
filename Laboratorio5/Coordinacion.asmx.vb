Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Data.SqlClient

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class Coordinacion
    Inherits System.Web.Services.WebService
    Private sql As SqlConnection
    Sub New()
        sql = New SqlConnection("Data Source=laboratoriohads.database.windows.net;Initial Catalog=Lab;Persist Security Info=True;User ID=adminhads;Password=A1s2d3f4")
    End Sub
    <WebMethod()>
    Public Function media(asignatura As String) As Double

        Dim mediahoras As Double = 0.0
        Dim reader As SqlDataReader
        'Try
        ' /// Comparar con 0 aquí
        sql.Open()
        Dim command As New SqlCommand("SELECT AVG(EstudiantesTareas.HReales) AS Media FROM EstudiantesTareas INNER JOIN TareasGenericas ON EstudiantesTareas.CodTarea = TareasGenericas.Codigo WHERE TareasGenericas.CodAsig= '" & asignatura & "'", sql)
        reader = command.ExecuteReader()
        If reader.Read() Then

            If reader.IsDBNull(0) Then
                mediahoras = -1

            Else

                ' MsgBox("Entro en while")
                reader.Close()
                reader = command.ExecuteReader()
                While (reader.Read)
                    mediahoras = Convert.ToDouble(reader("Media"))
                End While
                reader.Close()
                'MsgBox(mediahoras)
                'MsgBox("Salgo de while")
            End If
        Else

        End If

        'Catch ex As Exception
        '    MsgBox("Error al calcular la media de horas")
        'End Try
        sql.Close()

        Return mediahoras


    End Function

End Class