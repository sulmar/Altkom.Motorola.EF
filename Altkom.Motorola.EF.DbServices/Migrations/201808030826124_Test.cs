namespace Altkom.Motorola.EF.DbServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Calls", "Sender_Id", "dbo.Contacts");
            DropForeignKey("dbo.Calls", "Source_Id", "dbo.Devices");
            AddColumn("dbo.Calls", "Device_Id", c => c.Int());
            CreateIndex("dbo.Calls", "Device_Id");
            AddForeignKey("dbo.Calls", "Sender_Id", "dbo.Contacts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Calls", "Device_Id", "dbo.Devices", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Calls", "Device_Id", "dbo.Devices");
            DropForeignKey("dbo.Calls", "Sender_Id", "dbo.Contacts");
            DropIndex("dbo.Calls", new[] { "Device_Id" });
            DropColumn("dbo.Calls", "Device_Id");
            AddForeignKey("dbo.Calls", "Source_Id", "dbo.Devices", "Id");
            AddForeignKey("dbo.Calls", "Sender_Id", "dbo.Contacts", "Id");
        }
    }
}
