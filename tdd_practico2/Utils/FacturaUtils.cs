namespace ProyectoIdentity.Utils
{
    public class FacturaUtils
    {
        /// <summary>
        /// Calcula el total de un ítem considerando precio, cantidad y descuentos (producto y cliente).
        /// </summary>
        /// <param name="precioUnitario">Precio de venta del producto (de la BD)</param>
        /// <param name="cantidad">Cantidad vendida (del formulario)</param>
        /// <param name="descuentoProducto">Descuento del grupo producto (%)</param>
        /// <param name="descuentoCliente">Descuento del grupo cliente (%)</param>
        /// <returns>Total final del ítem con ambos descuentos aplicados</returns>
        public static decimal CalcularTotalItem(decimal precioUnitario, int cantidad, decimal descuentoProducto, decimal descuentoCliente)
        {
            var subtotal = precioUnitario * cantidad;
            var descuentoTotalPorcentaje = descuentoProducto + descuentoCliente;
            var descuentoTotal = subtotal * (descuentoTotalPorcentaje / 100m);
            var total = subtotal - descuentoTotal;
            return Math.Round(total, 2); // Redondea a 2 decimales, si quieres
        }
    }
}
