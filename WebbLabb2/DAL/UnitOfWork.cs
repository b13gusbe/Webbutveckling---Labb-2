using WebbLabb2.DAL.Repositories;
using WebbLabb2.DAL.Repositories.Interfaces;
using WebbLabb2.Models;

namespace WebbLabb2.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BokhandelContext _context;

        public UnitOfWork(BokhandelContext context)
        {
            _context = context;
            Böcker = new BöckerRepository(context);
            Författare = new FörfattareRepository(context);
            Butiker = new ButikerRepository(context);
        }

        public IBöckerRepository Böcker { get; private set; }
        public IFörfattareRepository Författare { get; private set; }
        public IButikerRepository Butiker { get; private set; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
