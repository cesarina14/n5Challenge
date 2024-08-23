using N5ChallengeFullStack.Model;

namespace N5ChallengeFullStack.Repository
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : class;
        Task<int> Commit();
    }
}
