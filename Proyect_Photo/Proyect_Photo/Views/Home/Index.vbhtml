@code
    ViewData("TituloPagina") = "Capturar Fotografia desde la camara"
    Layout = "~/Views/Shared/_Layout.vbhtml"

    Dim tituloPagina = ViewData("TituloPagina")
    'Dim claveAuxiliar = ViewData("ClaveAuxiliar_DatosGenerales")

    'Dim claveUsuario = Comunes.ObtieneCadena(ViewData, "ClaveUsuario")
    'Dim nombreUsuario = Comunes.ObtieneCadena(ViewData, "NombreUsuario")
    'Dim llave = Comunes.ObtieneCadena(ViewData, "Llave")

    Dim regresaUrl = String.Empty
    If (ViewData("RegresaUrl") IsNot Nothing) Then
        regresaUrl = ViewData("RegresaUrl")
    Else
        regresaUrl = "~/Forms/Index.aspx"
    End If

    Dim rutaImagenes = String.Empty
    If (ViewData("rutaImagenes") IsNot Nothing) Then
        rutaImagenes = ViewData("rutaImagenes")
    End If


    Dim imagenFinal As Image
    If (ViewData("_image") IsNot Nothing) Then
        imagenFinal = ViewData("_image")
    End If

    Dim claveAuxiliar = String.Empty
    If (ViewData("claveAuxiliar") IsNot Nothing) Then
        claveAuxiliar = ViewData("claveAuxiliar")
    End If

    Dim tipodeauxiliar = ""
    Dim fotografia As String = ""
    Dim comentarios As String = ""
    Dim rootPath As String = System.Web.HttpContext.Current.Server.MapPath("~")
    Dim photoBase64 As String = "1"
End Code

<div id="mySidenav" class="sidenav">
    <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>


</div>

<div class="container" id="">

    <div class="row" style="margin-top:10px; margin-bottom:40px;">

        <h2>@tituloPagina</h2>

        <div class="padding-top-3">
            <a class="btn btn-default" href="ComunCatalogodeAuxiliares2"><i class="glyphicon glyphicon-chevron-left"></i> Regresar</a>
            @*<button class="btn btn-info" type="button" onclick="openNav()"><i class="glyphicon glyphicon-search"></i> Buscar</button>*@
            @*<a class="btn btn-primary" type="button" href="@Url.Action("Index", "ComunCatalogodeAuxiliares2")?nuevo=1"><i class="glyphicon glyphicon-plus"></i> Nuevo</a>*@
        </div>

        <div class="form-group form-group-sm col-md-3">
            <label class="control-label" for="txtClaveAuxiliar">Clave Auxiliar:</label>
            <input id="txtClaveAuxiliar" name="txtClaveAuxiliar" readonly type="text" class="txtClaveAuxiliar form-control" value="1">

        </div>
        <div class="form-group form-group-sm col-md-3">
            <label class="control-label">Empresa:</label>
            <input id="txtEmpresa" name="txtEmpresa" readonly type="text" class="txtEmpresa form-control" value="SolucionesSinem">

        </div>

        <div class="form-group form-group-sm col-md-3">
            <label class="control-label" for="txtRutaImagenes">Ruta Imagenes:</label>
            <input id="txtRoot" name="txtRoot" type="text" class="txtRoot form-control" value=@rootPath hidden>
            <input id="txtRutaImagenes" name="txtRutaImagenes" type="text" class="txtRutaImagenes form-control" value="C:\Users\Valeria\Downloads">
        </div>

    </div>
</div>



<!DOCTYPE html>
<html lang="es" dir="ltr">

<head>
    <meta charset="utf-8">
    <title>CAPTURA FOTO DE LA CAMARA</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
</head>

<body runat="server">
    <h1>GUARDAR UNA FOTO</h1>
    <p id="errorTxt"></p>
    <div>
        <video id="theVideo" controls autoplay></video>
        <canvas id="theCanvas"></canvas>
        
        

    </div>

    <form method="post" enctype="multipart/form-data">
        <asp:HiddenField id="dataURL" name="dataURL" button>
            <button id="btnCapture" type="button" name="btnCapture"> Tomar Foto</button>
            <img src="@imagenFinal" id="imagP2" name="imagP2" style="background-color:black"/>
            <img src="" id="imagP" name="imagP"/>
            <button id="btnDownloadImage" type="button" name="btnDownloadImage"> Guardar Imagen</button>
</form>

    <!--EDITADO POR MARICRUZ-->
    <!--CREAR PRETION POST
    <form method="post" action='@Url.Action("ContactPrueba", "Home")'>
        <input id="data1" name="data1" value="Maricruz" hidden>
        <button id="btn1" type="submit" name="btn1">PETICION POST</button>
    </form>-->

    <script type="text/javascript">
        var videoWidth = 320;
        var videoHeight = 240;
        var videoTag = document.getElementById('theVideo');
        var canvasTag = document.getElementById('theCanvas');
        var btnCapture = document.getElementById("btnCapture");
        var btnDownloadImage = document.getElementById("btnDownloadImage");
        document.getElementById("dataURL").value = canvasTag.toDataURL('image/jpeg').split(';base64,')[1];

       

        videoTag.setAttribute('width', videoWidth);
        videoTag.setAttribute('height', videoHeight);
        canvasTag.setAttribute('width', videoWidth);
        canvasTag.setAttribute('height', videoHeight);

        window.onload = () => {
            navigator.mediaDevices.getUserMedia({
                audio: false,
                video: {
                    width: videoWidth,
                    height: videoHeight
                }
            }).then(stream => {
                videoTag.srcObject = stream;
            }).catch(e => {
                document.getElementById('errorTxt').innerHTML = 'ERROR: ' + e.toString();
            });

            //IMAGEN OBTENIDA ESTA DENTRO DE LA VARIABLE 'canvasContext'
            var canvasContext = canvasTag.getContext('2d');

            //TOMAR IMAGEN
            btnCapture.addEventListener("click", () => {
                canvasContext.drawImage(videoTag, 0, 0, videoWidth, videoHeight);
                //alert(canvasTag.toDataURL());
                document.getElementById('imagP')
                    .setAttribute(
                        'src', canvasTag.toDataURL('image/png')
                    );

            });

            //DESCARGAR IMAGEN
            btnDownloadImage.addEventListener("click", () => {
                var link = document.createElement('a');

                var photo_Path = $("#txtRutaImagenes").val();
                var photo_Clave = $("#txtClaveAuxiliar").val();
                var photo_empresa = $("#txtEmpresa").val();
                var root_Path = $("#txtRoot").val() + "\Img\\";
                var photo_fullpath = root_Path + photo_Clave + '.png';
                var nombrearchivo = photo_empresa + '-' + photo_Clave + '.png';


                alert(photo_fullpath);
                var request= $.ajax({
                        url: '@Url.Action("SavePhoto", "Home")',
                        type: 'POST',
                    data: { imageBase64: $('#dataURL').val(), imagenReal: document.getElementById('imagP').src ,root_Path,photo_Clave, photo_empresa, nombrearchivo },
                    }).done(function () {
                        alert('Foto guardada.')
                    });
                request.done(function (msg) {
                    $("#log").html(msg);
                });

                request.fail(function (jqXHR, textStatus, errorThrown) {
                    alert("Request failed: " + jqXHR.responseText);
                });

                            //link.download = nombrearchivo;
                            //link.href = canvasTag.toDataURL();
                            //link.click();
            });
        };
    </script>

</body>

</html>


