using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Datos
{
    public class Estudiante
    {
        // Atributos de la clase Estudiante

        [Key]  // CLAVE PRIMARIA
        public int CedulaId { get; set; }  // CLAVE PRIMARIA PARA QUE EL ENTITY FRAMEWORK SEPA QUE ES LA CLAVE PRIMARIA

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<EstudianteCurso> EstudiantesCursos { get; set; }
    }
}
