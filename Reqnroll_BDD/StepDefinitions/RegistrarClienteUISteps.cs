using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using System;
using System.Linq;
using System.Threading;
using Reqnroll_BDD.Contexts;

namespace Reqnroll_BDD.StepDefinitions
{
    [Binding]
    public class RegistrarClienteUISteps
    {
        private readonly UiTestContext _ui;
        private readonly string url = "http://localhost:5234/Cliente/Registrar";
        public RegistrarClienteUISteps(UiTestContext ui)
        {
            _ui = ui;
        }

        [Given("el usuario abre la pagina de registro de cliente")]
        public void GivenUsuarioAbreRegistroCliente()
        {
            _ui.Driver.Navigate().GoToUrl(url);
            Thread.Sleep(2000);
        }

        [When(@"ingresa ""(.*)"" en el campo Codigo Cliente")]
        public void WhenIngresaCodigoCliente(string codigo)
        {
            _ui.Driver.FindElement(By.Id("CodigoCliente")).SendKeys(codigo);
            Thread.Sleep(2000);
        }

        [When(@"ingresa ""(.*)"" en el campo Nombre")]
        public void WhenIngresaNombre(string nombre)
        {
            _ui.Driver.FindElement(By.Id("Nombre")).SendKeys(nombre);
            Thread.Sleep(2000);
        }

        [When(@"selecciona ""(.*)"" en el campo Tipo Documento")]
        public void WhenSeleccionaTipoDocumento(string tipo)
        {
            var tipoSelect = new SelectElement(_ui.Driver.FindElement(By.Id("TipoDocumento")));
            tipoSelect.SelectByText(tipo);
            Thread.Sleep(2000);
        }

        [When(@"ingresa ""(.*)"" en el campo Numero de Documento")]
        public void WhenIngresaNroDocumento(string nro)
        {
            _ui.Driver.FindElement(By.Id("NroDocumento")).SendKeys(nro);
            Thread.Sleep(2000);
        }

        [When(@"ingresa un email invalido ""(.*)"" en el campo Email")]
        public void WhenIngresaEmailInvalido(string email)
        {
            _ui.Driver.FindElement(By.Id("Email")).SendKeys(email);
            Thread.Sleep(2000);
        }

        [When(@"selecciona ""(.*)"" en el campo Grupo Cliente")]
        public void WhenSeleccionaGrupoCliente(string grupo)
        {
            var grupoSelect = new SelectElement(_ui.Driver.FindElement(By.Id("GrupoClienteId")));
            grupoSelect.SelectByText(grupo);
            Thread.Sleep(2000);
        }

        [When("hace clic en el boton de registrar")]
        public void WhenClicEnBotonRegistrar()
        {
            var boton = _ui.Driver.FindElement(By.CssSelector("button[type='submit']"));
            ((IJavaScriptExecutor)_ui.Driver).ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'center'});", boton);

            var wait = new WebDriverWait(_ui.Driver, TimeSpan.FromSeconds(5));
            wait.Until(driver =>
            {
                var elem = driver.FindElement(By.CssSelector("button[type='submit']"));
                return elem.Displayed && elem.Enabled;
            });

            Thread.Sleep(1000);
            boton.Click();
            Thread.Sleep(2000);
        }


        [When(@"corrige el campo Email con ""(.*)""")]
        public void WhenCorrigeEmail(string correoValido)
        {
            var emailInput = _ui.Driver.FindElement(By.Id("Email"));
            emailInput.Clear();
            _ui.Driver.FindElement(By.Id("Email")).SendKeys(correoValido);
            Thread.Sleep(2000);
        }

        [When("hace clic en el boton de registrar otra vez")]
        public void WhenClicEnBotonRegistrarOtraVez()
        {
            var boton = _ui.Driver.FindElement(By.CssSelector("button[type='submit']"));
            ((IJavaScriptExecutor)_ui.Driver).ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'center'});", boton);

            var wait = new WebDriverWait(_ui.Driver, TimeSpan.FromSeconds(5));
            wait.Until(driver =>
            {
                var elem = driver.FindElement(By.CssSelector("button[type='submit']"));
                return elem.Displayed && elem.Enabled;
            });

            Thread.Sleep(1000);
            boton.Click();
            Thread.Sleep(2000); 
        }

        [Then("debe mostrarse un mensaje de exito")]
        public void ThenDebeMostrarMensajeExito()
        {
            var alerta = _ui.Driver.FindElement(By.ClassName("alert-success"));
            Assert.IsTrue(alerta.Text.Contains("exito") || alerta.Text.Contains("registrado"), "No se encontró mensaje de éxito");
            Thread.Sleep(2000);
        }
    }
}
