using System;
using Microsoft.AspNetCore.Mvc;
using reportesApi.Services;
using reportesApi.Utilities;
using Microsoft.AspNetCore.Authorization;
using reportesApi.Models;
using Microsoft.Extensions.Logging;
using System.Net;
using reportesApi.Helpers;
using Newtonsoft.Json;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Microsoft.AspNetCore.Hosting;
using reportesApi.Models.Compras;

namespace reportesApi.Controllers
{
   
    [Route("api")]
    public class ComprasController: ControllerBase
    {
   
        private readonly ComprasService _articulosService;
        private readonly ILogger<ComprasController> _logger;
  
        private readonly IJwtAuthenticationService _authService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        

        Encrypt enc = new Encrypt();

        public ComprasController(ComprasService articulosservice, ILogger<ComprasController> logger, IJwtAuthenticationService authService) {
            _articulosService = articulosservice;
            _logger = logger;
       
            _authService = authService;
            // Configura la ruta base donde se almacenan los archivos.
            // Asegúrate de ajustar la ruta según tu estructura de directorios.

            
            
        }


        [HttpPost("DiasInventario")]
        public IActionResult ReporteDias([FromBody] GetReporteDiasInventarioModel req )
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                ( memory, string filePath) = _articulosService.ReporteDiasInventario(req.FechaInicial, req.FechaFinal, req.Proveedor);
                Console.WriteLine("la ruta es:" + filePath);

                // Configura el tipo de contenido correcto según el tipo de archivo.
                // Para archivos Excel, puedes usar "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                var fileExt = Path.GetExtension("ReporteDias.xlsx").ToLowerInvariant();
                if (fileExt == ".xlsx")
                {
                    contentType = "application/vnd.ms-excel";
                }
                return File(memory, contentType, Path.GetFileName(filePath));
            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }


            return new JsonResult(objectResponse);

        }

        [HttpGet("ReporteCatalogoArticulos")]
        public IActionResult ReporteCatalogoArticulos( [FromQuery  ] int sucursal )
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                ( memory, string filePath) = _articulosService.ReporteCatalogoArticulos(sucursal);
                Console.WriteLine("la ruta es:" + filePath);

                // Configura el tipo de contenido correcto según el tipo de archivo.
                // Para archivos Excel, puedes usar "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                var fileExt = Path.GetExtension("ReporteDias.xlsx").ToLowerInvariant();
                if (fileExt == ".xlsx")
                {
                    contentType = "application/vnd.ms-excel";
                }
                return File(memory, contentType, Path.GetFileName(filePath));
            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }


            return new JsonResult(objectResponse);

        }


        [HttpPost("FaltantesExistencia")]
        public IActionResult FaltantesExistencia([FromBody] DifrenciaInventariosReques req )
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                ( memory, string filePath) = _articulosService.ReporteFaltanteExistencias(req.Sucursal);
                Console.WriteLine("la ruta es:" + filePath);

                // Configura el tipo de contenido correcto según el tipo de archivo.
                // Para archivos Excel, puedes usar "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                var fileExt = Path.GetExtension("ReporteDias.xlsx").ToLowerInvariant();
                if (fileExt == ".xlsx")
                {
                    contentType = "application/vnd.ms-excel";
                }
                return File(memory, contentType, Path.GetFileName(filePath));
            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }


            return new JsonResult(objectResponse);

        }

    }

}

// Hola
// Moka-chan ga oshiete kureta iron'na mita me ni nareru apurina n datte dore dore 
// Me cae como el pico Stuart Little. Parece broma wn, pero no. Stuart Little es un maldito conchetumare.
//  ¿Una rata culia fue elegida entre niños reales en un orfanato y se supone que es un héroe? Y nisiquiera 
// puedo decirte cuantas veces he visto un espacio de estacionamiento solo para girar la esquina y darme cuenta
// de que la rata culia ya estaba estacionada alli en su auto culiao feo y enano. Se llevó a mi
// mujer, mis niños, mi casa y me quito mi trabajo. Te juro que voy a exterminar a ese ratón culiao maldito
// y lo voy a llevar al infierno conmigo. Stuart Little me cago la vida. El verano pasado, me acerque al ratón concheumare y le
// pedí su autógrafo, porque mi hijo es un gran fan. El ratón de mrd me dio el autógrafo y me dijo que me quemara en el infierno. 
// Más tarde, cuando le di a mi hijo el autógrafo, se echo a llorar y dijo que me odiaba. Resultó que el hijo de puta no escribió su autógrafo, 
// el escribió "eres un pedazo de mierda, y me culie a tu mamita". Ahora estoy divorciado y planeando una gran demanda colectiva
// contra el demonio blanco que arruinó mi vida. Tu tiempo casi ha terminado, Stuart. Todas las personas a las que has hecho daño se levantarán contra ti.