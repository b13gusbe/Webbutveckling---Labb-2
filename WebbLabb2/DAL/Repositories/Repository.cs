using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using WebbLabb2.DAL.Repositories.Interfaces;
using WebbLabb2.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebbLabb2.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly BokhandelContext _context;
        internal DbSet<T> _dbSet;

        public Repository(BokhandelContext context)
        {
            _context= context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetById(Expression<Func<T, bool>> filterExpression, string[]? include)
        {
            IQueryable<T> query = _dbSet;

            query = query.Where(filterExpression);

            foreach(string inc in include)
            {
                query = query.Include(inc);
            }


            //if (include != null)
            //{
            //    query = query.Include(include);
            //}

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAll(string[]? include)
        {
            IQueryable<T> query = _dbSet;

            foreach (string inc in include)
            {
                query = query.Include(inc);
            }

            //if (include != null)
            //{
            //    query = query.Include(include);
            //}

            return await query.ToListAsync();
        }

        public async void Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

    }
}
