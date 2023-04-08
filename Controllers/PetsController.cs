using AutoMapper;
using Data.DTOs.Pet;
using Data.DTOs.Tutor;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Models.Data;
using Models.Models;
using System.Linq;

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
        if (!Uri.TryCreate(petDto.ProfilePic, UriKind.Absolute, out Uri uriResult) || !(uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))

        {
            return BadRequest("A URL fornecida é inválida.");
        }

        Pets pet = _mapper.Map<Pets>(petDto);
        _context.Pets.Add(pet);
        _context.SaveChanges();

        return CreatedAtAction(nameof(BuscarPetPorId),new {id = pet.Id}, pet);
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
        //return _mapper.Map<List<ReadPetDto>>(_context.Pets.Skip(skip).Take(take));

        return _mapper.Map<List<ReadPetDto>>(_context.Pets.Where(status => status.Status != "Adopted").Skip(skip).Take(take));
    }

    /// <summary>
    /// Retorna um tutor cadastrado
    /// </summary>
    /// <param name="id">ID do Pet cadastrado no banco</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    /// <response code="404">Caso não exista o ID cadastrado</response>
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
    /// Retorna um tutor cadastrado
    /// </summary>
    /// <param name="id">ID do Owner cadastrado para o Pet</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    /// <response code="404">Caso não exista o ID cadastrado</response>
    [HttpGet("tutor/{id}")]
    public IEnumerable<ReadPetDto> BuscarPetPorIdTutor(int id)
    {
        var tutor = _context.Tutores.FirstOrDefault(tutor => tutor.Id == id);
        var tutorName = _mapper.Map<ReadTutorDto>(tutor).Name;

        return _mapper.Map<List<ReadPetDto>>(_context.Pets.Where(t => t.Owner == tutorName));
    }

    /// <summary>
    /// Retorna um pet cadastrado através do nome
    /// </summary>
    /// <param name="name">Nome do Pet cadastrado no banco</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet("name/{name}")]
    public IActionResult BuscarPetPorNome(string name)
    {
        var pet = _context.Pets.FirstOrDefault(pet => pet.Name == name);

        if (pet == null) return NotFound();

        var petDto = _mapper.Map<ReadPetDto>(pet);

        return Ok(petDto);
    }

    /// <summary>
    /// Aprova o cadastro do pet selecionado
    /// </summary>
    /// <param name="id">ID do pet cadastrado no banco</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a alteração seja feita com sucesso</response>
    [HttpPatch("{id}/approve")]
    public IActionResult AprovarPet(int id)
    {
        var pet = _context.Pets.FirstOrDefault(pet => pet.Id == id);

        if (pet == null) return NotFound();

        var petParaAprovar = _mapper.Map<UpdatePetDto>(pet);
        petParaAprovar.Status = "Avaiable";

        _mapper.Map(petParaAprovar, pet);
        _context.SaveChanges();
        return NoContent();

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

    /// <summary>
    /// Atualiza o cadastro de um campo especifico do tutor selecionado
    /// </summary>
    /// <param name="id">ID do tutor cadastrado no banco</param>
    /// <param name="patch">Objeto com os campos necessários para slteração especifica do dado de um tutor</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a alteração seja feita com sucesso</response>
    [HttpPatch("{id}")]
    public IActionResult AtualizarPetParial(int id, JsonPatchDocument<UpdatePetDto> patch)
    {
        var pet = _context.Pets.FirstOrDefault(pet => pet.Id == id);

        if (pet == null) return NotFound();

        var petParaAtualizar = _mapper.Map<UpdatePetDto>(pet);

        patch.ApplyTo(petParaAtualizar, ModelState);

        if (!TryValidateModel(petParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(petParaAtualizar, pet);
        _context.SaveChanges();
        return NoContent();

    }
}
