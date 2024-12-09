using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SkyReserves.Models
{
    public class Vuelo
    {

        [Key]
        public int VueloId { get; set; }

        [ForeignKey("Origen")]
        public int OrigenId { get; set; }
        public Origen? Origen { get; set; }


        [ForeignKey("Destino")]
        public int DestinoId { get; set; }
        public Destino? Destino { get; set; }

        public int NumeroPasajeros { get; set; }

    
    }
}
