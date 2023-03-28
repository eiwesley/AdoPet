using System.ComponentModel.DataAnnotations;

namespace AdoPet.Models;

public class Tutores
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome para cadastro é obrigatório!")]
    [MaxLength(50, ErrorMessage = "O tamanho do npme nao pode exceder 50 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O e-mail para cadastro é obrigatorio!")]
    [MaxLength(50, ErrorMessage = "O tamanho do e-mail nao pode exceder 50 caracteres")]
    public string Email { get; set; }

    [Required(ErrorMessage = "A senha para cadastro é obrigatoria!")]
    [MaxLength(20, ErrorMessage = "O tamanho da senha nao pode exceder 20 caracteres")]
    public string Senha { get; set; }
}
