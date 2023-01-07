using WebbLabb2.Models;

namespace WebbLabb2.DAL.Repositories.Interfaces
{
    public interface ILagerSaldoRepository : IRepository<LagerSaldo>
    {
        Task<IEnumerable<LagerSaldo>> GetByStoreId(int id);
        Task<IEnumerable<LagerSaldo>> GetByBookISBN(string iSBN);
    }
}
