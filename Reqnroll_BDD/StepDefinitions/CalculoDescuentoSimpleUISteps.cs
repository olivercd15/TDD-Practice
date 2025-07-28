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

        [Given(@"el usuario abre la pagina de registro de factura")]
        public void GivenElUsuarioAbrePagina()
        {
            _ui.Driver.Navigate().GoToUrl("http://localhost:5234/Factura/Registrar");
        }

        [When(@"selecciona el cliente ""(.*)""")]
        public void WhenSeleccionaCliente(string cliente)
        {
            var selectCliente = _ui.Driver.FindElement(By.Name("ClienteId"));
            new SelectElement(selectCliente).SelectByText(cliente);
            Thread.Sleep(2000);
        }

        [When(@"selecciona el producto ""(.*)""")]
        public void WhenSeleccionaProducto(string producto)
        {
            var selectProducto = _ui.Driver.FindElement(By.CssSelector(".producto-select"));
            new SelectElement(selectProducto).SelectByText(producto);
            Thread.Sleep(2000);
        }

        [When(@"el usuario ingresa cantidad (.*)")]
        public void WhenUsuarioIngresaCantidad(int cantidad)
        {
            var inputCantidad = _ui.Driver.FindElement(By.CssSelector(".cantidad-input"));
            inputCantidad.Clear();
            inputCantidad.SendKeys(cantidad.ToString());
            Thread.Sleep(2000);
        }

        [Then(@"el precio unitario UI debe ser (.*)")]
        public void ThenPrecioUnitario(int esperado)
        {
            var precio = _ui.Driver.FindElement(By.CssSelector(".precio-unitario-input")).GetAttribute("value");
            Assert.AreEqual(esperado, int.Parse(precio));
            Thread.Sleep(2000);
        }

        [Then(@"el total del producto UI debe ser (.*)")]
        public void ThenTotalDelProducto(decimal esperado)
        {
            var total = _ui.Driver.FindElement(By.CssSelector(".total-input")).GetAttribute("value");
            Assert.AreEqual(esperado, Decimal.Parse(total));
            Thread.Sleep(2000);
        }

        [Then(@"el total de la factura UI debe ser (.*)")]
        public void ThenTotalFactura(decimal esperado)
        {
            var total = _ui.Driver.FindElement(By.Id("totalFactura")).GetAttribute("value");
            Assert.AreEqual(esperado, Decimal.Parse(total));
            Thread.Sleep(2000);
        }
    }
}
