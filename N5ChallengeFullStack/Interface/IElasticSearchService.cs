namespace N5ChallengeFullStack.Interface
{
    public interface IElasticSearchService<T> where T : class
    {
        Task IndexDocumentAsync(T document);
        Task DeleteDocumentAsync(string id);
        Task<IEnumerable<T>> SearchDocumentsAsync(string query);
    }
}
