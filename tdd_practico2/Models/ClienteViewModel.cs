using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ProyectoIdentity.Models
{
    public class ClienteViewModel
    {
        [Required(ErrorMessage = "El código es obligatorio")]
        public string CodigoCliente { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El tipo de documento es obligatorio")]
        public TipoDocumento TipoDocumento { get; set; }

        [Required(ErrorMessage = "El número de documento es obligatorio")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Solo números permitidos")]
        [Display(Name = "Nro. Documento")]
        public string NroDocumento { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "Correo electrónico no válido")]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El grupo de cliente es obligatorio")]
        [Display(Name = "Grupo de Cliente")]
        public int GrupoClienteId { get; set; }

        [BindNever]
        public IEnumerable<SelectListItem> GrupoClientes { get; set; }

    }
}
