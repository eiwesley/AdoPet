using Models.Data;
using Models.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Data.DTOs.Tutor;

namespace Models.Controllers;

/// <summary>
/// Classe Responsavel por controlar os requisitos da API
/// </summary>
[ApiController]
[Route("[Controller]")]


public class TutoresController : ControllerBase
{
    private AdoPetContext _context;
    private IMapper _mapper;

    /// <summary>
    /// Metodo construtor
    /// </summary>
    /// <param name="context">retorna os dados da classe</param>
    /// <param name="mapper">Mapeia os dados para os DTOs</param>
    public TutoresController(AdoPetContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um tutor ao banco de dados
    /// </summary>
    /// <param name="tutorDto">Objeto com os campos necessários para criação de um tutor</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult CadastarTutor([FromBody] CreateTutorDto tutorDto)
    {
        User tutor = _mapper.Map<User>(tutorDto);

        _context.User.Add(tutor);
        _context.SaveChanges();

        return CreatedAtAction(nameof(BuscarTutorPorId), new { id = tutor.Id }, tutor);
    }

    /// <summary>
    /// Retorna os tutores cadastrados
    /// </summary>
    /// <param name="skip">Valor para iniciar a lista</param>
    /// <param name="take">Valor para trazer a quantidade de tutores</param>
    /// <returns>IEnumerable</returns>
    [HttpGet]
    public IEnumerable<ReadTutorDto> BuscarTutores([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadTutorDto>>(_context.User.Skip(skip).Take(take));
    }

    /// <summary>
    /// Retorna um tutor cadastrado
    /// </summary>
    /// <param name="id">ID do tutor cadastrado no banco</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet("{id}")]
    public IActionResult BuscarTutorPorId(int id)
    {
        var tutor = _context.User.FirstOrDefault(tutor => tutor.Id == id);

        if (tutor == null) return NotFound();

        var tutorDto = _mapper.Map<ReadTutorDto>(tutor);

        return Ok(tutorDto);
    }

    /// <summary>
    /// Retorna um tutor cadastrado através do E-mail
    /// </summary>
    /// <param name="email">ID do tutor cadastrado no banco</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet("email/{email}")]
    public IActionResult BuscarTutorPorEmail(string email)
    {
        var tutor = _context.User.FirstOrDefault(tutor => tutor.Email == email);

        if (tutor == null) return NotFound();

        var tutorDto = _mapper.Map<ReadTutorDto>(tutor);

        return Ok(tutorDto);
    }

    /// <summary>
    /// Desabilita o cadastro do tutor selecionado
    /// </summary>
    /// <param name="id">ID do tutor cadastrado no banco</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a alteração seja feita com sucesso</response>
    [HttpPatch("{id}/disable")]
    public IActionResult DesabilitarTutor(int id)
    {
        var tutor = _context.User.FirstOrDefault(tutor => tutor.Id == id);

        if (tutor == null) return NotFound();

        var tutorParaAtualizar = _mapper.Map<UpdateTutorDto>(tutor);
        tutorParaAtualizar.Active = false;

        _mapper.Map(tutorParaAtualizar, tutor);
        _context.SaveChanges();
        return NoContent();

    }

    /// <summary>
    /// Habilita o cadastro do tutor selecionado
    /// </summary>
    /// <param name="id">ID do tutor cadastrado no banco</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a alteração seja feita com sucesso</response>
    [HttpPatch("{id}/enable")]
    public IActionResult HabilitarTutor(int id)
    {
        var tutor = _context.User.FirstOrDefault(tutor => tutor.Id == id);

        if (tutor == null) return NotFound();

        var tutorParaAtualizar = _mapper.Map<UpdateTutorDto>(tutor);
        tutorParaAtualizar.Active = true;

        _mapper.Map(tutorParaAtualizar, tutor);
        _context.SaveChanges();
        return NoContent();

    }

    /// <summary>
    /// Atualiza o cadastro completo do tutor selecionado
    /// </summary>
    /// <param name="id">ID do tutor cadastrado no banco</param>
    /// <param name="tutorDto">Objeto com os campos necessários para alteração completa de um tutor</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a alteração seja feita com sucesso</response>
    [HttpPut("{id}")]
    public IActionResult AtualizarTutor(int id, [FromBody] UpdateTutorDto tutorDto)
    {
        var tutor = _context.User.FirstOrDefault(tutor => tutor.Id == id);

        if (tutor == null) return NotFound();

        _mapper.Map(tutorDto, tutor);
        _context.SaveChanges();
        return NoContent();

    }
    /// <summary>
    /// Atualiza o cadastro de um campo especifico do tutor selecionado
    /// </summary>
    /// <param name="id">ID do tutor cadastrado no banco</param>
    /// <param name="patch">Objeto com os campos necessários para slteração especifica do dado de um tutor</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a alteração seja feita com sucesso</response>
    [HttpPatch("{id}")]
    public IActionResult AtualizarTutorParial(int id, JsonPatchDocument<UpdateTutorDto> patch)
    {
        var tutor = _context.User.FirstOrDefault(tutor => tutor.Id == id);

        if (tutor == null) return NotFound();

        var tutorParaAtualizar = _mapper.Map<UpdateTutorDto>(tutor);

        patch.ApplyTo(tutorParaAtualizar, ModelState);

        if (!TryValidateModel(tutorParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(tutorParaAtualizar, tutor);
        _context.SaveChanges();
        return NoContent();

    }


    ///// <summary>
    ///// Deleta o cadastro de um tutor especifico
    ///// </summary>
    ///// <param name="id">ID do tutor cadastrado no banco</param>
    ///// <returns>IActionResult</returns>
    ///// <response code="200">Caso a alteração seja feita com sucesso</response>
    //[HttpDelete("{id}")]
    //public IActionResult DeletarTutor(int id)
    //{
    //    var tutor = _context.Tutores.FirstOrDefault(tutor => tutor.Id == id);

    //    if (tutor == null) return NotFound();

    //    _context.Remove(tutor);
    //    _context.SaveChanges();
    //    return NoContent();

    //}
}
