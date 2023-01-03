using WebbLabb2.DAL.Repositories.Interfaces;
using WebbLabb2.Models;

namespace WebbLabb2.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly BokhandelContext _context;

        public Repository(BokhandelContext context)
        {
            _context= context;
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async void Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }
        public void Update(T entity, int id)
        {
            var test = _context.Set<T>().Find(id);
            if (test is not null)
            {
                test = entity;
            }
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

    }
}
