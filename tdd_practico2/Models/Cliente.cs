namespace ProyectoIdentity.Models
{
    public class Cliente
    {
        public Cliente()
        {
        }

        // Constructor parametrizado
        public Cliente(int id, string codigoCliente, string nombre, int grupoClienteId, GrupoCliente grupoCliente, TipoDocumento tipoDocumento)
        {
            Id = id;
            CodigoCliente = codigoCliente;
            Nombre = nombre;
            GrupoClienteId = grupoClienteId;
            GrupoCliente = grupoCliente;
            TipoDocumento = tipoDocumento;
        }

        public int Id { get; set; }
        public string CodigoCliente { get; set; }
        public string Nombre { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string Email { get; set; }
        public int GrupoClienteId { get; set; }
        public GrupoCliente GrupoCliente {  get; set; }
    }
}
