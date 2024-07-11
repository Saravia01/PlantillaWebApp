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
    public class GruposMateriasController:ControllerBase
    {
        private readonly GruposMateriasService _GruposMateriasService;
        private readonly ILogger<GruposMateriasController> _logger;
  
        private readonly IJwtAuthenticationService _authService;


        public GruposMateriasController(ILogger<GruposMateriasController> logger, IJwtAuthenticationService authService, GruposMateriasService GruposMateriasService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _authService = authService;
        

               _GruposMateriasService = GruposMateriasService;
        }

     
         [HttpGet("GetGruposMaterias")]
        public IActionResult GetGruposMaterias()
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _GruposMateriasService.GetGruposMaterias();
                objectResponse.response = resultado;
          
                return new JsonResult(objectResponse);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }


            return new JsonResult(objectResponse);

        }

         [HttpPost("InsertGruposMaterias")]
        public IActionResult InsertGruposMaterias([FromBody] GruposMateriasService gm)
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _GruposMateriasService.InsertGruposMaterias(gm);
                objectResponse.response = resultado;
          
                return new JsonResult(objectResponse);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }


            return new JsonResult(objectResponse);

        }

        
         [HttpPut("UpdateGruposMaterias")]
        public IActionResult Update([FromBody] GruposMateriasModel gm)
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _GruposMateriasService.UpdateGruposMaterias(gm);
                objectResponse.response = resultado;
          
                return new JsonResult(objectResponse);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }


            return new JsonResult(objectResponse);

        }

        
         [HttpDelete("DeleteGruposMaterias")]
        public IActionResult DeleteCalificaciones([FromBody] GruposMateriasModel gm)
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _GruposMateriasService.DeleteGruposMaterias(gm.Id);
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



