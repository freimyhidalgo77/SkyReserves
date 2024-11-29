using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyReserves.Models
{
    public class AsientoDetalle
    {
        [Key]

        public int DetalleId { get; set; }

        [ForeignKey("Asiento")]
        public int AsientoId { get; set; }
        public Asiento? Asiento { get; set; }

        [ForeignKey("Reserva")]
        public int ReservaId { get; set; }
        public Reserva? Reserva { get; set; }


        [Required(ErrorMessage = "Favor elija una fila .")]
        public string? Fila { get; set; }
        public string? Letra { get; set; }
        public int Existencia { get; set; }






    }
}
