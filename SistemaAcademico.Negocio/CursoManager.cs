using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaAcademico.Datos; // Asegúrate de que la ruta sea correcta para tu proyecto

namespace SistemaAcademico.Negocio
{

    public class CursoManager
    {
        // Instancia del DbContext
        // Esta clase se encarga de gestionar las operaciones relacionadas con los cursos.

        private SistemaAcademicoDbContext db = new SistemaAcademicoDbContext();

        // Registrar un nuevo curso
        // Este método recibe un objeto Curso y lo agrega a la base de datos.
        // Si el curso ya existe, lanza una excepción.
        // Se utiliza el método Any() para verificar si ya existe un curso con el mismo ID.
        // Si no existe, se agrega el curso a la base de datos y se guardan los cambios.
        // Si ocurre un error, se lanza una excepción con un mensaje de error.
        public string RegistrarCurso(Curso curso)
        {
            try
            {
                if (db.Cursos.Any(c => c.CursoId == curso.CursoId))
                    return "Ya existe un curso con ese ID. Verifique el ID.";  // Mensaje si el curso ya existe

                db.Cursos.Add(curso);
                db.SaveChanges();
                return "Curso registrado con éxito.";  // Mensaje de éxito
            }
            catch (Exception ex)
            {
                return "Error al registrar el curso: " + ex.Message;  // Mensaje de error
            }
        }


        // Obtener todos los cursos
        // Este método devuelve una lista de todos los cursos en la base de datos.
        // Se utiliza el método ToList() para convertir la consulta en una lista.
        // Si ocurre un error, se lanza una excepción con un mensaje de error.

        public List<Curso> ObtenerTodos()
        {
            try
            {
                return db.Cursos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de cursos. " + ex.Message);
            }
        }

        // Obtener un curso por su ID
        // Este método recibe un ID de curso y busca el curso correspondiente en la base de datos.
        // Si el curso no existe, lanza una excepción.
        // Se utiliza el método FirstOrDefault() para buscar el curso.
        // Si ocurre un error, se lanza una excepción con un mensaje de error.
        public Curso ObtenerPorId(int cursoId)
        {
            try
            {
                var curso = db.Cursos.FirstOrDefault(c => c.CursoId == cursoId);
                if (curso == null)
                    throw new Exception("Curso no encontrado. Verifique el Curso");
                return curso;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el curso. " + ex.Message);
            }
        }

        // Actualizar curso
        // Este método recibe un objeto Curso actualizado y lo busca en la base de datos.
        // Si el curso no existe, lanza una excepción.
        // Se actualizan los campos del curso existente con los nuevos valores.
        // Luego se guardan los cambios en la base de datos.
        // Si ocurre un error, se lanza una excepción con un mensaje de error.
        public string ActualizarCurso(Curso cursoActualizado)
        {
            try
            {
                var cursoExistente = db.Cursos.FirstOrDefault(c => c.CursoId == cursoActualizado.CursoId);

                if (cursoExistente == null)
                    return "El curso no existe. Verifique el Curso.";  // Mensaje si el curso no se encuentra

                cursoExistente.Nombre = cursoActualizado.Nombre;
                cursoExistente.Descripcion = cursoActualizado.Descripcion;

                db.SaveChanges();
                return "Curso actualizado con éxito.";  // Mensaje de éxito
            }
            catch (Exception ex)
            {
                return "Error al actualizar el curso: " + ex.Message;  // Mensaje de error
            }
        }


        // Eliminar curso
        // Este método recibe un ID de curso y busca el curso correspondiente en la base de datos.
        // Si el curso no existe, lanza una excepción.
        // Se utiliza el método FirstOrDefault() para buscar el curso.
        // Si el curso existe, se elimina de la base de datos y se guardan los cambios.
        // Si ocurre un error, se lanza una excepción con un mensaje de error.
        public string EliminarCurso(int cursoId)
        {
            try
            {
                var curso = db.Cursos.FirstOrDefault(c => c.CursoId == cursoId);

                if (curso == null)
                    return "El curso no existe. Verifique el Curso.";  // Mensaje si el curso no se encuentra

                db.Cursos.Remove(curso);
                db.SaveChanges();
                return "Curso eliminado con éxito.";  // Mensaje de éxito
            }
            catch (Exception ex)
            {
                return "Error al eliminar el curso: " + ex.Message;  // Mensaje de error
            }
        }

    }
}


