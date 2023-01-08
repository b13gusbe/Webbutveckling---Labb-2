using WebbLabb2.Models;

namespace WebbLabb2.DAL.Repositories.Interfaces
{
    public interface IOrdrarRepository : IRepository<Ordrar>
    {
        Task<bool> UpdateOrder(Ordrar order);
    }
}
