namespace Altkom.Motorola.EF.DbServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColorToDevice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "Color", c => c.String());

            Sql("UPDATE dbo.Devices SET Color='black' WHERE Color is null");

        }
        
        public override void Down()
        {
            DropColumn("dbo.Devices", "Color");
        }
    }
}
