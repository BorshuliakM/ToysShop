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
    private readonly IWebHostEnvironment _webHostEnvironment;
    public ToyController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
    }
    public IActionResult Index()
    {
        List<Toy> ToysList = _context.Toys.ToList();
        return View(ToysList);
    }

    public IActionResult UpSert(int? id)
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
        if (id == null || id == 0)
        {
            return View(toyVM);
        }
        else
        {
            toyVM.Toy = _context.Toys.Find(id);
            return View(toyVM);
        }

    }
    [HttpPost]
    public IActionResult UpSert(ToyVM toyVM, IFormFile? file)
    {
        if (ModelState.IsValid)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string toyPath = Path.Combine(wwwRootPath, @"img\toy");
                using (var fileStream = new FileStream(Path.Combine(toyPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                toyVM.Toy.ImageUrl = @"\img\toy\" + fileName;
            }

            _context.Toys.Add(toyVM.Toy);
            _context.SaveChanges();
            TempData["Success"] = "Toy created successfully";
            return RedirectToAction("Index");
        }
        else
        {

            toyVM.CategoryList = _context.Categories
            .Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString(),
            });
            return View(toyVM);

        }
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

