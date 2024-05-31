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
    public class CarreraController: ControllerBase
    {
        private readonly CarreraService _Carreras;
        private readonly ILogger<CarreraController> _Logger;
        private readonly IJwtAuthenticationService _authService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        Encrypt enc = new Encrypt();

        public CarreraController(CarreraService carreras)
        {
            _Carreras = carreras;

            
        }

        [HttpPost("InsertCarreras")]
        public IActionResult InsertCarreras([ FromBody ] CarreraModel carreras)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";

                var memory = new MemoryStream();
                var resultado = _Carreras.InsertCarreras(carreras);
                objectResponse.response = resultado;

            }
            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }
            
             return new JsonResult(objectResponse);

        }

        [HttpGet("GetCarrera")]
        public IActionResult GetCarrera( [FromQuery ] int carrera)
        {
            var objectResponse = Helper.GetStructResponse();

            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";

                var MemoryStream = new MemoryStream();
                var resultado = _Carreras.GetCarrera(carrera);
                objectResponse.response = resultado;
            }
            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpPost("UpdateCarrera")]
        public IActionResult UpdateCarrera( [FromBody ] CarreraModel pcarrera)
        {
            var objectResponse = Helper.GetStructResponse();

            try 
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";

                var MemoryStream = new MemoryStream();
                var resultado = _Carreras.UpdateCarrera(pcarrera);
                objectResponse.response = resultado;
            }
            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpPost("DeleteCarrera")]
        public IActionResult DeleteCarrera( [FromBody ] CarreraModel Id)
        {
            var objectResponse = Helper.GetStructResponse();

            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";

                var MemoryStream = new MemoryStream();
                var resultado = _Carreras.DeleteCarrera(Id);
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