using System.ComponentModel.DataAnnotations;

namespace SkyReserves.Models
{
    public class Destino
    {
        [Key]

        public int DestinoId { get; set; }

        [Required(ErrorMessage = "Favor seleccione un destino.")]
        public string? destino { get; set; }

    }
}
