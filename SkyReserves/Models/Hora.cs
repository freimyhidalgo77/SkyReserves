using System;
using System.ComponentModel.DataAnnotations;

namespace SkyReserves.Models
{
    public class Hora
    {
        [Key]
        public int HoraID { get; set; } // Identificador único para cada horario.

        [Required(ErrorMessage = "La descripción es requerida.")]
        [StringLength(100, ErrorMessage = "La descripción no debe exceder los 100 caracteres.")]
        public string Descripcion { get; set; } // Descripción del horario (e.g., "Mañana", "Tarde").

        [Required(ErrorMessage = "La hora de inicio es requerida.")]
        [DataType(DataType.Time)] // Marca para indicar que es un valor de tiempo.
        public TimeSpan HoraInicio { get; set; } // Hora de inicio del intervalo.

        [Required(ErrorMessage = "La hora de fin es requerida.")]
        [DataType(DataType.Time)] // Marca para indicar que es un valor de tiempo.
        public TimeSpan HoraFin { get; set; } // Hora de fin del intervalo.

        [Range(0.5, 24, ErrorMessage = "La duración debe estar entre 0.5 y 24 horas.")]
        public double Duracion
        {
            get
            {
                // Calcula la duración en horas.
                var diferencia = (HoraFin - HoraInicio).TotalHours;
                return diferencia > 0 ? diferencia : 0; // Retorna 0 si la diferencia es negativa.
            }
        }
    }
}
