using Microsoft.EntityFrameworkCore;
using SkyReserves.Models;

namespace SkyReserves.DAL;
public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options) { }

    public DbSet<UserAccount> UserAccount { get; set; }
    public DbSet<ClaseVuelo> ClaseVuelo { get; set; }
    public DbSet<Accesibilidad> Accesibilidad { get; set; }
    public DbSet<Asiento> Asientos { get; set; }
    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<Hora> Hora { get; set; }
    public DbSet<Origen> Origen { get; set; }
    public DbSet<Destino> Destino { get; set; }
    public DbSet<Nacionalidad1> Nacionalida { get; set; }
    public DbSet<Pago> Pago { get; set; }
    public DbSet<Pasaporte> Pasaportes { get; set; }
    public DbSet<PasaporteDetalle> PasaportesDetalle { get; set; }
    public DbSet<Reserva> Reserva { get; set; }
    public DbSet<VuelosEspeciales2> VuelosEspeciales { get; set; }
    public DbSet <Vuelo> Vuelo { get; set; }
    public DbSet<ClaseVuelo> claseVuelo { get; set; }

    public DbSet<AsientoDetalle> AsientoDetalles { get; set; }

    public DbSet<ClaseVueloDetalle> ClaseVueloDetalle {  get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuración explícita de los nombres de las tablas
        modelBuilder.Entity<Destino>().ToTable("Destino2");
        modelBuilder.Entity<Vuelo>().ToTable("Vuelo2");

    

        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UserAccount>().HasData(
            new UserAccount { Id = 1, UserName = "Araject@gmail.com", Password = "Arajet", Role = "Admin" },
            new UserAccount { Id = 2, UserName = "Cliente@gmail.com", Password = "Cliente", Role = "User" }
        );

        modelBuilder.Entity<Asiento>().HasData(
            new Asiento { AsientoId = 1, Fila = "1", Letra = "A", Existencia = 1 },
            new Asiento { AsientoId = 2, Fila = "2", Letra = "B", Existencia = 1 },

            new Asiento { AsientoId = 3,  Fila = "1", Letra = "C", Existencia = 1 },
            new Asiento { AsientoId = 4,  Fila = "1", Letra = "D", Existencia = 1 },
            new Asiento { AsientoId = 5,  Fila = "1", Letra = "E", Existencia = 1 },
            new Asiento { AsientoId = 6,  Fila = "1", Letra = "F", Existencia = 1 },

        // Fila 2
            new Asiento { AsientoId = 7, Fila = "2", Letra = "A", Existencia = 1 },
            new Asiento { AsientoId = 8, Fila = "2", Letra = "B", Existencia = 1 },
            new Asiento { AsientoId = 9, Fila = "2", Letra = "C", Existencia = 1 },
            new Asiento { AsientoId = 10,Fila = "2", Letra = "D", Existencia = 1 },
            new Asiento { AsientoId = 11,Fila = "2", Letra = "E", Existencia = 1 },
            new Asiento { AsientoId = 12, Fila = "2", Letra = "F", Existencia = 1 },

        // Fila 3
            new Asiento { AsientoId = 13, Fila = "3", Letra = "A", Existencia = 1 },
            new Asiento { AsientoId = 14, Fila = "3", Letra = "B", Existencia = 1 },
            new Asiento { AsientoId = 15,  Fila = "3", Letra = "C", Existencia = 1 },
            new Asiento { AsientoId = 16,  Fila = "3", Letra = "D", Existencia = 1 },
            new Asiento { AsientoId = 17, Fila = "3", Letra = "E", Existencia = 1 },
            new Asiento { AsientoId = 18,  Fila = "3", Letra = "F", Existencia = 1 }


        );



        modelBuilder.Entity<ClaseVuelo>().HasData(
        new ClaseVuelo { ClaseVueloId = 1, descripcionClase = "Economy Class" },
        new ClaseVuelo { ClaseVueloId = 2, descripcionClase = "Bussiness Class" },
        new ClaseVuelo { ClaseVueloId = 3, descripcionClase = "Tourist Class" },
        new ClaseVuelo { ClaseVueloId = 4, descripcionClase = "Firts Class" },
        new ClaseVuelo { ClaseVueloId = 5, descripcionClase = "Smart Class" }


    );

    }
}
