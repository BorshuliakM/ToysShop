using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToysShop.DataAccess.Data;
using ToysShop.Models;

namespace ToysShop.Areas.Admin.Controllers;
[Area("Admin")]
public class ToyController : Controller
{
    private readonly ApplicationDbContext _context;
    public ToyController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        List<Toy> ToysList = _context.Toys.ToList();
        return View(ToysList);
    }

    public IActionResult Create()
    {
        IEnumerable<SelectListItem> CategoryList = _context.Categories
            .Select(u => new SelectListItem
            {
                Text= u.Name,
                Value=u.Id.ToString(),
            });
        ViewBag.CategoryList = CategoryList;
        return View();
    }
    [HttpPost]
    public IActionResult Create(Toy toy)
    {
        if (ModelState.IsValid)
        {
            _context.Toys.Add(toy);
            _context.SaveChanges();
            TempData["Success"] = "Toy created successfully";
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
        Toy? toyFromDb = _context.Toys.Find(id);
        if (toyFromDb == null)
        {
            return NotFound();
        }
        return View(toyFromDb);
    }

    [HttpPost]
    public IActionResult Edit(Toy toy)
    {
        if (ModelState.IsValid)
        {
            _context.Toys.Update(toy);
            _context.SaveChanges();
            TempData["Success"] = "Toy updated successfully";
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
        Toy? toyFromDb = _context.Toys.Find(id);
        if (toyFromDb == null)
        {
            return NotFound();
        }
        return View(toyFromDb);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePost(int? id)
    {
        Toy? toy = _context.Toys.Find(id);
        if (toy == null)
        {
            return NotFound();
        }
        _context.Toys.Remove(toy);
        _context.SaveChanges();
        TempData["Success"] = "Toy deleted successfully";
        return RedirectToAction("Index");
    }
}

