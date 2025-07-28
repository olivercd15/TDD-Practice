using ProyectoIdentity.Models;

namespace Testing
{
    [TestClass]
    public sealed class TestCalculoDescuentos
    {
        [TestMethod]
        public void Calcular_Descuento_Cliente_Producto_Simple()
        {
            // Arrange
            var grupoCliente = new GrupoCliente(1, "Especialista", 8);
            var cliente = new Cliente(1, "C001", "Juan Pérez", grupoCliente.Id, grupoCliente, TipoDocumento.CI);

            var almacen = new Almacen(1, "ALM001");

            var grupoProducto = new GrupoProducto(1, "Herramientas", 3);
            var producto = new Producto(1, "P001", "Taladro BOSCH", grupoProducto.Id, grupoProducto, almacen.Id, almacen, 800, 990);

            var condicionPago = new CondicionPago(1, "Contado", 1);
            var metodoPago = new MetodoPago(1, "Tarjeta");

            var factura = new Factura(1, DateTime.Now, cliente.Id, cliente, condicionPago.Id, condicionPago, metodoPago.Id, metodoPago, 0, new List<FacturaItem>());

            // Act
            var porcentajeDescuentoTotal = (grupoCliente.PorcentajeDescuento ?? 0) + (grupoProducto.PorcentajeDescuento ?? 0); // 8 + 3 = 11%
            var precioUnitario = producto.PrecioVenta; // 990
            var descuentoAplicado = Math.Round((precioUnitario * porcentajeDescuentoTotal) / 100, 2);
            var item = new FacturaItem(1, factura.Id, factura, producto.Id, producto, 1, precioUnitario, 0, descuentoAplicado);

            factura.Items.Add(item);
            factura.TotalFactura = item.PrecioUnitario - item.DescuentoAplicado; 

            // Assert
            var itemFactura = factura.Items.First();
            Assert.AreEqual(11, porcentajeDescuentoTotal);
            Assert.AreEqual(990, precioUnitario);
            Assert.AreEqual(881.10m, factura.TotalFactura); 
        }



        [TestMethod]
        public void Calcular_Descuento_Cliente_De_3_Productos()
        {
            // Arrange
            var grupoCliente = new GrupoCliente(1, "Especialista", 8);
            var cliente = new Cliente(1, "C001", "Juan Pérez", grupoCliente.Id, grupoCliente, TipoDocumento.CI);
            var almacen = new Almacen(1, "ALM001");
            var grupoProducto = new GrupoProducto(1, "Herramientas", 3);
            var producto = new Producto(1, "P001", "Taladro BOSCH", grupoProducto.Id, grupoProducto, almacen.Id, almacen, 800, 990);
            var condicionPago = new CondicionPago(1, "Contado", 1);
            var metodoPago = new MetodoPago(1, "Tarjeta");

            var factura = new Factura(1, DateTime.Now, cliente.Id, cliente, condicionPago.Id, condicionPago, metodoPago.Id, metodoPago, 0, new List<FacturaItem>());

            // Act
            var porcentajeDescuentoTotal = (grupoCliente.PorcentajeDescuento ?? 0) + (grupoProducto.PorcentajeDescuento ?? 0); 
            var precioUnitario = producto.PrecioVenta;
            var cantidad = 3;
            var descuentoUnitario = Math.Round((precioUnitario * porcentajeDescuentoTotal) / 100, 2); 
            var descuentoAplicado = descuentoUnitario * cantidad; 

            var item = new FacturaItem(1, factura.Id, factura, producto.Id, producto, cantidad, precioUnitario, 0, descuentoAplicado);

            factura.Items.Add(item);
            factura.TotalFactura = (precioUnitario * cantidad) - descuentoAplicado; 


            // Assert
            var itemFactura = factura.Items.First();
            Assert.AreEqual(11, porcentajeDescuentoTotal);
            Assert.AreEqual(2970, precioUnitario * cantidad);
            Assert.AreEqual(2643.30m, factura.TotalFactura);
        }



        [TestMethod]
        public void Calcular_Descuento_Cliente_Con_Tres_Productos_Distintos()
        {
            // Arrange
            var grupoCliente = new GrupoCliente(1, "Especialista", 8);
            var cliente = new Cliente(1, "C001", "Juan Pérez", grupoCliente.Id, grupoCliente, TipoDocumento.CI);
            var almacen = new Almacen(1, "ALM001");

            var condicionPago = new CondicionPago(1, "Contado", 1);
            var metodoPago = new MetodoPago(1, "Tarjeta");

            var factura = new Factura(1, DateTime.Now, cliente.Id, cliente, condicionPago.Id, condicionPago, metodoPago.Id, metodoPago, 0, new List<FacturaItem>());

            // Producto 1: Taladro BOSCH
            var grupoProducto1 = new GrupoProducto(1, "Herramientas", 3);
            var producto1 = new Producto(1, "P001", "Taladro BOSCH", grupoProducto1.Id, grupoProducto1, almacen.Id, almacen, 800, 990);
            var porcentajeDescuentoTotal1 = (grupoCliente.PorcentajeDescuento ?? 0) + (grupoProducto1.PorcentajeDescuento ?? 0); // 11%
            var descuentoUnitario1 = Math.Round(producto1.PrecioVenta * porcentajeDescuentoTotal1 / 100, 2); // 108.90
            var item1 = new FacturaItem(1, factura.Id, factura, producto1.Id, producto1, 1, producto1.PrecioVenta, 0, descuentoUnitario1);
            factura.Items.Add(item1);

            // Producto 2: Smartphone
            var grupoProducto2 = new GrupoProducto(2, "Tecnología", 5);
            var producto2 = new Producto(2, "P002", "Smartphone", grupoProducto2.Id, grupoProducto2, almacen.Id, almacen, 5000, 6000);
            var porcentajeDescuentoTotal2 = (grupoCliente.PorcentajeDescuento ?? 0) + (grupoProducto2.PorcentajeDescuento ?? 0); // 13%
            var descuentoUnitario2 = Math.Round(producto2.PrecioVenta * porcentajeDescuentoTotal2 / 100, 2); // 780.00
            var item2 = new FacturaItem(2, factura.Id, factura, producto2.Id, producto2, 1, producto2.PrecioVenta, 0, descuentoUnitario2);
            factura.Items.Add(item2);

            // Producto 3: Camisa de algodón
            var grupoProducto3 = new GrupoProducto(3, "Ropa", 10);
            var producto3 = new Producto(3, "P003", "Camisa de algodón", grupoProducto3.Id, grupoProducto3, almacen.Id, almacen, 200, 250);
            var porcentajeDescuentoTotal3 = (grupoCliente.PorcentajeDescuento ?? 0) + (grupoProducto3.PorcentajeDescuento ?? 0); // 18%
            var descuentoUnitario3 = Math.Round(producto3.PrecioVenta * porcentajeDescuentoTotal3 / 100, 2); // 45.00
            var item3 = new FacturaItem(3, factura.Id, factura, producto3.Id, producto3, 1, producto3.PrecioVenta, 0, descuentoUnitario3);
            factura.Items.Add(item3);

            // Total de la factura
            factura.TotalFactura = factura.Items.Sum(i => (i.PrecioUnitario * i.Cantidad) - i.DescuentoAplicado);

            // Assert
            Assert.AreEqual(108.90m, item1.DescuentoAplicado);
            Assert.AreEqual(780.00m, item2.DescuentoAplicado);
            Assert.AreEqual(45.00m, item3.DescuentoAplicado);

            Assert.AreEqual(881.10m, (item1.PrecioUnitario * item1.Cantidad) - item1.DescuentoAplicado);
            Assert.AreEqual(5220.00m, (item2.PrecioUnitario * item2.Cantidad) - item2.DescuentoAplicado);
            Assert.AreEqual(205.00m, (item3.PrecioUnitario * item3.Cantidad) - item3.DescuentoAplicado);

            Assert.AreEqual(6306.10m, factura.TotalFactura);
        }


        [TestMethod]
        public void Calcular_Descuento_Cliente_Con_Productos_Multiples_Cantidades()
        {
            // Arrange
            var grupoCliente = new GrupoCliente(1, "Especialista", 8);
            var cliente = new Cliente(1, "C001", "Juan Pérez", grupoCliente.Id, grupoCliente, TipoDocumento.CI);
            var almacen = new Almacen(1, "ALM001");

            var condicionPago = new CondicionPago(1, "Contado", 1);
            var metodoPago = new MetodoPago(1, "Tarjeta");

            var factura = new Factura(1, DateTime.Now, cliente.Id, cliente, condicionPago.Id, condicionPago, metodoPago.Id, metodoPago, 0, new List<FacturaItem>());

            // Producto 1: Taladro BOSCH (2 unidades)
            var grupoProducto1 = new GrupoProducto(1, "Herramientas", 3);
            var producto1 = new Producto(1, "P001", "Taladro BOSCH", grupoProducto1.Id, grupoProducto1, almacen.Id, almacen, 800, 990);
            var cantidad1 = 2;
            var porcentajeDescuentoTotal1 = (grupoCliente.PorcentajeDescuento ?? 0) + (grupoProducto1.PorcentajeDescuento ?? 0); // 11%
            var descuentoUnitario1 = Math.Round(producto1.PrecioVenta * porcentajeDescuentoTotal1 / 100, 2); // 108.90
            var descuentoAplicado1 = descuentoUnitario1 * cantidad1;
            var item1 = new FacturaItem(1, factura.Id, factura, producto1.Id, producto1, cantidad1, producto1.PrecioVenta, 0, descuentoAplicado1);
            factura.Items.Add(item1);

            // Producto 2: Smartphone (1 unidad)
            var grupoProducto2 = new GrupoProducto(2, "Tecnología", 5);
            var producto2 = new Producto(2, "P002", "Smartphone", grupoProducto2.Id, grupoProducto2, almacen.Id, almacen, 5000, 6000);
            var cantidad2 = 1;
            var porcentajeDescuentoTotal2 = (grupoCliente.PorcentajeDescuento ?? 0) + (grupoProducto2.PorcentajeDescuento ?? 0); // 13%
            var descuentoUnitario2 = Math.Round(producto2.PrecioVenta * porcentajeDescuentoTotal2 / 100, 2); // 780.00
            var descuentoAplicado2 = descuentoUnitario2 * cantidad2;
            var item2 = new FacturaItem(2, factura.Id, factura, producto2.Id, producto2, cantidad2, producto2.PrecioVenta, 0, descuentoAplicado2);
            factura.Items.Add(item2);

            // Producto 3: Camisa de algodón (3 unidades)
            var grupoProducto3 = new GrupoProducto(3, "Ropa", 10);
            var producto3 = new Producto(3, "P003", "Camisa de algodón", grupoProducto3.Id, grupoProducto3, almacen.Id, almacen, 200, 250);
            var cantidad3 = 3;
            var porcentajeDescuentoTotal3 = (grupoCliente.PorcentajeDescuento ?? 0) + (grupoProducto3.PorcentajeDescuento ?? 0); // 18%
            var descuentoUnitario3 = Math.Round(producto3.PrecioVenta * porcentajeDescuentoTotal3 / 100, 2); // 45.00
            var descuentoAplicado3 = descuentoUnitario3 * cantidad3;
            var item3 = new FacturaItem(3, factura.Id, factura, producto3.Id, producto3, cantidad3, producto3.PrecioVenta, 0, descuentoAplicado3);
            factura.Items.Add(item3);

            // Total de la factura
            factura.TotalFactura = factura.Items.Sum(i => (i.PrecioUnitario * i.Cantidad) - i.DescuentoAplicado);

            // Assert
            Assert.AreEqual(217.80m, descuentoAplicado1); // 108.90 * 2
            Assert.AreEqual(780.00m, descuentoAplicado2); // 780.00 * 1
            Assert.AreEqual(135.00m, descuentoAplicado3); // 45.00 * 3

            Assert.AreEqual(1762.20m, (producto1.PrecioVenta * cantidad1) - descuentoAplicado1);
            Assert.AreEqual(5220.00m, (producto2.PrecioVenta * cantidad2) - descuentoAplicado2);
            Assert.AreEqual(615.00m, (producto3.PrecioVenta * cantidad3) - descuentoAplicado3);

            Assert.AreEqual(7597.20m, factura.TotalFactura);
        }



    }
}
