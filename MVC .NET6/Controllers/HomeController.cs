using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_.NET6.Models;

namespace MVC_.NET6.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    
    
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var items = InitializeModels.GetItems();
        
        var user = new UserModel
        {
            Id = 0,
            Name = "Богдан Богданов",
            Email = "bogdan.bogdanov.net@gmail.com"
        };

        var models = new IndexViewModel
        {
            Items = items,
            User = user
        };
        
        return View(models);
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