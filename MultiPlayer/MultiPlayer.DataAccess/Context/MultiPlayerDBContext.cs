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

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}
