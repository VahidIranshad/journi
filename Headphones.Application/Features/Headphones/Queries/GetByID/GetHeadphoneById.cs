using Headphones.Application.Dtos.HeadphonesDtos;
using Headphones.Application.EventBus;

namespace Headphones.Application.Features.Headphones.Queries.GetByID
{
    public class GetHeadphoneById : IQuery<HeadphoneDto>
    {
        public int Id { get; set; }
    }
}
