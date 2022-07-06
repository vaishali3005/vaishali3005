
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;
using ToDoApp.Data;
using ToDoApp.Infrastructure.IRepository;

namespace ToDoApp.Infrastructure.Repository
{  
    public class ToDoRepository : Repository<ToDoCategory>, IToDoRepository
    {
        private readonly ApplicationDBContext _context;
        public ToDoRepository(ApplicationDBContext context) : base(context)
    {
        _context = context;
    }

        public void Update(ToDoCategory category)
    {
        // _context.categories.Update(category);
        var categoryDB = _context.ToDo.FirstOrDefault(x => x.Id == category.Id);
        if (categoryDB != null)
        {
            categoryDB.Title = category.Title;
            categoryDB.Description = category.Description;
            categoryDB.IsCompleted = category.IsCompleted;
            categoryDB.IsDeleted = category.IsDeleted;
            categoryDB.ModifiedBy = category.ModifiedBy;


            }
        //throw new NotImplementedException();
    }
    }
}
