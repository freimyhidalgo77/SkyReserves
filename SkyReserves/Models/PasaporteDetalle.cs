using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SkyReserves.Models
{
    public class PasaporteDetalle
    {

        [Key]

        [ForeignKey("Pasaporte")]
        public int PasaporteId { get; set; }
        public Pasaporte? Pasaporte { get; set; }

        [Required(ErrorMessage = "Favor ingrese el país de residencia.")]
        public string? PaisResidencia { get; set; }

        [Required(ErrorMessage = "Favor ingrese el número de pasaporte.")]
        public string? NumeroPasaporte { get; set; }

        [Required(ErrorMessage = "Favor ingrese quién expidió el pasaporte.")]
        public string? ExpendidoPor { get; set; }

        [Required(ErrorMessage = "Favor ingrese la fecha de vencimiento del pasaporte.")]
        public DateTime FechaVencimiento { get; set; }

        [Required(ErrorMessage = "Favor ingrese el país de nacimiento.")]
        public string? PaisNacimiento { get; set; }

        [Required(ErrorMessage = "Favor ingrese la ciudad natal.")]
        public string? CiudadNatal { get; set; }
    }
}
