using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SkyReserves.Models
{
	public class Asiento
	{
		public int AsientoId { get; set; }
		public int VueloId { get; set; }
		public string Fila { get; set; }
		public string Letra { get; set; }
		public int Existencia { get; set; }


	}

}
