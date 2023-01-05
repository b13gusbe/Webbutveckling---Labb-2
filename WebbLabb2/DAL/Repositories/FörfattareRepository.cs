using WebbLabb2.DAL.Repositories.Interfaces;
using WebbLabb2.Models;

namespace WebbLabb2.DAL.Repositories
{
    public class FörfattareRepository : Repository<Författare> , IFörfattareRepository
    {
        public FörfattareRepository(BokhandelContext context) : base(context) { }


        public async Task<bool> UpdateFörfattare(Författare newFörfattare)
        {
            var författare = await _context.Författares.FindAsync(newFörfattare.Id);
            if (författare is null)
            {
                return false;
            }

            författare.Förnamn = newFörfattare.Förnamn;
            författare.Efternamn = newFörfattare.Efternamn;
            författare.Födelsedatum = newFörfattare.Födelsedatum;

            _context.Författares.Update(författare);
            return true;
        }

    }
}
