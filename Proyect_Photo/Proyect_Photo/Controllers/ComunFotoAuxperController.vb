Imports System.Web.Mvc

Namespace Controllers
    Public Class ComunFotoAuxperController
        Inherits Controller
        '' GET: ComunFotoAuxper
        Function Index(ByVal clave As String) As ActionResult
            '    If String.IsNullOrEmpty(clave) = False Then
            '        Dim registro = Comunes.FRegresaRegistro("claveauxiliar = '" & clave & "'", "tbComunCatalogodeAuxiliares")
            '        ViewBag.Registro = registro
            '        ViewData("claveAuxiliar") = clave

            '    End If


            '    'Dim estados = Comunes.FRegresaRegistros("select ClaveEstado as clave, Nombreestado as nombre from tbComunCatalogodeEstados", False)
            '    'ViewData("Estados") = estados


            '    'Dim sucursales = Comunes.FRegresaRegistros("select ClaveSucursal as clave, NombreSucursal as nombre from tbComunCatalogodeSucursales")
            '    'ViewData("Sucursales") = sucursales
            '    ViewData("RegresaUrl") = Url.Action("index", "Home")

            '    Dim rutaImagenes = Url.Content("~/Content/empresas/" + Empresa + "/")

            '    ViewData("rutaImagenes") = rutaImagenes

            '    ViewData("claveAuxiliar") = clave

            '    Return View()


        End Function

    End Class
End Namespace