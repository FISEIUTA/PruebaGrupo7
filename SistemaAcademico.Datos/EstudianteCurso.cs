using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Datos
{
    public class EstudianteCurso
    {
        // Atributos de la clase EstudianteCurso

        [Key, Column(Order = 0)] //  Parte de la clave primaria
        public int CedulaId { get; set; }

        [Key, Column(Order = 1)] // Parte de la clave primaria
        public int CursoId { get; set; }

        public Estudiante Estudiante { get; set; } // Relación con Estudiante
        public Curso Curso { get; set; } // Relación con Curso
    }
}
