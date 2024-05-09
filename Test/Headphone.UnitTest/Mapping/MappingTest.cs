using AutoMapper;
using Headphones.Application.Dtos.HeadphonesDtos;
using Headphones.Application.Profiles;
using Headphones.Domain.Entity;
using System.Runtime.Serialization;

namespace Headphones.UnitTest.Mapping
{
    public class MappingTest
    {
        private static IConfigurationProvider _configuration;
        private static IConfigurationProvider configuration
        {
            get
            {
                if (_configuration == null)
                {
                    _configuration = new MapperConfiguration(cfg =>
                    {
                        cfg.AddProfile<MappingProfile>();
                    });
                }
                return _configuration;
            }
        }
        private static IMapper _mapper;
        private static IMapper mapper
        {
            get
            {
                if (_mapper == null)
                {
                    _mapper = configuration.CreateMapper();
                }
                return _mapper;
            }

        }
        [Theory]
        [InlineData(typeof(Headphone), typeof(HeadphoneDto))]
        [InlineData(typeof(HeadphoneDto), typeof(Headphone))]
        [InlineData(typeof(Headphone), typeof(HeadphoneCrudDto))]
        [InlineData(typeof(HeadphoneCrudDto), typeof(Headphone))]
        public void Map_SourceToDestination_ExistConfiguration(Type origin, Type destination)
        {
            var instance = FormatterServices.GetUninitializedObject(origin);

            mapper.Map(instance, origin, destination);
        }
    }
}
