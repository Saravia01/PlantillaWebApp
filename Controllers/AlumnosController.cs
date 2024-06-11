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
   
    [Route("Api")]
    public class AlumnosController: ControllerBase
    {
   
        private readonly AlumnosService _AlumnosService;
        private readonly ILogger<PersonasController> _logger;
        private readonly IJwtAuthenticationService _authService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        

        Encrypt enc = new Encrypt();

        public AlumnosController(AlumnosService AlumnosService, ILogger<AlumnosController> logger, IJwtAuthenticationService authService) {
            _AlumnosService = AlumnosService;
            _logger = logger;
            _authService = authService;
            
        }
        [HttpGet("GetAlumnos")]
        public IActionResult GetAlumnos( )
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _AlumnosService.GetAlumnos();
                objectResponse.response = resultado;
                return new JsonResult(objectResponse);
             
            
            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }


            return new JsonResult(objectResponse);

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

         [HttpPost("UpdateAlumnos")]
        public IActionResult UpdateAlumnos([FromBody] AlumnosModel alumnos )
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

         [HttpGet("DeleteAlumnos")]
        public IActionResult DeleteAlumnos([FromBody] AlumnosModel alumnos )
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
    

 
}