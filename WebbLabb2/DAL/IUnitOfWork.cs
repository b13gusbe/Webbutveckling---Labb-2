using WebbLabb2.DAL.Repositories.Interfaces;

namespace WebbLabb2.DAL
{
    public interface IUnitOfWork
    {
        IBöckerRepository Böcker { get; }
        void Save();
    }
}
