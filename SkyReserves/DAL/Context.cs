using Microsoft.EntityFrameworkCore;
using SkyReserves.Models;

namespace SkyReserves.DAL;
public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options) { }

    public DbSet<UserAccount2> UserAccount2 { get; set; }
    public DbSet<ClaseVuelo2> ClaseVuelo { get; set; }
    public DbSet<Accesibilidad2> Accesibilidad2 { get; set; }
    public DbSet<Asiento2> Asientos2 { get; set; }
    public DbSet<Cliente2> Cliente2 { get; set; }
    public DbSet<Hora2> Hora2 { get; set; }
    public DbSet<Origen2> Origen2 { get; set; }
    public DbSet<Destino2> Destino2 { get; set; }
    public DbSet<Nacionalidad1> Nacionalida1 { get; set; }
    public DbSet<Pago2> Pago2 { get; set; }
    public DbSet<Pasaporte2> Pasaportes2 { get; set; }
    public DbSet<PasaporteDetalle2> PasaportesDetalle { get; set; }
    public DbSet<Reserva2> Reserva2 { get; set; }
    public DbSet<VuelosEspeciales2> VuelosEspeciales2 { get; set; }
    public DbSet <Vuelo2> Vuelo2 { get; set; }
    public DbSet<ClaseVuelo2> claseVuelo1 { get; set; }

    public DbSet<AsientoDetalle> AsientoDetalles1 { get; set; }

    public DbSet<ClaseVueloDetalle> ClaseVueloDetalle {  get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuración explícita de los nombres de las tablas
        modelBuilder.Entity<Destino2>().ToTable("Destino2");
        modelBuilder.Entity<Vuelo2>().ToTable("Vuelo2");

    

        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UserAccount2>().HasData(
            new UserAccount2 { Id = 1, UserName = "Araject@gmail.com", Password = "Arajet", Role = "Admin" },
            new UserAccount2 { Id = 2, UserName = "Cliente@gmail.com", Password = "Cliente", Role = "User" }
        );

        modelBuilder.Entity<Asiento2>().HasData(
            new Asiento2 { AsientoId = 1, Fila = "1", Letra = "A", Existencia = 1 },
            new Asiento2 { AsientoId = 2, Fila = "2", Letra = "B", Existencia = 1 },

            new Asiento2 { AsientoId = 3,  Fila = "1", Letra = "C", Existencia = 1 },
            new Asiento2 { AsientoId = 4,  Fila = "1", Letra = "D", Existencia = 1 },
            new Asiento2 { AsientoId = 5,  Fila = "1", Letra = "E", Existencia = 1 },
            new Asiento2 { AsientoId = 6,  Fila = "1", Letra = "F", Existencia = 1 },

        // Fila 2
            new Asiento2 { AsientoId = 7, Fila = "2", Letra = "A", Existencia = 1 },
            new Asiento2 { AsientoId = 8, Fila = "2", Letra = "B", Existencia = 1 },
            new Asiento2 { AsientoId = 9, Fila = "2", Letra = "C", Existencia = 1 },
            new Asiento2 { AsientoId = 10,Fila = "2", Letra = "D", Existencia = 1 },
            new Asiento2 { AsientoId = 11,Fila = "2", Letra = "E", Existencia = 1 },
            new Asiento2 { AsientoId = 12, Fila = "2", Letra = "F", Existencia = 1 },

        // Fila 3
            new Asiento2 { AsientoId = 13, Fila = "3", Letra = "A", Existencia = 1 },
            new Asiento2 { AsientoId = 14, Fila = "3", Letra = "B", Existencia = 1 },
            new Asiento2 { AsientoId = 15,  Fila = "3", Letra = "C", Existencia = 1 },
            new Asiento2 { AsientoId = 16,  Fila = "3", Letra = "D", Existencia = 1 },
            new Asiento2 { AsientoId = 17, Fila = "3", Letra = "E", Existencia = 1 },
            new Asiento2 { AsientoId = 18,  Fila = "3", Letra = "F", Existencia = 1 }


        );



        modelBuilder.Entity<ClaseVuelo2>().HasData(
        new ClaseVuelo2 { ClaseVueloId = 1, descripcionClase = "Economy Class" },
        new ClaseVuelo2 { ClaseVueloId = 2, descripcionClase = "Bussiness Class" },
        new ClaseVuelo2 { ClaseVueloId = 3, descripcionClase = "Tourist Class" },
        new ClaseVuelo2 { ClaseVueloId = 4, descripcionClase = "Firts Class" },
        new ClaseVuelo2 { ClaseVueloId = 5, descripcionClase = "Smart Class" }


    );

    }
}
