using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class Repository<T> where T : class
    {
        DbContext _db;
        DbSet<T> _dbSet;
        public Repository(DbContext dbContext) 
        {
            _db = dbContext;
            _dbSet = _db.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }
        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).AsEnumerable();
        }
        public void Create(T model) 
        {
            _dbSet.Add(model);
        }
        public void Update(T model)
        {
            _db.Entry<T>(model).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            _dbSet.Remove(_dbSet.Find(id));
        }
    }
}
