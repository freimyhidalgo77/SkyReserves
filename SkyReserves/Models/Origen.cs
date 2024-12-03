using System.ComponentModel.DataAnnotations;

namespace SkyReserves.Models
{
    public class Origen
    {

        [Key]
        public int OrigenId { get; set; }

        [Required(ErrorMessage = "Favor ingrese un origen.")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s\(\)]+$", ErrorMessage = "El campo solo puede contener letras, espacios")]
        public string? origen { get; set; }
    }
}
