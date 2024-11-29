using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyReserves.Models
{
    public class Cliente
    {

        [Key]

        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Favor introdiuzca un nombre.")]
        public string? NombreCliente { get; set; }

        [Required(ErrorMessage = "Favor introdiuzca un apellido .")]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "Favor seleccione una clase de vuelo.")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Favor seleccione una clase de vuelo.")]
        public string? Genero { get; set; }

        [Required(ErrorMessage = "Favor seleccione una clase de vuelo.")]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "Favor seleccione una clase de vuelo.")]

        [ForeignKey("Accesibilidad")]
        public int AccesibilidadId { get; set; }
        public Accesibilidad? Accesibilidad { get; set; }

        [Required(ErrorMessage = "Favor seleccione una clase de vuelo.")]
        public string? Email { get; set; }


    }
}
