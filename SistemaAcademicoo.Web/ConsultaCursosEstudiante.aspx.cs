using SistemaAcademico.Datos;
using System;
using System.Linq;

namespace SistemaAcademicoo.Web
{
    public partial class ConsultaCursosEstudiante : System.Web.UI.Page
    {
        private SistemaAcademicoDbContext db = new SistemaAcademicoDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEstudiantes();
            }
        }

        private void CargarEstudiantes()
        {
            var estudiantes = db.Estudiantes
                .Select(es => new
                {
                    es.CedulaId,
                    NombreCompleto = es.Nombre + " " + es.Apellido
                })
                .ToList();

            ddlEstudiantes.DataSource = estudiantes;
            ddlEstudiantes.DataTextField = "NombreCompleto";
            ddlEstudiantes.DataValueField = "CedulaId";
            ddlEstudiantes.DataBind();

            ddlEstudiantes.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Seleccione un estudiante --", "0"));
        }

        protected void ddlEstudiantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMensaje.Text = ""; // Limpia el mensaje

            int cedulaId;
            if (!int.TryParse(ddlEstudiantes.SelectedValue, out cedulaId) || cedulaId == 0)
            {
                gvCursos.DataSource = null;
                gvCursos.DataBind();
                lblMensaje.Text = "Seleccione un estudiante válido.";
                return;
            }

            var cursos = db.EstudiantesCursos
                .Where(ec => ec.CedulaId == cedulaId)
                .Select(ec => new
                {
                    ec.Curso.CursoId,
                    ec.Curso.Nombre,
                    ec.Curso.Descripcion
                })
                .ToList();

            if (cursos.Count == 0)
            {
                lblMensaje.Text = "El estudiante no tiene cursos asignados.";
            }

            gvCursos.DataSource = cursos;
            gvCursos.DataBind();
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }
    }
}
