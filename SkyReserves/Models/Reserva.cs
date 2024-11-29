using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SkyReserves.Models
{
    public class Reserva
    {

        [Key]
        public int ReservaId { get; set; }

        [ForeignKey("Origen")]
        public int OrigenId { get; set; }
        public Origen? Origen { get; set; }


        [ForeignKey("Destino")]
        public int DestinoId { get; set; }
        public Destino? Destino { get; set; }

        public int NumeroPasajeros { get; set; }

        public ICollection<AsientoDetalle> AsientoDetalle { get; set; } = new List<AsientoDetalle>();


    }
}
