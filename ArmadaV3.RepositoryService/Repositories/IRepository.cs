using System.Collections.Generic;

namespace ArmadaV3.RepositoryService.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Edit(TEntity entity);
        TEntity FindById(int? id);
        IEnumerable<TEntity> Get();
    }
}