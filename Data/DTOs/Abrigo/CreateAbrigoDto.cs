using System.ComponentModel.DataAnnotations;

namespace Data.DTOs.Abrigo;

/// <summary>
/// Classe Responsabel pela criação do cadastro
/// </summary>
public class CreateAbrigoDto
{
    /// <summary>
    /// Responsavel pelo abrigo
    /// </summary>
    [Required(ErrorMessage = "O nome responsavel para cadastro é obrigatório!")]
    [MaxLength(50, ErrorMessage = "O tamanho do nome nao pode exceder 50 caracteres")]
    public string? Responsable { get; set; }

    /// <summary>
    /// Endereço principal do abrigo
    /// </summary>
    [Required(ErrorMessage = "O endereço para cadastro é obrigatório!")]
    [MaxLength(100, ErrorMessage = "O tamanho do endereço nao pode exceder 100 caracteres")]
    public string? Address1 { get; set; }


    /// <summary>
    /// Complemento do abrigo
    /// </summary>
    [MaxLength(50, ErrorMessage = "O tamanho do complemento nao pode exceder 50 caracteres")]
    public string? Address2 { get; set; }

    /// <summary>
    /// numero do endereço do abrigo
    /// </summary>
    [MaxLength(10, ErrorMessage = "O npumero do endereço do nome nao pode exceder 10 caracteres")]
    public string? AddressNumber { get; set; }

    /// <summary>
    /// Cidade do Abrigo
    /// </summary>
    [Required(ErrorMessage = "A cidade para cadastro é obrigatório!")]
    [MaxLength(50, ErrorMessage = "O tamanho da cidade nao pode exceder 50 caracteres")]
    public string? City { get; set; }

    /// <summary>
    /// Estado o Abrigo
    /// </summary>
    [Required(ErrorMessage = "O estado para cadastro é obrigatório!")]
    [MaxLength(2, ErrorMessage = "O tamanho do estado nao pode exceder 2 caracteres, utilizado a UF do estado!")]
    public string? State { get; set; }

    /// <summary>
    /// Status do Abrigo, ativo ou não
    /// </summary>
    [Required(ErrorMessage = "O status do local para cadastro é obrigatório!")]
    public bool Active { get; set; } = true;

}
