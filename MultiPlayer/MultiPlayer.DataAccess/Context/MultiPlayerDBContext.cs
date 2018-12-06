using MultiPlayer.BusinessObjects.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MultiPlayer.DataAccess.Context
{
	public class MultiPlayerDBContext : DbContext
	{
		public MultiPlayerDBContext() : base("MultiPlayer") { }
		public DbSet<User> Users { get; set; }
		public DbSet<Game> Games { get; set; }
		public DbSet<Match> Matches { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<User>().HasKey(u => u.Id);
			modelBuilder.Entity<User>().HasMany(u => u.Matches).WithOptional(m => m.User);
			modelBuilder.Entity<Game>().HasKey(g => g.Id);
			modelBuilder.Entity<Game>().HasMany(g => g.Matches).WithOptional(m => m.Game);
			modelBuilder.Entity<Match>().HasKey(m => m.Id);
			modelBuilder.Entity<Match>().HasOptional(m => m.User).WithMany(u => u.Matches);
			modelBuilder.Entity<Match>().HasOptional(m => m.Game).WithMany(g => g.Matches);
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}
