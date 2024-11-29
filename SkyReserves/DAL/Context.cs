using Microsoft.EntityFrameworkCore;
using SkyReserves.Models;

namespace SkyReserve.DAL;
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
	

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<UserAccount>().HasData(
			new UserAccount { Id = 1, UserName = "Araject@gmail.com", Password = "Arajet", Role = "Admin" },
			new UserAccount { Id = 2, UserName = "Cliente@gmail.com", Password = "Cliente", Role = "User" }
		);

		modelBuilder.Entity<Asiento>().HasData(
			new Asiento { AsientoId = 1,  VueloId = 1 , Fila = "1", Letra ="A", Existencia = 5},
			new Asiento { AsientoId = 2,  VueloId = 1 , Fila= "2", Letra ="B" , Existencia = 5}
		
		);

	
	}
}
