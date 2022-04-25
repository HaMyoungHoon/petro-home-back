using System.Linq.Expressions;

namespace petro_home_back.Repository.Base
{
    public interface IMSRepository<T> where T : class
    {
        public IEnumerable<T> FindAll();
        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);

        public Task<IEnumerable<T>> FindAllAsync();
        public Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);
        public void AddAsync(T entity);
        public void UpdateAsync(T entity);
        public void DeleteAsync(T entity);
    }
}
