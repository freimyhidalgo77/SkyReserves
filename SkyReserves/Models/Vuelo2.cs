﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SkyReserves.Models
{
    public class Vuelo2
    {

       
            [Key]

            public int VueloID { get; set; }


            [ForeignKey("Origen")]
            public int OrigenId { get; set; }
            public Origen2? Origen { get; set; }


            [ForeignKey("Destino")]
            public int DestinoId { get; set; }
            public Destino2? Destino { get; set; }

            public int NumeroPasajeros { get; set; }

           /* [ForeignKey("AsientoDetalleId")]
            public int AsientoDetalleId { get; set; }
            public AsientoDetalle? AsientoDetalle { get; set; }*/

        /*[ForeignKey("VueloID")]
        public ICollection<Reserva2>? Reservas { get; set; }*/



    }
    }



