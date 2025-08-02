using System;

class Program
{
    static void Main(string[] args)
    {
        var contexto = new UniversidadContext();

        var estudiante = new Estudiante
        {
            Nombre = "Juan Perez",
            Email = "juan@test.com",
            Activo = true
        };

        contexto.agregar(estudiante);
        Console.WriteLine($"Estudiante creado: {estudiante.Nombre} (ID: {estudiante.Id}) (Estado: {estudiante.Activo}) (Email: {estudiante.Email})");
        Console.WriteLine($"Total de estudiantes registrados: {contexto.Estudiantes.Count}");

        var estudiante2 = new Estudiante
        {
            Nombre = "Carlos Valderrama",
            Email = "carlos@test.com",
            Activo = false
        };
        contexto.agregar(estudiante2);
        Console.WriteLine($"Estudiante creado: {estudiante2.Nombre} (ID: {estudiante2.Id}) (Estado: {estudiante2.Activo}) (Email: {estudiante2.Email})");
        Console.WriteLine($"Total de estudiantes registrados: {contexto.Estudiantes.Count}");
    }
}