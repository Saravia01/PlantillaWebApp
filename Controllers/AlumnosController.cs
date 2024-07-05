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

namespace reportesApi.Controllers
{
 [Route("api")]
    public class AlumnosController:ControllerBase
    {
        private readonly AlumnosService _AlumnosService;
        private readonly ILogger<AlumnosController> _logger;
  
        private readonly IJwtAuthenticationService _authService;


        public AlumnosController(ILogger<AlumnosController> logger, IJwtAuthenticationService authService, AlumnosService AlumnosService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _authService = authService;
        

               _AlumnosService = AlumnosService;
        }

     
         [HttpGet("GetAlumnos")]
        public IActionResult GetAlumnos()
        {


            var objectResponse = Helper.GetStructResponse();
            var resultado = _AlumnosService.GetAlumnos();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                
                objectResponse.response = resultado;
          
                return new JsonResult(resultado);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }


            return new JsonResult(resultado);

        }

         [HttpPost("InsertAlumnos")]
        public IActionResult InsertAlumnos([FromBody] AlumnosModel alumnos)
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _AlumnosService.InsertAlumnos(alumnos);
                objectResponse.response = resultado;
          
                return new JsonResult(objectResponse);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }


            return new JsonResult(objectResponse);

        }

        
         [HttpPut("UpdateAlumnos")]
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

        
         [HttpDelete("DeleteAlumnos")]
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
    }

  internal class HttpUpdateAttribute : Attribute
  {
    public HttpUpdateAttribute(string v)
    {
      V = v;
    }

    public string V { get; }
  }
}



