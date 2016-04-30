Imports System.Data.SqlClient
Imports System.Net
Imports System.Xml

Public Class ImportarTareasXML
    Inherits System.Web.UI.Page

    Dim sql As SqlConnection
    Dim MisTablas As New DataTable
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Dim XMLD As New XmlDocument


    Sub New()
        sql = New SqlConnection("Data Source=laboratoriohads.database.windows.net;Initial Catalog=Lab;Persist Security Info=True;User ID=adminhads;Password=A1s2d3f4")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("usuario") IsNot Nothing Then
            If Page.IsPostBack Then
            Else
                da = New SqlDataAdapter("SELECT Asignaturas.codigo, Asignaturas.Nombre FROM ProfesoresGrupo INNER JOIN Asignaturas INNER JOIN GruposClase ON Asignaturas.codigo = GruposClase.codigoasig ON ProfesoresGrupo.codigogrupo = GruposClase.codigo WHERE ProfesoresGrupo.email='" & Session("usuario") & "'", sql)
                da.Fill(ds, "AsignaturasProfesor")

                MisTablas = ds.Tables("AsignaturasProfesor")
                lista.DataTextField = "codigo"
                lista.DataSource = MisTablas
                lista.DataBind()
                lista.Items.Item(0).Attributes.Add("selected", "selected")
                Try
                    If My.Computer.FileSystem.FileExists(Server.MapPath("/App_Data/" & lista.SelectedValue & ".xml")) Then
                        Xml1.DocumentSource = Server.MapPath("/App_Data/" & lista.SelectedValue & ".xml")
                        Xml1.TransformSource = Server.MapPath("/App_Data/XSLTFile.xsl")
                        Errores.Text = " "
                    Else
                        Errores.Text = "No existe el XML."
                    End If
                Catch ex As Exception
                    Errores.Text = "Fallo en el sistema"
                End Try
            End If

        Else
            Response.Redirect("../inicio.aspx")
        End If
    End Sub

    Protected Sub lista_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lista.TextChanged
        Try
            If My.Computer.FileSystem.FileExists(Server.MapPath("/App_Data/" & lista.SelectedValue & ".xml")) Then
                Xml1.DocumentSource = Server.MapPath("/App_Data/" & lista.SelectedValue & ".xml")
                Xml1.TransformSource = Server.MapPath("/App_Data/XSLTFile.xsl")
                Errores.Text = " "
            Else
                Errores.Text = "No existe el XML."
            End If
        Catch ex As Exception
            Errores.Text = "Fallo en el sistema"
        End Try
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            XMLD.Load(Server.MapPath("/App_Data/" & lista.SelectedValue & ".xml"))

            da = New SqlDataAdapter("SELECT * FROM TareasGenericas ", sql)
            da.Fill(ds, "TareasGenericas")
            MisTablas = ds.Tables("TareasGenericas")
            Dim tareas As XmlNodeList = XMLD.GetElementsByTagName("tarea")

            Dim i As Integer
            For i = 0 To (tareas.Count - 1)
                MisTablas.Rows.Add(tareas(i).ChildNodes(0).ChildNodes(0).Value, tareas(i).ChildNodes(1).ChildNodes(0).Value, lista.SelectedValue, Integer.Parse(tareas(i).ChildNodes(2).ChildNodes(0).Value), Boolean.Parse(tareas(i).ChildNodes(3).ChildNodes(0).Value), tareas(i).ChildNodes(4).ChildNodes(0).Value)
            Next

            Dim builder As SqlCommandBuilder = New SqlCommandBuilder(da)
            da.Update(ds, "TareasGenericas")
            ds.AcceptChanges()

            Errores.Text = "Importado con éxito"

        Catch ex As Exception
            Errores.Text = "Ya se ha importado este XML"
        End Try

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Response.Redirect("Profesor.aspx")
    End Sub

    Protected Sub lista_SelectedIndexChanged1(sender As Object, e As EventArgs) Handles lista.SelectedIndexChanged

    End Sub
End Class