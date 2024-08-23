
using N5ChallengeFullStack.Model;

namespace N5ChallengeFullStack.Repository
{
    public class UniOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        public UniOfWork(DbContext context)
        {
            _context = context;

        }
      
        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(_context);
        }
  
        public async Task<int> Commit() => await _context.SaveChangesAsync();

    }
}
