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

        // Datos iniciales para Asiento
        modelBuilder.Entity<Asiento>().HasData(
            new Asiento { AsientoId = 1, VueloId = 1, Fila = "1", Letra = "A", Existencia = 5 },
            new Asiento { AsientoId = 2, VueloId = 1, Fila = "2", Letra = "B", Existencia = 5 }
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
            }

        );
    }
}
