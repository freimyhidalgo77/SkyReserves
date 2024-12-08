using System.ComponentModel.DataAnnotations;

namespace SkyReserves.Models
{
    public class Hora2
    {
        [Key]
        public int HoraID { get; set; }

        [Required(ErrorMessage = "Favor seleccione una hora de viaje.")]
        public double horaViaje { get; set; }   //Lapso de horas disponibles en las que el cliente puede viajar

    }
}
