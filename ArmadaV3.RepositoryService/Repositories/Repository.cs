using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ArmadaV3.RepositoryService.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public IEnumerable<TEntity> Get()
        {
            return Context.Set<TEntity>().ToList();
        }

        public TEntity FindById(int? id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public void Create(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
        }

        public void Edit(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
        }
    }
}
