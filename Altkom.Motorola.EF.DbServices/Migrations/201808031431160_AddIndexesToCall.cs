namespace Altkom.Motorola.EF.DbServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIndexesToCall : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Calls", new[] { "BeginCallDate", "EndCallDate" });
        }
        
        public override void Down()
        {
            DropIndex("dbo.Calls", new[] { "BeginCallDate", "EndCallDate" });
        }
    }
}
