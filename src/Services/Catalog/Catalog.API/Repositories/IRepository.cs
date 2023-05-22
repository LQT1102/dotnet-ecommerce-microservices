using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetManyAsync(FilterDefinition<T>? filterDefinition = null, int? skip = null, int? limit = null, SortDefinition<T>? sortDefinition = null, ProjectionDefinition<T, T>? projectionDefinition = null);

        Task<long> GetCountAsync(FilterDefinition<T>? filterDefinition = null);

        Task<T> GetOneAync(string id);

        Task<T> Create(T entity);

        Task Update(string id, T entity);

        Task Delete(string id);
    }
}
