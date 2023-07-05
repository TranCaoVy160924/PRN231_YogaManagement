
namespace YogaCenterAPIV2.Repositories
{
    public interface IRepository<T>
    {
        Task<dynamic> GetById(int id);
        Task Add(T entity);
        Task Update(int id, T entity);
        Task Delete(int id);
        Task<List<dynamic>> GetAll();
    }
}
