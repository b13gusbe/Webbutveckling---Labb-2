using WebbLabb2.Models;

namespace WebbLabb2.DAL
{
    public class BokhandelStorage
    {
        private readonly BokhandelContext _context;

        public BokhandelStorage()
        {
            _context= new BokhandelContext();
        }



    }
}
