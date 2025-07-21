namespace ProyectoIdentity.Models
{
    public class FacturaViewModel
    {
        public FacturaViewModel()
        {
            Items = new List<FacturaItemViewModel>();
        }
        public int ClienteId { get; set; }
        public int CondicionPagoId { get; set; }
        public int MetodoPagoId { get; set; }
        public decimal TotalFactura { get; set; }
        public DateTime Fecha { get; set; }

        //items
        public List<FacturaItemViewModel> Items { get; set; } = new List<FacturaItemViewModel>();

    }
}
