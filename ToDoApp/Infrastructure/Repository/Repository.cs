using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Data;
using ToDoApp.Infrastructure.IRepository;

namespace ToDoApp.Infrastructure.Repository
{
    public class Repository<T> :IRepository<T> where T : class
    {
      private readonly ApplicationDBContext _context;
        private DbSet<T> _dbSet;
        public Repository(ApplicationDBContext context)
        {
            _context = context;
            _dbSet =_context.Set<T>();
            
        }

        public T GetT(Expression<Func<T, bool>> predicate, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            query=query.Where(predicate);
            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))

                {
                    query = query.Include(item);
                }

            }
            return query.FirstOrDefault();
           //throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
            //throw new NotImplementedException();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
           // throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            //throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate=null, string? includeProperties = null)
        {

            IQueryable<T> query = _dbSet;
            if (predicate!=null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties != null)
            {
                foreach( var item in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries ))
                   
                {
                    query = query.Include(item);
                }
               
            }
            return query.ToList();
            //throw new NotImplementedException();
        }
    }
}
