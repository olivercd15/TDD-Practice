using Microsoft.EntityFrameworkCore;

namespace ProyectoIdentity.Models
{
    public class FacturaItem
    {
        public FacturaItem()
        {
        }

        // Constructor parametrizado
        public FacturaItem(int id, int facturaId, Factura factura,
                           int productoId, Producto producto,
                           int cantidad, decimal precioUnitario,
                           decimal otroDescuento, decimal descuentoAplicado)
        {
            Id = id;
            FacturaId = facturaId;
            Factura = factura;
            ProductoId = productoId;
            Producto = producto;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
            OtroDescuento = otroDescuento;
            DescuentoAplicado = descuentoAplicado;
        }

        public int Id { get; set; }
        public int FacturaId { get; set; }
        public Factura Factura { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        public int Cantidad { get; set; }
        [Precision(10,2)]
        public decimal PrecioUnitario { get; set; }
        [Precision(10, 2)]
        public decimal OtroDescuento { get; set; }
        [Precision(10, 2)]
        public decimal DescuentoAplicado { get; set; } 
    }
}
