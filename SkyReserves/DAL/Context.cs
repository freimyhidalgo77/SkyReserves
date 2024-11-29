using SkyReserves.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace SkyReserves.DAL;
public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options) { }

    public DbSet<UserAccount> UserAccount { get; set; }

    public DbSet<ClaseVuelo> ClaseVuelo { get; set; }
    public DbSet<Accesibilidad> Accesibilidad { get; set; }
    public DbSet<Asiento> Asientos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Hora> Hora { get; set; }
    public DbSet<Origen> Origen { get; set; }
    public DbSet<Destino> Destino { get; set; }
    public DbSet<Nacionalidad> Nacionalidad { get; set; }
    public DbSet<Pago> Pago { get; set; }
    public DbSet<Pasaporte> Pasaportes { get; set; }
    public DbSet<PasaporteDetalle> PasaporteDetalles { get; set; }
    public DbSet<Reserva> Reserva { get; set; }
    public DbSet<VuelosEspeciales> VuelosEspeciales { get; set; }

    public DbSet<AsientoDetalle> AsientoDetalles { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UserAccount>().HasData(new List<UserAccount>()
             {
              new UserAccount() {Id = 1, UserName= "Wilmer", Password="Will04", Role ="Admin" },
              new UserAccount() {Id = 2, UserName = "Juan", Password = "Perez05", Role = "User" }

            });

        modelBuilder.Entity<AsientoDetalle>().HasData(new List<AsientoDetalle>()
        {

        new AsientoDetalle {DetalleId = 1, AsientoId = 1, Fila = "1", Letra = "A", Existencia = 1},
        new AsientoDetalle {DetalleId = 2, AsientoId = 2, Fila = "1", Letra = "B", Existencia = 1 },
        new AsientoDetalle {DetalleId = 3, AsientoId = 3, Fila = "2", Letra = "C", Existencia = 1},
        new AsientoDetalle {DetalleId = 4, AsientoId = 4, Fila = "2", Letra = "D", Existencia = 3 },


          // Asientos para el vuelo 1, clase Business

        new AsientoDetalle {DetalleId = 5, AsientoId = 5, Fila = "3", Letra = "A", Existencia = 1},
        new AsientoDetalle {DetalleId = 6, AsientoId = 6, Fila = "3", Letra = "B", Existencia = 1 },
        new AsientoDetalle {DetalleId = 7, AsientoId = 7, Fila = "4", Letra = "C", Existencia = 1},
        new AsientoDetalle {DetalleId = 8, AsientoId = 8, Fila = "4", Letra = "D", Existencia = 3 },

        // Asientos para el vuelo 1, clase Tourist
        new AsientoDetalle {DetalleId = 9, AsientoId = 9, Fila = " 5", Letra = "A", Existencia = 1},
        new AsientoDetalle {DetalleId = 10, AsientoId = 10, Fila = "5", Letra = "B", Existencia = 1 },
        new AsientoDetalle {DetalleId = 11, AsientoId = 11, Fila = "6", Letra = "C", Existencia = 1},
        new AsientoDetalle {DetalleId = 12, AsientoId = 12, Fila = "6", Letra = "D", Existencia = 3 },


        // Asientos para el vuelo 1, clase Smart
        new AsientoDetalle {DetalleId = 13, AsientoId = 13, Fila = "7", Letra = "A", Existencia = 1},
        new AsientoDetalle {DetalleId = 14, AsientoId = 14, Fila = "7", Letra = "B", Existencia = 1 },
        new AsientoDetalle {DetalleId = 15, AsientoId = 15, Fila = "8", Letra = "C", Existencia = 1},
        new AsientoDetalle {DetalleId = 16, AsientoId = 16, Fila = "8", Letra = "D", Existencia = 3 },




        });

    }
   
}