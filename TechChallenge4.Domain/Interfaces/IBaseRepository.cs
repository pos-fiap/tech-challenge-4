using System.Linq.Expressions;
using TechChallenge4.Domain.Entities;

namespace TechChallenge4.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T?> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);

        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> where);
    }
}
