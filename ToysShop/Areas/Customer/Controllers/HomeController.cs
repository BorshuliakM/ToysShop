using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToysShop.Models;

namespace ToysShop.Areas.Customer.Controllers;
[Area("Customer")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    //private readonly <HomeController> _;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
