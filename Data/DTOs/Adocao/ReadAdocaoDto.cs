using System.ComponentModel.DataAnnotations;

namespace AdoPet.Models;

/// <summary>
/// Classe mãe, responsavel pelo mapeamento dos campos, para inserção ou consulta ao banco.
/// </summary>
public class ReadAdocaoDto
{
    /// <summary>
    /// Nome do Tutor
    /// </summary>
    public int Pet { get; set; }

    /// <summary>
    /// Nome do Tutor
    /// </summary>
    public int Tutor { get; set; }

    /// <summary>
    /// Nome do Tutor
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Hora da Consulta
    /// </summary>
    public DateTime HoraDaConsulta { get; set; } = DateTime.Now;

}
