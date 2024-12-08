using System.ComponentModel.DataAnnotations;

namespace SkyReserves.Models
{
    public class Destino2
    {
        [Key]

        public int DestinoId { get; set; }

        [Required(ErrorMessage = "Favor seleccione un destino.")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s\(\)]+$", ErrorMessage = "El campo solo puede contener letras, espacios")]

        public string? destino { get; set; }

        public ICollection<Reserva2>? Reservas { get; set; }

    }
}
