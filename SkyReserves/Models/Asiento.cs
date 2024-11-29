using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SkyReserves.Models
{
    public class Asiento
    {
        [Key]

        public int AsientoId { get; set; }

        [ForeignKey("Reserva")]
        public int ReservaId { get; set; }
        public Reserva? Reserva { get; set; }


        [ForeignKey("AsientoId")]
        public ICollection<AsientoDetalle> AsientoDetalle { get; set; } = new List<AsientoDetalle>();

    }
}
