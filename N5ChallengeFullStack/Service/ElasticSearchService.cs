using N5ChallengeFullStack.Interface;
using Nest;

namespace N5ChallengeFullStack.Service
{
    public class ElasticSearchService<T> : IElasticSearchService<T> where T : class
    {
        private readonly IElasticClient _elasticClient;

        public ElasticSearchService(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public async Task IndexDocumentAsync(T document)
        {
            await _elasticClient.IndexDocumentAsync(document);
        }

        public async Task DeleteDocumentAsync(string id)
        {
            await _elasticClient.DeleteAsync<T>(id);
        }

        public async Task<IEnumerable<T>> SearchDocumentsAsync(string query)
        {
            var searchResponse = await _elasticClient.SearchAsync<T>(s => s
                .Query(q => q
                    .QueryString(d => d
                        .Query(query)
                    )
                )
            );

            return searchResponse.Documents;
        }
    }
}

