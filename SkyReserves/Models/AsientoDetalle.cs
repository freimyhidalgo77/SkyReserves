using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyReserves.Models
{
    public class AsientoDetalle
    {

        [Key]

        public int AsientoDetalleID { get; set; }


        [ForeignKey("Reserva2")]
        public int ReservaId { get; set; }
        public Reserva2? Reserva { get; set; }


        [ForeignKey("Asiento2")]
        public int AsientoId { get; set; }
        public Asiento2? Asiento { get; set; }

        public string? Fila { get; set; }
        public string? Letra { get; set; }
        public int Existencia { get; set; }



    }
}
