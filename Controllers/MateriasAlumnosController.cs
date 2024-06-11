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
    public class MateriasAlumnosController:ControllerBase
    {
        private readonly MateriasAlumnosService _MateriasAlumnosService;
        private readonly ILogger<MateriasAlumnosController> _logger;
  
        private readonly IJwtAuthenticationService _authService;


        public MateriasAlumnosController(ILogger<MateriasAlumnosController> logger, IJwtAuthenticationService authService, MateriasAlumnosService MateriasAlumnosService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _authService = authService;
        

               _MateriasAlumnosService = MateriasAlumnosService;
        }

     
         [HttpGet("GetMateriasAlum")]
        public IActionResult GetMateriasAlum()
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _MateriasAlumnosService.GetMateriasAlum();
                objectResponse.response = resultado;
          
                return new JsonResult(objectResponse);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }


            return new JsonResult(objectResponse);

        }

         [HttpPost("InsertMateriasAlum")]
        public IActionResult InsertMateriasAlum([FromBody] MateriasAlumnosModel materiasalum)
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _MateriasAlumnosService.InsertMateriasAlum(materiasalum);
                objectResponse.response = resultado;
          
                return new JsonResult(objectResponse);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }


            return new JsonResult(objectResponse);

        }

        
         [HttpPost("UpdateMateriasAlum")]
        public IActionResult UpdateGruposAlum([FromBody] MateriasAlumnosModel materiasalum)
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _MateriasAlumnosService.UpdateMateriasAlum(materiasalum);
                objectResponse.response = resultado;
          
                return new JsonResult(objectResponse);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }


            return new JsonResult(objectResponse);

        }

        
         [HttpPost("DeleteMateriasAlum")]
        public IActionResult DeleteGruposAlum([FromBody] MateriasAlumnosModel materiasalum)
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _MateriasAlumnosService.DeleteMateriasAlum(materiasalum.Id);
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



