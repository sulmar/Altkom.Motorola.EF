namespace Altkom.Motorola.EF.DbServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCountryIndexToContact : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Contacts", "Country");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Contacts", new[] { "Country" });
        }
    }
}
