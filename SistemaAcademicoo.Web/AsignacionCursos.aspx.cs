using SistemaAcademico.Datos;
using System;
using System.Linq;

namespace SistemaAcademicoo.Web
{
    public partial class AsignacionCursos : System.Web.UI.Page
    {
        SistemaAcademicoDbContext db = new SistemaAcademicoDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEstudiantes();
                CargarCursos();
            }
        }

        private void CargarEstudiantes()
        {
            ddlEstudiantes.DataSource = db.Estudiantes
                .Select(e => new { e.CedulaId, NombreCompleto = e.Nombre + " " + e.Apellido })
                .ToList();

            ddlEstudiantes.DataTextField = "NombreCompleto";
            ddlEstudiantes.DataValueField = "CedulaId";
            ddlEstudiantes.DataBind();
        }

        private void CargarCursos()
        {
            ddlCursos.DataSource = db.Cursos.ToList();
            ddlCursos.DataTextField = "Nombre";
            ddlCursos.DataValueField = "CursoId";
            ddlCursos.DataBind();
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            int cedulaId = int.Parse(ddlEstudiantes.SelectedValue);
            int cursoId = int.Parse(ddlCursos.SelectedValue);

            // Validar si ya está asignado
            bool yaAsignado = db.EstudiantesCursos
                .Any(ec => ec.CedulaId == cedulaId && ec.CursoId == cursoId);

            if (yaAsignado)
            {
                lblMensaje.Text = "El curso ya está asignado a este estudiante.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            var asignacion = new EstudianteCurso
            {
                CedulaId = cedulaId,
                CursoId = cursoId
            };

            db.EstudiantesCursos.Add(asignacion);
            db.SaveChanges();

            lblMensaje.Text = "Curso asignado exitosamente.";
            lblMensaje.ForeColor = System.Drawing.Color.Green;
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }
    }
}
