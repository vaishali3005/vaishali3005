using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoApp.Data;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    public class ToDoController : Controller
    {
        private ApplicationDBContext _context;
        public ToDoController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()

        {
            // GetList();
            IEnumerable<ToDoCategory> toDoCategories = _context.ToDo;
            return View(toDoCategories);
        }
        private void GetList()
        {
           
                var result = (from TodoItem in _context.ToDo

                              select new ToDoCategory
                              {
                                  Id = TodoItem.Id,
                                  Title = TodoItem.Title,
                                  Description = TodoItem.Description,

                              }).ToList();
           

        }

    }
   
}
   