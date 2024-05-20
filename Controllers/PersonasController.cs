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
   
    [Route("Personas")]
    public class PersonasController: ControllerBase
    {
   
        private readonly PersonasService _PersonasService;
        private readonly ILogger<PersonasController> _logger;
        private readonly IJwtAuthenticationService _authService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        

        Encrypt enc = new Encrypt();

        public PersonasController(PersonasService PersonasService, ILogger<PersonasController> logger, IJwtAuthenticationService authService) {
            _PersonasService = PersonasService;
            _logger = logger;
            _authService = authService;
            
        }
        [HttpGet("GetPersonas")]
        public IActionResult GetPersonas()
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _PersonasService.GetPersonas();
                objectResponse.response = resultado;
                return new JsonResult(objectResponse);
             
            
            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }


            return new JsonResult(objectResponse);

        }
        
         [HttpPost("InsertPersonas")]
        public IActionResult InsertPersonas([FromBody] PersonasModel persona)
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _PersonasService.InsertPersonas(persona);
                objectResponse.response = resultado;
                return new JsonResult(objectResponse);
             
            
            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }


            return new JsonResult(objectResponse);

        }
          [HttpPost("UpdatePersonas")]
        public IActionResult UpdatePersonas([FromBody] PersonasModel persona)
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _PersonasService.UpdatePersonas(persona);
                objectResponse.response = resultado;
                return new JsonResult(objectResponse);
             
            
            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }


            return new JsonResult(objectResponse);

        }
          [HttpPost("DeletePersonas")]
        public IActionResult DeletePersonas([FromBody] PersonasModel persona)
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _PersonasService.DeletePersonas(persona);
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