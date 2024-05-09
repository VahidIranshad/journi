using AutoMapper;
using FluentValidation;
using Headphones.Application.Contracts;
using Headphones.Application.Dtos.HeadphonesDtos;
using Headphones.Application.EventBus;
using Headphones.Domain.Entity;
using MediatR;

namespace Headphones.Application.Features.Headphones.Commands.Update
{

    public class UpdateHeadphoneCommandHandler : ICommandHandler<UpdateHeadphoneCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<HeadphoneCrudDto> _validator;

        public UpdateHeadphoneCommandHandler(IUnitOfWork unitOfWork,
            IMapper mapper,
            IValidator<HeadphoneCrudDto> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }


        public async Task<Unit> Handle(UpdateHeadphoneCommand request, CancellationToken cancellationToken)
        {
            if (_validator != null)
            {
                var result = await _validator.ValidateAsync(request.headphonesCrudDto);

                if (!result.IsValid)
                {
                    throw new ValidationException(result.Errors.ToList());
                }
            }

            var data = _mapper.Map<Headphone>(request.headphonesCrudDto);

            await _unitOfWork.HeadphoneRepository.Update(data);
            return Unit.Value;
        }
    }
}
