using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Profesor
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Especializacion { get; set; }

    public List<Curso> Cursos { get; set; } = new List<Curso>();
}
