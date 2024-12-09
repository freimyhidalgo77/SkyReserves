using Microsoft.EntityFrameworkCore;
using SkyReserves.Models;

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
    public DbSet<FlightDeal> FlightDeals { get; set; }
   
    public DbSet<Generos> Generos {  get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Datos iniciales para UserAccount
        modelBuilder.Entity<UserAccount>().HasData(
            new UserAccount { Id = 1, UserName = "Arajet@gmail.com", Password = "Arajet", Role = "Admin" },
            new UserAccount { Id = 2, UserName = "Cliente@gmail.com", Password = "Cliente", Role = "User" }
        );

        modelBuilder.Entity<Asiento>().HasData(
            new Asiento { AsientoId = 1, Fila = "1", Letra = "A", Existencia = 1 },
            new Asiento { AsientoId = 2, Fila = "2", Letra = "B", Existencia = 1 },

            new Asiento { AsientoId = 3, Fila = "1", Letra = "C", Existencia = 1 },
            new Asiento { AsientoId = 4, Fila = "1", Letra = "D", Existencia = 1 },
            new Asiento { AsientoId = 5, Fila = "1", Letra = "E", Existencia = 1 },
            new Asiento { AsientoId = 6, Fila = "1", Letra = "F", Existencia = 1 },

    
            new Asiento { AsientoId = 7, Fila = "2", Letra = "A", Existencia = 1 },
            new Asiento { AsientoId = 8, Fila = "2", Letra = "B", Existencia = 1 },
            new Asiento { AsientoId = 9, Fila = "2", Letra = "C", Existencia = 1 },
            new Asiento { AsientoId = 10, Fila = "2", Letra = "D", Existencia = 1 },
            new Asiento { AsientoId = 11, Fila = "2", Letra = "E", Existencia = 1 },
            new Asiento { AsientoId = 12, Fila = "2", Letra = "F", Existencia = 1 },


            new Asiento { AsientoId = 13, Fila = "3", Letra = "A", Existencia = 1 },
            new Asiento { AsientoId = 14, Fila = "3", Letra = "B", Existencia = 1 },
            new Asiento { AsientoId = 15, Fila = "3", Letra = "C", Existencia = 1 },
            new Asiento { AsientoId = 16, Fila = "3", Letra = "D", Existencia = 1 },
            new Asiento { AsientoId = 17, Fila = "3", Letra = "E", Existencia = 1 },
            new Asiento { AsientoId = 18, Fila = "3", Letra = "F", Existencia = 1 }


        );


        modelBuilder.Entity<Generos>().HasData(

            new Generos { GenerosId = 1, Nombre = "Masculino" },
            new Generos { GenerosId = 2, Nombre = "Femenino" },
            new Generos { GenerosId = 3, Nombre = "Prefiero no decirlo" }

         );

        // Datos iniciales para FlightDeals
        modelBuilder.Entity<FlightDeal>().HasData(
            new FlightDeal
            {
                Id = 1,
                ImageUrl = "/Imagenes/Timer.png ",
                Description = "Como administrador, aquí podrás gestionar la configuración: crear, editar o eliminar de manera eficiente."
            },
            new FlightDeal
            {
               Id = 2,
                ImageUrl = "/Imagenes/Clase.jpeg",
                Description = "Como administrador, aquí podrás gestionar la configuración: crear, editar o eliminar de manera eficiente."
            },
            new FlightDeal
            {
                Id = 3,
                ImageUrl = "/Imagenes/Accesibilidad.png",
                Description = "Como administrador, aquí podrás gestionar la configuración: crear, editar o eliminar de manera eficiente."
            },

             new FlightDeal
             {
                 Id = 4,
                 ImageUrl = "/Imagenes/Bogota.jpg",
                 Description = "Como administrador, aquí podrás gestionar la configuración: crear, editar o eliminar de manera eficiente."
             },

              new FlightDeal
              {
                  Id = 5,
                  ImageUrl = "/Imagenes/Mexico.jpeg",
                  Description = "Como administrador, aquí podrás gestionar la configuración: crear, editar o eliminar de manera eficiente."
              }

        );
    }
}
