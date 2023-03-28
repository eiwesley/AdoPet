using AdoPet.Data.DTOs;
using AdoPet.Models;
using AutoMapper;

namespace AdoPet.Profiles;

public class TutorProfile : Profile
{
    public TutorProfile()
    {
        CreateMap<CreateTutorDto, Tutores>();
        CreateMap<UpdateTutorDto, Tutores>();
        CreateMap<Tutores, UpdateTutorDto>();
        CreateMap<Tutores, ReadTutorDto>();
    }
}
