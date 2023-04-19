using AutoMapper;
using Data.DTOs.Pets;
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
        CreateMap<CreatePetDto, Pet>();
        CreateMap<UpdatePetDto, Pet>();
        CreateMap<Pet, UpdatePetDto>();
        CreateMap<Pet, ReadPetDto>();
    }
}