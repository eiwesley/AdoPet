using System.ComponentModel.DataAnnotations;

namespace Data.DTOs.Pet;
/// <summary>
/// Classe Responsabel pela leitura do cadastro do pet
/// </summary>
public class ReadPetDto
{
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
    /// Responsavel pelo pet
    /// </summary>
    public string? Owner { get; set; }

    /// <summary>
    /// Data de Adoção
    /// </summary>
    public DateTime? AdoptedDate { get; set; }

    /// <summary>
    /// Hora da Consulta
    /// </summary>
    public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
}

