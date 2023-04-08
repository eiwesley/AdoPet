using System.ComponentModel.DataAnnotations;

namespace AdoPet.Models;

/// <summary>
/// Classe mãe, responsavel pelo mapeamento dos campos, para inserção ou consulta ao banco.
/// </summary>
public class CreateAdocaoDto
{
    /// <summary>
    /// Nome do Tutor
    /// </summary>
    [Required(ErrorMessage = "O ID do Pet é obrigatório!")]
    public int Pet { get; set; }

    /// <summary>
    /// Nome do Tutor
    /// </summary>
    [Required(ErrorMessage = "O ID do Tutor é obrigatório!")]
    public int Tutor { get; set; }

    /// <summary>
    /// Nome do Tutor
    /// </summary>
    [Required(ErrorMessage = "A Data de Adoção é obrigatória!")]
    public DateTime Date { get; set; } = DateTime.Now;

}
