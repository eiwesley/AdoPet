using System.ComponentModel.DataAnnotations;

namespace AdoPet.Data.DTOs;

/// <summary>
/// Classe Responsabel pela criação do cadastro
/// </summary>
public class CreateTutorDto
{
    /// <summary>
    /// Nome do Tutor
    /// </summary>
    [Required(ErrorMessage = "O nome para cadastro é obrigatório!")]
    [StringLength(50, ErrorMessage = "O tamanho do npme nao pode exceder 50 caracteres")]
    public string? Name { get; set; }

    /// <summary>
    /// Email do Tutor
    /// </summary>
    [Required(ErrorMessage = "O e-mail para cadastro é obrigatorio!")]
    [StringLength(50, ErrorMessage = "O tamanho do e-mail nao pode exceder 50 caracteres")]
    public string? Email { get; set; }

    /// <summary>
    /// Senha de acesso do Tutor
    /// </summary>
    [Required(ErrorMessage = "A senha para cadastro é obrigatoria!")]
    [StringLength(20, ErrorMessage = "O tamanho da senha nao pode exceder 20 caracteres")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    /// <summary>
    /// Nome do Pet do tutoe
    /// </summary>
    public string? PetName { get; set; }

    /// <summary>
    /// Imagem do tutor
    /// </summary>
    public string? Image { get; set; }

    /// <summary>
    /// Tutor ativo ou não.
    /// </summary>
    public Boolean Active { get; set; } = true;
}
