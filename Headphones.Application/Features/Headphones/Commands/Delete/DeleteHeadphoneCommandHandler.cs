using Headphones.Application.Contracts;
using Headphones.Application.EventBus;
using Headphones.Application.Exceptions;
using Headphones.Domain.Entity;
using MediatR;

namespace Headphones.Application.Features.Headphones.Commands.Delete
{
    public class DeleteHeadphoneCommandHandler : ICommandHandler<DeleteHeadphoneCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteHeadphoneCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteHeadphoneCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.HeadphoneRepository.Delete(request.Id );
            return Unit.Value;
        }
    }
}
