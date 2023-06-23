using Microsoft.AspNetCore.Mvc;
using ToysShop.DataAccess.Data;
using ToysShop.Models;

namespace ToysShop.Areas.Admin.Controllers;
[Area("Admin")]
public class CategoryController : Controller
{
    private readonly ApplicationDbContext _context;
    public CategoryController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        List<Category> CategoryList = _context.Categories.ToList();
        return View(CategoryList);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Category category)
    {
        if (ModelState.IsValid)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            TempData["Success"] = "Category created successfully";
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        Category? categoryFromDb = _context.Categories.Find(id);
        if (categoryFromDb == null)
        {
            return NotFound();
        }
        return View(categoryFromDb);
    }

    [HttpPost]
    public IActionResult Edit(Category category)
    {
        if (ModelState.IsValid)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            TempData["Success"] = "Category updated successfully";
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpGet]
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        Category? categoryFromDb = _context.Categories.Find(id);
        if (categoryFromDb == null)
        {
            return NotFound();
        }
        return View(categoryFromDb);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePost(int? id)
    {
        Category? category = _context.Categories.Find(id);
        if (category == null)
        {
            return NotFound();
        }
        _context.Categories.Remove(category);
        _context.SaveChanges();
        TempData["Success"] = "Category deleted successfully";
        return RedirectToAction("Index");
    }
}

