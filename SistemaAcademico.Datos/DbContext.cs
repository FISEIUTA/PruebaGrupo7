using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Datos
{
    public class SistemaAcademicoDbContext : DbContext
    {
        public SistemaAcademicoDbContext()
            : base("name=SistemaAcademicoConnection") // NOMBRE DE LA CADENA DE CONEXION
        {
        }

        // Definicion de las tablas en la base de datos
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<EstudianteCurso> EstudiantesCursos { get; set; }

        // Configuracion de la cadena de conexion
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configurar la clave primaria compuesta para la tabla EstudianteCurso
            modelBuilder.Entity<EstudianteCurso>()
                .HasKey(ec => new { ec.CedulaId, ec.CursoId });

            // Configuración de la relación entre Estudiante y EstudianteCurso
            modelBuilder.Entity<EstudianteCurso>()
                .HasRequired(ec => ec.Estudiante)
                .WithMany(e => e.EstudiantesCursos)
                .HasForeignKey(ec => ec.CedulaId);

            // Configuración de la relación entre Curso y EstudianteCurso
            modelBuilder.Entity<EstudianteCurso>()
                .HasRequired(ec => ec.Curso)
                .WithMany(c => c.EstudiantesCursos)
                .HasForeignKey(ec => ec.CursoId);

            // Configuración para que la clave CedulaId no sea auto-generada
            modelBuilder.Entity<Estudiante>()
                .Property(e => e.CedulaId)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);

            // Configuración para que la clave CursoId no sea auto-generada
            modelBuilder.Entity<Curso>()
                .Property(c => c.CursoId)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);

            base.OnModelCreating(modelBuilder);
        }
    }
}
