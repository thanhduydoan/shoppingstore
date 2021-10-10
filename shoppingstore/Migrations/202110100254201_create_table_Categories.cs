namespace shoppingstore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_Categories : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Items");
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        RecordId = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        ItemId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RecordId)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        Username = c.String(),
                        FirstName = c.String(nullable: false, maxLength: 160),
                        LastName = c.String(nullable: false, maxLength: 160),
                        Address = c.String(nullable: false, maxLength: 70),
                        City = c.String(nullable: false, maxLength: 40),
                        State = c.String(nullable: false, maxLength: 40),
                        PostalCode = c.String(nullable: false, maxLength: 10),
                        Country = c.String(nullable: false, maxLength: 40),
                        Phone = c.String(nullable: false, maxLength: 24),
                        Email = c.String(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderId);
            
            AddColumn("dbo.Items", "ItemId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Items", "Title", c => c.String(nullable: false, maxLength: 160));
            AlterColumn("dbo.Items", "ItemArtUrl", c => c.String(maxLength: 1024));
            AddPrimaryKey("dbo.Items", "ItemId");
            CreateIndex("dbo.Items", "ProducerId");
            AddForeignKey("dbo.Items", "ProducerId", "dbo.Producers", "ProducerId", cascadeDelete: true);
            DropColumn("dbo.Items", "Producer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "Producer", c => c.Int(nullable: false));
            DropForeignKey("dbo.Carts", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Items", "ProducerId", "dbo.Producers");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "ItemId", "dbo.Items");
            DropIndex("dbo.OrderDetails", new[] { "ItemId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.Items", new[] { "ProducerId" });
            DropIndex("dbo.Carts", new[] { "ItemId" });
            DropPrimaryKey("dbo.Items");
            AlterColumn("dbo.Items", "ItemArtUrl", c => c.String());
            AlterColumn("dbo.Items", "Title", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Items", "ItemId");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Carts");
            AddPrimaryKey("dbo.Items", "Title");
        }
    }
}
