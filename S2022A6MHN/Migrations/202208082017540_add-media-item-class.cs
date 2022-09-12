namespace S2022A6MHN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmediaitemclass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MediaItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Caption = c.String(nullable: false, maxLength: 100),
                        Content = c.Binary(),
                        ContentType = c.String(maxLength: 200),
                        StringId = c.String(nullable: false, maxLength: 100),
                        Timestamp = c.DateTime(nullable: false),
                        Artist_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.Artist_Id)
                .Index(t => t.Artist_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MediaItems", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.MediaItems", new[] { "Artist_Id" });
            DropTable("dbo.MediaItems");
        }
    }
}
