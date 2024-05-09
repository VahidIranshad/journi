using Headphones.Application.Dtos.HeadphonesDtos;
using Headphones.Application.EventBus;

namespace Headphones.Application.Features.Headphones.Queries.GetList
{
    public class GetHedphoneListQuery : IQuery<IList<HeadphoneDto>>
    {
    }
}
