Imports System
Imports System.IO
Public Class HomeController
    Inherits System.Web.Mvc.Controller
    Dim WithEvents btnDownloadImage As New Button()
    Function Index() As ActionResult
        Return View()
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function


    'CREATE POST PETITION'
    '<HttpPost()>
    'Function ContactPrueba(data1 As String) As ActionResult
    '    MsgBox(data1)

    'End Function

    Function SavePhoto(imageBase64 As String, imagenReal As Drawing.Image, photo_Clave As String, photo_empresa As String,
                       nombrearchivo As String, root_Path As String)
        Dim newpath = VirtualPathUtility.GetDirectory(Request.Path)
        'Dim fullpathVirtual = "/Img/" + nombrearchivo

        Dim filePath As String = Path.Combine(root_Path, nombrearchivo)
        Dim pathFull = Path.Combine(Server.MapPath("~/Img/"), nombrearchivo)
        Dim finalImg As Drawing.Bitmap = GetImageFromBase64(imageBase64, pathFull, imagenReal)
        Dim img1 As Drawing.Bitmap
        'Dim newImage As Drawing.Image = Drawing.Image.FromFile("C:\Users\Valeria\Downloads\" + "1.png")



        ViewData("imagenFinal") = imagenReal
        Return View("Index")
    End Function

    Private Function GetImageFromBase64(ByVal Base64String As String, pathFull As String, imagenReal As Drawing.Image) As Drawing.Bitmap
        Dim fileBytes As Byte()
        Dim streamImage As Drawing.Bitmap
        Dim _image As Drawing.Image
        Try

            If String.Empty <> Base64String Then ''Checking The Base64 string validity
                fileBytes = Convert.FromBase64String(Base64String) ''Converting Base64 string to Byte Array

                Dim msee As MemoryStream = New MemoryStream(fileBytes)
                _image = Drawing.Image.FromStream(msee)
                _image.Save(pathFull, System.Drawing.Imaging.ImageFormat.Jpeg)
                msee.Close()

                'Using ms As New MemoryStream(fileBytes) ''Copying Byte Array to Memory Stream

                '    streamImage = Drawing.Image.FromStream(ms) ''Constructing Image from Memory Stream

                '    If Not IsNothing(streamImage) Then
                '        Dim w As Integer = 300
                '        Dim h As Integer = 150

                '        'Creamos un fondo blanco antes de crear la imagen
                '        Dim mybitmap As Drawing.Bitmap = New Drawing.Bitmap(w, h)
                '        Dim Gr As Drawing.Graphics
                '        Dim mybrush As Drawing.Brush = New Drawing.SolidBrush(Drawing.Color.Pink)

                '        streamImage = mybitmap
                '        Gr = Drawing.Graphics.FromImage(_image)
                '        Gr.Clear(Drawing.Color.White)
                '        Gr.FillRectangle(mybrush, 0, 0, w, h)
                '        Gr.DrawImageUnscaled(_image, 0, 0)


                '        'streamImage = mybitmap
                '        _image.Save(pathFull, System.Drawing.Imaging.ImageFormat.Jpeg)
                '        'Gr.Dispose()
                '        streamImage.Dispose()
                '        ms.Close()
                '        MsgBox("GUARDADITAA")




                '    End If

                'End Using

            End If

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")

        End Try

        Return _image ''Returning Image 

    End Function
End Class



'Convert byte[] to Image
'ms.Write(imageBytes, 0, imageBytes.Length)
'Dim Img As Bitmap = Image.FromStream(MS, True)

'Img.Save("PATH", System.Drawing.Imaging.ImageFormat.Jpeg);