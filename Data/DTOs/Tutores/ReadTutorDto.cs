using AdoPet.Models;
using Models.Models;
using System.ComponentModel.DataAnnotations;

namespace Data.DTOs.Tutor;

/// <summary>
/// Classe Responsabel por retornar os dados consultados
/// </summary>
public class ReadTutorDto
{
    /// <summary>
    /// ID do tutor cadastrado no banco
    /// </summary>
    [Key]
    [Required]
    public int Id { get; set; }

    /// <summary>
    /// Nome do Tutor
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Email do Tutor
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Senha de acesso do Tutor
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// Lista de Pets do tutor
    /// </summary>
    public List<Pet>? Pets { get; set; }

    /// <summary>
    /// Imagem do tutor
    /// </summary>
    public string? Image { get; set; }

    /// <summary>
    /// Tutor ativo ou não.
    /// </summary>
    public Boolean Active { get; set; }

    /// <summary>
    /// Tipo de Perfil - Adm, Tutor, etc....
    /// </summary>
    public string? Profile { get; set; }

    /// <summary>
    /// Lista de adoções do tutor
    /// </summary>
    public List<Adocao>? Adocoes { get; set; }

    /// <summary>
    /// Hora da Consulta
    /// </summary>
    public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
}
