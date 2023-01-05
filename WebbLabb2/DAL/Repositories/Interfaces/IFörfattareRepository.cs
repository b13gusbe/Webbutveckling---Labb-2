using WebbLabb2.Models;

namespace WebbLabb2.DAL.Repositories.Interfaces
{
    public interface IFörfattareRepository : IRepository<Författare>
    {
        Task<bool> UpdateFörfattare(Författare newFörfattare);
    }
}
