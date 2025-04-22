using System;
using System.Web.UI;

namespace SistemaAcademicoo.Web
{
    public partial class Inicio : System.Web.UI.Page
    {
        // Este método se ejecuta cuando se carga la página
        protected void Page_Load(object sender, EventArgs e)
        {
            // Código de carga de la página
        }

        // Método para manejar el clic en el botón "Registrar Estudiante"
        protected void btnRegistrarEstudiante_Click(object sender, EventArgs e)
        {
            Response.Redirect("Estudiantes.aspx");
        }

        // Método para manejar el clic en el botón "Agregar Cursos"
        protected void btnAgregarCursos_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cursos.aspx");
        }

        // Método para manejar el clic en el botón "Asignar Cursos"
        protected void btnAsignarCursos_Click(object sender, EventArgs e)
        {
            Response.Redirect("AsignacionCursos.aspx");
        }

        // Método para manejar el clic en el botón "Listado Consultas"
        protected void btnListadoConsultas_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultaCursosEstudiante.aspx");
        }
    }
}
