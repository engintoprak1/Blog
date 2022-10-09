using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var entityToAdd = context.Entry(entity);
                entityToAdd.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var entityToDelete = context.Entry(entity);
                entityToDelete.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().FirstOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var entityToUpdate = context.Entry(entity);
                entityToUpdate.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        //#region OtherCase
        //private bool _disposed;
        //private readonly TContext _context;

        //public EfEntityRepositoryBase(TContext context)
        //{
        //    _context = context;
        //}

        //public bool Add(TEntity entity)
        //{
        //    try
        //    {
        //        EntityEntry<TEntity> addedEntity = _context.Entry(entity);
        //        addedEntity.State = EntityState.Added;

        //        _context.SaveChanges();

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        _context.ChangeTracker.Clear();

        //        return false;
        //    }
        //}

        //public async Task<bool> AddAsync(TEntity entity)
        //{
        //    try
        //    {
        //        EntityEntry<TEntity> addedEntity = _context.Entry(entity);
        //        addedEntity.State = EntityState.Added;

        //        await _context.SaveChangesAsync();

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        _context.ChangeTracker.Clear();

        //        return false;
        //    }
        //}

        //public bool Update(TEntity entity)
        //{
        //    try
        //    {
        //        EntityEntry<TEntity> updatedEntity = _context.Entry(entity);
        //        updatedEntity.State = EntityState.Modified;

        //        _context.SaveChanges();

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        _context.ChangeTracker.Clear();

        //        return false;
        //    }
        //}

        //public async Task<bool> UpdateAsync(TEntity entity)
        //{
        //    try
        //    {
        //        EntityEntry<TEntity> updatedEntity = _context.Entry(entity);
        //        updatedEntity.State = EntityState.Modified;

        //        await _context.SaveChangesAsync();

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        _context.ChangeTracker.Clear();

        //        return false;
        //    }
        //}

        //public bool Delete(TEntity entity)
        //{
        //    try
        //    {
        //        EntityEntry<TEntity> deletedEntity = _context.Entry(entity);
        //        deletedEntity.State = EntityState.Deleted;

        //        _context.SaveChanges();

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        _context.ChangeTracker.Clear();

        //        return false;
        //    }
        //}

        //public async Task<bool> DeleteAsync(TEntity entity)
        //{
        //    try
        //    {
        //        EntityEntry<TEntity> deletedEntity = _context.Entry(entity);
        //        deletedEntity.State = EntityState.Deleted;

        //        await _context.SaveChangesAsync();

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        _context.ChangeTracker.Clear();

        //        return false;
        //    }
        //}

        //public TEntity Get(Expression<Func<TEntity, bool>> filter)
        //{
        //    try
        //    {
        //        return _context.Set<TEntity>()
        //            .FirstOrDefault(filter);
        //    }
        //    catch (Exception ex)
        //    {
        //        _context.ChangeTracker.Clear();

        //        return default;
        //    }
        //}

        //public TEntity Get<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> order, bool desc = false)
        //{
        //    try
        //    {
        //        if (order == null)
        //        {
        //            return Get(filter);
        //        }

        //        return (desc)
        //            ? _context.Set<TEntity>()
        //                .OrderByDescending(order)
        //                .FirstOrDefault(filter)
        //            : _context.Set<TEntity>()
        //                .OrderBy(order)
        //                .FirstOrDefault(filter);
        //    }
        //    catch (Exception ex)
        //    {
        //        _context.ChangeTracker.Clear();

        //        return default;
        //    }
        //}

        //public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        //{
        //    try
        //    {
        //        return await _context.Set<TEntity>()
        //            .FirstOrDefaultAsync(filter);
        //    }
        //    catch (Exception ex)
        //    {
        //        _context.ChangeTracker.Clear();

        //        return default;
        //    }
        //}

        //public async Task<TEntity> GetAsync<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> order, bool desc = false)
        //{
        //    try
        //    {
        //        if (order == null)
        //        {
        //            return Get(filter);
        //        }

        //        return (desc)
        //            ? await _context.Set<TEntity>()
        //                .OrderByDescending(order)
        //                .FirstOrDefaultAsync(filter)
        //            : await _context.Set<TEntity>()
        //                .OrderBy(order)
        //                .FirstOrDefaultAsync(filter);
        //    }
        //    catch (Exception ex)
        //    {
        //        _context.ChangeTracker.Clear();

        //        return default;
        //    }
        //}

        //public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        //{
        //    try
        //    {
        //        return (filter == null)
        //            ? _context.Set<TEntity>().ToList()
        //            : _context.Set<TEntity>().Where(filter).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        _context.ChangeTracker.Clear();

        //        return default;
        //    }
        //}

        //public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, TKey>> order = null, bool desc = false)
        //{
        //    try
        //    {
        //        if (order == null)
        //        {
        //            if (filter == null)
        //            {
        //                return await _context.Set<TEntity>()
        //                .ToListAsync();
        //            }
        //            else
        //            {
        //                return await _context.Set<TEntity>()
        //                .Where(filter)
        //                .ToListAsync();
        //            }
        //        }
        //        else
        //        {
        //            if (desc)
        //            {
        //                if (filter == null)
        //                {
        //                    return await _context.Set<TEntity>().OrderByDescending(order)
        //                    .ToListAsync();
        //                }
        //                else
        //                {
        //                    return await _context.Set<TEntity>()
        //                    .Where(filter).OrderByDescending(order)
        //                    .ToListAsync();
        //                }
        //            }
        //            else
        //            {
        //                if (filter == null)
        //                {
        //                    return await _context.Set<TEntity>().OrderBy(order)
        //                    .ToListAsync();
        //                }
        //                else
        //                {
        //                    return await _context.Set<TEntity>()
        //                    .Where(filter).OrderBy(order)
        //                    .ToListAsync();
        //                }
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        _context.ChangeTracker.Clear();

        //        return default;
        //    }
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (disposing && !_disposed)
        //    {
        //        _context.Dispose();
        //        _disposed = true;
        //    }
        //}
        //#endregion
    }
}
