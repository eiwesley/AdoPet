using Models.Models;
using AutoMapper;
using Data.DTOs.Tutor;

namespace Models.Profiles;

/// <summary>
/// Classe de profile para tutor
/// </summary>
public class TutorProfile : Profile
{
    /// <summary>
    /// Metodo construtor para mapeamento entre os DTOs e o cadastro de Tutor
    /// </summary>
    public TutorProfile()
    {
        CreateMap<CreateTutorDto, Tutores>();
        CreateMap<UpdateTutorDto, Tutores>();
        CreateMap<Tutores, UpdateTutorDto>();
        CreateMap<Tutores, ReadTutorDto>();
    }
}
