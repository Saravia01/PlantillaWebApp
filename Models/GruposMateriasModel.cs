using System;
namespace reportesApi.Models
{
    public class GruposMateriasModel
    {
        public int Id { get; set; }
        public int IdMateria { get; set; }
        public int IdGrupo { get; set; }
        public int Estatus {get; set;}
        public string Fecha_registra { get; set; }        
        public int UsuarioRegistra { get; set; }
   
    }
}