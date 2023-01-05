using WebbLabb2.DAL.Repositories.Interfaces;
using WebbLabb2.Models;

namespace WebbLabb2.DAL.Repositories
{
    public class ButikerRepository : Repository<Butiker> , IButikerRepository
    {
        public ButikerRepository(BokhandelContext context) : base(context) { }

        public async Task<bool> UpdateStore(Butiker newButik)
        {
            var butik = await _context.Butikers.FindAsync(newButik.Id);
            if (butik is null)
            {
                return false;
            }

            butik.Butiksnamn = newButik.Butiksnamn;
            butik.Adress = newButik.Adress;

            _context.Butikers.Update(butik);
            return true;
        }
    }
}
