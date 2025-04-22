<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignacionCursos.aspx.cs" Inherits="SistemaAcademicoo.Web.AsignacionCursos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Asignar Cursos a Estudiantes</title>
    <style>
        body {
            font-family: 'Segoe UI', sans-serif;
            background-color: #f4f6f9;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .container {
            background-color: white;
            padding: 30px 40px;
            border-radius: 12px;
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
            width: 400px;
            text-align: center;
        }

        h2 {
            color: #2c3e50;
            font-size: 2rem;
            margin-bottom: 20px;
        }

        label {
            font-size: 1.2rem;
            color: #2c3e50;
            margin-bottom: 10px;
            display: block;
            text-align: left;
        }

        .form-control {
            width: 100%;
            padding: 10px;
            margin-bottom: 15px;
            border-radius: 6px;
            border: 1px solid #ccc;
        }

        .btn {
            padding: 12px 25px;
            font-size: 16px;
            background-color: #3498db;
            color: white;
            border: none;
            cursor: pointer;
            border-radius: 8px;
            margin-top: 15px;
            transition: background-color 0.3s, transform 0.3s;
        }

        .btn:hover {
            background-color: #2980b9;
            transform: translateY(-5px);
        }

        .btn:active {
            transform: translateY(2px);
        }

        .btn-secondary {
            background-color: #95a5a6;
            margin-top: 20px;
        }

        .message {
            margin-top: 20px;
            font-weight: bold;
            color: green;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Asignar Curso a Estudiante</h2>

            <label>Estudiante:</label>
            <asp:DropDownList ID="ddlEstudiantes" runat="server" Width="100%" CssClass="form-control"></asp:DropDownList>

            <label>Curso:</label>
            <asp:DropDownList ID="ddlCursos" runat="server" Width="100%" CssClass="form-control"></asp:DropDownList>

            <asp:Button ID="btnAsignar" runat="server" Text="Asignar Curso" OnClick="btnAsignar_Click" CssClass="btn" />
            <asp:Button ID="Button1" runat="server" Text="Volver al Inicio" OnClick="btnSalir_Click" CssClass="btn btn-secondary" />

            <asp:Label ID="lblMensaje" runat="server" CssClass="message" />
        </div>
    </form>
</body>
</html>
