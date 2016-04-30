Imports System.Data.SqlClient
Imports System.IO

Public Class ExportarTareasXML
    Inherits System.Web.UI.Page

    Dim sql As SqlConnection
    Dim MisTablas As New DataTable
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet


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
            End If

        Else
            Response.Redirect("../inicio.aspx")
        End If


        Dim dirInfo As New DirectoryInfo(Server.MapPath("../"))

        articleList.DataSource = dirInfo.GetFiles("*.xml")
        articleList.DataBind()
    End Sub

    Protected Sub articleList_Link(ByVal rutaFichero As Object, ByVal e As DataGridItemEventArgs) Handles articleList.ItemDataBound

        If e.Item.Cells(0).Controls.Count > 0 Then

            Dim a As HyperLink
            a = CType(e.Item.Cells(0).Controls(0), HyperLink)
            a.NavigateUrl = a.NavigateUrl.Replace(Server.MapPath(""), "~")

        End If

        Return
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Response.Redirect("../Profesor/Profesor.aspx")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        da = New SqlDataAdapter("SELECT Codigo, Descripcion, HEstimadas, Explotacion, TipoTarea FROM TareasGenericas WHERE TareasGenericas.CodAsig='" & lista.SelectedValue & "'", sql)
        da.Fill(ds, "tarea")

        MisTablas = ds.Tables("tarea")

        ds.DataSetName = "tareas"

        Try


            'se sobreescribe 
            ds.WriteXml(Server.MapPath("../" & lista.SelectedValue & ".xml"))
            Errores.Text = "XML Exportado."
        Catch ex As Exception
            Errores.Text = "Error al exportar el XML. "
        End Try

        Dim dirInfo As New DirectoryInfo(Server.MapPath("../"))

        articleList.DataSource = dirInfo.GetFiles("*.xml")
        articleList.DataBind()
    End Sub


    Protected Sub lista_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lista.SelectedIndexChanged
        Errores.Text = ""
    End Sub
End Class