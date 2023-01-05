using WebbLabb2.Models;

namespace WebbLabb2.DAL.Repositories.Interfaces
{
    public interface IButikerRepository : IRepository<Butiker>
    {
        Task<bool> UpdateStore(Butiker butik);
    }
}
