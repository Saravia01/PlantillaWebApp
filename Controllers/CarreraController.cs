
13/5/2024
17/4/2024
Los mensajes enviados a este mismo número están cifrados de extremo a extremo. Nadie fuera de este chat, ni siquiera WhatsApp, puede leerlos ni escucharlos. Haz clic para obtener más información.

113 kB

7:57 a.m.

146 kB

7:57 a.m.

116 kB

7:57 a.m.

153 kB

+2
8/5/2024

0:17

1:48 a.m.
13/5/2024
Reenviado
Informe_P2_DotNet.pdf
6 páginas•PDF•878 kB
6:05 p.m.
14/5/2024
UNIVERSIDAD TECNOLÓGICA DE LINARE1.docx
DOCX•86 kB
9:55 a.m.
HOY
public int UpdateCarrerasABM(CarrerasModel carreras)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@Nombre", SqlDbType = SqlDbType.VarChar, Value = carreras.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@Clave", SqlDbType = SqlDbType.VarChar, Value = carreras.Clave });
                parametros.Add(new SqlParameter { ParameterName = "@Estatus", SqlDbType = SqlDbType.Int, Value = carreras.Estatus });
                 parametros.Add(new SqlParameter { ParameterName = "@Usuario", SqlDbType = SqlDbType.VarChar, Value = carreras.Usuario });

                dac.ExecuteNonQuery("UpdateCarrerasABM", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
            
        }
        
          public int DeleteCarrerasABM(CarrerasModel carreras)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = carreras.Id });
               
                dac.ExecuteNonQuery("DeleteCarrerasABM", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
            
        }
9:46 a.m.
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
    public class CarreraControllers: ControllerBase
    {
   
        private readonly CarreraService _CarreraService;
        private readonly ILogger<CarreraControllers> _logger;
        private readonly IJwtAuthenticationService _authService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        

        Encrypt enc = new Encrypt();

        public CarreraControllers(CarreraService CarreraService, ILogger<CarreraControllers> logger, IJwtAuthenticationService authService) {
           
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
             _CarreraService = CarreraService;
            _authService = authService;
            
        }
        [HttpGet("getcarreras")]
        public IActionResult GetCarreradot net return()
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _CarreraService.getcarreras();
                objectResponse.response = resultado;
                return new JsonResult(objectResponse);
             
            
            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }


            return new JsonResult(objectResponse);

        }
        
         [HttpPost("Insertcarreras")]
        public IActionResult InsertCarrera([FromBody] CarreraModel carreras)
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _CarreraService.Insertcarreras(carreras);
                objectResponse.response = resultado;
                return new JsonResult(objectResponse);
             
            
            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }


            return new JsonResult(objectResponse);

        }
          [HttpPost("Updatecarrera")]
        public IActionResult UpdateCarrera([FromBody] CarrerasModel  carreras)
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _CarreraService.Updatecarrera(carreras);
                objectResponse.response = resultado;
                return new JsonResult(objectResponse);
             
            
            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }


            return new JsonResult(objectResponse);

        }
          [HttpPost("DeleteCarrera")]
        public IActionResult DeleteCarrera([FromBody] CarrerasModel carreras)
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _CarreraService.DeleteCarrera(carreras.Id);
                objectResponse.response = resultado;
                return new JsonResult(objectResponse);
             
            
            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }


            return new JsonResult(objectResponse);

        }
    }
    

 
}