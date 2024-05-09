
using Headphones.Application.EventBus;

namespace Headphones.Application.Features.Headphones.Commands.Delete
{
    public class DeleteHeadphoneCommand : ICommand
    {
        public int Id { get; set; }
    }
}
