using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SkyReserves.Models
{
    public class Pago
    { 

        public int PagoId { get; set; } 


        [Required(ErrorMessage = "La clase de vuelo es obligatoria.")]
        public int ClaseVueloId { get; set; }

        [Required(ErrorMessage = "El número de tarjeta es obligatorio.")]
        public string TarjetaNumero { get; set; }

        [Required(ErrorMessage = "La fecha de vencimiento es obligatoria.")]
        public string FechaVencimiento { get; set; }

        [Required(ErrorMessage = "El CVV es obligatorio.")]
        [StringLength(4, ErrorMessage = "El CVV debe tener entre 3 y 4 dígitos.", MinimumLength = 3)]
        public string CVV { get; set; }

        [Required(ErrorMessage = "El CVV es obligatorio.")]
        public double MontoPagar { get; set; }
    }

}
