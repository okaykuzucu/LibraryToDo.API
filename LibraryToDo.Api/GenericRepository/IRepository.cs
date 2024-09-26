namespace LibraryToDo.GenericRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> Insert(T model);
        Task<bool> Delete(Guid Id);
        Task<T> Update(T model);
        Task<List<T>> GetAll();
        Task<T> GetById(Guid Id);
    }
}
