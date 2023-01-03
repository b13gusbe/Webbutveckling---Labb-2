namespace WebbLabb2.DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity, int id);
        void Delete(T entity);

    }
}
