using WebbLabb2.DAL.Repositories.Interfaces;

namespace WebbLabb2.DAL
{
    public interface IUnitOfWork
    {
        IBöckerRepository Böcker { get; }
        IFörfattareRepository Författare { get; }
        IButikerRepository Butiker { get; }
        ILagerSaldoRepository LagerSaldo { get; }
        IOrdrarRepository Ordrar { get; }
        void Save();
    }
}
