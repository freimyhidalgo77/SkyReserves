using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyReserves.Models
{
    public class AsientoDetalle
    {

        [Key]

        public int AsientoDetalleID { get; set; }


        [ForeignKey("Reserva2")]
        public int ReservaId { get; set; }
        public Reserva? Reserva { get; set; }


        [ForeignKey("Asiento2")]
        public int AsientoId { get; set; }
        public Asiento? Asiento { get; set; }

        [Required(ErrorMessage = "Favor llenar este campo ")]
        public string? Fila { get; set; }

        public string? Letra { get; set; }

        public int Existencia { get; set; }



    }
}
