using AutoMapper;
using Headphones.Application.Dtos.HeadphonesDtos;
using Headphones.Domain.Entity;

namespace Headphones.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            #region Headphone


            CreateMap<HeadphoneDto, Headphone>().ReverseMap();
            CreateMap<HeadphoneCrudDto, Headphone>().ReverseMap();
            #endregion
        }
    }
}
