using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyReserves.Models
{
    public class ClaseVueloDetalle
    {
        [Key]

        public int ClaseVueloDetalleId { get; set; }

        [ForeignKey("Reserva2")]
        public int ReservaId { get; set; }
        public Reserva? Reserva { get; set; }


        [ForeignKey("ClaseVuelo2")]
        public int ClaseVueloId { get; set; }
        public ClaseVuelo? ClaseVuelo { get; set; }


        public string? DescripcionClase { get; set; }

    }
}
