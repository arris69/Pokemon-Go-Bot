namespace PokemonGo.RocketAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Captures",
                c => new
                    {
                        CaptureId = c.Int(nullable: false, identity: true),
                        EarnedXp = c.Double(nullable: false),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        CaptureTime = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        PokemonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CaptureId)
                .ForeignKey("dbo.Pokemons", t => t.PokemonId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PokemonId);
            
            CreateTable(
                "dbo.Pokemons",
                c => new
                    {
                        PokemonId = c.Int(nullable: false, identity: true),
                        PokedexNumber = c.Int(nullable: false),
                        Name = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.PokemonId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Checkins",
                c => new
                    {
                        CheckinId = c.Int(nullable: false, identity: true),
                        EarnedXp = c.Double(nullable: false),
                        CheckinTime = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        PokestopId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CheckinId)
                .ForeignKey("dbo.Pokestops", t => t.PokestopId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PokestopId);
            
            CreateTable(
                "dbo.Pokestops",
                c => new
                    {
                        PokestopId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Identifier = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PokestopId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Checkins", "UserId", "dbo.Users");
            DropForeignKey("dbo.Checkins", "PokestopId", "dbo.Pokestops");
            DropForeignKey("dbo.Captures", "UserId", "dbo.Users");
            DropForeignKey("dbo.Captures", "PokemonId", "dbo.Pokemons");
            DropIndex("dbo.Checkins", new[] { "PokestopId" });
            DropIndex("dbo.Checkins", new[] { "UserId" });
            DropIndex("dbo.Captures", new[] { "PokemonId" });
            DropIndex("dbo.Captures", new[] { "UserId" });
            DropTable("dbo.Pokestops");
            DropTable("dbo.Checkins");
            DropTable("dbo.Users");
            DropTable("dbo.Pokemons");
            DropTable("dbo.Captures");
        }
    }
}
