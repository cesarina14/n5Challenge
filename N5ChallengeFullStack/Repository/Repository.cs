
using N5ChallengeFullStack.Model;

namespace N5ChallengeFullStack.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public virtual void AddEntity(T entity) => _context.Set<T>().Add(entity);

        public  virtual void Update(T entity) => _context.Set<T>().Update(entity);

        public void Remove(T entity) => _context.Set<T>().Remove(entity);

        public List<T> ListAll() => _context.Set<T>().ToList();

        public T GetSingle(long Id) => _context.Set<T>().Find(Id);
     
    }
}
