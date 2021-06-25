using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Armada.Database;
using Armada.Entities;

namespace Armada.RepositoryServices
{
    class EmperorRepos
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable<Emperor> Get() => db.Emperors.ToList();

        public Emperor FindById(int? id) => db.Emperors.Find(id);

        public void Create(Emperor emperor) => db.Entry(emperor).State = EntityState.Added;

        public void Edit(Emperor emperor) => db.Entry(emperor).State = EntityState.Modified;

        public void Delete(Emperor emperor) => db.Entry(emperor).State = EntityState.Deleted;

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
