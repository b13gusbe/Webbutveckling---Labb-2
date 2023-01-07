using Microsoft.EntityFrameworkCore;
using WebbLabb2.DAL.Repositories.Interfaces;
using WebbLabb2.Models;

namespace WebbLabb2.DAL.Repositories
{
    public class LagerSaldoRepository : Repository<LagerSaldo> , ILagerSaldoRepository
    {
        public LagerSaldoRepository(BokhandelContext context) : base(context) { }

        public async Task<IEnumerable<LagerSaldo>> GetByStoreId(int id)
        {
            return await _context.LagerSaldos.Where(x => x.ButikId == id).ToListAsync();
        }

        public async Task<IEnumerable<LagerSaldo>> GetByBookISBN(string iSBN)
        {
            return await _context.LagerSaldos.Where(x => x.Isbn == iSBN).ToListAsync();
        }


    }
}
