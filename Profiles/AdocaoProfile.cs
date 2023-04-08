using AdoPet.Models;
using AutoMapper;
using Data.DTOs.Abrigo;
using Data.DTOs.Pet;
using Models.Models;

namespace AdoPet.Profiles;

/// <summary>
/// Classe de profile para Abrigo
/// </summary>
public class AdocaoProfile : Profile
{
    /// <summary>
    /// Metodo construtor para mapeamento entre os DTOs e o cadastro de Abrigo
    /// </summary>
    public AdocaoProfile()
    {
        CreateMap<CreateAdocaoDto, Adocao>();
        CreateMap<UpdateAdocaoDto, Adocao>();
        CreateMap<Adocao, UpdateAdocaoDto>();
        CreateMap<Adocao, ReadAdocaoDto>();
    }
}
