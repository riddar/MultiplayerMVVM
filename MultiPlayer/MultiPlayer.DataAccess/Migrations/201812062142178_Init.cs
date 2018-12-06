namespace MultiPlayer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Match", name: "Game_Id", newName: "GameId");
            RenameColumn(table: "dbo.Match", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.Match", name: "IX_Game_Id", newName: "IX_GameId");
            RenameIndex(table: "dbo.Match", name: "IX_User_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Match", name: "IX_UserId", newName: "IX_User_Id");
            RenameIndex(table: "dbo.Match", name: "IX_GameId", newName: "IX_Game_Id");
            RenameColumn(table: "dbo.Match", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Match", name: "GameId", newName: "Game_Id");
        }
    }
}
