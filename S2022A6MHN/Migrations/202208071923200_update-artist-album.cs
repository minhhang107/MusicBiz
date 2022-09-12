namespace S2022A6MHN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateartistalbum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "Background", c => c.String());
            AddColumn("dbo.Artists", "Portrayal", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artists", "Portrayal");
            DropColumn("dbo.Albums", "Background");
        }
    }
}
