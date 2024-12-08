using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SkyReserves.Models
{
    public class Reserva2
    {

        [Key]

        public int ReservaId { get; set; }


        [ForeignKey("ReservaId")]
        public ICollection<AsientoDetalle> AsientoDetalle { get; set; } = new List<AsientoDetalle>();


        [ForeignKey("ReservaId")]
        public ICollection<ClaseVueloDetalle> ClaseVueloDetalle { get; set; } = new List<ClaseVueloDetalle>();

     

    }
}
