using System.Linq.Expressions;

namespace WebbLabb2.DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(Expression<Func<T, bool>> filterExpression, string[]? include);
        Task<IEnumerable<T>> GetAll(string[]? include);
        void Add(T entity);
        void Delete(T entity);

    }
}
