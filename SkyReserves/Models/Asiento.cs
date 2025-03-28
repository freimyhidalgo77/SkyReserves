﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SkyReserves.Models
{
	public class Asiento
	{
		public int AsientoId { get; set; }
		public string Fila { get; set; }
		public string Letra { get; set; }
		public int Existencia { get; set; }

        public ICollection<AsientoDetalle> AsientoDetalle { get; set; } = new List<AsientoDetalle>();
    }

}
