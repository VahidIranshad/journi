using AutoMapper;
using Headphones.Application.Contracts;
using Headphones.Application.Dtos.HeadphonesDtos;
using Headphones.Application.Features.Headphones.Commands.Create;
using Headphones.Application.Profiles;
using Headphones.UnitTest.Mocks;
using Moq;

namespace Headphones.UnitTest.Feature.Headphone
{
    public class CreateHeadphoneCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly HeadphoneCrudDto _crudDto;
        private readonly CreateHeadphoneCommandHandler _handler;
        private readonly HeadphoneCrudDtoValidation _Validator;
        public CreateHeadphoneCommandHandlerTest()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();
            _Validator = new HeadphoneCrudDtoValidation();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateHeadphoneCommandHandler(_mockUow.Object, _mapper, _Validator);

            _crudDto = new HeadphoneCrudDto()
            {
                Name = "name",
                Manufacturer = "manufacturer",
                Description = "description",
                Color = "color",
                Price = 1,
                ImageFileName = "imageFileName",
                Type = "type",
                Wireless = false,
                BatteryLife = "batteryLife",
                NoiseCancellationType = "noiseCancellationType",
                Weight = "weight",
                Mic = false
            };
        }


        [Fact]
        public async Task Valid_LeaveType_Added()
        {
            var result = await _handler.Handle(new CreateHeadphoneCommand() { headphonesCrudDto = _crudDto }, CancellationToken.None);
            var items = await _mockUow.Object.HeadphoneRepository.GetAll();
            Assert.Equal(items.Count, 2);
        }
    }
}
