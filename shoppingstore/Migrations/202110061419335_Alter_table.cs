namespace shoppingstore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_table : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Items");
            AddColumn("dbo.Items", "ItemId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Items", "Title", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Items", "Price", c => c.String());
            AlterColumn("dbo.Items", "ItemArtUrl", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Items", "ItemId");
            DropColumn("dbo.Items", "Producer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "Producer", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.Items");
            AlterColumn("dbo.Items", "ItemArtUrl", c => c.String());
            AlterColumn("dbo.Items", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Items", "Title", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Items", "ItemId");
            AddPrimaryKey("dbo.Items", "Title");
        }
    }
}
