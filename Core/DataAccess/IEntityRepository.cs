using Core.Entities;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> 
        where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter = null);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);

        //#region OtherCase
        //List<T> GetAll(Expression<Func<T, bool>> filter = null);

        //Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter = null, Expression<Func<T, TKey>> order = null, bool desc = false);

        //T Get(Expression<Func<T, bool>> filter);

        //T Get<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> order, bool desc = false);

        //Task<T> GetAsync(Expression<Func<T, bool>> filter);

        //Task<T> GetAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> order, bool desc = false);

        //bool Add(T entity);

        //Task<bool> AddAsync(T entity);

        //bool Update(T entity);

        //Task<bool> UpdateAsync(T entity);

        //bool Delete(T entity);

        //Task<bool> DeleteAsync(T entity);
        //#endregion
    }
}
