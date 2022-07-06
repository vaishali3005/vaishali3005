using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoApp.Models;

using ToDoApp.Infrastructure.IRepository;
using ToDoApp.Infrastructure.Repository;
namespace ToDoApp.Controllers
{
    public class ToDoController : Controller
    {
        ToDoVM vm = new ToDoVM();
       
        private IUnitOfWork _unitOfWork;
        public ToDoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public IActionResult Index()
        {
            ToDoVM categoryVM = new ToDoVM();
            categoryVM.ToDoCategories = _unitOfWork.Category.GetAll();
            return View(categoryVM);
        }
        //HTTP GET
        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {
            vm.Category = _unitOfWork.Category.GetT(x => x.Id == id);

            if (id == null || id == 0)
            {
                return View(vm);
            }
            else
            {
                // var category = _unitOfWork.Category.GetT(x => x.Id == id);

                if (vm.Category == null)
                {
                    return NotFound();

                }
                else
                {
                    return View(vm);
                }

            }

        }

        [HttpPost, ActionName("CreateUpdate")]
        // [Route("[action]", Name = "Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdate(ToDoVM vm)

        {
            ToDoVM categoryVM = new ToDoVM();
            categoryVM.ToDoCategories = _unitOfWork.Category.GetAll();
            //vm.Category = _unitOfWork.Category.GetT(x => x.Id == id);

            if (ModelState.IsValid)
            {
                if (vm.Category.Id == 0)
                {
                    _unitOfWork.Category.Add(vm.Category);
                    TempData["success"] = "Category Created";
                }
                else
                {
                    _unitOfWork.Category.Update(vm.Category);
                    TempData["success"] = "Category Updated";
                }


                _unitOfWork.Save();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _unitOfWork.Category.GetT(x => x.Id == id);
            if (category == null)
            {
                return NotFound();

            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        // [HttpPost] , ActionName("Delete")
        [ValidateAntiForgeryToken]
        //[Route("[action]", Name = "Delete")]
        public IActionResult Deletedata(int? id)
        {

            var category = _unitOfWork.Category.GetT(x => x.Id == id);
            if (category == null)
            {
                return NotFound();

            }
            _unitOfWork.Category.Delete(category);
            _unitOfWork.Save();
            TempData["Success"] = "Categary Deleted";
            return RedirectToAction("Index");
        }

    }
}
   