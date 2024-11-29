using System.ComponentModel.DataAnnotations;

namespace SkyReserves.Models
{
    public class Nacionalidad
    {
        [Key]

        public int NacionalidadId { get; set; }

        [Required(ErrorMessage = "Favor de seleccionar un pais.")]
        public string? Pais { get; set; }

    }
}
