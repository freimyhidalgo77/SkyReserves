using System.ComponentModel.DataAnnotations;

namespace SkyReserves.Models
{
    public class Destino
    {
        [Key]

        public int DestinoId { get; set; }

        [Required(ErrorMessage = "Favor seleccione un destino.")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s\(\)]+$", ErrorMessage = "El campo solo puede contener letras, espacios")]

        public string? destino { get; set; }

   

    }
}
