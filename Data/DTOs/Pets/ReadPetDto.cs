using AdoPet.Models;
using Models.Models;
using System.ComponentModel.DataAnnotations;

namespace Data.DTOs.Pets;
/// <summary>
/// Classe Responsabel pela leitura do cadastro do pet
/// </summary>
public class ReadPetDto
{
    /// <summary>
    /// ID do pet cadastrado no banco
    /// </summary>
    [Key]
    [Required]
    public int Id { get; set; }

    /// <summary>
    /// Nome do Pet
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Sexo do Pet
    /// </summary>
    public string? Sex { get; set; }

    /// <summary>
    /// Idade do Pet
    /// </summary>
    public double Age { get; set; }

    /// <summary>
    /// A raça do pet
    /// </summary>
    public string? Breed { get; set; }

    /// <summary>
    /// A personalidade predominante do pet
    /// </summary>
    public string? Personality { get; set; }

    /// <summary>
    /// Cidade de Cadastro do Pet
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// Estado de Cadastro do Pet
    /// </summary>
    public string? UF { get; set; }

    /// <summary>
    /// Imagem de perfil do Pet
    /// </summary>
    public string? ProfilePic { get; set; }

    /// <summary>
    /// Especie do Pet
    /// </summary>
    public string? Species { get; set; }

    /// <summary>
    /// Porte do pet
    /// </summary>
    public string? Size { get; set; }

    /// <summary>
    /// Status do Pet
    /// </summary>
    public string? Status { get; set; }

    /// <summary>
    /// Objeto Adocao
    /// </summary>
    public Adocao? Adocao { get; set; }

    /// <summary>
    /// UserID do Tutor do Pet
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// ID do Abrigo
    /// </summary>
    public int AbrigoId { get; set; }

    /// <summary>
    /// Abrigo aonde o Pet esta habitando
    /// </summary>
    public virtual Abrigo? Abrigo { get; set; }

    /// <summary>
    /// Hora da Consulta
    /// </summary>
    public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
}

