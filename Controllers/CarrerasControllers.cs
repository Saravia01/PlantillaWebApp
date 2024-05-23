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
    public class CarrerasController:ControllerBase
    {
        private readonly CarrerasService _CarrerasService;
        private readonly ILogger<CarrerasController> _logger;
  
        private readonly IJwtAuthenticationService _authService;


        public CarrerasController(ILogger<CarrerasController> logger, IJwtAuthenticationService authService, CarrerasService CarrerasService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _authService = authService;
        

               _CarrerasService = CarrerasService;
        }

     
         [HttpGet("GetCarrerasABM")]
        public IActionResult GetCarrerasABM()
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _CarrerasService.GetCarrerasABM();
                objectResponse.response = resultado;
          
                return new JsonResult(objectResponse);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }


            return new JsonResult(objectResponse);

        }

         [HttpPost("InsertCarrerasABM")]
        public IActionResult InsertCarrerasABM([FromBody] CarrerasModel carreras)
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _CarrerasService.InsertCarrerasABM(carreras);
                objectResponse.response = resultado;
          
                return new JsonResult(objectResponse);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }


            return new JsonResult(objectResponse);

        }

        
         [HttpPost("UpdateCarrerasABM")]
        public IActionResult UpdateCarrerasABM([FromBody] CarrerasModel carreras)
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _CarrerasService.UpdateCarrerasABM(carreras);
                objectResponse.response = resultado;
          
                return new JsonResult(objectResponse);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }


            return new JsonResult(objectResponse);

        }

        
         [HttpPost("DelateCarrerasABM")]
        public IActionResult DelateCarrerasABM([FromBody] CarrerasModel carreras)
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _CarrerasService.DelateCarrerasABM(carreras.Id);
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