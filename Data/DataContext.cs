using AcademiaIMC.Models;
using Microsoft.EntityFrameworkCore;

namespace AcademiaIMC.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
		
		public DbSet<IMC> Imcs { get; set; }
		public DbSet<Usuario> Usuarios { get; set; }

	}
}