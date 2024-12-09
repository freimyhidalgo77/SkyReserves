using System;
using System.ComponentModel.DataAnnotations;

namespace SkyReserves.Models
{
    public class Hora
    {
        [Key]
        public int HoraID { get; set; } 

        [Required(ErrorMessage = "La descripción es requerida.")]
        [StringLength(100, ErrorMessage = "La descripción no debe exceder los 100 caracteres.")]
        public string Descripcion { get; set; } 

        [Required(ErrorMessage = "La hora de inicio es requerida.")]
        [DataType(DataType.Time)] 
        public TimeSpan HoraInicio { get; set; } 
        [Required(ErrorMessage = "La hora de fin es requerida.")]
        [DataType(DataType.Time)] 
        public TimeSpan HoraFin { get; set; } 

        [Range(0.5, 24, ErrorMessage = "La duración debe estar entre 0.5 y 24 horas.")]
        public double Duracion
        {
            get
            {
               
                var diferencia = (HoraFin - HoraInicio).TotalHours;
                return diferencia > 0 ? diferencia : 0; 
            }
        }
    }
}
