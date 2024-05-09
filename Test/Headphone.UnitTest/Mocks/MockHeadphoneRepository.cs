using Headphones.Application.Contracts;
using Headphones.Domain.Entity;
using Moq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Headphones.UnitTest.Mocks
{
    public static class MockHeadphoneRepository
    {
        public static Mock<IHeadphoneRepository> GetRepository()
        {
            var list = new List<Headphone>
            {
                new Headphone(1, "name", "manufacturer", "description", "color", 1, "imageFileName", 
                "type", false, "batteryLife", "noiseCancellationType", "weight", false)
            };

            var mockRepo = new Mock<IHeadphoneRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(list);

            mockRepo.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                return list.Where(p => p.Id == id).First();
            });

            mockRepo.Setup(r => r.Add(It.IsAny<Headphone>())).ReturnsAsync((Headphone data) =>
            {
                list.Add(data);
                return data;
            });
            mockRepo.Setup(r => r.Update(It.IsAny<Headphone>())).Callback((Headphone data) =>
            {
                var old = list.First(p => p.Id == data.Id);
                list.Remove(old);
                list.Add(data);
            });
            mockRepo.Setup(r => r.Delete(It.IsAny<int>())).Callback((int id) =>
            {
                var item = list.First(p => p.Id == id); 
                list.Remove(item);
            });

            return mockRepo;

        }
    }
}
