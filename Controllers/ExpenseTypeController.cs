using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InAndOut_2.Data;
using InAndOut_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace InAndOut_2.Controllers
{
    public class ExpenseTypeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ExpenseTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ExpenseType> objList = _db.ExpenseTypes;
            return View(objList);
        }

        //GET-Create
        public IActionResult Create()
        {
            return View();
        }

        //POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseType exp)
        {
            if (ModelState.IsValid)
            {
                _db.ExpenseTypes.Add(exp);
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

            var exp = _db.ExpenseTypes.Find(id);

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
            var exp = _db.ExpenseTypes.Find(id);
            if (exp == null)
            {
                return NotFound();
            }

            _db.ExpenseTypes.Remove(exp);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET- Update
        public IActionResult Update(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var exp = _db.ExpenseTypes.Find(id);

            if (exp == null)
            {
                return NotFound();
            }

            return View(exp);
        }

        //POST-Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(ExpenseType exp)
        {
            if (ModelState.IsValid)
            {
                _db.ExpenseTypes.Update(exp);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exp);
        }
    }
}
