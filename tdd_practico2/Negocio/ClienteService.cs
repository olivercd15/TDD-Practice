using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoIdentity.Datos;
using ProyectoIdentity.Models;

namespace ProyectoIdentity.Negocio
{
    public class ClienteService
    {
        private readonly ApplicationDbContext _context;

        public ClienteService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void RegistrarCliente(ClienteViewModel model)
        {
            var cliente = new Cliente
            {
                CodigoCliente = model.CodigoCliente,
                Nombre = model.Nombre,
                TipoDocumento = model.TipoDocumento,
                NroDocumento = model.NroDocumento,
                Email = model.Email,
                GrupoClienteId = model.GrupoClienteId
            };

            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }
        public IEnumerable<SelectListItem> ObtenerGrupoClientes()
        {
            return _context.GrupoClientes
                .Select(gc => new SelectListItem
                {
                    Value = gc.Id.ToString(),
                    Text = gc.Nombre
                })
                .ToList();
        }
    }
}
