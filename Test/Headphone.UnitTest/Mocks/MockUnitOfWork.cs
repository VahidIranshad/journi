using Headphones.Application.Contracts;
using Moq;

namespace Headphones.UnitTest.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var _headphoneRepository = MockHeadphoneRepository.GetRepository();
            var mockUow = new Mock<IUnitOfWork>();
            mockUow.Setup(p => p.HeadphoneRepository).Returns(()=> { return _headphoneRepository.Object; });
            return mockUow;
        }
    }
}
