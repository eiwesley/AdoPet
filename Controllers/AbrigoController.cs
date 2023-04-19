using AutoMapper;
using Data.DTOs.Abrigos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Models.Data;
using Models.Models;

namespace AdoPet.Controllers;

/// <summary>
/// Classe Responsavel por controlar os requisitos da API
/// </summary>
[ApiController]
[Route("[Controller]")]

public class AbrigoController : Controller
{
    private AdoPetContext _context;
    private IMapper _mapper;

    /// <summary>
    /// Metodo construtor
    /// </summary>
    /// <param name="context">retorna os dados da classe</param>
    /// <param name="mapper">Mapeia os dados para os DTOs</param>
    public AbrigoController(AdoPetContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um tutor ao banco de dados
    /// </summary>
    /// <param name="abrigoDto">Objeto com os campos necessários para criação de um tutor</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    public IActionResult CadastrarAbrigo([FromBody] CreateAbrigoDto abrigoDto)
    {
        Abrigo abrigo = _mapper.Map<Abrigo>(abrigoDto);
        _context.Abrigo.Add(abrigo);
        _context.SaveChanges();

        return CreatedAtAction(nameof(BuscarAbrigoPorId), new { id = abrigo.Id }, abrigo);
    }

    /// <summary>
    /// Retorna os tutores cadastrados
    /// </summary>
    /// <param name="skip">Valor para iniciar a lista</param>
    /// <param name="take">Valor para trazer a quantidade de tutores</param>
    /// <returns>IEnumerable</returns>
    [HttpGet]
    public IEnumerable<ReadAbrigoDto> BuscarAbrigos([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadAbrigoDto>>(_context.Abrigo.Skip(skip).Take(take));
    }

    /// <summary>
    /// Retorna um tutor cadastrado
    /// </summary>
    /// <param name="id">ID do Pet cadastrado no banco</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    /// /// <response code="404">Caso não exista o ID cadastrado</response>
    [HttpGet("{id}")]
    public IActionResult BuscarAbrigoPorId(int id)
    {
        var abrigo = _context.Abrigo.FirstOrDefault(abrigo => abrigo.Id == id);
        if (abrigo == null)
        {
            return NotFound();
        }

        var abrigoDto = _mapper.Map<ReadAbrigoDto>(abrigo);

        return Ok(abrigoDto);
    }


    /// <summary>
    /// Atualiza o cadastro completo do tutor selecionado
    /// </summary>
    /// <param name="id">ID do abrigo cadastrado no banco</param>
    /// <param name="abrigoDto">Objeto com os campos necessários para alteração completa de um tutor</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a alteração seja feita com sucesso</response>
    [HttpPut("{id}")]
    public IActionResult AtualizarAbrigo(int id, [FromBody] UpdateAbrigoDto abrigoDto)
    {
        var abrigo = _context.Abrigo.FirstOrDefault(abrigo => abrigo.Id == id);

        if (abrigo == null) return NotFound();

        _mapper.Map(abrigoDto, abrigo);
        _context.SaveChanges();
        return NoContent();

    }

    /// <summary>
    /// Atualiza o cadastro de um campo especifico do tutor selecionado
    /// </summary>
    /// <param name="id">ID do tutor cadastrado no banco</param>
    /// <param name="patch">Objeto com os campos necessários para slteração especifica do dado de um tutor</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a alteração seja feita com sucesso</response>
    [HttpPatch("{id}")]
    public IActionResult AtualizarAbrigoParial(int id, JsonPatchDocument<UpdateAbrigoDto> patch)
    {
        var abrigo = _context.Abrigo.FirstOrDefault(abrigo => abrigo.Id == id);

        if (abrigo == null) return NotFound();

        var abrigoParaAtualizar = _mapper.Map<UpdateAbrigoDto>(abrigo);

        patch.ApplyTo(abrigoParaAtualizar, ModelState);

        if (!TryValidateModel(abrigoParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(abrigoParaAtualizar, abrigo);
        _context.SaveChanges();
        return NoContent();

    }

    /// <summary>
    /// Desabilita o cadastro do tutor selecionado
    /// </summary>
    /// <param name="id">ID do abrigo cadastrado no banco</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a alteração seja feita com sucesso</response>
    [HttpPatch("{id}/disable")]
    public IActionResult DesabilitarAbrigo(int id)
    {
        var abrigo = _context.Abrigo.FirstOrDefault(abrigo => abrigo.Id == id);

        if (abrigo == null) return NotFound();

        var abrigoParaDesabilitar = _mapper.Map<UpdateAbrigoDto>(abrigo);
        abrigoParaDesabilitar.Active = false;

        _mapper.Map(abrigoParaDesabilitar, abrigo);
        _context.SaveChanges();
        return NoContent();

    }

    /// <summary>
    /// Desabilita o cadastro do tutor selecionado
    /// </summary>
    /// <param name="id">ID do abrigo cadastrado no banco</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a alteração seja feita com sucesso</response>
    [HttpPatch("{id}/enable")]
    public IActionResult HabilitarAbrigo(int id)
    {
        var abrigo = _context.Abrigo.FirstOrDefault(abrigo => abrigo.Id == id);

        if (abrigo == null) return NotFound();

        var abrigoParaHabilitar = _mapper.Map<UpdateAbrigoDto>(abrigo);
        abrigoParaHabilitar.Active = true;

        _mapper.Map(abrigoParaHabilitar, abrigo);
        _context.SaveChanges();
        return NoContent();

    }
}

