using BookKeepingWeb.Data;
using BookKeepingWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookKeepingWeb.Controllers
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
            IEnumerable<Category> objCategoryList = _db.Categories.ToList();  
            return View(objCategoryList);
        }

        //GET
        public IActionResult Create()
        {
        
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            //To avoid wrong values
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                //create & send it to Database
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //EDIT
        public IActionResult Edit(int? id)
        {
             if(id == null || id == 0)
            {
                return NotFound();
            }
             var categoryFromDb = _db.Categories.Find(id); 
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            //To avoid wrong values
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                //create & send it to Database
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        //DELETE
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        { 
            var obj = _db.Categories.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
                //create & send it to Database
                _db.Categories.Remove(obj);
                _db.SaveChanges();
            TempData["Success"] = "Category deleted successfully";
            return RedirectToAction("Index");
            }
            
        }
    
}
