using System.ComponentModel.DataAnnotations;

namespace Data.DTOs.Abrigo;

/// <summary>
/// Classe Responsabel pela leitura do cadastro
/// </summary>
public class ReadAbrigoDto
{
    /// <summary>
    /// Id do cadsatro do abrigo
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Responsavel pelo abrigo
    /// </summary>
    public string? Responsable { get; set; }

    /// <summary>
    /// Endereço principal do abrigo
    /// </summary>
    public string? Address1 { get; set; }

    /// <summary>
    /// Complemento do abrigo
    /// </summary>
    public string? Address2 { get; set; }


    /// <summary>
    /// numero do endereço do abrigo
    /// </summary>
    public string? AddressNumber { get; set; }

    /// <summary>
    /// Cidade do Abrigo
    /// </summary>
    public string? City { get; set; }


    /// <summary>
    /// Estado o Abrigo
    /// </summary>
    public string? State { get; set; }


    /// <summary>
    /// Status do Abrigo, ativo ou não
    /// </summary>
    public bool? Active { get; set; }

}
