using System;
namespace reportesApi.Models
{
    public class GrupoMateriaModel
    {
        public int Id { get; set; }
        public int IdGrupo { get; set; }
        public int IdMateria{ get; set; }
        public int Estatus { get; set; }
        public string Fecha { get; set; }
        public int Usuario { get; set; }
       
    }
}