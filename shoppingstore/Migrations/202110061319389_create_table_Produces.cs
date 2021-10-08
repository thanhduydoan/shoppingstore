namespace shoppingstore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_Produces : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Producers",
                c => new
                    {
                        ProducerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ProducerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Producers");
        }
    }
}
