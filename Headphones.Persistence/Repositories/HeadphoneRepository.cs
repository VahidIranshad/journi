using Headphones.Application.Contracts;
using Headphones.Domain.Base;
using Headphones.Domain.Entity;
using Microsoft.Extensions.Options;

namespace Headphones.Persistence.Repositories
{
    public class HeadphoneRepository : GenericRepositoryForJson<Headphone>, IHeadphoneRepository
    {
        public HeadphoneRepository(IOptions<AppSettings> appSettings) : base(appSettings) { }
    }
}
