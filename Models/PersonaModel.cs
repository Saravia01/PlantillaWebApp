using System;
namespace reportesApi.Models
{
    public class PersonaModel
    {
        public int Id {get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Direccion { get; set; }
        public int Estatus { get; set; }
    }
}