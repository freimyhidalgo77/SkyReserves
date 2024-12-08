using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SkyReserves.Models
{
    public class VuelosEspeciales2
    {

        [Key]

        public int VuelosEspecialesId { get; set; }
        public DateTime FechaIda { get; set; }

        [ForeignKey("Origen")]
        public int OrigenId { get; set; }
        public Origen2? Origen { get; set; }


        [ForeignKey("Destino")]
        public int DestinoId { get; set; }
        public Destino2? Destino { get; set; }


    }
}
