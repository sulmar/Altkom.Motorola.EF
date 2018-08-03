namespace Altkom.Motorola.EF.DbServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRowVersionToDevice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Devices", "RowVersion");
        }
    }
}
