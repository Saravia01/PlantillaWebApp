using System;
namespace reportesApi.Models
{
    public class CarrerasModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public string Usuario { get; set; }        
        public int Estatus { get; set; }
    }
}