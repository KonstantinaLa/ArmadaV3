using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Armada.Database;
using Armada.Entities;

namespace Armada.RepositoryServices
{
    public class CrewRepos
    {
        ApplicationDbContext db = new ApplicationDbContext();


        public IEnumerable<Crew> Get() => db.Crews.ToList();

        public Crew FindById(int? id) => db.Crews.Find(id);

        public void Create(Crew crew) => db.Entry(crew).State = EntityState.Added;

        public void Edit(Crew crew) => db.Entry(crew).State = EntityState.Modified;

        public void Delete(Crew crew) => db.Entry(crew).State = EntityState.Deleted;

        public void SaveChanges() => db.SaveChanges();

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
