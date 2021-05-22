using InAndOut_2.Data;
using InAndOut_2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut_2.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Item> objList = _db.Items;
            return View(objList);
        }

        //GET-Create
        public IActionResult Create()
        {
            return View();
        }

        //PSOT-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item itm)
        {
            _db.Items.Add(itm);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
