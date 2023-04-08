using System.Linq.Expressions;

namespace Florage.Shared.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task DeleteAsync(string attribute, string value);
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<T> FilterAsync(Expression<Func<T, bool>> filter);
        Task<T> GetByIdAsync(string id);
        Task<T> GetOneAsync(string attribute, string value);
        Task UpdateAsync(string attribute, string value, T entity);
    }
}
