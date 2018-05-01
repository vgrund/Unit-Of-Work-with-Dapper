namespace DapperUnitOfWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Estantes",
                c => new
                    {
                        EstanteId = c.Guid(nullable: false),
                        Corredor = c.String(maxLength:20),
                    })
                .PrimaryKey(t => t.EstanteId);
            
            CreateTable(
                "dbo.Livroes",
                c => new
                    {
                        LivroId = c.Guid(nullable: false),
                        Titulo = c.String(maxLength:20),
                        Autor = c.String(maxLength:10),
                        EstanteId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.LivroId)
                .ForeignKey("dbo.Estantes", t => t.EstanteId, cascadeDelete: false)
                .Index(t => t.EstanteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Livroes", "EstanteId", "dbo.Estantes");
            DropIndex("dbo.Livroes", new[] { "EstanteId" });
            DropTable("dbo.Livroes");
            DropTable("dbo.Estantes");
        }
    }
}
