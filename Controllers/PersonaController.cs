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
    public class PersonaController:ControllerBase
    {
        private readonly PersonaService _PersonaService;
        private readonly ILogger<PersonaController> _logger;
  
        private readonly IJwtAuthenticationService _authService;


        public PersonaController(ILogger<PersonaController> logger, IJwtAuthenticationService authService, PersonaService PersonaService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _authService = authService;
        

               _PersonaService = PersonaService;
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
                var resultado = _PersonaService.GetPersonas();
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
        public IActionResult InsertPersonas([FromBody] PersonaModel persona)
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _PersonaService.InsertPersonas(persona);
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
        public IActionResult UpdatePersonas([FromBody] PersonaModel persona)
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _PersonaService.UpdatePersonas(persona);
                objectResponse.response = resultado;
          
                return new JsonResult(objectResponse);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }


            return new JsonResult(objectResponse);

        }

        
         [HttpPost("DelatePersona")]
        public IActionResult DelatePersona([FromBody] PersonaModel persona)
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _PersonaService.DelatePersona(persona);
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



