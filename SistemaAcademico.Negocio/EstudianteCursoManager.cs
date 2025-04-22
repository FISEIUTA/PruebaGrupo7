using System;
using System.Collections.Generic;
using System.Linq;
using SistemaAcademico.Datos;

namespace SistemaAcademico.Negocio
{
    public class EstudianteCursoManager
    {
        private readonly SistemaAcademicoDbContext db = new SistemaAcademicoDbContext();

        // Matricular estudiante en un curso
        // Este método recibe la cédula del estudiante y el ID del curso y los relaciona en la base de datos.
        // Se utiliza el método Any() para verificar si ya existe una matrícula con la misma cédula y curso.
        // Si no existe, se crea una nueva matrícula y se guarda en la base de datos.
        // Si ocurre un error, se lanza una excepción con un mensaje de error.
        // Se utiliza el método Add() para agregar la nueva matrícula a la base de datos.
        // Se utiliza el método SaveChanges() para guardar los cambios en la base de datos.
        // Se utiliza el método FirstOrDefault() para buscar la matrícula.
        // Se utiliza el método Remove() para eliminar la matrícula de la base de datos.
        // Se utiliza el método ToList() para convertir la consulta en una lista.
        // Se utiliza el método Select() para proyectar los resultados de la consulta.
        // Se utiliza el método Where() para filtrar los resultados de la consulta.
        public string MatricularEstudiante(int cedulaId, int cursoId)
        {
            try
            {
                var existe = db.EstudiantesCursos.Any(ec => ec.CedulaId == cedulaId && ec.CursoId == cursoId);
                if (!existe)
                {
                    var nuevaMatricula = new EstudianteCurso
                    {
                        CedulaId = cedulaId,
                        CursoId = cursoId
                    };
                    db.EstudiantesCursos.Add(nuevaMatricula);
                    db.SaveChanges();
                    return "Estudiante matriculado con éxito en el curso."; // Mensaje de éxito
                }
                else
                {
                    return "El estudiante ya está matriculado en este curso."; // Mensaje si ya está matriculado
                }
            }
            catch (Exception ex)
            {
                return "Error al matricular estudiante: " + ex.Message; // Mensaje de error
            }
        }


        // Obtener cursos por estudiante
        // Este método recibe la cédula del estudiante y busca los cursos correspondientes en la base de datos.
        // Se utiliza el método Where() para filtrar los resultados de la consulta.
        // Se utiliza el método Select() para proyectar los resultados de la consulta.
        // Se utiliza el método ToList() para convertir la consulta en una lista.
        // Si ocurre un error, se lanza una excepción con un mensaje de error.
        // Se utiliza el método FirstOrDefault() para buscar la matrícula.
        // Se utiliza el método Remove() para eliminar la matrícula de la base de datos.
        // Se utiliza el método SaveChanges() para guardar los cambios en la base de datos.
        // Se utiliza el método Any() para verificar si ya existe una matrícula con la misma cédula y curso.
        // Se utiliza el método Add() para agregar la nueva matrícula a la base de datos.

        public List<Curso> ObtenerCursosPorEstudiante(int cedulaId)
        {
            try
            {
                return db.EstudiantesCursos
                         .Where(ec => ec.CedulaId == cedulaId)
                         .Select(ec => ec.Curso)
                         .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener cursos del estudiante: " + ex.Message);
            }
        }

        // Obtener estudiantes por curso
        // Este método recibe el ID del curso y busca los estudiantes correspondientes en la base de datos.
        // Se utiliza el método Where() para filtrar los resultados de la consulta.
        // Se utiliza el método Select() para proyectar los resultados de la consulta.
        // Se utiliza el método ToList() para convertir la consulta en una lista.
        // Si ocurre un error, se lanza una excepción con un mensaje de error.
        // Se utiliza el método FirstOrDefault() para buscar la matrícula.

        public List<Estudiante> ObtenerEstudiantesPorCurso(int cursoId)
        {
            try
            {
                return db.EstudiantesCursos
                         .Where(ec => ec.CursoId == cursoId)
                         .Select(ec => ec.Estudiante)
                         .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener estudiantes del curso: " + ex.Message);
            }
        }

        // Desmatricular estudiante de un curso
        // Este método recibe la cédula del estudiante y el ID del curso y elimina la relación en la base de datos.
        // Se utiliza el método FirstOrDefault() para buscar la matrícula.
        // Si la matrícula existe, se elimina de la base de datos.
        // Se utiliza el método Remove() para eliminar la matrícula de la base de datos.
        // Se utiliza el método SaveChanges() para guardar los cambios en la base de datos.
        // Si la matrícula no existe, lanza una excepción.

        public string EliminarMatricula(int cedulaId, int cursoId)
        {
            try
            {
                var matricula = db.EstudiantesCursos
                                  .FirstOrDefault(ec => ec.CedulaId == cedulaId && ec.CursoId == cursoId);

                if (matricula != null)
                {
                    db.EstudiantesCursos.Remove(matricula);
                    db.SaveChanges();
                    return "Matrícula eliminada con éxito."; // Mensaje de éxito
                }
                else
                {
                    return "La matrícula no existe."; // Mensaje si no se encuentra
                }
            }
            catch (Exception ex)
            {
                return "Error al eliminar matrícula: " + ex.Message; // Mensaje de error
            }
        }

    }
}
