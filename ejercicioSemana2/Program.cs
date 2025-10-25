using System;

class Program
{
    static void Main(string[] args)
    {
        var contexto = new UniversidadContext();

        Console.WriteLine("INICIO PRUEBAS CEUTEC");

        //Agregar estudiantes
        Console.WriteLine("\nAgregando Estudiantes");
        contexto.agregar(new Estudiante { Nombre = "Juan Perez", Email = "juan@ceutec.com", Activo = true });
        contexto.agregar(new Estudiante { Nombre = "Maria Lopez", Email = "maria@ceutec.com", Activo = true });
        contexto.agregar(new Estudiante { Nombre = "Carlos Ruiz", Email = "carlos@ceutec.com", Activo = false });

        Console.WriteLine($"Estudiantes registrados: {contexto.Estudiantes.Count}");

        //Agregar profesores
        Console.WriteLine("\nAgregando Profesores");
        contexto.agregar(new Profesor { Nombre = "Ana Garcia", Email = "ana@ceutec.com", Especializacion = "Programación Web" });
        contexto.agregar(new Profesor { Nombre = "Luis Martinez", Email = "luis@ceutec.com", Especializacion = "Base de Datos" });
        contexto.agregar(new Profesor { Nombre = "Marta Rodriguez", Email = "marta@ceutec.com", Especializacion = "Programación Movil" });

        Console.WriteLine($"Profesores registrados: {contexto.Profesores.Count}");

        //Agregar cursos
        Console.WriteLine("\nAgregando Cursos");
        contexto.agregar(new Curso { Nombre = "ASP.NET Core", unidadesValorativas = 3, ProfesorId = 1 });
        contexto.agregar(new Curso { Nombre = "SQL Server", unidadesValorativas = 2, ProfesorId = 2 });
        contexto.agregar(new Curso { Nombre = "C# Avanzado", unidadesValorativas = 4, ProfesorId = 3 });
        contexto.agregar(new Curso { Nombre = "Entity Framework", unidadesValorativas = 3, ProfesorId = 1 });

        Console.WriteLine($"Cursos registrados: {contexto.Cursos.Count}");

        //MÉTODO 3
        Console.WriteLine("\nPRUEBA MÉTODO 3: BuscarEstudiantePorEmail");
        var estudianteEncontrado = contexto.BuscarEstudiantePorEmail("maria@ceutec.com");
        if (estudianteEncontrado != null)
        {
            Console.WriteLine($"ENCONTRADO: {estudianteEncontrado.Nombre} (Email: {estudianteEncontrado.Email}, Activo: {estudianteEncontrado.Activo})");
        }
        else
        {
            Console.WriteLine("Estudiante no encontrado");
        }

        // Probar con email que no existe
        var estudianteNoExiste = contexto.BuscarEstudiantePorEmail("noexiste@test.com");
        Console.WriteLine(estudianteNoExiste == null ? "Correcto: Email no existe" : "Error: Email debería no existir");

        //MÉTODO 4
        Console.WriteLine("\nPRUEBA MÉTODO 4: ObtenerProfesoresPorEspecializacion");
        var profesoresProgramacion = contexto.ObtenerProfesoresPorEspecializacion("programación");
        Console.WriteLine($"Profesores con 'Programación': {profesoresProgramacion.Count}");
        foreach (var prof in profesoresProgramacion)
        {
            Console.WriteLine($"  - {prof.Nombre}: {prof.Especializacion}");
        }

        //MÉTODO 5
        Console.WriteLine("\nPRUEBA MÉTODO 5: ActualizarUnidadesValorativas");

        // Caso 1
        Console.WriteLine("Caso 1: Actualización válida:");
        bool resultado1 = contexto.ActualizarUnidadesValorativas(1, 2);
        Console.WriteLine($"Resultado: {(resultado1 ? "Éxito" : "Falló")}");

        // Caso 2
        Console.WriteLine("\nCaso 2: Unidades fuera de rango (5):");
        bool resultado2 = contexto.ActualizarUnidadesValorativas(2, 5);
        Console.WriteLine($"Resultado: {(resultado2 ? "Éxito" : "Falló ")}");

        // Caso 3
        Console.WriteLine("\nCaso 3: Curso no existe (ID 99):");
        bool resultado3 = contexto.ActualizarUnidadesValorativas(99, 2);
        Console.WriteLine($"Resultado: {(resultado3 ? "Éxito" : "Falló ")}");

        Console.WriteLine("\nRESUMEN FINAL");
        Console.WriteLine($"Total estudiantes: {contexto.Estudiantes.Count}");
        Console.WriteLine($"Total profesores: {contexto.Profesores.Count}");
        Console.WriteLine($"Total cursos: {contexto.Cursos.Count}");

        Console.WriteLine("\nTODAS LAS PRUEBAS COMPLETADAS");
        Console.WriteLine("Presiona cualquier tecla para salir");
        Console.ReadKey();
    }
}