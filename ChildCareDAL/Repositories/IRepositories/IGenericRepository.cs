using System.Linq.Expressions;

namespace ChildCareDAL.Repositories.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<(bool, T)> Add(T entity);
        Task<T> Get(Expression<Func<T, bool>> filter = null);
        Task<List<T>> GetList(Expression<Func<T, bool>> filter = null);
        Task<int> Delete(T entity);
        Task<bool> Update(T entity);
    }
}
