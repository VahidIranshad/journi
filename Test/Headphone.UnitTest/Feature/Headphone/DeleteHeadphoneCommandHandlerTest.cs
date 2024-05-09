using AutoMapper;
using Headphones.Application.Contracts;
using Headphones.Application.Features.Headphones.Commands.Delete;
using Headphones.Application.Profiles;
using Headphones.UnitTest.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Headphones.UnitTest.Feature.Headphone
{
    public class DeleteHeadphoneCommandHandlerTest
    {
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly DeleteHeadphoneCommandHandler _handler;

        public DeleteHeadphoneCommandHandlerTest()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _handler = new DeleteHeadphoneCommandHandler(_mockUow.Object);
        }


        [Fact]
        public async Task Valid_LeaveType_Deleted()
        {
            var result = await _handler.Handle(new DeleteHeadphoneCommand() { Id = 1 }, CancellationToken.None);
            var items = await _mockUow.Object.HeadphoneRepository.GetAll();
            Assert.Equal(items.Count, 0);
        }
    }
}
