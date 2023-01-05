using WebbLabb2.DAL.Repositories.Interfaces;
using WebbLabb2.Models;

namespace WebbLabb2.DAL.Repositories
{
    public class FörfattareRepository : Repository<Författare> , IFörfattareRepository
    {
        public FörfattareRepository(BokhandelContext context) : base(context) { }



    }
}
