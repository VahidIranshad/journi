using AutoMapper;
using Headphones.Application.Contracts;
using Headphones.Application.Dtos.HeadphonesDtos;
using Headphones.Application.EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Headphones.Application.Features.Headphones.Queries.GetByID
{
    public class GetHeadphoneByIdHandler : IQueryHandler<GetHeadphoneById, HeadphoneDto>
    {

        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;


        public GetHeadphoneByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<HeadphoneDto> Handle(GetHeadphoneById request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.HeadphoneRepository.Get(request.Id);
            return _mapper.Map<HeadphoneDto>(result);
        }

    }
}
