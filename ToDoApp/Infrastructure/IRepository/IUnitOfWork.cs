using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Infrastructure.IRepository
{
    public interface IUnitOfWork
    {
        IToDoRepository Category { get; }
       
        void Save();    
    }
}
