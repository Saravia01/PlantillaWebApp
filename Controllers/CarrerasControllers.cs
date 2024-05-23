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
    public class CarrerasControllers: ControllerBase
    {
   
        private readonly CarrerasService _CarrerasService;
        private readonly ILogger<CarrerasControllers> _logger;
        private readonly IJwtAuthenticationService _authService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        

        Encrypt enc = new Encrypt();

        public CarrerasControllers(CarrerasService CarrerasService, ILogger<CarrerasControllers> logger, IJwtAuthenticationService authService) {
           
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
             _CarrerasService = CarrerasService;
            _authService = authService;
            
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
        public IActionResult UpdateCarrerasABM([FromBody] CarrerasModel  carreras)
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
          [HttpPost("DeleteCarrerasABM")]
        public IActionResult DeleteCarrerasABM([FromBody] CarrerasModel carreras)
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _CarrerasService.DeleteCarrerasABM(carreras);
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