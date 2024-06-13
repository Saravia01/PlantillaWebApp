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
<<<<<<< Updated upstream
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Microsoft.AspNetCore.Hosting;
using reportesApi.Models.Compras;

namespace reportesApi.Controllers
{
   
    [Route("api")]
    public class CarreraController: ControllerBase
    {
   
        private readonly CarreraService _carreraService;
=======

namespace reportesApi.Controllers
{
 [Route("api")]
    public class CarreraController:ControllerBase
    {
        private readonly CarreraService _CarreraService;
>>>>>>> Stashed changes
        private readonly ILogger<CarreraController> _logger;
  
        private readonly IJwtAuthenticationService _authService;


        public CarreraController(ILogger<CarreraController> logger, IJwtAuthenticationService authService, CarreraService CarreraService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _authService = authService;
        

<<<<<<< Updated upstream
        Encrypt enc = new Encrypt();

        public CarreraController(CarreraService carreraService, ILogger<CarreraController> logger, IJwtAuthenticationService authService) {
            _carreraService = carreraService;
            _logger = logger;
       
            _authService = authService;
            // Configura la ruta base donde se almacenan los archivos.
            // Asegúrate de ajustar la ruta según tu estructura de directorios.

            
            
        }


        [HttpPost("InsertCarrera")]
        public IActionResult InsertCarreras([FromBody] InsertCarreraModel req )
=======
               _CarreraService = CarreraService;
        }

     
         [HttpGet("getcarreras")]
        public IActionResult getcarreras()
>>>>>>> Stashed changes
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = _carreraService.InsertCarrera(req);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpGet("GetCarreras")]
        public IActionResult GetCarreras()
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                // Llamando a la función y recibiendo los dos valores.
<<<<<<< Updated upstream
                
                 var resultado = _carreraService.GetCarreras();
                 objectResponse.response = resultado;
=======
                var resultado = _CarreraService.getcarreras();
                objectResponse.response = resultado;
          
                return new JsonResult(objectResponse);

>>>>>>> Stashed changes
            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpPut("UpdateCarrera")]
        public IActionResult UpdateCarreras([FromBody] UpdateCarreraModel req )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = _carreraService.UpdateCarrera(req);

                ;

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

<<<<<<< Updated upstream
        [HttpDelete("DeleteCarrera")]
        public IActionResult DeleteCarrera([FromBody] int id )
=======
         [HttpPost("Insertcarreras")]
        public IActionResult Insertcarreras([FromBody] CarrerasModel carreras)
>>>>>>> Stashed changes
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";

                _carreraService.DeleteCarrera(id);

<<<<<<< Updated upstream
=======
                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _CarreraService.Insertcarreras(carreras);
                objectResponse.response = resultado;
          
                return new JsonResult(objectResponse);

>>>>>>> Stashed changes
            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
<<<<<<< Updated upstream
=======

        }

        
         [HttpPost("Updatecarrera")]
        public IActionResult Updatecarrera([FromBody] CarrerasModel carreras)
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _CarreraService.Updatecarrera(carreras);
                objectResponse.response = resultado;
          
                return new JsonResult(objectResponse);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }


            return new JsonResult(objectResponse);

        }

        
         [HttpPost("Deletecarrera")]
        public IActionResult Deletecarrera([FromBody] CarrerasModel carreras)
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";


                var memory = new MemoryStream();
                // Llamando a la función y recibiendo los dos valores.
                var resultado = _CarreraService.Deletecarrera(carreras.Id);
                objectResponse.response = resultado;
          
                return new JsonResult(objectResponse);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }


            return new JsonResult(objectResponse);

>>>>>>> Stashed changes
        }
    }
}