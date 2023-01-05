using Microsoft.EntityFrameworkCore;
using WebbLabb2.DAL.Repositories.Interfaces;
using WebbLabb2.Models;

namespace WebbLabb2.DAL.Repositories
{
    public class BöckerRepository : Repository<Böcker>, IBöckerRepository
    {
        public BöckerRepository(BokhandelContext context) : base(context) { }

        public async Task<Böcker> GetBook(string isbn)
        {
            return await _context.Böckers.FirstOrDefaultAsync(b => b.Isbn13.Equals(isbn));
        }

        public async Task<bool> UpdateBook(string isbn, Böcker newBook)
        {
            var book =  await _context.Böckers.FirstOrDefaultAsync(b => b.Isbn13.Equals(isbn));
            if(book is null)
            {
                return false;
            }
            book = newBook;
            _context.SaveChanges();
            return true;
        }


    }
}
