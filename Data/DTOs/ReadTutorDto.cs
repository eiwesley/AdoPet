using System.ComponentModel.DataAnnotations;

namespace AdoPet.Data.DTOs;

public class ReadTutorDto
{
    public string Nome { get; set; }

    public string Email { get; set; }

    public string Senha { get; set; }

    public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
}
