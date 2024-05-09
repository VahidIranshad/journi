using Headphones.Application.Contracts;

namespace Headphones.Persistence.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        public Application.Contracts.IHeadphoneRepository HeadphoneRepository { get; private set; }
        public UnitOfWork(IHeadphoneRepository headphoneRepository)
        {
            HeadphoneRepository = headphoneRepository;
        }
    }
}
