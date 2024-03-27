using ChildCareDAL.DBcontext;
using ChildCareDAL.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

#nullable disable
namespace ChildCareDAL.Repositories.Implementation
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public GenericRepository(ApplicationDbContext applicationDbContext) { _applicationDbContext = applicationDbContext; }
        public async Task<(bool, TEntity)> Add(TEntity entity)
        {
            await _applicationDbContext.Set<TEntity>().AddAsync(entity);
            await _applicationDbContext.SaveChangesAsync();
            return (true, entity);
        }
        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {

            TEntity Getdata = await _applicationDbContext.Set<TEntity>().FirstOrDefaultAsync(filter);

            if (Getdata != null) _applicationDbContext.Entry<TEntity>(Getdata).State = EntityState.Detached;

            return Getdata;
        }
        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return await (filter == null ? _applicationDbContext.Set<TEntity>().ToListAsync() : _applicationDbContext.Set<TEntity>().Where(filter).ToListAsync());
        }
        public async Task<int> Delete(TEntity entity)
        {
            _applicationDbContext.Remove(entity); return await _applicationDbContext.SaveChangesAsync();
        }
        public virtual async Task<bool> Update(TEntity entity)
        {
            bool IsFlag = _applicationDbContext.Set<TEntity>().Contains(entity);

            if (IsFlag == true)
            {
                _applicationDbContext.Entry(entity).State = EntityState.Modified;
                await _applicationDbContext.SaveChangesAsync(); return true;
            }
            else { return false; }
        }
    }
}
