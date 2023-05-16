using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetManyAsync(FilterDefinition<T>? filterDefinition = null, int? skip = null, int? limit = null, SortDefinition<T>? sortDefinition = null, ProjectionDefinition<T, T>? projectionDefinition = null);

        Task<long> GetCountAsync(FilterDefinition<T> filterDefinition);

        Task<T> GetOneAync();

        Task<IEnumerable<T>> GetByNameAsync(string name);

        Task<IEnumerable<T>> GetByCategoryAsync(string categoryName);

        Task Create(T entity);

        Task<bool> Update(T entity);

        Task Delete(string id);
    }
}
