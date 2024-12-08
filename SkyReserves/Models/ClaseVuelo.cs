using System.ComponentModel.DataAnnotations;

namespace SkyReserves.Models
{
    public class ClaseVuelo
    {

        [Key]
        public int ClaseVueloId { get; set; }

        public string? descripcionClase { get; set; }

  
    }
}
