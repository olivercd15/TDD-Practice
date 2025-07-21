using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoIdentity.Datos;
using ProyectoIdentity.Models;

namespace ProyectoIdentity.Controllers
{
    public class FacturaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FacturaController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Registrar()
        {
            var model = new FacturaViewModel();
            model.Fecha = DateTime.Now;
            model.Items.Add(new FacturaItemViewModel());

            ViewBag.Clientes = new SelectList(_context.Clientes, "Id", "Nombre");
            ViewBag.CondicionesPago = new SelectList(_context.CondicionesPago, "Id", "Descripcion");
            ViewBag.MetodosPago = new SelectList(_context.MetodosPago, "Id", "Nombre");
            ViewBag.Productos = new SelectList(_context.Productos, "Id", "Nombre");

            // Clientes para JS: ID y descuento de grupo cliente
            ViewBag.ClientesList = _context.Clientes
                .Select(c => new {
                    c.Id,
                    c.CodigoCliente,
                    c.GrupoClienteId,
                    DescuentoCliente = c.GrupoCliente.PorcentajeDescuento
                }).ToList();


            // Cargar productos con su descuento (PorcentajeDescuento del GrupoProducto)
            var productos = _context.Productos
                .Select(p => new
                {
                    p.Id,
                    p.PrecioVenta,
                    PorcentajeDescuento = p.GrupoProducto.PorcentajeDescuento
                })
                .ToList();

            ViewBag.ProductosList = productos; // Para precios y descuentos en JS

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registrar(FacturaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Clientes = new SelectList(_context.Clientes, "Id", "Nombre");
                ViewBag.CondicionesPago = new SelectList(_context.CondicionesPago, "Id", "Descripcion");
                ViewBag.MetodosPago = new SelectList(_context.MetodosPago, "Id", "Nombre");
                ViewBag.Productos = new SelectList(_context.Productos, "Id", "Nombre");

                // Repasar datos para JS también en error
                ViewBag.ClientesList = _context.Clientes
                    .Select(c => new {
                        c.Id,
                        c.CodigoCliente,
                        c.GrupoClienteId,
                        DescuentoCliente = c.GrupoCliente.PorcentajeDescuento
                    }).ToList();
                ViewBag.ProductosList = _context.Productos
                    .Select(p => new {
                        p.Id,
                        p.PrecioVenta,
                        PorcentajeDescuento = p.GrupoProducto.PorcentajeDescuento
                    }).ToList();
                /*
                var errores = ModelState
                .Where(ms => ms.Value.Errors.Any())
                .Select(ms => $"{ms.Key}: {string.Join(", ", ms.Value.Errors.Select(e => e.ErrorMessage))}")
                .ToList();
                System.Diagnostics.Debug.WriteLine("Errores de validación: " + string.Join(" | ", errores));
                */

                return View(model);
            }
            // Guardado básico, agrega tus lógicas según tu modelo real
            var factura = new Factura
            {
                ClienteId = model.ClienteId,
                CondicionPagoId = model.CondicionPagoId,
                MetodoPagoId = model.MetodoPagoId,
                Fecha = model.Fecha,
                TotalFactura = model.TotalFactura,
                //mapeo a la entidad
                Items = model.Items.Select(i => new FacturaItem
                {
                    ProductoId = i.ProductoId,
                    Cantidad = i.Cantidad,
                    PrecioUnitario = i.PrecioUnitario,
                    DescuentoAplicado = i.DescuentoAplicado, //columna descuento producto
                    OtroDescuento = i.OtroDescuento     //columna descuento cliente
                }).ToList()
            };
            _context.Facturas.Add(factura);
            _context.SaveChanges();
            TempData["MensajeExito"] = "¡Factura registrada exitosamente!";
            return RedirectToAction("Registrar");
        }
    }
}
