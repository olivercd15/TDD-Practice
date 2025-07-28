using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoIdentity.Models;

namespace Reqnroll_BDD.Contexts
{
    [Binding]
    public class CalculoDescuentoSimpleContext
    {
        public GrupoCliente? GrupoCliente { get; set; }
        public GrupoProducto? GrupoProducto { get; set; }
        public Cliente? Cliente { get; set; }
        public Almacen? Almacen { get; set; }
        public Producto? Producto { get; set; }
        public CondicionPago? CondicionPago { get; set; }
        public MetodoPago? MetodoPago { get; set; }
        public Factura? Factura { get; set; }
        public decimal PorcentajeDescuentoTotal { get; set; }
    }
}
