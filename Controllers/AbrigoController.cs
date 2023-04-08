using AutoMapper;
using Data.DTOs.Abrigo;
using Data.DTOs.Pet;
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


}

