using Headphones.Application.Dtos.HeadphonesDtos;
using Headphones.Application.EventBus;

namespace Headphones.Application.Features.Headphones.Commands.Update
{
    public class UpdateHeadphoneCommand : ICommand
    {
        public required HeadphoneCrudDto headphonesCrudDto { get; set; }
    }
}
