using System.Collections.Generic;
using System.Linq;
using InAndOut_2.Data;
using InAndOut_2.Models;
using InAndOut_2.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InAndOut_2.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _db;

        public object ExpenseVM { get; private set; }

        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Expense> objList = _db.Expenses;
            foreach (var obj in objList)
            {
                obj.ExpenseType = _db.ExpenseTypes.FirstOrDefault(u => u.Id == obj.ExpTypeId);
            }
            return View(objList);
        }

        //GET-Create
        public IActionResult Create()
        {
            ExpenceVM expenseVM = new ExpenceVM()
            {
                Expense = new Expense(),
                TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            return View(expenseVM);
        }

        //POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenceVM exp)
        {
            if (ModelState.IsValid)
            {
                //exp.ExpTypeId = 1; stupid desition
                _db.Expenses.Add(exp.Expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exp);
        }

        //GET-Delete
        public IActionResult Delete(int? id)
        {
            
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var exp = _db.Expenses.Find(id);

            if(exp == null)
            {
                return NotFound();
            }

            return View(exp);
        }

        //POST-Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var exp = _db.Expenses.Find(id);
            if (exp == null)
            {
                return NotFound();
            }

            _db.Expenses.Remove(exp);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET- Update
        public IActionResult Update(int? id)
        {
            ExpenceVM expenseVM = new ExpenceVM()
            {
                Expense = new Expense(),
                TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            if (id == null || id == 0)
            {
                return NotFound();
            }

            expenseVM.Expense = _db.Expenses.Find(id);

            if (expenseVM.Expense == null)
            {
                return NotFound();
            }

            return View(expenseVM);
        }

        //POST-Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(ExpenceVM exp)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Update(exp.Expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exp);
        }
    }
}
