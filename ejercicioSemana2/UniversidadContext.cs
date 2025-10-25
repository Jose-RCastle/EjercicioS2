using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UniversidadContext
{
    public List<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
    public List<Profesor> Profesores { get; set; }   = new List<Profesor>();
    public List<Curso> Cursos { get; set; } = new List<Curso>();

    public void agregar(Estudiante estudiante)
    {
        estudiante.Id = Estudiantes.Count + 1;
        Estudiantes.Add(estudiante);
    }
    public void agregar(Profesor profesor)
    {
        profesor.Id = Profesores.Count + 1;
        Profesores.Add(profesor);
    }

    public void agregar(Curso curso)
    {
        curso.Id = Cursos.Count + 1;
        Cursos.Add(curso);
    }
    public Estudiante BuscarEstudiantePorEmail(string email)
    {
        return Estudiantes.FirstOrDefault(e =>
            e.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
    }

    public List<Profesor> ObtenerProfesoresPorEspecializacion(string especializacion)
    {
        return Profesores
            .Where(p => p.Especializacion.ToLower().Contains(especializacion.ToLower()))
            .OrderBy(p => p.Nombre)
            .ToList();
    }
    public bool ActualizarUnidadesValorativas(int cursoId, int nuevasUnidades)
    {
        if (nuevasUnidades < 1 || nuevasUnidades > 4)
        {
            Console.WriteLine("Error: Las unidades valorativas deben estar entre 1 y 4");
            return false;
        }

        var curso = Cursos.FirstOrDefault(c => c.Id == cursoId);
        if (curso == null)
        {
            Console.WriteLine($"Error: No se encontró el curso con ID {cursoId}");
            return false;
        }

        curso.unidadesValorativas = nuevasUnidades;
        Console.WriteLine($"Curso '{curso.Nombre}' actualizado a {nuevasUnidades} unidades valorativas");
        return true;
    }
}
