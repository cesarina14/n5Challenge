namespace N5ChallengeFullStack.Repository
{
    public interface IRepository<T> where T : class
    {
        void AddEntity(T entity);
        void Update(T entity);
        void Remove(T entity);
        List<T> ListAll();
        T GetSingle(long Id);

    }
}
