using System;
using System.Net.Http;
using reportesApi.Models;
using reportesApi.Services;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using reportesApi.Helpers;
using System.Net;
using System.IO;
<<<<<<< HEAD:Controllers/AlumnosController.cs

namespace reportesApi.Controllers
{
 [Route("api")]
    public class AlumnosController:ControllerBase
    {
        private readonly AlumnosService _AlumnosService;
        private readonly ILogger<AlumnosController> _logger;
=======
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Microsoft.AspNetCore.Hosting;
using reportesApi.Models.Compras;

namespace reportesApi.Controllers
{
   
    [Route("api")]
    public class AlumnoController: ControllerBase
    {
   
        private readonly AlumnoService _AlumnoService;
        private readonly ILogger<AlumnoController> _logger;
>>>>>>> a6188d3f56bd959348c00796715e211e00072b5c:Controllers/AlumnoController.cs
  
        private readonly IJwtAuthenticationService _authService;


        public AlumnosController(ILogger<AlumnosController> logger, IJwtAuthenticationService authService, AlumnosService AlumnosService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _authService = authService;
        

<<<<<<< HEAD:Controllers/AlumnosController.cs
               _AlumnosService = AlumnosService;
        }

     
         [HttpGet("GetAlumnos")]
=======
        Encrypt enc = new Encrypt();

        public AlumnoController(AlumnoService AlumnoService, ILogger<AlumnoController> logger, IJwtAuthenticationService authService) {
            _AlumnoService = AlumnoService;
            _logger = logger;
       
            _authService = authService;
            // Configura la ruta base donde se almacenan los archivos.
            // Asegúrate de ajustar la ruta según tu estructura de directorios.

            
            
        }


        [HttpPost("InsertAlumno")]
        public IActionResult InsertAlumnos([FromBody] InsertAlumnoModel req )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = _AlumnoService.InsertAlumno(req);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpGet("GetAlumnos")]
>>>>>>> a6188d3f56bd959348c00796715e211e00072b5c:Controllers/AlumnoController.cs
        public IActionResult GetAlumnos()
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                // Llamando a la función y recibiendo los dos valores.
<<<<<<< HEAD:Controllers/AlumnosController.cs
                var resultado = _AlumnosService.GetAlumnos();
                objectResponse.response = resultado;
          
                return new JsonResult(objectResponse);

=======
                
                 var resultado = _AlumnoService.GetAlumnos();
                 objectResponse.response = resultado;
>>>>>>> a6188d3f56bd959348c00796715e211e00072b5c:Controllers/AlumnoController.cs
            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpPut("UpdateAlumno")]
        public IActionResult UpdateAlumnos([FromBody] UpdateAlumnoModel req )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = _AlumnoService.UpdateAlumno(req);

                ;

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpDelete("DeleteAlumno")]
        public IActionResult DeleteAlumno([FromBody] int id )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";

                _AlumnoService.DeleteAlumno(id);

<<<<<<< HEAD:Controllers/AlumnosController.cs
                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _AlumnosService.InsertAlumnos(alumnos);
                objectResponse.response = resultado;
          
                return new JsonResult(objectResponse);

=======
>>>>>>> a6188d3f56bd959348c00796715e211e00072b5c:Controllers/AlumnoController.cs
            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }
<<<<<<< HEAD:Controllers/AlumnosController.cs

        
         [HttpPost("UpdateAlumnos")]
        public IActionResult UpdateAlumnos([FromBody] AlumnosModel alumnos)
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _AlumnosService.UpdateAlumnos(alumnos);
                objectResponse.response = resultado;
          
                return new JsonResult(objectResponse);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }


            return new JsonResult(objectResponse);

        }

        
         [HttpPost("DeleteAlumnos")]
        public IActionResult DeleteAlumnos([FromBody] AlumnosModel alumnos)
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _AlumnosService.DeleteAlumnos(alumnos.Id);
                objectResponse.response = resultado;
          
                return new JsonResult(objectResponse);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }


            return new JsonResult(objectResponse);

        }
=======
>>>>>>> a6188d3f56bd959348c00796715e211e00072b5c:Controllers/AlumnoController.cs
    }
}