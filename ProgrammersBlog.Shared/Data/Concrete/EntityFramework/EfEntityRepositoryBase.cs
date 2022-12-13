using LinqKit;
using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Shared.Data.Abstract;
using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Data.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<Tentity> : IEntityRepository<Tentity>
        where Tentity : class, IEntity, new()
    {
        protected readonly DbContext _context;

        public EfEntityRepositoryBase(DbContext context)
        {
            _context = context;
            //Include referanslarin hepsini getirmek yerine istenilen degerleri getirmesi saglaniyor.
            //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Tentity> AddAsync(Tentity entity)
        {
            await _context.Set<Tentity>().AddAsync(entity);
            return entity;
        }

        public async Task<bool> AnyAsync(Expression<Func<Tentity, bool>> predicate)
        {
            return await _context.Set<Tentity>().AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<Tentity, bool>> predicate = null)
        {

            return await (predicate == null ? _context.Set<Tentity>().CountAsync() : _context.Set<Tentity>().CountAsync(predicate));
        }

        public async Task DeleteAsync(Tentity entity)
        {
            await Task.Run(() => { _context.Set<Tentity>().Remove(entity); });
        }

        public async Task<IList<Tentity>> GetAllAsync(Expression<Func<Tentity, bool>> predicate = null, params Expression<Func<Tentity, object>>[] includeProperties)
        {
            IQueryable<Tentity> query = _context.Set<Tentity>();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties.Any())
            {
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }
            }
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<IList<Tentity>> GetAllAsync(IList<Expression<Func<Tentity, bool>>> predicates, IList<Expression<Func<Tentity, object>>> includeProperties)
        {
            IQueryable<Tentity> query = _context.Set<Tentity>();
            if (predicates != null && predicates.Any())
            {
                foreach (var predicate in predicates)
                {
                    query = query.Where(predicate);
                }
            }
            if (includeProperties != null && includeProperties.Any())
            {
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }
            }
            return await query.AsNoTracking().ToListAsync();
        }

        public IQueryable<Tentity> GetAsQueryable()
        {
            return _context.Set<Tentity>().AsQueryable();
        }

        public async Task<Tentity> GetAsync(Expression<Func<Tentity, bool>> predicate, params Expression<Func<Tentity, object>>[] includeProperties)
        {
            IQueryable<Tentity> query = _context.Set<Tentity>();
            query = query.Where(predicate);
            if (includeProperties.Any())
            {
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }
            }
            return await query.AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<Tentity> GetAsync(IList<Expression<Func<Tentity, bool>>> predicates, IList<Expression<Func<Tentity, object>>> includeProperties)
        {
            IQueryable<Tentity> query = _context.Set<Tentity>();
            if(predicates != null && predicates.Any())
            {
                foreach (var predicate in predicates)
                {
                    query = query.Where(predicate);
                }
            }
            if (includeProperties != null &&includeProperties.Any())
            {
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }
            }
            return await query.AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<IList<Tentity>> SearchAsync(IList<Expression<Func<Tentity, bool>>> predicates, params Expression<Func<Tentity, object>>[] includeProperties)
        {
            IQueryable<Tentity> query = _context.Set<Tentity>();
            if (predicates.Any())
            {
                var predicateChain = PredicateBuilder.New<Tentity>();
                foreach (var predicate in predicates)
                {
                    // default olarak ==> predicate 1 && predicate 2
                    // linqkit ile predicate 1 || predicate 2 yapma şansı
                    predicateChain.Or(predicate);
                }
                query = query.Where(predicateChain);
            }

            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<Tentity> UpdateAsync(Tentity entity)
        {
            await Task.Run(() => { _context.Set<Tentity>().Update(entity); });
            return entity;
        }
    }
}
