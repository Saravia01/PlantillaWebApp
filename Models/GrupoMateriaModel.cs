using System;
namespace reportesApi.Models
{
    public class GetGrupoMateriaModel
    {
        public int Id { get; set; }
        public int IdGrupo { get; set; }
        public int IdMateria{ get; set; }
        public string Estatus { get; set; }
        public string Fecha { get; set; }
        public string Usuario { get; set; }
       
    }

    public class InsertGrupoMateriaModel
    {
        public int IdGrupo { get; set; }
        public int IdMateria{ get; set; }
        public string Estatus { get; set; }
        public string Fecha { get; set; }
        public string Usuario { get; set; }
    }

    public class UpdateGrupoMateriaModel
    {
        public int Id { get; set; }
        public int IdGrupo { get; set; }
        public int IdMateria{ get; set; }
        public string Estatus { get; set; }
        public string Fecha { get; set; }
        public string Usuario { get; set; }
       
    }

}