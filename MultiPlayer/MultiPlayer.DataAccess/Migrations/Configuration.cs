namespace MultiPlayer.DataAccess.Migrations
{
	using MultiPlayer.BusinessObjects.Models;
	using MultiPlayer.DataAccess.Context;
	using System.Data.Entity.Migrations;

	internal sealed class Configuration : DbMigrationsConfiguration<MultiPlayerDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MultiPlayerDBContext context)
        {
			context.Users.AddOrUpdate(u => u.Username,
				new User { Username = "test", Password = "test", Firstname = "test", Lastname = "test" },
				new User { Username = "test1", Password = "test1", Firstname = "test1", Lastname = "test1" },
				new User { Username = "test2", Password = "test2", Firstname = "test2", Lastname = "test2" },
				new User { Username = "test3", Password = "test3", Firstname = "test3", Lastname = "test3" }
			);

			context.Games.AddOrUpdate(g => g.Name,
				new Game { Name = "test" },
				new Game { Name = "test1" },
				new Game { Name = "test2" });
		}
    }
}
