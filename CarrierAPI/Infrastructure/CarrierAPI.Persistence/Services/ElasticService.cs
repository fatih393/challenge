using CarrierAPI.Application.Abstractions.Services;
using CarrierAPI.Domain.Entities;
using Elastic.Clients.Elasticsearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Persistence.Services
{
    public class ElasticService<T> : IElasticService<T> where T : class
    {
        private readonly ElasticsearchClient _client;
        private readonly string _indexName;
        public ElasticService(ElasticsearchClient client, string indexName)
        {
            _client = client;
            _indexName = indexName;
        }
        public async Task IndexAsync(T document, int id)
        {
            var response = await _client.IndexAsync(document, idx => idx.Index(_indexName).Id(id.ToString()));
            if (!response.IsValidResponse)
                throw new Exception("Indexing failed: " + response.ElasticsearchServerError?.ToString());
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            var response = await _client.GetAsync<T>(id.ToString(), idx => idx.Index(_indexName));
            return response.Source;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync<T>(id.ToString(), idx => idx.Index(_indexName));
            return response.IsValidResponse;
        }

       public async Task<List<T>> SearchByNameAsync(string name)
{
    var response = await _client.SearchAsync<T>(s => s
        .Index(_indexName)
        .Query(q => q
            .Wildcard(w => w
                .Field("name.keyword")  
                .Value($"{name.ToLower()}*")
            )
        )
    );

    if (!response.IsValidResponse)
        throw new Exception("Search failed: " + response.ElasticsearchServerError?.ToString());

    return response.Documents.ToList();
}

        public async Task<bool> UpdateAsync(int id, T entity)
        {
            var request = new UpdateRequest<T, T>(_indexName, id.ToString())
            {
                Doc = entity
            };

            var response = await _client.UpdateAsync<T, T>(request);
            return response.IsValidResponse;
        }
    }
}

