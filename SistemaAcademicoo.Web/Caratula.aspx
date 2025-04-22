<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Carátula - Sistema de Gestión Académica</title>
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

        .caratula-container {
            background-color: white;
            padding: 40px;
            width: 600px;
            text-align: center;
            border-radius: 12px;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
        }

        h1 {
            font-size: 2.5rem;
            color: #2c3e50;
            margin-bottom: 20px;
        }

        h2, h3 {
            font-size: 1.5rem;
            color: #34495e;
            margin-bottom: 10px;
        }

        p {
            font-size: 1.2rem;
            color: #7f8c8d;
            margin-bottom: 10px;
        }

        .highlight {
            font-weight: bold;
            color: #2980b9;
        }

        .footer {
            margin-top: 30px;
            font-size: 1.1rem;
            color: #34495e;
        }

        .footer span {
            color: #2980b9;
        }

        .btn-inicio {
            margin-top: 30px;
            padding: 12px 24px;
            background-color: #3498db;
            color: white;
            border: none;
            cursor: pointer;
            border-radius: 8px;
            font-size: 16px;
        }

        .btn-inicio:hover {
            background-color: #2980b9;
        }
    </style>
</head>
<body>

    <div class="caratula-container">
        <h1>UNIVERSIDAD TÉCNICA DE AMBATO</h1>
        <h2>CARRERA DE TECNOLOGÍAS DE INFORMACIÓN</h2>

        <h3>TEMA: SISTEMA DE GESTIÓN ACADÉMICA</h3>

        <p><span class="highlight">INTEGRANTES:</span> Michael Falcon, Sebastián Salazar, Alexander Tituaña</p>

        

        <!-- Botón para ir al formulario de inicio -->
        <a href="Inicio.aspx">
            <button class="btn-inicio">Abrir</button>
        </a>
    </div>

</body>
</html>
