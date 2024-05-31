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
    public class MateriasController: ControllerBase
    {
        private readonly MateriasService _Materias;
        private readonly ILogger<MateriasController> _Logger;
        private readonly IJwtAuthenticationService _authService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        Encrypt enc = new Encrypt();

        public MateriasController(MateriasService materia)
        {
            _Materias = materia;

            
        }

        [HttpPost("InsertMaterias")]
        public IActionResult InsertMaterias([ FromBody ] MateriasModel materias)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";

                var memory = new MemoryStream();
                var resultado = _Materias.InsertMaterias(materias);
                objectResponse.response = resultado;

            }
            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }
            
             return new JsonResult(objectResponse);

        }

        [HttpGet("GetMaterias")]
        public IActionResult GetMaterias( [FromQuery ] int materia)
        {
            var objectResponse = Helper.GetStructResponse();

            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";

                var MemoryStream = new MemoryStream();
                var resultado = _Materias.GetMaterias(materia);
                objectResponse.response = resultado;
            }
            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpPost("UpdateMaterias")]
        public IActionResult UpdateMaterias( [FromBody ] MateriasModel pmaterias)
        {
            var objectResponse = Helper.GetStructResponse();

            try 
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";

                var MemoryStream = new MemoryStream();
                var resultado = _Materias.UpdateMaterias(pmaterias);
                objectResponse.response = resultado;
            }
            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpPost("DeleteMaterias")]
        public IActionResult DeleteMaterias( [FromBody ] MateriasModel Id)
        {
            var objectResponse = Helper.GetStructResponse();

            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";

                var MemoryStream = new MemoryStream();
                var resultado = _Materias.DeleteMaterias(Id);
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