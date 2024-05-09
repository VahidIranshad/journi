using AutoMapper;
using Headphones.Application.Contracts;
using Headphones.Application.Dtos.HeadphonesDtos;
using Headphones.Application.Features.Headphones.Commands.Create;
using Headphones.Application.Features.Headphones.Commands.Update;
using Headphones.Application.Profiles;
using Headphones.UnitTest.Mocks;
using Moq;

namespace Headphones.UnitTest.Feature.Headphone
{
    public class UpdateHeadphoneCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly HeadphoneCrudDto _crudDto;
        private readonly UpdateHeadphoneCommandHandler _handler;
        private readonly HeadphoneCrudDtoValidation _Validator;
        public UpdateHeadphoneCommandHandlerTest()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();
            _Validator = new HeadphoneCrudDtoValidation();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new UpdateHeadphoneCommandHandler(_mockUow.Object, _mapper,  _Validator);

            _crudDto = new HeadphoneCrudDto()
            {
                Id = 1,
                Name = "name_updatetest",
                Manufacturer = "manufacturer_updatetest",
                Description = "description_updatetest",
                Color = "color_updatetest",
                Price = 1000,
                ImageFileName = "imageFileName_updatetest",
                Type = "type_updatetest",
                Wireless = true,
                BatteryLife = "batteryLife_updatetest",
                NoiseCancellationType = "noiseCancellationType_updatetest",
                Weight = "weight_updatetest",
                Mic = true
            };

        }
        [Fact]
        public async Task Valid_LeaveType_Updated()
        {
            var result = await _handler.Handle(new UpdateHeadphoneCommand() { headphonesCrudDto = _crudDto }, CancellationToken.None);
            var blog = await _mockUow.Object.HeadphoneRepository.Get(_crudDto.Id);
            Assert.Equal(_crudDto.Name, blog.Name);
            Assert.Equal(_crudDto.Price, blog.Price);
            Assert.Equal(_crudDto.Mic, blog.Mic);
        }
    }
}
