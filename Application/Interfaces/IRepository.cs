namespace Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> Insert(T entity);
        Task Remove(T entity);
        Task SaveChanges();
        Task <List<T>> RecoveryAll();
        Task<T> RecoveryById(int id);

    }
}
