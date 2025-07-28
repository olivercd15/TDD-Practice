using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Reqnroll_BDD.Contexts
{
    public class UiTestContext : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        public UiTestContext()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized"); // Abre ventana completa
            // options.AddArgument("--headless"); // Si quieres ejecutar sin ventana visible

            Driver = new ChromeDriver(options);
        }

        public void Dispose()
        {
            Driver?.Quit();
            Driver?.Dispose();
        }
    }
}
