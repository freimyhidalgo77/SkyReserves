using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SkyReserves.Models
{
    public class AsientoDetalle
    {

        [Key]

        public int AsientoDetalleID { get; set; }


        [ForeignKey("Asiento")]
        public int AsientoId { get; set; }
        public Asiento? Asiento { get; set; }

        [Required(ErrorMessage = "Favor llenar este campo ")]
        public string? Fila { get; set; }

        public string? Letra { get; set; }

        public int Existencia { get; set; }


    }
    
}

