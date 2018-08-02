namespace Altkom.Motorola.EF.DbServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWeigthToDevice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "Weight", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Devices", "Weight");
        }
    }
}
