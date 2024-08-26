
using N5ChallengeFullStack.Model;

namespace N5ChallengeFullStack.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly  DbN5Context _context;
        public UnitOfWork(DbN5Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(_context);
        }


        public async Task<int> Commit() => await _context.SaveChangesAsync();

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
