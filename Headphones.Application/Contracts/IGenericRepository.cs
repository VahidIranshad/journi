using Headphones.Domain.Base;

namespace Headphones.Application.Contracts
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IList<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}
