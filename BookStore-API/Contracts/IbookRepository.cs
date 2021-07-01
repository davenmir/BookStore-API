using BookStore_API.Data;

namespace BookStore_API.Contracts
{
    public interface IbookRepository : IRepositoryBase<Book>
    {
        //public Task<string> GetImageFileName(int id);
    }
}
