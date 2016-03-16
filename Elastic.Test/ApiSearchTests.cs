using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nest;

namespace Elastic.Test
{
    [TestClass]
    public class ApiSearchTests
    {
        public const string TwitterIndexName = "tweetindex";
        public const string ReutersCorpusIndexName = "reuterscorpusindex";
        private IElasticClient _client;
        private IndexName _reutersIndex;
        private ISearchClient _searchClient;

        [TestInitialize]
        public void Setup()
        {
            _searchClient = new SearchClient(_client);
        }

        [ClassInitialize]
        public void SetupClient()
        {
            var node = new Uri("http://localhost:9200");
            var settings = new ConnectionSettings(node);
            _client = new ElasticClient(settings);

            _reutersIndex = new IndexName();
            _reutersIndex.Name = ReutersCorpusIndexName;
            _client.CreateIndex(_reutersIndex);
        }
        [TestMethod]
        public void ShouldGetResults()
        {
            var result = _searchClient.Search("Oil");

            result.Should().HaveCount(10);
        }

        [TestMethod]
        public void TopResultsShouldHaveScoreOver90()
        {
            var result = _searchClient.Search("Oil");

        }
    }
}
