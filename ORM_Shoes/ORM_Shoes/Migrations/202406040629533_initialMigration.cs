namespace ORM_Shoes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        Nomer = c.Int(nullable: false),
                        Shoes_typeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shoes_type", t => t.Shoes_typeId, cascadeDelete: true)
                .Index(t => t.Shoes_typeId);
            
            CreateTable(
                "dbo.Shoes_type",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Shoe_Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shoes", "Shoes_typeId", "dbo.Shoes_type");
            DropIndex("dbo.Shoes", new[] { "Shoes_typeId" });
            DropTable("dbo.Shoes_type");
            DropTable("dbo.Shoes");
        }
    }
}
