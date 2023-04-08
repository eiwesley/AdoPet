using System.ComponentModel.DataAnnotations;

namespace Data.DTOs.Pet;
/// <summary>
/// Classe Responsabel pela atualização do cadastro do pet
/// </summary>
public class UpdatePetDto
{
    /// <summary>
    /// Nome do Pet
    /// </summary>
    [Required(ErrorMessage = "O nome para cadastro é obrigatório!")]
    [MaxLength(50, ErrorMessage = "O tamanho do nome nao pode exceder 50 caracteres")]
    public string? Name { get; set; }

    /// <summary>
    /// Sexo do Pet
    /// </summary>
    [Required(ErrorMessage = "O sexo para cadastro é obrigatorio!")]
    [MaxLength(10, ErrorMessage = "O tamanho do sexo nao pode exceder 10 caracteres. Escolha entre Feminino e Masculino")]
    public string? Sex { get; set; }

    /// <summary>
    /// Idade do Pet
    /// </summary>
    [Required(ErrorMessage = "A idade para cadastro é obrigatoria!")]
    [Range(0, 30, ErrorMessage = "A idade do Pet deve ser entre 0 e 30 anos")]
    public double Age { get; set; }

    /// <summary>
    /// A raça do pet
    /// </summary>
    [Required(ErrorMessage = "A raça para cadastro é obrigatoria!")]
    [MaxLength(50, ErrorMessage = "O raça nao pode exceder 50 caracteres.")]
    public string? Breed { get; set; }

    /// <summary>
    /// A personalidade predominante do pet
    /// </summary>
    [Required(ErrorMessage = "A personalidade predominante para cadastro é obrigatoria!")]
    [MaxLength(50, ErrorMessage = "A personalidade nao pode exceder 50 caracteres.")]
    public string? Personality { get; set; }

    /// <summary>
    /// Cidade de Cadastro do Pet
    /// </summary>
    [Required(ErrorMessage = "A Cidade onde o pet esta para cadastro é obrigatorio!")]
    [MaxLength(50, ErrorMessage = "A cidade nao pode exceder 50 caracteres.")]
    public string? City { get; set; }

    /// <summary>
    /// Estado de Cadastro do Pet
    /// </summary>
    [Required(ErrorMessage = "O estado onde o pet esta para cadastro é obrigatorio!")]
    [MaxLength(2, ErrorMessage = "O estado nao pode exceder 2 caracteres. Utilize a silga de do estado.")]
    public string? UF { get; set; }

    /// <summary>
    /// Imagem de perfil do Pet
    /// </summary>
    [Required(ErrorMessage = "A imagem do pet para cadastro é obrigatorio!")]
    public string? ProfilePic { get; set; }

    /// <summary>
    /// Especie do Pet
    /// </summary>
    [Required(ErrorMessage = "A especie do pet para cadastro é obrigatorio!")]
    [MaxLength(50, ErrorMessage = "A especie nao pode exceder 50 caracteres. Utilize 'DOG ou CAT'.")]
    public string? Species { get; set; }

    /// <summary>
    /// Porte do pet
    /// </summary>
    [Required(ErrorMessage = "O porte do pet para cadastro é obrigatorio!")]
    [MaxLength(50, ErrorMessage = "O porte nao pode exceder 50 caracteres. Utilize 'Mini, Small, Medium, Large, Giant'.")]
    public string? Size { get; set; }

    /// <summary>
    /// Status do Pet
    /// </summary>
    [Required(ErrorMessage = "A status do pet para cadastro é obrigatorio!")]
    [MaxLength(50, ErrorMessage = "A status nao pode exceder 50 caracteres. Utilize 'New, Available, Adopted, Quarantane, Removed, Suspended'.")]
    public string? Status { get; set; }

    /// <summary>
    /// Responsavel pelo pet
    /// </summary>
    public string? Owner { get; set; }

    /// <summary>
    /// Data de Adoção
    /// </summary>
    public DateTime? AdoptedDate { get; set; }
}

