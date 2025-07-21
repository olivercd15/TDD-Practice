using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoIdentity.Models
{
    public class CondicionPago
    {
        public CondicionPago()
        {
        }

        public CondicionPago(int id, string descripcion, int? diasCredito)
        {
            Id = id;
            Descripcion = descripcion;
            DiasCredito = diasCredito;
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int? DiasCredito { get; set; } 
    }
}
