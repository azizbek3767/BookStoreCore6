using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //var objCategoryList = _db.Categories.ToList();
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Custom", "Порядковый номер и имя не могут совпадать");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Категория успешно добавлена";
                return RedirectToAction("Index");
            }

            return View(obj);
            
        }

        // GET
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Categories.FirstOrDefault(c => c.Id == id);

            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Custom", "Порядковый номер и имя не могут совпадать");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Категория успешно обновлена";
                return RedirectToAction("Index");
            }

            return View(obj);

        }

        // GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Categories.FirstOrDefault(c => c.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Categories.FirstOrDefault(c => c.Id == id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Категория успешно удалена";
            return RedirectToAction("Index");
          


        }
    }
}
