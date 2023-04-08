using AutoMapper;
using Data.DTOs.Pet;
using Data.DTOs.Tutor;
using Microsoft.AspNetCore.Mvc;
using Models.Data;
using Models.Models;

namespace AdoPet.Controllers;


/// <summary>
/// Classe Responsavel por controlar os requisitos da API
/// </summary>
[ApiController]
[Route("[Controller]")]
public class PetsController : Controller
{
    private AdoPetContext _context;
    private IMapper _mapper;

    /// <summary>
    /// Metodo construtor
    /// </summary>
    /// <param name="context">retorna os dados da classe</param>
    /// <param name="mapper">Mapeia os dados para os DTOs</param>
    public PetsController(AdoPetContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um tutor ao banco de dados
    /// </summary>
    /// <param name="petDto">Objeto com os campos necessários para criação de um tutor</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    public IActionResult CadastrarPet([FromBody] CreatePetDto petDto)
    {
        Pets pet = _mapper.Map<Pets>(petDto);
        _context.Pets.Add(pet);
        _context.SaveChanges();

        return Ok();
    }

    /// <summary>
    /// Retorna os tutores cadastrados
    /// </summary>
    /// <param name="skip">Valor para iniciar a lista</param>
    /// <param name="take">Valor para trazer a quantidade de tutores</param>
    /// <returns>IEnumerable</returns>
    [HttpGet]
    public IEnumerable<ReadPetDto> BuscarPets([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadPetDto>>(_context.Pets.Skip(skip).Take(take));
    }

    /// <summary>
    /// Retorna um tutor cadastrado
    /// </summary>
    /// <param name="id">ID do Pet cadastrado no banco</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    /// /// <response code="404">Caso não exista o ID cadastrado</response>
    [HttpGet("{id}")]
    public IActionResult BuscarPetPorId(int id) 
    {
        var pet = _context.Pets.FirstOrDefault(pet => pet.Id == id);
        if (pet == null)
        {
            return NotFound();
        }

        var petDto = _mapper.Map<ReadPetDto>(pet);

        return Ok(petDto);
    }

    /// <summary>
    /// Atualiza o cadastro completo do tutor selecionado
    /// </summary>
    /// <param name="id">ID do tutor cadastrado no banco</param>
    /// <param name="petDto">Objeto com os campos necessários para alteração completa de um tutor</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a alteração seja feita com sucesso</response>
    [HttpPut("{id}")]
    public IActionResult AtualizarPet(int id, [FromBody] UpdatePetDto petDto)
    {
        var pet = _context.Pets.FirstOrDefault(pet => pet.Id == id);

        if (pet == null) return NotFound();

        _mapper.Map(petDto, pet);
        _context.SaveChanges();
        return NoContent();

    }
}
