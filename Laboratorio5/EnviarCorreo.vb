Public Class EnviarCorreo
    Sub enviarCorreo(ByVal codigo As Long, ByVal dircorreo As String)


        'Declaro la variable para enviar el correo
        Dim correo As New System.Net.Mail.MailMessage()
        correo.From = New System.Net.Mail.MailAddress("hadspportalo@hotmail.com")

        correo.Subject = "Mensaje de confirmacion"
        correo.To.Add(dircorreo)
        correo.Body = "http://labo23.azurewebsites.net/confirmar.aspx?mbr=" & dircorreo & "&clave=" & codigo

        'Configuracion del servidor
        Dim Servidor As New System.Net.Mail.SmtpClient
        Servidor.Host = "smtp.live.com"
        Servidor.Port = 25
        Servidor.EnableSsl = True
        Servidor.Credentials = New System.Net.NetworkCredential("hadspportalo@hotmail.com", "A1s2d3f4")

        Servidor.Send(correo)

        'MsgBox("Correo enviado!")

    End Sub
End Class
