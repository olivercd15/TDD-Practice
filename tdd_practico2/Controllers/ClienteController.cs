using Microsoft.AspNetCore.Mvc;
using ProyectoIdentity.Models;
using ProyectoIdentity.Negocio;

namespace ProyectoIdentity.Controllers
{
    public class ClienteController : Controller
    {
       private readonly ClienteService _clienteService;
        public ClienteController(ClienteService clienteService)
        {
               _clienteService = clienteService;
        }
        [HttpGet]
        public IActionResult Registrar()
        {
            var model = new ClienteViewModel
            {
                GrupoClientes = _clienteService.ObtenerGrupoClientes()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Registrar(ClienteViewModel model)
        {
            ModelState.Remove("GrupoClientes");
            if (!ModelState.IsValid)
            {
                model.GrupoClientes = _clienteService.ObtenerGrupoClientes();
                return View(model);
            }
            _clienteService.RegistrarCliente(model);
            TempData["MensajeExito"] = "Cliente registrado correctamente.";
            return RedirectToAction("Registrar");
        }
    }
}
