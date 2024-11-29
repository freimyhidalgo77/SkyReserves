using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SkyReserves.Models
{
    public class PasaporteDetalle
    {

        [Key]

        [ForeignKey("Pasaporte")]
        public int PasaporteId { get; set; }
        public Pasaporte? Pasaporte { get; set; }
    }
}
