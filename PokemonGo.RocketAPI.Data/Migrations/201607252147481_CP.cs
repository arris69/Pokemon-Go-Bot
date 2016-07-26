namespace PokemonGo.RocketAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CP : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Captures", "CP", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Captures", "CP");
        }
    }
}
