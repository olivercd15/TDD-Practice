namespace ProyectoIdentity.Models
{
    public class Cliente
    {
        public Cliente()
        {
        }

        // Constructor parametrizado
        public Cliente(int id, string codigoCliente, string nombre, int grupoClienteId, GrupoCliente grupoCliente)
        {
            Id = id;
            CodigoCliente = codigoCliente;
            Nombre = nombre;
            GrupoClienteId = grupoClienteId;
            GrupoCliente = grupoCliente;
        }

        public int Id { get; set; }
        public string CodigoCliente { get; set; }
        public string Nombre { get; set; }
        public int GrupoClienteId { get; set; }
        public GrupoCliente GrupoCliente {  get; set; }
    }
}
