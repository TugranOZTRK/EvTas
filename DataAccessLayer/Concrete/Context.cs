using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
	public class Context : IdentityDbContext<AppUser, AppRole, int>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=TUGRAN\\SQLEXPRESS08;initial catalog=EvTasDb;integrated Security=true");
		}
		public DbSet<Araclar> Araclar { get; set; }
		public DbSet<Kasa> Kasa { get; set; }
	}
}