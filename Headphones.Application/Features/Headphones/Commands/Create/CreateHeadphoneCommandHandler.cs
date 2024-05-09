using AutoMapper;
using FluentValidation;
using Headphones.Application.Contracts;
using Headphones.Application.Dtos.HeadphonesDtos;
using Headphones.Application.EventBus;
using Headphones.Domain.Entity;

namespace Headphones.Application.Features.Headphones.Commands.Create
{
    public class CreateHeadphoneCommandHandler : ICommandHandler<CreateHeadphoneCommand, HeadphoneDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<HeadphoneCrudDto> _validator;

        public CreateHeadphoneCommandHandler(IUnitOfWork unitOfWork,
            IMapper mapper,
            IValidator<HeadphoneCrudDto> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }


        public async Task<HeadphoneDto> Handle(CreateHeadphoneCommand request, CancellationToken cancellationToken)
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

            data = await _unitOfWork.HeadphoneRepository.Add(data);
            return _mapper.Map<HeadphoneDto>(data);
        }
    }
}
