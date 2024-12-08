using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyReserves.Models
{
    public class ClaseVueloDetalle
    {
        [Key]

        [ForeignKey("Reserva2")]
        public int ReservaId { get; set; }
        public Reserva2? Reserva { get; set; }


        [ForeignKey("ClaseVuelo2")]
        public int ClaseVueloId { get; set; }
        public ClaseVuelo2? ClaseVuelo { get; set; }


        public string? DescripcionClase { get; set; }

    }
}
