namespace ProyectoIdentity.Models
{
    public class Almacen
    {
        public Almacen()
        {
        }

        public Almacen(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
            Productos = new List<Producto>();
        }


        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<Producto> Productos { get; set; }

    }
}
