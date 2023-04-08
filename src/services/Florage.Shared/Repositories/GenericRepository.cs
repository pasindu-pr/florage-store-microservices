using Florage.Shared.Contracts;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Florage.Shared.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly IMongoCollection<T>  dbCollection;
        private readonly FilterDefinitionBuilder<T> filterBuilder = Builders<T>.Filter;

        public GenericRepository(IMongoDatabase database)
        {
            dbCollection = database.GetCollection<T>("collection");
        }
         
        public async Task CreateAsync(T entity)
        {
            await dbCollection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string attribute, string value)
        {
            await dbCollection.DeleteOneAsync(filterBuilder.Eq(attribute, value));
        } 

        public async Task<T> FilterAsync(Expression<Func<T, bool>> filter)
        {
            return await dbCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            return await dbCollection.Find(filterBuilder.Empty).ToListAsync();
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            return await dbCollection.Find(filter).ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await dbCollection.Find(filterBuilder.Eq("Id", id)).FirstOrDefaultAsync();
        }

        public async Task<T> GetOneAsync(string attribute, string value)
        {
            return await dbCollection.Find(filterBuilder.Eq(attribute, value)).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(string attribute, string value,T entity)
        { 
            await dbCollection.ReplaceOneAsync(filterBuilder.Eq(attribute, value), entity);
        }
 
    }
}
