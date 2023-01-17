using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using library.Models;
using BOL;
using BLL;
namespace library.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // List<user> users=
        return View();
        // return RedirectToAction("Book","index");
    }

    public IActionResult Validate(string email,string password)
    {
        Console.WriteLine(email+"  "+password);
        // List<user> users=BuisnessLogic.alluser();
        if(BuisnessLogic.validateuser(email,password)=="admin"){
           return RedirectToAction("Admin","Roles");
        }
        else if(BuisnessLogic.validateuser(email,password)=="seller"){
            return RedirectToAction("Seller","Roles");
        }

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
