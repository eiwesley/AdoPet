using AdoPet.Models;
using Models.Models;
using System.ComponentModel.DataAnnotations;

namespace Data.DTOs.Tutor;

/// <summary>
/// Classe Responsabel por retornar os dados para atualização
/// </summary>
public class UpdateTutorDto
{
    /// <summary>
    /// Nome do Tutor
    /// </summary>
    [Required(ErrorMessage = "O nome para cadastro é obrigatório!")]
    [MaxLength(50, ErrorMessage = "O tamanho do npme nao pode exceder 50 caracteres")]
    public string? Name { get; set; }

    /// <summary>
    /// Email do Tutor
    /// </summary>
    [Required(ErrorMessage = "O e-mail para cadastro é obrigatorio!")]
    [MaxLength(50, ErrorMessage = "O tamanho do e-mail nao pode exceder 50 caracteres")]
    public string? Email { get; set; }

    /// <summary>
    /// Senha de acesso do Tutor
    /// </summary>
    [Required(ErrorMessage = "A senha para cadastro é obrigatoria!")]
    [MaxLength(20, ErrorMessage = "O tamanho da senha nao pode exceder 20 caracteres")]
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
    [Required(ErrorMessage = "O tipo de perfil para cadastro é obrigatorio!")]
    [MaxLength(20, ErrorMessage = "O tamanho do perfil nao pode exceder 20 caracteres")]
    public string? Profile { get; set; }

    /// <summary>
    /// Lista de adoções do tutor
    /// </summary>
    public List<Adocao>? Adocoes { get; set; }
}
