using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ItemsController : Controller
    {
        private ToDoListDbContext _context;

        public ItemsController(ToDoListDbContext context)
        {
            _context = context;    
        }

        // GET: Items
        public IActionResult Index()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View(_context.Items.ToList());
        }

        // GET: Items/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Item item = _context.Items.Single(m => m.ItemId == id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "Categories", "Name");
            return View();
        }

        // POST: Items/Create
        [HttpPost]
        public IActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Items.Add(item);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(_context.Categories, "Categories", "Name");
            return View(item);
        }

        // GET: Items/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Item item = _context.Items.Single(m => m.ItemId == id);
            if (item == null)
            {
                return HttpNotFound();
            }
            //ViewBag.CategoryId = new SelectList(_context.Categories, "CategoryId", "Category", item.CategoryId);
            return View(item);
        }

        // POST: Items/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Update(item);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.CategoryId = new SelectList(_context.Categories, "CategoryId", "Category", item.CategoryId);
            return View(item);
        }

        // GET: Items/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Item item = _context.Items.Single(m => m.ItemId == id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Item item = _context.Items.Single(m => m.ItemId == id);
            _context.Items.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Done(int id)
        {
            var thisItem = _context.Items.FirstOrDefault(x => x.ItemId == id);
            thisItem.Done = !thisItem.Done;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
