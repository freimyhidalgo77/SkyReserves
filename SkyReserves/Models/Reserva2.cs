using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SkyReserves.Models
{
    public class Reserva2
    {

        [Key]

        public int ReservaId { get; set; }


        [ForeignKey("ReservaId")]
        public ICollection<Asiento2> AsientoDetalle { get; set; } = new List<Asiento2>();


        [ForeignKey("ReservaId")]
        public ICollection<ClaseVuelo2> ClaseVueloDetalle { get; set; } = new List<ClaseVuelo2>();

     

    }
}
