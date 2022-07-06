
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Data;
using ToDoApp.Infrastructure.IRepository;

namespace ToDoApp.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDBContext _context;
      
        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
            Category= new ToDoRepository(context);
           
        }
        public IToDoRepository Category { get; private set; }

       
        public void Save()
        {
            _context.SaveChanges();
            //throw new NotImplementedException();
        }
    }
}
