using Blazored.LocalStorage;
using BookStore_UI.Contracts;
using BookStore_UI.Models;
using System.Net.Http;

namespace BookStore_UI.Service
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        private readonly IHttpClientFactory _client;
        private readonly ILocalStorageService _localStoreage;
        public AuthorRepository(IHttpClientFactory client, ILocalStorageService localStoreage) : base(client, localStoreage)
        {
            _client = client;
            _localStoreage = localStoreage;
        }
    }
}
