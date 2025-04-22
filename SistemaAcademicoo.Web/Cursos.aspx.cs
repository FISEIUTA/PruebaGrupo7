using SistemaAcademico.Negocio;
using SistemaAcademico.Datos;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaAcademicoo.Web
{
    public partial class Cursos : Page
    {
        private readonly CursoManager _cursoManager;

        // Constructor
        public Cursos()
        {
            _cursoManager = new CursoManager();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCursos();
            }
        }

        // Registrar un curso
        protected void btnRegistrarCurso_Click(object sender, EventArgs e)
        {
            var idTexto = txtCursoId.Text;
            var nombre = txtCursoNombre.Text;
            var descripcion = txtCursoDescripcion.Text;

            if (!string.IsNullOrEmpty(idTexto) && !string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(descripcion))
            {
                if (int.TryParse(idTexto, out int idCurso))
                {
                    var curso = new Curso
                    {
                        CursoId = idCurso,
                        Nombre = nombre,
                        Descripcion = descripcion
                    };

                    var resultado = _cursoManager.RegistrarCurso(curso);
                    lblMensaje.Text = resultado;

                    CargarCursos(); // Recarga la lista de cursos después de registrar uno

                    // Limpiar campos
                    txtCursoId.Text = "";
                    txtCursoNombre.Text = "";
                    txtCursoDescripcion.Text = "";
                }
                else
                {
                    lblMensaje.Text = "El ID del curso debe ser un número válido.";
                }
            }
            else
            {
                lblMensaje.Text = "Por favor, complete todos los campos.";
            }
        }


        // Cargar los cursos desde la base de datos
        private void CargarCursos()
        {
            try
            {
                var cursos = _cursoManager.ObtenerTodos();
                gvCursos.DataSource = cursos;
                gvCursos.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cargar los cursos: " + ex.Message;
            }
        }

        // Eliminar un curso
        protected void gvCursos_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EliminarCurso")
            {
                int cursoId = Convert.ToInt32(e.CommandArgument);
                var resultado = _cursoManager.EliminarCurso(cursoId);
                lblMensaje.Text = resultado;

                CargarCursos(); // Actualiza la lista de cursos después de eliminar uno
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }



    }



}
