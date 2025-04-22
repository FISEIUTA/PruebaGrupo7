using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Datos
{
    public class Curso
    {
        //Atributos de la clase Curso
        [Key]  // CLAVE PRIMARIA
        public int CursoId { get; set; }  // PONGO KEY PARA QUE EL ENTITY FRAMEWORK SEPA QUE ES LA CLAVE PRIMARIA

        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<EstudianteCurso> EstudiantesCursos { get; set; }
    }

}
