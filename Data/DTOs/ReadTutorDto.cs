using System.ComponentModel.DataAnnotations;

namespace AdoPet.Data.DTOs;

public class ReadTutorDto
{
    public string Name { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string PetName { get; set; }

    public string Image { get; set; }

    public Boolean Active { get; set; }

    public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
}
