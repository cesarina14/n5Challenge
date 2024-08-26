using N5ChallengeFullStack.Model;

namespace N5ChallengeFullStack.Repository
{
    public interface IUnitOfWork : IDisposable
    {
     
        Task<int> Commit();
    }
}
