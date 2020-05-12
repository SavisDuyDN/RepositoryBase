using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class UnitOfWork : IDisposable
    {
        DbContext _db;
        public void Dispose()
        {

        }
        public UnitOfWork()
        {
            _db = new TestDataBaseEntities();
        }
        public Repository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
