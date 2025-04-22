<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="SistemaAcademicoo.Web.Inicio" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inicio - Sistema Académico</title>
    <style>
        body {
            font-family: 'Segoe UI', sans-serif;
            background-color: #f4f6f8;
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
            text-align: center;
            width: 400px;
        }

        h1 {
            font-size: 2.5rem;
            color: #2c3e50;
            margin-bottom: 20px;
        }

        .menu-container {
            display: flex;
            flex-direction: column;
            gap: 15px;
        }

        .menu-button {
            padding: 15px 25px;
            font-size: 18px;
            background-color: #3498db;
            color: white;
            border: none;
            border-radius: 8px;
            cursor: pointer;
            transition: background-color 0.3s, transform 0.3s;
        }

        .menu-button:hover {
            background-color: #2980b9;
            transform: translateY(-5px);
        }

        .menu-button:active {
            transform: translateY(2px);
        }

        .menu-button:focus {
            outline: none;
        }

        .menu-button:nth-child(1) {
            background-color: #3498db;
        }

        .menu-button:nth-child(2) {
            background-color: #2ecc71;
        }

        .menu-button:nth-child(3) {
            background-color: #f39c12;
        }

        .menu-button:nth-child(4) {
            background-color: #e74c3c;
        }

        .menu-button:hover:nth-child(1) {
            background-color: #2980b9;
        }

        .menu-button:hover:nth-child(2) {
            background-color: #27ae60;
        }

        .menu-button:hover:nth-child(3) {
            background-color: #f39c12;
        }

        .menu-button:hover:nth-child(4) {
            background-color: #c0392b;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Bienvenido al Sistema Académico</h1>

            <div class="menu-container">
                <asp:Button ID="btnRegistrarEstudiante" runat="server" CssClass="menu-button" Text="Registrar Estudiante" OnClick="btnRegistrarEstudiante_Click" />
                <asp:Button ID="btnAgregarCursos" runat="server" CssClass="menu-button" Text="Agregar Cursos" OnClick="btnAgregarCursos_Click" />
                <asp:Button ID="btnAsignarCursos" runat="server" CssClass="menu-button" Text="Asignación de Cursos a Estudiantes" OnClick="btnAsignarCursos_Click" />
                <asp:Button ID="btnListadoConsultas" runat="server" CssClass="menu-button" Text="Listado de Consultas y Filtros" OnClick="btnListadoConsultas_Click" />
            </div>
        </div>
    </form>
</body>
</html>
