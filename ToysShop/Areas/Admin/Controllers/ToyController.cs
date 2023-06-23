using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToysShop.DataAccess.Data;
using ToysShop.Models;
using ToysShop.Models.ViewModels;

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
        ToyVM toyVM = new()
        {
            CategoryList = _context.Categories
            .Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString(),
            }),
            Toy = new Toy()
        };
        return View(toyVM);
    }
    [HttpPost]
    public IActionResult Create(ToyVM obj)
    {
        if (ModelState.IsValid)
        {
            _context.Toys.Add(obj.Toy);
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

