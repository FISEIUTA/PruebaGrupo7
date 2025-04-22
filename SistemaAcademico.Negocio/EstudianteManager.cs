using System;
using System.Collections.Generic;
using System.Linq;
using SistemaAcademico.Datos;

namespace SistemaAcademico.Negocio
{
    // Esta clase se encarga de gestionar las operaciones relacionadas con los estudiantes.
    // Todo el Proceso Crud de los estudiantes
    public class EstudianteManager
    {
        // Instancia del contexto de la base de datos
        // Esta clase se encarga de gestionar las operaciones relacionadas con los estudiantes.
        // Se utiliza el patrón de diseño Singleton para asegurar que solo haya una instancia de la base de datos.
        // Se crea una instancia de la clase SistemaAcademicoDbContext para interactuar con la base de datos.
        private SistemaAcademicoDbContext db = new SistemaAcademicoDbContext();

        // Registrar un nuevo estudiante
        // Este método recibe un objeto Estudiante y lo agrega a la base de datos.
        // Si el estudiante ya existe, lanza una excepción.
        // Se utiliza el método Any() para verificar si ya existe un estudiante con la misma cédula.
        // Si no existe, se agrega el estudiante a la base de datos y se guardan los cambios.
        // Si ocurre un error, se lanza una excepción con un mensaje de error.
        public string RegistrarEstudiante(Estudiante estudiante)
        {
            try
            {
                // Verifica si ya existe un estudiante con la misma cédula
                if (db.Estudiantes.Any(e => e.CedulaId == estudiante.CedulaId))
                    return "Ya existe un estudiante con esa cédula.";  // Mensaje si ya existe un estudiante

                db.Estudiantes.Add(estudiante);
                db.SaveChanges();
                return "Estudiante registrado con éxito.";  // Mensaje de éxito
            }
            catch (Exception ex)
            {
                return "Error al registrar el estudiante: " + ex.Message;  // Mensaje de error
            }
        }


        // Obtener todos los estudiantes
        // Este método devuelve una lista de todos los estudiantes en la base de datos.
        // Se utiliza el método ToList() para convertir la consulta en una lista.
        // Si ocurre un error, se lanza una excepción con un mensaje de error.

        public List<Estudiante> ObtenerTodos()
        {
            try
            {
                return db.Estudiantes.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de estudiantes. " + ex.Message);
            }
        }

        // Obtener un estudiante por su cédula
        // Este método recibe un ID de cédula y busca el estudiante correspondiente en la base de datos.
        // Si el estudiante no existe, lanza una excepción.
        // Se utiliza el método FirstOrDefault() para buscar el estudiante.
        // Si ocurre un error, se lanza una excepción con un mensaje de error.
        // Este método devuelve el estudiante encontrado.
        public Estudiante ObtenerPorCedula(int cedulaId)
        {
            try
            {
                var estudiante = db.Estudiantes.FirstOrDefault(e => e.CedulaId == cedulaId);
                if (estudiante == null)
                    throw new Exception("Estudiante no encontrado.");
                return estudiante;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el estudiante. " + ex.Message);
            }
        }

        // Actualizar estudiante
        // Este método recibe un objeto Estudiante actualizado y busca el estudiante correspondiente en la base de datos.
        // Si el estudiante no existe, lanza una excepción.
        // Se utiliza el método FirstOrDefault() para buscar el estudiante.
        // Si el estudiante existe, se actualizan sus propiedades con los nuevos valores.
        // Luego, se guardan los cambios en la base de datos.
        // Si ocurre un error, se lanza una excepción con un mensaje de error.
        // Este método no devuelve nada.

        public string ActualizarEstudiante(Estudiante estudianteActualizado)
        {
            try
            {
                // Verifica si el estudiante existe en la base de datos
                var estudianteExistente = db.Estudiantes.FirstOrDefault(e => e.CedulaId == estudianteActualizado.CedulaId);

                if (estudianteExistente == null)
                    return "El estudiante no existe. Verifique el número de cédula.";  // Mensaje si no existe el estudiante

                // Actualiza los datos del estudiante
                estudianteExistente.Nombre = estudianteActualizado.Nombre;
                estudianteExistente.Apellido = estudianteActualizado.Apellido;
                estudianteExistente.CorreoElectronico = estudianteActualizado.CorreoElectronico;
                estudianteExistente.Telefono = estudianteActualizado.Telefono;

                db.SaveChanges();
                return "Estudiante actualizado con éxito.";  // Mensaje de éxito
            }
            catch (Exception ex)
            {
                return "Error al actualizar el estudiante: " + ex.Message;  // Mensaje de error
            }
        }


        // Eliminar estudiante
        // Este método recibe un ID de cédula y busca el estudiante correspondiente en la base de datos.
        // Si el estudiante no existe, lanza una excepción.
        // Se utiliza el método FirstOrDefault() para buscar el estudiante.
        // Si el estudiante existe, se elimina de la base de datos.
        // Luego, se guardan los cambios en la base de datos.
        // Si ocurre un error, se lanza una excepción con un mensaje de error.
        public string EliminarEstudiante(int cedulaId)
        {
            try
            {
                var estudiante = db.Estudiantes.FirstOrDefault(e => e.CedulaId == cedulaId);

                if (estudiante == null)
                    return "El estudiante no existe. Verifique el número de cédula.";

                db.Estudiantes.Remove(estudiante);
                db.SaveChanges();

                return "Estudiante eliminado con éxito.";
            }
            catch (Exception ex)
            {
                return "Error al eliminar el estudiante: " + ex.Message;
            }
        }

    }
}
