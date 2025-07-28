using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Reqnroll_BDD.Contexts;

namespace Reqnroll_BDD.StepDefinitions
{
    [Binding]
    public class CalculoDescuentoSimpleUISteps
    {
        private readonly UiTestContext _ui;

        public CalculoDescuentoSimpleUISteps(UiTestContext ui)
        {
            _ui = ui;
        }

        [Given(@"el usuario abre la página de registro de factura")]
        public void GivenElUsuarioAbrePagina()
        {
            _ui.Driver.Navigate().GoToUrl("https://localhost:5001/factura/crear");
        }

        [When(@"selecciona el cliente ""(.*)""")]
        public void WhenSeleccionaCliente(string nombre)
        {
            var clienteSelect = _ui.Driver.FindElement(By.Id("cliente"));
            new SelectElement(clienteSelect).SelectByText(nombre);
        }

        [When(@"selecciona el producto ""(.*)""")]
        public void WhenSeleccionaProducto(string nombre)
        {
            var productoSelect = _ui.Driver.FindElement(By.Id("producto"));
            new SelectElement(productoSelect).SelectByText(nombre);
        }

        [When(@"el sistema muestra el precio venta de ""(.*)""")]
        public void WhenElSistemaMuestraPrecio(string precio)
        {
            var precioInput = _ui.Driver.FindElement(By.Id("precioVenta"));
            Assert.AreEqual(precio, precioInput.GetAttribute("value"));
        }

        [When(@"el grupo cliente tiene un descuento de (.*)")]
        public void WhenGrupoClienteDescuento(int descuento)
        {
            var descuentoInput = _ui.Driver.FindElement(By.Id("descuentoCliente"));
            Assert.AreEqual(descuento.ToString(), descuentoInput.GetAttribute("value"));
        }

        [When(@"el grupo producto tiene un descuento de (.*)")]
        public void WhenGrupoProductoDescuento(int descuento)
        {
            var descuentoInput = _ui.Driver.FindElement(By.Id("descuentoProducto"));
            Assert.AreEqual(descuento.ToString(), descuentoInput.GetAttribute("value"));
        }

        [When(@"el usuario ingresa cantidad (.*)")]
        public void WhenUsuarioIngresaCantidad(int cantidad)
        {
            var cantidadInput = _ui.Driver.FindElement(By.Id("cantidad"));
            cantidadInput.Clear();
            cantidadInput.SendKeys(cantidad.ToString());
        }

        [When(@"hace clic en el botón ""(.*)""")]
        public void WhenHaceClickEnBoton(string nombreBoton)
        {
            _ui.Driver.FindElement(By.XPath($"//button[text()='{nombreBoton}']")).Click();
        }

        [Then(@"el sistema debe mostrar un total de ""(.*)""")]
        public void ThenDebeMostrarTotal(string esperado)
        {
            var total = _ui.Driver.FindElement(By.Id("totalFactura")).Text;
            Assert.AreEqual(esperado, total);
        }
    }
}
