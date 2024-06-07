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
    public class GruposAlumnosController:ControllerBase
    {
        private readonly GruposAlumnosService _GruposAlumnosService;
        private readonly ILogger<GruposAlumnosController> _logger;
  
        private readonly IJwtAuthenticationService _authService;


        public GruposAlumnosController(ILogger<GruposAlumnosController> logger, IJwtAuthenticationService authService, GruposAlumnosService GruposAlumnosService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _authService = authService;
        

               _GruposAlumnosService = GruposAlumnosService;
        }

     
         [HttpGet("GetGruposAlum")]
        public IActionResult GetGruposAlum()
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _GruposAlumnosService.GetGruposAlum();
                objectResponse.response = resultado;
          
                return new JsonResult(objectResponse);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }


            return new JsonResult(objectResponse);

        }

         [HttpPost("InsertGruposAlum")]
        public IActionResult InsertGruposAlum([FromBody] GruposAlumnosModel gruposalum)
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _GruposAlumnosService.InsertGruposAlum(gruposalum);
                objectResponse.response = resultado;
          
                return new JsonResult(objectResponse);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }


            return new JsonResult(objectResponse);

        }

        
         [HttpPost("UpdateGruposAlum")]
        public IActionResult UpdateGruposAlum([FromBody] GruposAlumnosModel gruposalum)
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _GruposAlumnosService.UpdateGruposAlum(gruposalum);
                objectResponse.response = resultado;
          
                return new JsonResult(objectResponse);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }


            return new JsonResult(objectResponse);

        }

        
         [HttpPost("DeleteGruposAlum")]
        public IActionResult DeleteGruposAlum([FromBody] GruposAlumnosModel gruposalum)
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _GruposAlumnosService.DeleteGruposAlum(gruposalum.Id);
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



