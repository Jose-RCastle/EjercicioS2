using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Curso
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int unidadesValorativas { get; set; }

    public int ProfesorId { get; set; }
    public Profesor Profesor { get; set; }
}
