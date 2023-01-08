using Microsoft.EntityFrameworkCore;
using WebbLabb2.DAL.Repositories.Interfaces;
using WebbLabb2.Models;

namespace WebbLabb2.DAL.Repositories
{
    public class BöckerRepository : Repository<Böcker>, IBöckerRepository
    {
        public BöckerRepository(BokhandelContext context) : base(context) { }

        //public async Task<Böcker> GetBook(string isbn)
        //{
        //    return await _context.Böckers.Where(b => b.Isbn13 == isbn).Include(f => f.Författare).FirstOrDefaultAsync();
        //    //return await _context.Böckers.FirstOrDefaultAsync(b => b.Isbn13.Equals(isbn));
        //}

        //public async Task<IEnumerable<Böcker>> GetAllBöcker()
        //{
        //    return await _context.Böckers.Include(f => f.Författare).ToListAsync();
        //}

        public async Task<bool> UpdateBook(Böcker newBook)
        {
            var book = await _context.Böckers.FindAsync(newBook.Isbn13);
            if (book is null)
            {
                return false;
            }

            book.Titel = newBook.Titel;
            book.Språk = newBook.Språk;
            book.Pris = newBook.Pris;
            book.Utgivningsdatum = newBook.Utgivningsdatum;

            _context.Böckers.Update(book);
            return true;
        }


    }
}
