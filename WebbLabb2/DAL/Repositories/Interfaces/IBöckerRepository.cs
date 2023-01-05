using WebbLabb2.Models;

namespace WebbLabb2.DAL.Repositories.Interfaces
{
    public interface IBöckerRepository : IRepository<Böcker>
    {
        Task<Böcker> GetBook(string isbn);
        Task<bool> UpdateBook(Böcker newBook);
    }
}
