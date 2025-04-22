INFORME DE GUÍA PRÁCTICA


I.	PORTADA
Tema: Sistema de Gestión Académica
Unidad de Organización Curricular: BÁSICA
Nivel y Paralelo:	3ro TI “A”
Alumnos participantes: Falcon Yacchirema Michael Falcon
                       Salazar Villarroel Kevin Sebastián
                       Tituaña Gualoto Bryan Alexander
Asignatura:	Programación Avanzada
Docente: Ing. Caiza Caizabuano José Rubén


I.	INFORME DE GUÍA PRÁCTICA

II.	OBJETIVOS

2.1	General
Desarrollar un sistema web académico utilizando ASP.NET Web Forms que permita registrar estudiantes, administrar cursos, asignar cursos a estudiantes, y consultar esta información desde una interfaz amigable, ordenada y funcional.

2.2	Específicos
•	Crear una base de datos que permita almacenar y organizar la información personal, académica y administrativa.
•	Crear una interfaz intuitiva que facilite la gestión, consulta, modificación y eliminación de los datos de los estudiantes.
•	Incluir funciones de búsqueda y filtrado para acceder rápidamente a información específica de los estudiantes. (solo por nombre)

3.	Introducción

La gestión eficiente de la información académica y administrativa de los estudiantes es fundamental para el buen funcionamiento de cualquier institución educativa. En el contexto de la Carrera de Tecnologías de la Información, contar con un sistema que permita organizar, consultar y actualizar los datos de los estudiantes de manera ágil y segura resulta esencial. Este proyecto tiene como finalidad el desarrollo de un programa informático que facilite dicha gestión, integrando herramientas que mejoren la accesibilidad, precisión y disponibilidad de la información, contribuyendo así a una administración más eficiente y moderna.

4.	Marco Teórico

El desarrollo de sistemas de la información para la gestión de datos académicos es una práctica común en el ámbito de las Tecnologías de la Información, ya que permite automatizar procesos, mejorar la organización y garantizar el acceso rápido a la información relevante. Un sistema de gestión de estudiantes es una herramienta que centraliza y facilita el manejo de datos personales, académicos y administrativos, permitiendo a los usuarios registrar, consultar, modificar y eliminar información de manera eficiente.
Para este programa se utilizaron los siguientes conceptos fundamentales:

•	Base de datos: Son estructuras organizadas que permitan almacenar, administrar y recuperar información de forma estructurada. Aunque este proyecto puede utilizar estructuras simples, sigue los principios básicos de manejo de datos.
•	Interfaces de Usuario: El diseño de interfaces graficas o en línea de comandos facilita la interacción entre el usuario y el sistema, permitiendo realizar operaciones sin necesidad de conocimientos técnicos profundos.
•	Programación orientada a objetos: Dependiendo del lenguaje utilizado, se pueden aplicar estos paradigmas para mejorar la organización del código.
•	Validación de datos: Es un proceso esencial para asegurar que la información ingresada por los usuarios sea coherente, completa y precisa. 
5.	Listado de equipos, materiales y recursos 

Listado de equipos y materiales generales empleados en la guía práctica:
•	Laptop
•	Visual Studio 2022
•	Herramientas para Diseños
•	Acceso a Internet
6.	Desarrollo

CAPA DE SISTEMA ACADEMICO DE DATOS
El sistema académico desarrollado está basado en una arquitectura en capas, organizada de manera que cada componente tenga una responsabilidad especifica, facilitando la mantenibilidad 

y escalabilidad del proyecto. La solución está dividida en tres capas principales: la capa de presentación, la capa de lógica de negocio y la capa de acceso a datos.

En primer lugar, la capa de presentación, implementada mediante un proyecto ASP.NET Web Forms, constituye la interfaz gráfica del sistema. Esta capa permite la interacción directa del usuario con el sistema, proporcionando páginas web para la gestión de estudiantes, cursos, asignaciones y reportes. A través de controles como texbox, dropdowns, grids, botones y validadores de ASP.NET, los usuarios pueden ingresar datos y navegar por las diferentes funcionalidades disponibles. Esta capa se comunica exclusivamente con la capa de lógica de negocio, sin acceso directo a la base de datos.

Por otra parte, la capa lógica de negocio, desarrollada como una biblioteca de clases en NET Framework, encapsula la funcionalidad central del sistema. Aquí se implementan class como EstudianteManager y CursoManager, responsables de validad datos, gestionar las operaciones básicas y aplicar la lógica necesaria, como la asignación de cursos a estudiantes. Esta capa actúa como intermediaria entre la interfaz de usuario y el acceso a los datos.

Y por último la capa de acceso a datos se encarga de la comunicación con la base de datos, utilizando Entity Framework para interactuar con SQL Server. En esta biblioteca se definen las entidades principales del sistema, tales como Estudiante y Curso, con sus respectivas propiedades como nombre, cedula y código. También se implementa la clase SistemaAcademicoDbContext, 

que hereda de DbContext y getiona la conexión con la base de datos. Esta es la única capa autorizada para acceder directamente a los datos persistentes.
 
CREACION DE LA BASE DE DATOS Y CONFIGURACION DEL ENTORNO
Para gestionar la persistencia de los datos del sistema académico, se diseñó una base de datos relacional implementada en SQL Server, utilizando Entity Framework como herramienta de mapeo objeto-relacional (ORM). Esta fase del proyecto implicó la creación de las clases del modelo de datos, la configuración del contexto de base de datos (DbContext), la definición de la cadena de conexión en el archivo Web.config y la aplicación de migraciones para generar la estructura de la base de datos de manera automática.
En primer lugar, se implementaron tres clases fundamentales dentro del proyecto SistemaAcademico.Datos: Estudiante, Curso y EstudianteCurso. La clase Estudiante tiene como clave primaria el campo CedulaId, mientras que la clase Curso posee CursoId como identificador único. Para representar la relación de muchos a muchos entre estudiantes y cursos, se definió la 

clase intermedia EstudianteCurso, que contiene una clave compuesta formada por los campos CedulaId y CursoId.
A continuación, se configuró el contexto de base de datos mediante la creación de la clase SistemaAcademicoDbContext, la cual hereda de DbContext. En ella se definieron las propiedades tipo DbSet correspondientes a cada entidad, lo que permitió mapear las clases del modelo a sus respectivas tablas en la base de datos.
Posteriormente, se incluyó la cadena de conexión en el archivo Web.config del proyecto principal (SistemaAcademico.Web), bajo la sección <connectionStrings>. Esta cadena especifica el nombre del servidor de base de datos, el nombre del catálogo y la autenticación integrada con Windows:
 
Una vez finalizada la preparación del modelo y la configuración de la conexión, se procedió a habilitar las migraciones mediante la consola de administración de paquetes (Package Manager Console), ejecutando el comando:
 
Este paso generó la carpeta Migrations junto con la clase Configuration.cs, que permite gestionar cambios futuros en el modelo. Luego, se creó la migración inicial con el comando:
 Este comando generó un archivo con las instrucciones necesarias para crear las tablas correspondientes en la base de datos. Finalmente, se aplicó la migración utilizando:
 Como resultado, se creó automáticamente la base de datos SistemaAcademicoDB en el servidor SQL Server, incluyendo las tablas Estudiantes, Cursos y EstudianteCurso, visibles y gestionables a través de SQL Server Management Studio (SSMS). Además, el método Seed() fue ejecutado, aunque inicialmente no contenía datos predefinidos.
Resultados de la Base de Datos en (ssms):

Estudiantes

Cursos
 
Estudiantes_Cursos
 
Notas

Profesores

CAPA DE LOGICA DE NEGOCIO
Es La capa de lógica de negocio se implementó en el proyecto SistemaAcademico.Negocio, utilizando una biblioteca de clases en .NET Framework. Esta capa actúa como intermediaria entre la interfaz de usuario y la capa de acceso a datos, concentrando las reglas del negocio y la lógica asociada a los procesos del sistema académico. Su función principal es asegurar la correcta manipulación de los datos antes de que sean enviados o recuperados desde la base de datos.
 
EstudianteManager
La clase EstudianteManager se encarga de administrar las operaciones relacionadas con los estudiantes. Encapsula toda la lógica necesaria para realizar tareas como:
1.	Registrar estudiantes: Permite almacenar nuevos estudiantes en la base de datos, validando previamente los datos requeridos.
2.	Obtener todos los estudiantes: Recupera y devuelve una lista con todos los estudiantes registrados en el sistema.
3.	Buscar estudiante por cédula: Localiza a un estudiante específico a través de su número de cédula, que funciona como identificador único.
4.	Actualizar datos de un estudiante: Modifica información existente de un estudiante, como su nombre, correo electrónico u otros atributos.
5.	Eliminar un estudiante: Elimina permanentemente un estudiante de la base de datos a partir de su cédula.

CursoManager
La clase CursoManager centraliza la lógica relacionada con los cursos, y cumple funciones similares a las de EstudianteManager, enfocadas en esta otra entidad:
1.	Registrar cursos: Inserta un nuevo curso en la base de datos, garantizando que la información sea válida y completa.
2.	Obtener todos los cursos: Devuelve un listado de todos los cursos disponibles actualmente en el sistema.
3.	Buscar curso por ID: Permite localizar un curso específico mediante su identificador único (CursoId).
4.	Actualizar datos de un curso: Modifica la información correspondiente a un curso ya existente, incluyendo su nombre, descripción u otros datos.
5.	Eliminar un curso: Elimina un curso específico de la base de datos según su ID.

ProfesorManager
La clase ProfesorManager centraliza la lógica relacionada con los profesores desde crear hasta eliminar a un profesor.
1. Registrar profesor: Inserta un nuevo profesor en la base de datos, asegurando que todos los campos requeridos (como nombre, cédula, título académico, etc.) estén completos y sean válidos.
2. Obtener todos los profesores: Devuelve un listado completo de todos los profesores registrados actualmente en el sistema, útil para listados o selección en formularios.
3. Eliminar un profesor: Elimina de forma permanente un profesor del sistema utilizando su número de cédula como identificador. Esta operación debe validar si el profesor está relacionado con algún curso antes de proceder.

EstudianteCursoManager
La clase EstudianteCursoManager gestiona la relación muchos-a-muchos entre estudiantes y cursos, es decir, la inscripción de estudiantes en los cursos disponibles. Esta clase permite realizar las siguientes acciones:
•	Matricular estudiantes: Registra la inscripción de un estudiante en un curso determinado, asegurando que no se dupliquen las matrículas.
•	Obtener cursos de un estudiante: Lista todos los cursos en los que está inscrito un estudiante específico.
•	Obtener estudiantes de un curso: Devuelve los estudiantes que están registrados en un curso dado.
•	Eliminar matrícula: Elimina la inscripción de un estudiante en un curso, borrando la relación entre ambas entidades.
Estas clases no contienen componentes de interfaz de usuario ni acceso directo a la base de datos. Toda la lógica definida en esta capa es consumida por la capa de presentación (SistemaAcademicoo.Web), que se encarga de interpretar las acciones del usuario (como clics o entradas de texto) y coordinar las operaciones solicitadas.
CAPA DE SISTEMA ACADEMICO WEB
La capa web del sistema académico constituye el punto de entrada principal para los usuarios, brindando una interfaz amigable y accesible desde cualquier navegador. Esta capa fue desarrollada con ASP.NET Web Forms, permitiendo construir formularios dinámicos, controles visuales e interacciones que conectan directamente con la lógica de negocio. Su diseño garantiza una experiencia de usuario fluida, facilitando el uso del sistema sin necesidad de conocimientos técnicos avanzados.
 
1. Páginas Desarrolladas
El sistema académico desarrollado cuenta con una interfaz de usuario construida mediante páginas Web Forms de ASP.NET, diseñadas para facilitar la gestión de estudiantes, cursos y asignaciones. A continuación, se describen las principales páginas implementadas:
•	Carátula: Es la página de bienvenida del sistema, donde se presentan los datos institucionales como el nombre de la universidad, el nombre del proyecto, la carrera académica y los integrantes del equipo de desarrollo. Además, contiene un botón de navegación que permite acceder directamente al menú principal (Inicio.aspx).
 
•	Inicio.aspx: Representa la página principal del sistema y funciona como menú central. Contiene botones que redirigen a las distintas funcionalidades clave del sistema: registro de estudiantes, registro de cursos, asignación de cursos y consultas personalizadas.

•	Estudiantes.aspx: Esta página permite el registro de nuevos estudiantes en el sistema. El usuario puede ingresar datos como cédula de identidad, nombre completo y correo electrónico. Una vez ingresados, estos datos son almacenados en la base de datos utilizando Entity Framework.

•	Profesores.aspx: Esta página está destinada al registro de nuevos profesores en el sistema. El formulario incluye campos como número de cédula, nombre completo, correo electrónico institucional. Al completar el formulario, los datos se almacenan en la base de datos utilizando Entity Framework, garantizando una integración eficiente con el modelo de datos. También se incorpora un botón para regresar al menú principal, facilitando la navegación del usuario.
 
•	Cursos.aspx: En esta página se pueden agregar nuevos cursos al sistema. El formulario incluye campos para el nombre del curso y su descripción. Al igual que los estudiantes, los cursos son almacenados en la base de datos mediante operaciones ORM con Entity Framework. 

•	AsignacionCursos.aspx: Esta funcionalidad permite asignar uno o varios cursos a un estudiante específico. Se utilizan listas desplegables (DropDownList) para seleccionar al estudiante y al curso correspondiente. La relación se guarda en una tabla intermedia en la base de datos que representa la asociación entre ambas entidades. También se incluye un botón para regresar al menú principal.

•	ConsultaCursosEstudiante.aspx: Esta página ofrece una funcionalidad de consulta, donde se puede seleccionar a un estudiante y visualizar todos los cursos en los que está inscrito. Los resultados se muestran en un control GridView, permitiendo una presentación clara y ordenada de la información. Se incluye un botón de navegación hacia el menú principal.
 
2. Tecnologías y Herramientas Utilizadas
Para la implementación del sistema académico se utilizaron diversas tecnologías y herramientas modernas, que permitieron un desarrollo ágil y estructurado:
•	ASP.NET Web Forms: Utilizado para el diseño de la interfaz web y la construcción de las páginas del sistema.
•	C#: Lenguaje de programación principal utilizado para implementar la lógica de negocio y eventos asociados a la interfaz.
•	Entity Framework: Framework ORM que permitió mapear las clases del modelo a tablas de la base de datos y realizar operaciones CRUD de manera sencilla y eficiente.
•	SQL Server Management (ssms) : Sistema de gestión de bases de datos utilizado para almacenar de forma estructurada toda la información del sistema.
•	Visual Studio: Entorno de desarrollo integrado (IDE) empleado para la creación, configuración y despliegue del proyecto.
•	Diseño de la Interfaz Web (Esquema Visual en HTML): El sistema académico cuenta con una interfaz desarrollada en ASP.NET Web Forms, estructurada en páginas diseñadas para facilitar la gestión de estudiantes, cursos, profesores y notas.

3. Arquitectura del Proyecto
El proyecto fue desarrollado siguiendo una arquitectura por capas, que permite una separación clara de responsabilidades y facilita el mantenimiento y la escalabilidad del sistema. 
Las capas definidas son:
•	Capa de presentación (Web): Constituida por las páginas .aspx y sus archivos de código subyacente.aspx.cs. Esta capa se encarga de la interacción con el usuario final y la visualización de los datos.
•	Capa de lógica de negocio: Contiene las clases responsables de aplicar las reglas del sistema y gestionar la lógica detrás de cada operación. Esta capa procesa las solicitudes de la presentación y coordina las acciones que deben ejecutarse.
•	Capa de acceso a datos: Encargada de la comunicación directa con la base de datos. Aquí se definen las entidades del sistema y el contexto de datos, utilizando Entity Framework para facilitar la interacción y persistencia de los datos.

7.	CONCLUSIONES
El proyecto SistemaAcadémico.Web logró crear un sistema funcional de gestión académica con una estructura sólida, una navegación clara y una correcta separación entre presentación y lógica. Utiliza correctamente el modelo Web Forms, facilitando la reutilización de componentes y manteniendo una interfaz visual sencilla e intuitiva para el usuario final.

Enlace a Github: https://github.com/seba138/PAAGR7
Enlace de Azure: SysAcademic7 Team Sprint 1 Taskboard - Boards
Programa en Funcionamiento:
          
 
 
