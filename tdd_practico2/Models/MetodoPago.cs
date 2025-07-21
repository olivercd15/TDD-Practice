namespace ProyectoIdentity.Models
{
    public class MetodoPago
    {
        public MetodoPago()
        {
        }

        public MetodoPago(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
