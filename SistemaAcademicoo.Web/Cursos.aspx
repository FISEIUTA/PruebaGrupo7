<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="SistemaAcademicoo.Web.Cursos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Cursos</title>
    <style>
        body {
            font-family: 'Segoe UI', sans-serif;
            background-color: #f4f6f9;
            margin: 0;
            padding: 20px;
        }

        h2 {
            color: #2c3e50;
        }

        .container {
            max-width: 800px;
            margin: auto;
            background: white;
            padding: 25px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
        }

        .form-control {
            margin-bottom: 12px;
            padding: 10px;
            width: 100%;
            border: 1px solid #ccc;
            border-radius: 6px;
        }

        .btn {
            margin-right: 10px;
            padding: 10px 16px;
            cursor: pointer;
            border-radius: 6px;
            border: none;
            font-weight: bold;
        }

        .btn-primary {
            background-color: #3498db;
            color: white;
        }

        .btn-danger {
            background-color: #e74c3c;
            color: white;
        }

        .btn-secondary {
            background-color: #95a5a6;
            color: white;
        }

        .table {
            margin-top: 20px;
            width: 100%;
            border-collapse: collapse;
        }

        .table th, .table td {
            border: 1px solid #ddd;
            padding: 12px;
            text-align: left;
        }

        .table th {
            background-color: #2980b9;
            color: white;
        }

        .message {
            margin-bottom: 10px;
            display: block;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Gestión de Cursos</h2>

            <asp:Label ID="lblMensaje" runat="server" CssClass="message" ForeColor="Green" />

            <!-- Formulario de registro -->
            <asp:TextBox ID="txtCursoId" runat="server" CssClass="form-control" Placeholder="ID del Curso" />
            <asp:TextBox ID="txtCursoNombre" runat="server" CssClass="form-control" Placeholder="Nombre del Curso" />
            <asp:TextBox ID="txtCursoDescripcion" runat="server" CssClass="form-control" Placeholder="Descripción del Curso" />

            <asp:Button ID="btnRegistrarCurso" runat="server" CssClass="btn btn-primary" Text="Registrar Curso" OnClick="btnRegistrarCurso_Click" />
            <asp:Button ID="btnSalir" runat="server" CssClass="btn btn-secondary" Text="Volver al Inicio" OnClick="btnSalir_Click" />

            <!-- Tabla de cursos -->
            <h3 style="margin-top: 30px;">Lista de Cursos</h3>
            <asp:GridView ID="gvCursos" runat="server" AutoGenerateColumns="False" CssClass="table" OnRowCommand="gvCursos_RowCommand">
                <Columns>
                    <asp:BoundField DataField="CursoId" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger btn-sm" 
                                CommandName="EliminarCurso" CommandArgument='<%# Eval("CursoId") %>' 
                                OnClientClick="return confirm('¿Estás seguro de que deseas eliminar este curso?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>