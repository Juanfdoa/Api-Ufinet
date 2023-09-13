using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Ufinet.Contracts.Interfaces.Repositories;

namespace Ufinet.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        private readonly ApplicationDbContext _databaseContext;

        public BaseRepository(ApplicationDbContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IQueryable<T> GetAll()
        {
            var entitySet = _databaseContext.Set<T>();
            return entitySet.AsQueryable();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public async Task Add(T entity)
        {
            await _databaseContext.AddAsync(entity);
            _databaseContext.Entry(entity).State = EntityState.Added;
            await _databaseContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _databaseContext.Update(entity);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _databaseContext.Remove(entity);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
