using MediatR;

namespace Headphones.Application.EventBus
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
        where TResponse : notnull
    {
    }

}
