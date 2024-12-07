using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SkyReserves.Models
{
    public class Pasaporte
    {
        [Key]

        public int PasaporteId { get; set; }

        [Required(ErrorMessage = "Favor ingrese el nombre de pila.")]
        public string? NombrePila { get; set; }

        [Required(ErrorMessage = "Favor ingrese el apellido.")]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "Favor ingrese la fecha de nacimiento.")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Favor ingrese el género.")]
        public string? Genero { get; set; }

        [Required(ErrorMessage = "Favor ingrese la accesibilidad.")]
        public string? Accesibilidad { get; set; }

        [Required(ErrorMessage = "Favor ingrese la nacionalidad.")]
        public string? Nacionalidad { get; set; }

        [ForeignKey("PasaporteId")]
        public ICollection<PasaporteDetalle> PasaporteDetalle { get; set; } = new List<PasaporteDetalle>();
    }
}
