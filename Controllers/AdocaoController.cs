using AdoPet.Models;
using AutoMapper;
using Data.DTOs.Abrigo;
using Microsoft.AspNetCore.Mvc;
using Models.Data;
using Models.Models;
using AdoPet.Controllers;
using Data.DTOs.Pet;
using Data.DTOs.Tutor;

namespace AdoPet.Controllers;

/// <summary>
/// Classe Responsavel por controlar os requisitos da API
/// </summary>
[ApiController]
[Route("[Controller]")]
public class AdocaoController : Controller
{
    private AdoPetContext _context;
    private IMapper _mapper;

    /// <summary>
    /// Metodo construtor
    /// </summary>
    /// <param name="context">retorna os dados da classe</param>
    /// <param name="mapper">Mapeia os dados para os DTOs</param>
    public AdocaoController(AdoPetContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona uma adocao ao banco de dados
    /// </summary>
    /// <param name="adocaoDto">Objeto com os campos necessários para criação de um tutor</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    public IActionResult CadastrarAdocao([FromBody] CreateAdocaoDto adocaoDto)
    {
        Adocao adocao = _mapper.Map<Adocao>(adocaoDto);
        _context.Adocao.Add(adocao);
        _context.SaveChanges();

        // retorna o nome do Tutor cadastrado, de acordo com o ID informado
        var tutor = _context.Tutores.FirstOrDefault(tutor => tutor.Id == adocaoDto.Tutor);
        if (tutor == null) return NotFound();
        var tutorName = _mapper.Map<ReadTutorDto>(tutor).Name;

        // atualiza o status, tutor e data de adoção do pet, de acordo com o ID informado
        var pet = _context.Pets.FirstOrDefault(pet => pet.Id == adocaoDto.Pet);
        if (pet == null) return NotFound();
        var petParaAdotar = _mapper.Map<UpdatePetDto>(pet);
        petParaAdotar.Status = "Adopted";
        petParaAdotar.Owner = tutorName;
        petParaAdotar.AdoptedDate = adocaoDto.Date;

        _mapper.Map(petParaAdotar, pet);
        _context.SaveChanges();

        return Ok(pet);

    }
}
