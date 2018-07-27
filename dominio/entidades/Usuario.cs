namespace dominio.entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Foto { get; set; }
        public int IdPuesto { get; set; }
        public Puesto Puesto { get; set; }
    }
}