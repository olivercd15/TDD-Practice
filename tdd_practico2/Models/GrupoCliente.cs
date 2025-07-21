using Microsoft.EntityFrameworkCore;

namespace ProyectoIdentity.Models
{
    public class GrupoCliente
    {
        public GrupoCliente()
        {
        }

        public GrupoCliente(int id, string nombre, decimal? porcentajeDescuento)
        {
            Id = id;
            Nombre = nombre;
            PorcentajeDescuento = porcentajeDescuento;
            Clientes = new List<Cliente>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        [Precision(10, 2)]
        public decimal? PorcentajeDescuento { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
    }
}
