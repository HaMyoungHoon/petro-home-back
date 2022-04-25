using Microsoft.EntityFrameworkCore;
using petro_home_back.Service;
using System.Linq.Expressions;

namespace petro_home_back.Repository.Base
{
    public class MSRepository<T> : IMSRepository<T> where T : class
    {
        private readonly MsSQLDbContext _context;
        private readonly DbSet<T> _entities;

        public MSRepository(MsSQLDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public IEnumerable<T> FindAll()
        {
            return Task.Run(async () => await _entities.ToListAsync()).Result;
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return Task.Run(async () => await _entities.Where(expression).ToListAsync()).Result;
        }

        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _ = Task.Run(async () => await _entities.AddAsync(entity)).Result;
            _ = Task.Run(async () => await _context.SaveChangesAsync()).Result;
        }
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _entities.Update(entity);
            _ = Task.Run(async () => await _context.SaveChangesAsync()).Result;
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _entities.Remove(entity);
            _ = Task.Run(async () => await _context.SaveChangesAsync()).Result;
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await _entities.ToListAsync();
        }
        public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await _entities.Where(expression).ToListAsync();
        }
        public async void AddAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async void UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async void DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
