using AutoMapper;
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
}
