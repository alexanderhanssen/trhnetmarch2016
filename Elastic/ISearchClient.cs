using System.Collections.Generic;

namespace Elastic
{
    public interface ISearchClient
    {
        IEnumerable<SearchResult> Search(string query);
    }
}
