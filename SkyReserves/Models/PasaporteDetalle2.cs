using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SkyReserves.Models
{
    public class PasaporteDetalle2
    {

        [Key]

        [ForeignKey("Pasaporte")]
        public int PasaporteId { get; set; }
        public Pasaporte2? Pasaporte { get; set; }
    }
}
