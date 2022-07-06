
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.Infrastructure.IRepository
{
    public interface IToDoRepository:IRepository<ToDoCategory>  
    {
        void Update(ToDoCategory category);
        
    }
}
