using Catalog.API.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Catalog.API.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public Repository(IMongoCollection<T> collection)
        {
            _collection = collection;
        }

        public Task Create(T entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetByCategoryAsync(string categoryName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetManyAsync(FilterDefinition<T>? filterDefinition = null, int? skip = null, int? limit = null, SortDefinition<T>? sortDefinition = null, ProjectionDefinition<T, T>? projectionDefinition = null)
        {
            var operation = _collection.Find(filterDefinition);
            if(skip != null)
            {
                operation = operation.Skip(skip);
            }

            if(limit != null)
            {
                operation = operation.Limit(limit);
            }

            if(sortDefinition != null)
            {
                operation = operation.Sort(sortDefinition);
            }

            var projectionBuilder = Builders<Product>.Projection;
            var projection = projectionBuilder.Combine(
                projectionBuilder.Include(u => u.Name),
                projectionBuilder.Include(u => u.Description)
            );

            if (projectionDefinition != null)
            {
                operation = operation.Project(projectionDefinition);
            }

            return await operation.ToListAsync();
        }

        public async Task<long> GetCountAsync(FilterDefinition<T> filterDefinition)
        {
            return await _collection.CountDocumentsAsync(filterDefinition);
        }

        public Task<T> GetOneAync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
