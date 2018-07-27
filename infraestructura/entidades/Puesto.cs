using System.ComponentModel.DataAnnotations;

namespace infraestructura.entidades
{
    public class Puesto
    {
        [Key]
        public int IdPuesto { get; set; }
        public string Descripcion { get; set; }
    }
}