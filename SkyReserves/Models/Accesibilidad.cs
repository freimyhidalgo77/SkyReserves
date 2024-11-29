using System.ComponentModel.DataAnnotations;

namespace SkyReserves.Models
{
    public class Accesibilidad
    {

        [Key]
        public int AccesibilidadId { get; set; }

        [Required(ErrorMessage = "Favor ingrese una descripcion.")]
        public string? Descripcion { get; set; }

    }
}
