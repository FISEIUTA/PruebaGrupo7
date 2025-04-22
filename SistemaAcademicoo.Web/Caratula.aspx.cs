using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaAcademicoo.Web
{
    public partial class Caratula : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnIrInicio_Click(object sender, EventArgs e)
        {
            // Redirige a la página de inicio del sistema
            Response.Redirect("Inicio.aspx");
        }
    }
}