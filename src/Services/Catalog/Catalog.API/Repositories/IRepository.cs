using Catalog.API.Entities;

namespace Catalog.API.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetManyAsync();

        Task<T> GetOneÁync();

        Task<IEnumerable<T>> GetByNameAsync(string name);

        Task<IEnumerable<T>> GetByCategoryAsync(string categoryName);

        Task Create(T entity);

        Task<bool> Update(T entity);

        Task Delete(string id);
    }
}
