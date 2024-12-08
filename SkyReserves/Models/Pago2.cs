using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SkyReserves.Models
{
    public class Pago2
    {

        [Key]

        public int PagoId { get; set; }

        [Required(ErrorMessage = "Favor seleccione una forma de pago.")]
        public string? MetodoPago { get; set; } //Forma de pago paar la reserva de vuelo

        public DateTime FechaPago { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Favor marque el estado del pago.")]
        public string? EstadoPago { get; set; } //(Pagado/No pagado)

        [ForeignKey("Reserva")]
        public int ReservaId { get; set; }
        Reserva2? Reserva { get; set; }

    }
}
