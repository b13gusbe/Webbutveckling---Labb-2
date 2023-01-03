using WebbLabb2.DAL.Repositories.Interfaces;
using WebbLabb2.Models;

namespace WebbLabb2.DAL.Repositories
{
    public class BöckerRepository : Repository<Böcker>, IBöckerRepository
    {
        public BöckerRepository(BokhandelContext context) : base(context) { }
        
    }
}
