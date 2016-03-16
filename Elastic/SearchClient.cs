using System.Collections.Generic;
using System.Linq;
using Nest;

namespace Elastic
{
    public class SearchClient : ISearchClient
    {
        private readonly IElasticClient _client;

        public SearchClient(IElasticClient client)
        {
            _client = client;
        }

        public IEnumerable<SearchResult> Search(string query)
        {
            var result = _client.Search<Article>(s => s.From(0).Size(10).Query(q => q.Term(p => p.Name(query))));
            return result.Hits.Select(x => new SearchResult
            {
                Title = x.Source.Title
            });
        }
    }
}
