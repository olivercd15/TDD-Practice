using Microsoft.EntityFrameworkCore;

namespace ProyectoIdentity.Models
{
    public class GrupoProducto
    {
        public GrupoProducto()
        {
        }

        public GrupoProducto(int id, string nombre, decimal? porcentajeDescuento)
        {
            Id = id;
            Nombre = nombre;
            PorcentajeDescuento = porcentajeDescuento;
            Productos = new List<Producto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        [Precision(10, 2)]
        public decimal? PorcentajeDescuento { get; set; }
        public ICollection<Producto> Productos { get; set; }
    }
}
