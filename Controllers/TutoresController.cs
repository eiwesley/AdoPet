using AdoPet.Data;
using AdoPet.Data.DTOs;
using AdoPet.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AdoPet.Controllers;

[ApiController]
[Route("[Controller]")]

public class TutoresController : ControllerBase
{
    private TutorContext _context;
    private IMapper _mapper;

    public TutoresController(TutorContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um tutor ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um tutor</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult CadastarTutor([FromBody] CreateTutorDto tutorDto)
    {
        Tutores tutor = _mapper.Map<Tutores>(tutorDto);

        _context.Tutores.Add(tutor);
        _context.SaveChanges();

        return CreatedAtAction(nameof(BuscarTutorPorId), new { id = tutor.Id }, tutor);
    }

    [HttpGet]
    public IEnumerable<ReadTutorDto> BuscarTutores([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadTutorDto>>(_context.Tutores.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult BuscarTutorPorId(int id) 
    {
        var tutor = _context.Tutores.FirstOrDefault(tutor => tutor.Id == id);

        if(tutor == null) return NotFound();

        var tutorDto = _mapper.Map<ReadTutorDto>(tutor);

        return Ok(tutorDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarTutor(int id, [FromBody] UpdateTutorDto tutorDto)
    {
        var tutor = _context.Tutores.FirstOrDefault(tutor => tutor.Id == id);

        if (tutor == null) return NotFound();

        _mapper.Map(tutorDto, tutor);
        _context.SaveChanges();
        return NoContent();

    }
}
