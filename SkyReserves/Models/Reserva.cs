using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SkyReserves.Models
{
    public class Reserva
    {

        [Key]

        public int ReservaId { get; set; }


        [ForeignKey("ReservaId")]
        public ICollection<AsientoDetalle> AsientoDetalle { get; set; } = new List<AsientoDetalle>();


        [ForeignKey("ReservaId")]
        public ICollection<ClaseVueloDetalle> ClaseVueloDetalle { get; set; } = new List<ClaseVueloDetalle>();


        public int OrigenId { get; set; } 
        public int DestinoId { get; set; }


    }
}
