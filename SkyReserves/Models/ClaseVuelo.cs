using System.ComponentModel.DataAnnotations;

namespace SkyReserves.Models
{
    public class ClaseVuelo
    {

        [Key]
        public int ClaseVueloId { get; set; }

        [Required(ErrorMessage = "Favor ingrese una clase de vuelo.")]
        public string? descripcionClase { get; set; }
    }
}
