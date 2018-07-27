namespace dominio
{
    public class RespuestaApi<T>
    {
        public bool Exito { get; set; }
        public T Valor { get; set; }
        public string Mensaje { get; set; }
    }
}