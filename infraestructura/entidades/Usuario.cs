using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace infraestructura.entidades
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Foto { get; set; }

        [ForeignKey("Puesto")]
        public int IdPuesto { get; set; }
        public virtual Puesto Puesto { get; set; }
    }
}