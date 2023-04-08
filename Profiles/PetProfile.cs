using AutoMapper;
using Data.DTOs.Pet;
using Models.Models;

namespace Profiles;

/// <summary>
/// Classe de profile para tutor
/// </summary>
public class PetProfile : Profile
{
    /// <summary>
    /// Metodo construtor para mapeamento entre os DTOs e o cadastro de Tutor
    /// </summary>
    public PetProfile()
    {
        CreateMap<CreatePetDto, Pets>();
        CreateMap<UpdatePetDto, Pets>();
        CreateMap<Pets, UpdatePetDto>();
        CreateMap<Pets, ReadPetDto>();
    }
}