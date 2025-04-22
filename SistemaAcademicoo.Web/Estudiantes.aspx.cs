using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemaAcademico.Datos;
using SistemaAcademico.Negocio;

namespace SistemaAcademicoo.Web
{
    // Página de gestión de estudiantes en el sistema académico
    public partial class Estudiantes : Page
    {
        // Instancia del manejador de lógica de negocio para estudiantes
        private readonly EstudianteManager estudianteManager = new EstudianteManager();

        // Evento que se ejecuta al cargar la página
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEstudiantes();
            }
        }

        // Botón Registrar / Actualizar estudiante
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                    return;

                // Crear el objeto estudiante
                var estudiante = new Estudiante
                {
                    CedulaId = int.Parse(txtCedula.Text),
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    CorreoElectronico = txtCorreo.Text,
                    Telefono = txtTelefono.Text
                };

                if (btnRegistrar.Text == "Registrar Estudiante")
                {
                    estudianteManager.RegistrarEstudiante(estudiante);
                    lblMensaje.Text = "Estudiante registrado con éxito.";
                }
                else
                {
                    estudianteManager.ActualizarEstudiante(estudiante);
                    lblMensaje.Text = "Estudiante actualizado con éxito.";
                    btnRegistrar.Text = "Registrar Estudiante"; // Restaurar texto original
                }

                lblMensaje.ForeColor = System.Drawing.Color.Green;
                CargarEstudiantes();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MostrarError("Error al registrar/actualizar estudiante: " + ex.Message);
            }
        }

        // Botón Editar estudiante
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender is Button btn && int.TryParse(btn.CommandArgument, out int cedulaId))
                {
                    var estudiante = estudianteManager.ObtenerPorCedula(cedulaId);
                    if (estudiante != null)
                    {
                        txtCedula.Text = estudiante.CedulaId.ToString();
                        txtNombre.Text = estudiante.Nombre;
                        txtApellido.Text = estudiante.Apellido;
                        txtCorreo.Text = estudiante.CorreoElectronico;
                        txtTelefono.Text = estudiante.Telefono;

                        btnRegistrar.Text = "Actualizar Estudiante";
                        lblMensaje.Text = "";
                    }
                    else
                    {
                        MostrarError("Estudiante no encontrado.");
                    }
                }
                else
                {
                    MostrarError("Cédula no válida.");
                }
            }
            catch (Exception)
            {
                MostrarError("Ocurrió un error al intentar editar el estudiante.");
            }
        }

        // Botón Eliminar estudiante
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender is Button btn && int.TryParse(btn.CommandArgument, out int cedulaId))
                {
                    estudianteManager.EliminarEstudiante(cedulaId);
                    lblMensaje.Text = "Estudiante eliminado con éxito.";
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                    CargarEstudiantes();
                }
                else
                {
                    MostrarError("Cédula no válida.");
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al eliminar estudiante: " + ex.Message);
            }
        }

        // Botón Consultar estudiantes
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarEstudiantes();
            lblMensaje.Text = "Estudiantes cargados correctamente.";
            lblMensaje.ForeColor = System.Drawing.Color.Green;
        }

        // Cargar datos en el GridView
        private void CargarEstudiantes()
        {
            gvEstudiantes.DataSource = estudianteManager.ObtenerTodos();
            gvEstudiantes.DataBind();
        }

        // Limpiar campos del formulario
        private void LimpiarCampos()
        {
            txtCedula.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
        }

        // Validar que los campos estén llenos y correctos
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtCedula.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MostrarError("Todos los campos son obligatorios.");
                return false;
            }

            if (!int.TryParse(txtCedula.Text, out _))
            {
                MostrarError("La cédula debe ser un número válido.");
                return false;
            }

            return true;
        }

        // Mostrar mensaje de error en etiqueta
        private void MostrarError(string mensaje)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.ForeColor = System.Drawing.Color.Red;
        }
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }
    }


}
