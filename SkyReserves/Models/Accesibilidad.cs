using System.ComponentModel.DataAnnotations;

namespace SkyReserves.Models
{
    public class Accesibilidad
    {

        [Key]
        public int AccesibilidadId { get; set; }

        [Required(ErrorMessage = "Favor ingrese una descripcion.")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s\(\)]+$", ErrorMessage = "El campo solo puede contener letras, espacios")]
        public string? Descripcion { get; set; }

    }
}
