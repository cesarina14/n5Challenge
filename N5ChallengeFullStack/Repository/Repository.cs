
using Microsoft.EntityFrameworkCore;
using N5ChallengeFullStack.Model;

namespace N5ChallengeFullStack.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbN5Context _context;
        private readonly DbSet<T> _dbSet;
        public Repository(DbN5Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        public virtual void AddEntity(T entity) => _dbSet.Add(entity);

        public  virtual void Update(T entity) => _dbSet.Update(entity);

        public void Remove(T entity) =>_dbSet.Remove(entity);

        public List<T> ListAll() => 
            _dbSet.ToList();

        public T GetSingle(long Id) => _dbSet.Find(Id);
     
    }
}
