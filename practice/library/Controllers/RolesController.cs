using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using library.Models;
using DAL;
using BOL;

namespace library.Controllers;

public class RolesController : Controller
{
    private readonly ILogger<RolesController> _logger;

    public RolesController(ILogger<RolesController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(){
        return View();
    }

    public IActionResult Admin(){
       DataAccessLayer da=new DataAccessLayer();
       List<user> users=da.getAllUser();
       ViewData["list"]=users;
        return View();
    }

     public IActionResult Seller(){
        DataAccessLayer da=new DataAccessLayer();
        List<Book> books=da.getAllBooks();
        ViewData["blist"]=books;
        return View();
    }
    
    public IActionResult Form(){
        return View();
    }
    public IActionResult Addbook(int bookid,string bname,string author,string category,double price){
        Console.WriteLine("in contoller");
        // Book b= new Book(bookid,bname,author,category,price);
        DataAccessLayer da=new DataAccessLayer();
        bool status=da.AddBook(bookid,bname,author,category,price);
        if(status==true){
            return Redirect("Seller");
        }
        else{
            return View();
        }
    }

    public IActionResult DeleteBook(int id){
        Console.WriteLine(id);
         DataAccessLayer da=new DataAccessLayer();
         bool sta=da.deleteb(id);
         Console.WriteLine("after delete");
         if(sta==true){
            Console.WriteLine("in if"+sta);
         return RedirectToAction("index","Home");
         }
         else return View();
    }

}