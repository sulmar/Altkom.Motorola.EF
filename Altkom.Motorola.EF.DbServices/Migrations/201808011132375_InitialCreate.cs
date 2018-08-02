namespace Altkom.Motorola.EF.DbServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Calls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BeginCallDate = c.DateTime(nullable: false),
                        EndCallDate = c.DateTime(),
                        ChannelId = c.Int(nullable: false),
                        IsAnswered = c.Boolean(nullable: false),
                        Status = c.Int(nullable: false),
                        Sender_Id = c.Int(),
                        Source_Id = c.Int(),
                        Target_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.Sender_Id)
                .ForeignKey("dbo.Devices", t => t.Source_Id)
                .ForeignKey("dbo.Devices", t => t.Target_Id)
                .Index(t => t.ChannelId)
                .Index(t => t.Sender_Id)
                .Index(t => t.Source_Id)
                .Index(t => t.Target_Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Country = c.String(maxLength: 100),
                        CompanyName = c.String(maxLength: 100),
                        IsRemoved = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 100),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Model = c.String(nullable: false, maxLength: 20, unicode: false),
                        Firmware = c.String(maxLength: 20, unicode: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Calls", "Target_Id", "dbo.Devices");
            DropForeignKey("dbo.Calls", "Source_Id", "dbo.Devices");
            DropForeignKey("dbo.Calls", "Sender_Id", "dbo.Contacts");
            DropIndex("dbo.Calls", new[] { "Target_Id" });
            DropIndex("dbo.Calls", new[] { "Source_Id" });
            DropIndex("dbo.Calls", new[] { "Sender_Id" });
            DropIndex("dbo.Calls", new[] { "ChannelId" });
            DropTable("dbo.Devices");
            DropTable("dbo.Contacts");
            DropTable("dbo.Calls");
        }
    }
}
