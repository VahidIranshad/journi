using AutoMapper;
using Headphones.Application.Contracts;
using Headphones.Application.Dtos.HeadphonesDtos;
using Headphones.Application.EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Headphones.Application.Features.Headphones.Queries.GetList
{
    public class GetHedphoneListQueryHandler : IQueryHandler<GetHedphoneListQuery, IList<HeadphoneDto>>
    {

        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;


        public GetHedphoneListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<HeadphoneDto>> Handle(GetHedphoneListQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.HeadphoneRepository.GetAll();
            return _mapper.Map<IList<HeadphoneDto>>(result);
        }

    }
}
