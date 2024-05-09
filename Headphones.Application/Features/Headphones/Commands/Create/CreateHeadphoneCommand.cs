
using Headphones.Application.Dtos.HeadphonesDtos;
using Headphones.Application.EventBus;

namespace Headphones.Application.Features.Headphones.Commands.Create
{
    public class CreateHeadphoneCommand : ICommand<HeadphoneDto>
    {
        public required HeadphoneCrudDto headphonesCrudDto { get; set; }
    }
}
