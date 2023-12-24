namespace Sm.Crm.Application.Repositories
{
    public interface IRepository<TEntity, TKey>
    {
        Task<List<TEntity>> GetAll(int page = 1);

        Task<TEntity?> GetById(TKey id);

        Task Create(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(TEntity entity);

        Task DeleteById(TKey id);

        Task SoftDelete(TEntity id);
    }

    public interface IRepository<TEntity> : IRepository<TEntity, int>
    {
    }
}