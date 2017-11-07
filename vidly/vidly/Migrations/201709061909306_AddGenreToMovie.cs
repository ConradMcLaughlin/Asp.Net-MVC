namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreToMovie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbos", "GenreId", c => c.Byte(nullable: false));
            CreateIndex("dbos", "GenreId");
            AddForeignKey("dbos", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbos", "GenreId", "dbo.Genres");
            DropIndex("dbos", new[] { "GenreId" });
            DropColumn("dbos", "GenreId");
            DropTable("dbo.Genres");
        }
    }
}
