using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.Models
{
    public class ToDoVM
    {
       // public IEnumerable<Category> mycategories;

        public ToDoCategory Category { get; set; }  = new ToDoCategory();
         public IEnumerable<ToDoCategory> ToDoCategories { get; set; } = new List<ToDoCategory>();

    }
}
