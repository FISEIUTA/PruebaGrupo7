<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Estudiantes.aspx.cs" Inherits="SistemaAcademicoo.Web.Estudiantes" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Estudiantes</title>
    <style>
        body {
            font-family: 'Segoe UI', sans-serif;
            background-color: #f4f6f9;
            margin: 0;
            padding: 20px;
        }

        .container {
            max-width: 850px;
            margin: auto;
            background: #fff;
            padding: 25px;
            border-radius: 10px;
            box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
        }

        h2, h3 {
            color: #2c3e50;
            margin-bottom: 20px;
        }

        .form-control {
            width: 100%;
            padding: 10px;
            margin-bottom: 12px;
            border: 1px solid #ccc;
            border-radius: 6px;
        }

        .btn {
            padding: 10px 16px;
            margin-right: 10px;
            margin-top: 10px;
            border: none;
            border-radius: 6px;
            font-weight: bold;
            cursor: pointer;
        }

        .btn-primary {
            background-color: #3498db;
            color: white;
        }

        .btn-success {
            background-color: #2ecc71;
            color: white;
        }

        .btn-warning {
            background-color: #f39c12;
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

        .message {
            margin: 15px 0;
            font-weight: bold;
            color: green;
        }

        .table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
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

        .actions .btn {
            margin-right: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Gestión de Estudiantes</h2>

            <asp:Label ID="lblMensaje" runat="server" CssClass="message" />

            <!-- Formulario de estudiante -->
            <asp:TextBox ID="txtCedula" runat="server" CssClass="form-control" Placeholder="Cédula" />
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Placeholder="Nombre" />
            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" Placeholder="Apellido" />
            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" Placeholder="Correo Electrónico" />
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" Placeholder="Teléfono" />

            <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-primary" Text="Registrar Estudiante" OnClick="btnRegistrar_Click" />
            <asp:Button ID="btnConsultar" runat="server" CssClass="btn btn-success" Text="Consultar" OnClick="btnConsultar_Click" />
            <asp:Button ID="btnSalir" runat="server" CssClass="btn btn-secondary" Text="Volver al Inicio" OnClick="btnSalir_Click" />

            <!-- Tabla de estudiantes -->
            <h3>Lista de Estudiantes</h3>
            <asp:GridView ID="gvEstudiantes" runat="server" AutoGenerateColumns="False" CssClass="table">
                <Columns>
                    <asp:BoundField DataField="CedulaId" HeaderText="Cédula" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="CorreoElectronico" HeaderText="Correo" />
                    <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <div class="actions">
                                <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-warning btn-sm"
                                    CommandArgument='<%# Eval("CedulaId") %>' OnClick="btnEditar_Click" />
                                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger btn-sm"
                                    CommandArgument='<%# Eval("CedulaId") %>' OnClick="btnEliminar_Click"
                                    OnClientClick="return confirm('¿Estás seguro de que deseas eliminar este estudiante?');" />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
