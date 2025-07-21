using Microsoft.EntityFrameworkCore;

namespace ProyectoIdentity.Models
{
    public class Factura
    {
        public Factura()
        {
            Items = new List<FacturaItem>();
        }

        // Constructor parametrizado
        public Factura(int id, DateTime fecha, int clienteId, Cliente cliente,
                       int condicionPagoId, CondicionPago condicionPago,
                       int metodoPagoId, MetodoPago metodoPago,
                       decimal totalFactura, ICollection<FacturaItem> items)
        {
            Id = id;
            Fecha = fecha;
            ClienteId = clienteId;
            Cliente = cliente;
            CondicionPagoId = condicionPagoId;
            CondicionPago = condicionPago;
            MetodoPagoId = metodoPagoId;
            MetodoPago = metodoPago;
            TotalFactura = totalFactura;
            Items = items ?? new List<FacturaItem>();
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int CondicionPagoId { get; set; }
        public CondicionPago CondicionPago { get; set; }

        public int MetodoPagoId { get; set; }
        public MetodoPago MetodoPago { get; set; }
        [Precision(10, 2)]
        public decimal TotalFactura { get; set; }

        public ICollection<FacturaItem> Items { get; set; }
    }
}
