using System.ComponentModel.DataAnnotations;

namespace SkyReserves.Models
{
    public class Origen2
    {

        [Key]
        public int OrigenId { get; set; }

        [Required(ErrorMessage = "Favor ingrese un origen.")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s\(\)]+$", ErrorMessage = "El campo solo puede contener letras, espacios")]
        public string? origen { get; set; }

        public ICollection<Reserva2>? Reservas { get; set; }
    }
}
