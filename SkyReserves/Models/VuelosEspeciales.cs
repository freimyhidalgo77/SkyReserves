using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SkyReserves.Models
{
    public class VuelosEspeciales
    {

        [Key]

        public int VuelosEspecialesId { get; set; }
        public DateTime FechaIda { get; set; }

        [ForeignKey("Origen")]
        public int OrigenId { get; set; }
        public Origen? Origen { get; set; }


        [ForeignKey("Destino")]
        public int DestinoId { get; set; }
        public Destino? Destino { get; set; }


    }
}
