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
    public class PersonasController: ControllerBase
    {
        private readonly PersonaService _Personas;
        private readonly ILogger<PersonasController> _Logger;
        private readonly IJwtAuthenticationService _authService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        Encrypt enc = new Encrypt();

        public PersonasController(PersonaService personas)
        {
            _Personas = personas;

            
        }

        [HttpPost("InsertPersonas")]
        public IActionResult InsertPersonas([ FromBody ] PersonaModel persona)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";

                var memory = new MemoryStream();
                var resultado = _Personas.InsertPersonas(persona);
                objectResponse.response = resultado;

            }
            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }
            
             return new JsonResult(objectResponse);

        }

        [HttpGet("GetPersona")]
        public IActionResult GetPersona( [FromQuery ] int persona)
        {
            var objectResponse = Helper.GetStructResponse();

            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";

                var MemoryStream = new MemoryStream();
                var resultado = _Personas.GetPersona(persona);
                objectResponse.response = resultado;
            }
            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpPost("UpdatePersona")]
        public IActionResult UpdatePersona( [FromBody ] PersonaModel ppersona)
        {
            var objectResponse = Helper.GetStructResponse();

            try 
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";

                var MemoryStream = new MemoryStream();
                var resultado = _Personas.UpdatePersona(ppersona);
                objectResponse.response = resultado;
            }
            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpPost("DeletePersonas")]
        public IActionResult DeletePersonas( [FromBody ] PersonaModel Id)
        {
            var objectResponse = Helper.GetStructResponse();

            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";

                var MemoryStream = new MemoryStream();
                var resultado = _Personas.DeletePersonas(Id);
                objectResponse.response = resultado;
            }
            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }
    }
}