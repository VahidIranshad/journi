namespace Headphones.Application.Contracts
{
    public interface IUnitOfWork
    {
        IHeadphoneRepository HeadphoneRepository { get;  }
    }
}
