using WebbLabb2.DAL.Repositories.Interfaces;
using WebbLabb2.Models;

namespace WebbLabb2.DAL.Repositories
{
    public class OrdrarRepository : Repository<Ordrar> , IOrdrarRepository
    {
        public OrdrarRepository(BokhandelContext context) : base(context) { }

        public async Task<bool> UpdateOrder(Ordrar newOrder)
        {
            var order = await _context.Ordrars.FindAsync(newOrder);
            if(order is null)
            {
                return false;
            }

            order.OrderNummer = newOrder.OrderNummer;
            order.Kund = newOrder.Kund;
            order.Bok = newOrder.Bok;
            order.Antal = newOrder.Antal;

            _context.Ordrars.Update(order);
            return true;
        }

    }
}
