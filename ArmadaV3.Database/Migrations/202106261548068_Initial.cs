namespace ArmadaV3.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admirals",
                c => new
                    {
                        AdmiralId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Age = c.Int(nullable: false),
                        EnlistmentDate = c.DateTime(nullable: false, storeType: "date"),
                        Photo = c.String(),
                        Description = c.String(nullable: false, maxLength: 1000),
                        Specialty = c.Int(nullable: false),
                        Species = c.Int(nullable: false),
                        EmpireId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdmiralId)
                .ForeignKey("dbo.Crews", t => t.AdmiralId)
                .ForeignKey("dbo.Empires", t => t.EmpireId, cascadeDelete: true)
                .Index(t => t.AdmiralId)
                .Index(t => t.EmpireId);
            
            CreateTable(
                "dbo.AdmiralMissions",
                c => new
                    {
                        AdmiralId = c.Int(nullable: false),
                        MissionId = c.Int(nullable: false),
                        IsSuccess = c.Boolean(),
                    })
                .PrimaryKey(t => new { t.AdmiralId, t.MissionId })
                .ForeignKey("dbo.Admirals", t => t.AdmiralId, cascadeDelete: true)
                .ForeignKey("dbo.Missions", t => t.MissionId, cascadeDelete: true)
                .Index(t => t.AdmiralId)
                .Index(t => t.MissionId);
            
            CreateTable(
                "dbo.Missions",
                c => new
                    {
                        MissionId = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false, maxLength: 50),
                        StartDate = c.DateTime(nullable: false, storeType: "date"),
                        EndDate = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.MissionId);
            
            CreateTable(
                "dbo.Planets",
                c => new
                    {
                        PlanetId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        StarSystem = c.String(nullable: false, maxLength: 50),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlanetId);
            
            CreateTable(
                "dbo.Crews",
                c => new
                    {
                        CrewId = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Specialty = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CrewId);
            
            CreateTable(
                "dbo.Empires",
                c => new
                    {
                        EmpireId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Trait = c.String(nullable: false, maxLength: 50),
                        ControlledSystems = c.Int(nullable: false),
                        Photo = c.String(),
                        Description = c.String(nullable: false, maxLength: 1000),
                    })
                .PrimaryKey(t => t.EmpireId);
            
            CreateTable(
                "dbo.Emperors",
                c => new
                    {
                        EmperorId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Age = c.Int(nullable: false),
                        Photo = c.String(),
                        Description = c.String(nullable: false, maxLength: 1000),
                        Species = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmperorId)
                .ForeignKey("dbo.Empires", t => t.EmperorId)
                .Index(t => t.EmperorId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PlanetsMissions",
                c => new
                    {
                        MissionId = c.Int(nullable: false),
                        PlanetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MissionId, t.PlanetId })
                .ForeignKey("dbo.Missions", t => t.MissionId, cascadeDelete: true)
                .ForeignKey("dbo.Planets", t => t.PlanetId, cascadeDelete: true)
                .Index(t => t.MissionId)
                .Index(t => t.PlanetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Admirals", "EmpireId", "dbo.Empires");
            DropForeignKey("dbo.Emperors", "EmperorId", "dbo.Empires");
            DropForeignKey("dbo.Admirals", "AdmiralId", "dbo.Crews");
            DropForeignKey("dbo.AdmiralMissions", "MissionId", "dbo.Missions");
            DropForeignKey("dbo.PlanetsMissions", "PlanetId", "dbo.Planets");
            DropForeignKey("dbo.PlanetsMissions", "MissionId", "dbo.Missions");
            DropForeignKey("dbo.AdmiralMissions", "AdmiralId", "dbo.Admirals");
            DropIndex("dbo.PlanetsMissions", new[] { "PlanetId" });
            DropIndex("dbo.PlanetsMissions", new[] { "MissionId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Emperors", new[] { "EmperorId" });
            DropIndex("dbo.AdmiralMissions", new[] { "MissionId" });
            DropIndex("dbo.AdmiralMissions", new[] { "AdmiralId" });
            DropIndex("dbo.Admirals", new[] { "EmpireId" });
            DropIndex("dbo.Admirals", new[] { "AdmiralId" });
            DropTable("dbo.PlanetsMissions");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Emperors");
            DropTable("dbo.Empires");
            DropTable("dbo.Crews");
            DropTable("dbo.Planets");
            DropTable("dbo.Missions");
            DropTable("dbo.AdmiralMissions");
            DropTable("dbo.Admirals");
        }
    }
}
