namespace Cinema2026.Repo.Interfaces
{
    public interface IGenericRepositories<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T?> GetById(int id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<bool> Delete(int id);
    }
}