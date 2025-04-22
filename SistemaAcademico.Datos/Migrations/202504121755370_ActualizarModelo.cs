namespace SistemaAcademico.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActualizarModelo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cursoes",
                c => new
                    {
                        CursoId = c.Int(nullable: false),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.CursoId);
            
            CreateTable(
                "dbo.EstudianteCursoes",
                c => new
                    {
                        CedulaId = c.Int(nullable: false),
                        CursoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CedulaId, t.CursoId })
                .ForeignKey("dbo.Cursoes", t => t.CursoId, cascadeDelete: true)
                .ForeignKey("dbo.Estudiantes", t => t.CedulaId, cascadeDelete: true)
                .Index(t => t.CedulaId)
                .Index(t => t.CursoId);
            
            CreateTable(
                "dbo.Estudiantes",
                c => new
                    {
                        CedulaId = c.Int(nullable: false),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        CorreoElectronico = c.String(),
                        Telefono = c.String(),
                    })
                .PrimaryKey(t => t.CedulaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EstudianteCursoes", "CedulaId", "dbo.Estudiantes");
            DropForeignKey("dbo.EstudianteCursoes", "CursoId", "dbo.Cursoes");
            DropIndex("dbo.EstudianteCursoes", new[] { "CursoId" });
            DropIndex("dbo.EstudianteCursoes", new[] { "CedulaId" });
            DropTable("dbo.Estudiantes");
            DropTable("dbo.EstudianteCursoes");
            DropTable("dbo.Cursoes");
        }
    }
}
