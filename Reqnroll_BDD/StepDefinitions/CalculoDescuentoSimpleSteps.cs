using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoIdentity.Models;
using Reqnroll_BDD.Contexts;

namespace Reqnroll_BDD.StepDefinitions
{
    [Binding]
    public class CalculoDescuentoSimpleSteps
    {
        private readonly CalculoDescuentoSimpleContext _context;

        public CalculoDescuentoSimpleSteps(CalculoDescuentoSimpleContext context)
        {
            _context = context;
        }

        [Given(@"un grupo de cliente ""(.*)"" con porcentaje (.*)")]
        public void GivenUnGrupoDeClienteConPorcentaje(string nombre, int porcentaje)
        {
            _context.GrupoCliente = new GrupoCliente(1, nombre, porcentaje);
        }

        [Given(@"un grupo de producto ""(.*)"" con porcentaje (.*)")]
        public void GivenUnGrupoDeProductoConPorcentaje(string nombre, int porcentaje)
        {
            _context.GrupoProducto = new GrupoProducto(1, nombre, porcentaje);
        }

        [Given(@"un cliente ""(.*)"" del grupo de cliente ""(.*)""")]
        public void GivenUnClienteDelGrupoDeCliente(string nombreCliente, string nombreGrupoCliente)
        {
            Assert.IsNotNull(_context.GrupoCliente, "Primero define el grupo de cliente.");
            _context.Cliente = new Cliente(1, "C001", nombreCliente, _context.GrupoCliente.Id, _context.GrupoCliente, TipoDocumento.CI);
        }

        [Given(@"un almacen ""(.*)""")]
        public void GivenUnAlmacen(string codigo)
        {
            _context.Almacen = new Almacen(1, codigo);
        }

        [Given(@"un producto ""(.*)"" con codigo ""(.*)"" del grupo ""(.*)"" con precio venta (.*) y precio costo (.*) en el almacen ""(.*)""")]
        public void GivenUnProducto(string nombre, string codigo, string nombreGrupoProducto, decimal precioVenta, decimal precioCosto, string codAlmacen)
        {
            Assert.IsNotNull(_context.GrupoProducto, "Primero define el grupo de producto.");
            Assert.IsNotNull(_context.Almacen, "Primero define el almacen.");

            _context.Producto = new Producto(
                1, codigo, nombre,
                _context.GrupoProducto.Id, _context.GrupoProducto,
                _context.Almacen.Id, _context.Almacen,
                precioCosto, precioVenta
            );
        }

        [Given(@"una condicion de pago ""(.*)"" con dias (.*)")]
        public void GivenUnaCondicionDePago(string nombre, int dias)
        {
            _context.CondicionPago = new CondicionPago(1, nombre, dias);
        }

        [Given(@"un metodo de pago ""(.*)""")]
        public void GivenUnMetodoDePago(string nombre)
        {
            _context.MetodoPago = new MetodoPago(1, nombre);
        }

        [When(@"creo una factura con cantidad (.*) del producto ""(.*)""")]
        public void WhenCreoUnaFacturaConCantidadDelProducto(int cantidad, string codigoProducto)
        {
            Assert.AreEqual(_context.Producto.CodigoSKU, codigoProducto);

            _context.Factura = new Factura(
                1, DateTime.Now,
                _context.Cliente.Id, _context.Cliente,
                _context.CondicionPago.Id, _context.CondicionPago,
                _context.MetodoPago.Id, _context.MetodoPago,
                0, new List<FacturaItem>()
            );

            var porcentajeCliente = _context.GrupoCliente.PorcentajeDescuento ?? 0;
            var porcentajeProducto = _context.GrupoProducto.PorcentajeDescuento ?? 0;
            _context.PorcentajeDescuentoTotal = porcentajeCliente + porcentajeProducto;

            var precioUnitario = _context.Producto.PrecioVenta;
            var descuentoAplicado = Math.Round((precioUnitario * _context.PorcentajeDescuentoTotal) / 100, 2);
            var item = new FacturaItem(
                1, _context.Factura.Id, _context.Factura,
                _context.Producto.Id, _context.Producto,
                cantidad, precioUnitario, 0, descuentoAplicado
            );

            _context.Factura.Items.Add(item);
            _context.Factura.TotalFactura = (item.PrecioUnitario * cantidad) - (item.DescuentoAplicado * cantidad);
        }

        [Then(@"el porcentaje de descuento total debe ser (.*)")]
        public void ThenElPorcentajeDeDescuentoTotalDebeSer(int esperado)
        {
            Assert.AreEqual(esperado, _context.PorcentajeDescuentoTotal);
        }

        [Then(@"el precio unitario debe ser (.*)")]
        public void ThenElPrecioUnitarioDebeSer(decimal esperado)
        {
            var item = _context.Factura.Items.First();
            Assert.AreEqual(esperado, item.PrecioUnitario);
        }

        [Then(@"el total de la factura debe ser (.*)")]
        public void ThenElTotalDeLaFacturaDebeSer(decimal esperado)
        {
            Assert.AreEqual(esperado, _context.Factura.TotalFactura);
        }
    }
}
