using System;
namespace reportesApi.Models
{
    public class CalificacionesModel
    {
        public int Id { get; set; }
        public int IdMateria { get; set; }
        public string Periodo { get; set; }
        public string Materia {get; set;}
        public string Parcial { get; set; }        
        public string Matricula { get; set; }
        public int Calificacion {get; set;}
    }
}