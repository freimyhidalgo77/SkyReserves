using System.ComponentModel.DataAnnotations;

namespace SkyReserves.Models
{
    public class ClaseVuelo2
    {

        [Key]
        public int ClaseVueloId { get; set; }

        public string? descripcionClase { get; set; }

  
    }
}
