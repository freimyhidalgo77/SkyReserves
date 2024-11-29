using System.ComponentModel.DataAnnotations;

namespace SkyReserves.Models
{
    public class Origen
    {

        [Key]
        public int OrigenId { get; set; }

        [Required(ErrorMessage = "Favor ingrese un origen.")]
        public string? origen { get; set; }
    }
}
