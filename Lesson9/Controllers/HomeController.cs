using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lesson9.Models;

namespace Lesson9.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private static readonly List<Product> _products = new()
    {
        new() { Name = "Молоко", Description = "Простоквашино", Count = 100 },
        new() { Name = "Часы", Description = "Ролекс", Count = 1 },
        new() { Name = "Книга", Description = "Властелин колец", Count = 10 }
    };
    
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(string firstname, string lastname, string gender)
    {
        var model = new IndexModel
        {
            Products = _products
        };
        return View(model);
    }

    [HttpPost("create-product")]
    public IActionResult CreateProduct([FromForm]Product newProduct)
    {
        _products.Add(newProduct);
        return RedirectToAction("Index");
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